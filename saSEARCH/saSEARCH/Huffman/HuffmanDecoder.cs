using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace saSEARCH
{
    //
    //___________________________________________HUFFMAN DECODE________________________________________
    //

    static class HuffmanDecoder
    {

        /// <summary>
        /// Checks, if all characters were used due to their Count.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns> true if there are all counts in leaves equal to zero </returns>
        private static bool CheckIfEverythingWasUsed(HuffmanNode treeNode)
        {
            if (treeNode.IsLeaf)
            {
                if (treeNode.Count == 0)
                    return true;
                return false;
            }
            return CheckIfEverythingWasUsed(treeNode.Left) && CheckIfEverythingWasUsed(treeNode.Right);
        }

        /// <summary>
        /// Checks, if count in each node is valid due to construction. 
        /// Count for leaf must be > 0. 
        /// Count for inner node must be == count of left + count of right and recursively left and right must fullfil 
        /// this constraint.
        /// </summary>
        /// <param name="treeNode"> actual node </param>
        /// <returns> true if node fullfils all constraints </returns>
        private static bool CheckCounts(HuffmanNode treeNode)
        {
            if (treeNode.IsLeaf)
                return treeNode.Count > 0;

            if (treeNode.Right == null || treeNode.Left == null)
                return false;

            if (treeNode.Count == treeNode.Left.Count + treeNode.Right.Count)
                return CheckCounts(treeNode.Right) && CheckCounts(treeNode.Left);

            return false;
        }

        /// <summary>
        /// Recursively reconstructs Huffman tree from encoded postfix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="actualNode"> actually constructed node </param>
        /// <param name="cont"> if we still should look </param>
        /// <returns> root of Huffman tree </returns>
        private static HuffmanNode CreateTreeFromPrefix(List<ulong> prefix, ref int actualNode, ref bool cont)
        {
            if (!cont)
                return null;

            if (prefix.Count <= actualNode)
            {
                cont = false;
                return null;
            }

            ulong leaf = prefix[actualNode] % 2;
            ulong count = prefix[actualNode] << 8 >> 9;
            ulong character = prefix[actualNode] >> 56;

            HuffmanNode node = new HuffmanNode((byte)character, (long)count);
            node.IsLeaf = leaf == 1;
            ++actualNode;
            if (leaf == 0)
            {
                node.Left = CreateTreeFromPrefix(prefix, ref actualNode, ref cont);
                node.Right = CreateTreeFromPrefix(prefix, ref actualNode, ref cont);
            }

            return node;
        }


        /// <summary>
        /// Reconstructs Huffman tree and decodes the text.
        /// </summary>
        /// <param name="nameOfInputFile"></param>
        /// <param name="nameOfOutputFile"></param>
        public static void Decode(string nameOfInputFile, string nameOfOutputFile)
        {
            if (!File.Exists(nameOfInputFile))
                 Console.WriteLine("File", "Input file does not exist");

            // set file streams
            FileStream ifs = new FileStream(nameOfInputFile, FileMode.Open, FileAccess.Read);
            FileStream ofs = new FileStream(nameOfOutputFile, FileMode.Create, FileAccess.Write);

            // header check
            byte[] headerAcquired = new byte[8];
            if (ifs.Length > 7)
                for (int i = 0; i < 8; ++i)
                    headerAcquired[i] = (byte)ifs.ReadByte();
            else
                 Console.WriteLine("File", "Header for Huffman is missing");

            byte[] headerOriginal = new byte[] { 0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66 };
            bool acquiredMatchesOriginal = true;
            for (int i = 0; i < 8; ++i)
                if (headerAcquired[i] != headerOriginal[i])
                    acquiredMatchesOriginal = false;
            if (!acquiredMatchesOriginal)
                 Console.WriteLine("File", "Header for Huffman does not match");

            // construct huffman tree from prefix notation
            List<ulong> nodeList = new List<ulong>();

            ulong nodeBeingRead = 1;
            byte[] partsOfNodeBeingRead = new byte[8];
            while (ifs.Position + 8 <= ifs.Length && nodeBeingRead != 0)
            {
                ifs.Read(partsOfNodeBeingRead, 0, 8);
                nodeBeingRead = BitConverter.ToUInt64(partsOfNodeBeingRead, 0);
                if (nodeBeingRead != 0)
                    nodeList.Add(nodeBeingRead);
            }

            if (ifs.Position + 8 > ifs.Length && nodeBeingRead != 0)
                 Console.WriteLine("File", "File is not valid : Data being in unknown state");

            bool validTree = true;
            int actualNodeForTreeConstruction = 0;
            HuffmanNode huffmanTree = CreateTreeFromPrefix(nodeList, ref actualNodeForTreeConstruction, ref validTree);

            if (actualNodeForTreeConstruction != nodeList.Count)
                 Console.WriteLine("File", "File is not valid : Prefix tree is not valid (too many nodes");

            if (!validTree)
                 Console.WriteLine("File", "File is not valid : Prefix tree is not valid (missing nodes)");

            if (!CheckCounts(huffmanTree))
                 Console.WriteLine("File", "File is not valid : Prefix tree is not valid (invalid counts)");

            // decode text
            HuffmanNode actualNode = huffmanTree;
            int character;
            bool onlyLeftSinceRestart = true;
            bool end = false;
            while ((character = ifs.ReadByte()) != -1)
            {
                byte z = (byte)character;

                for (int i = 0; i < 8; ++i)
                {
                    if (z % 2 == 1)
                    {
                        if (end)
                             Console.WriteLine("File", "File is not valid : bit 1 during ending sequence");

                        if (actualNode.Right == null)
                             Console.WriteLine("File", "File is not valid : Wrong path during text decoding");
                        actualNode = actualNode.Right;

                        onlyLeftSinceRestart = false;
                    }
                    else // if ((z % 2) == 0)
                    {
                        if (actualNode.Left == null)
                             Console.WriteLine("File", "File is not valid : Wrong path during text decoding");
                        actualNode = actualNode.Left;
                    }

                    if (actualNode.IsLeaf)
                    {
                        if (actualNode.Count > 0)
                        {
                            ofs.WriteByte(actualNode.Char);
                            --actualNode.Count;
                            actualNode = huffmanTree;
                            onlyLeftSinceRestart = true;
                        }
                        else // we have run out of occurences of character - tricky part
                        {
                            // we will check if path is valid "left only"
                            if (!onlyLeftSinceRestart)
                                Console.WriteLine("File", "File is not valid : bit 1 during ending sequence");

                            // we will put ourselves into state end
                            if (!end)
                                end = true;

                            // we will check if it isn't too soon to be end
                            if (ifs.Position + 1 >= ifs.Length)
                                actualNode = huffmanTree;
                            else
                                Console.WriteLine("File", "File is not valid : Too many uses of a character");
                        }
                    }

                    // advance
                    z = (byte)(z >> 1);
                }
            }

            if (!CheckIfEverythingWasUsed(huffmanTree))
                Console.WriteLine("File", "File is not valid : Some unused characters remain");

            ifs.Close();
            ofs.Close();
        }


    }
}