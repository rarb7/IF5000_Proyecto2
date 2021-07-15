
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using saSEARCH;
//
//___________________________________________HUFFMAN ENCODE________________________________________
//

static class HuffmanEncoder
{
    private const int CountOfCharacters = 256; // ~ Byte ... Program is set for byte characters

    /// <summary>
    /// Construction of leaves.
    /// </summary>
    /// <param name="ifs"> </param>
    /// <returns> all leaves constructed from ifs sorted in queue </returns>
    private static Queue<HuffmanNode> GetLeaves(FileStream ifs)
    {
        // count represents count of occurences for each character
        long[] counts = new long[CountOfCharacters];
        for (int i = 0; i < CountOfCharacters; ++i)
            counts[i] = 0;

        // obtain count of occurences for each character
        int b;
        while ((b = ifs.ReadByte()) != -1)
            ++counts[b];

        // create leaves
        List<HuffmanNode> leaves = new List<HuffmanNode>();
        for (int i = 0; i < CountOfCharacters; ++i)
            if (counts[i] > 0)
                leaves.Add(new HuffmanNode((byte)i, counts[i]));

        // we want to have leaves ordered primary by counts of occurences 
        // and secondary by characters
        leaves.Sort(new HuffmanNodeComparer(true, true));

        // changing list to queue
        return new Queue<HuffmanNode>(leaves);
    }

    /// <summary>
    /// Merges forest of trees into one tree. 
    /// </summary>
    /// <param name="orderedLeaves"> trees ordered due to count </param>
    /// <returns> one tree containing all ordered leaves </returns>
    private static HuffmanNode MergeForestIntoNode(Queue<HuffmanNode> orderedLeaves)
    {
        // queue of merged trees
        Queue<HuffmanNode> trees = new Queue<HuffmanNode>();

        if (orderedLeaves.Count == 0)
            return null;

        // merge 2 trees that have least counts until we will have only one merged tree
        // algorithm : we will have separatelly merged trees and leaves
        //             both will be sorted due to their counts amongst themselves
        //             select 2 with least counts and merge them into one
        while (!(orderedLeaves.Count == 0 && trees.Count == 1))
        {
            // only one leaf and not merged tree yet => it is already one merged tree
            if (orderedLeaves.Count == 1 && trees.Count == 0)
            {
                trees.Enqueue(orderedLeaves.Dequeue());
                continue;
            }

            // no trees yet made => first 2 leaves have least counts
            if (trees.Count == 0)
            {
                HuffmanNode l1 = orderedLeaves.Dequeue();
                HuffmanNode l2 = orderedLeaves.Dequeue();
                trees.Enqueue(new HuffmanNode(l1, l2));
                continue;
            }

            // no leaves anymore => first 2 trees have least counts
            if (orderedLeaves.Count == 0)
            {
                HuffmanNode mt1 = trees.Dequeue();
                HuffmanNode mt2 = trees.Dequeue();
                trees.Enqueue(new HuffmanNode(mt1, mt2));
                continue;
            }

            // we have at least one tree and one leaf => we need to find 2 trees 
            // with least counts (we preferably select leaves)
            {
                // selected trees
                HuffmanNode least1;
                HuffmanNode least2;

                HuffmanNode leaf1 = orderedLeaves.Peek();
                HuffmanNode tree1 = trees.Peek();

                if (leaf1.Count < tree1.Count || leaf1.Count == tree1.Count)
                {
                    least1 = orderedLeaves.Dequeue();
                    if (orderedLeaves.Count != 0)
                    {
                        HuffmanNode leaf2 = orderedLeaves.Peek();
                        if (leaf2.Count < tree1.Count ||
                            leaf2.Count == tree1.Count)
                            least2 = orderedLeaves.Dequeue();
                        else least2 = trees.Dequeue();
                    }
                    else
                        least2 = trees.Dequeue();
                }
                else // (leaf1.Count > tree1.Count)
                {
                    least1 = trees.Dequeue();
                    if (trees.Count != 0)
                    {
                        HuffmanNode s2 = trees.Peek();
                        if (leaf1.Count < s2.Count || leaf1.Count == s2.Count) least2 = orderedLeaves.Dequeue();
                        else least2 = trees.Dequeue();
                    }
                    else
                        least2 = orderedLeaves.Dequeue();
                }
                HuffmanNode ns = new HuffmanNode(least1, least2);
                trees.Enqueue(ns);
            }
        }

        HuffmanNode mergedForest = trees.Dequeue();
        return mergedForest;
    }

    /// <summary>
    /// Recursive function to make prefix out of tree (for debug purposes).
    /// </summary>
    /// <param name="tree"> </param>
    /// /// <param name="sb"> </param>
    private static void ConstructPrefixOutOfTree(HuffmanNode tree, StringBuilder sb)
    {
        if (tree.IsLeaf)
            sb.Append("*" + tree.Char.ToString() + ":" + tree.Count.ToString());
        else
        {
            sb.Append(tree.Count.ToString() + " ");
            ConstructPrefixOutOfTree(tree.Left, sb);
            sb.Append(" ");
            ConstructPrefixOutOfTree(tree.Right, sb);
        }
    }

    /// <summary>
    /// Recursive function that constructs binary prefix notation out of Huffman tree 
    /// </summary>
    /// <param name="huffmanTree"></param>
    /// <param name="fs"></param>
    private static void ConstructPrefixOutOfHuffmanTree(HuffmanNode huffmanTree, FileStream fs)
    {
        if (huffmanTree.IsLeaf)
        {
            ulong ul = 1;
            ulong weight = (ulong)huffmanTree.Count;
            weight = (weight << 9) >> 8;
            ulong character = (ulong)huffmanTree.Char;
            character = character << 56;
            ul = (ul | weight) | character;
            byte[] flushOut = BitConverter.GetBytes(ul);
            fs.Write(flushOut, 0, flushOut.Length);
        }
        else
        {
            ulong ul = 0;
            ulong weight = (ulong)huffmanTree.Count;
            weight = (weight << 9) >> 8;
            ul = (ul | weight);
            byte[] flushOut = BitConverter.GetBytes(ul);
            fs.Write(flushOut, 0, flushOut.Length);

            ConstructPrefixOutOfHuffmanTree(huffmanTree.Left, fs);
            ConstructPrefixOutOfHuffmanTree(huffmanTree.Right, fs);
        }
    }

    /// <summary>
    /// Finds the path to the character in the Huffmans tree.
    /// </summary>
    /// <param name="huffmanTree"></param>
    /// <param name="character"> target character to be found </param>
    /// <param name="path"> path to the target character, where true == right / false == left </param>
    /// <returns> true == target character found in tree / false == target character not found in tree </returns>
    private static bool SearchHuffmanTreeForPath(HuffmanNode huffmanTree, ref ulong character, List<bool> path)
    {
        if (huffmanTree.IsLeaf)
        {
            if (huffmanTree.Char == (byte)character)
                return true;
            return false;
        }

        bool leftChild = SearchHuffmanTreeForPath(huffmanTree.Left, ref character, path);
        if (leftChild)
        {
            path.Add(false);
            return true;
        }

        bool rightChild = SearchHuffmanTreeForPath(huffmanTree.Right, ref character, path);
        if (rightChild)
        {
            path.Add(true);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Constructs path to each character out of Huffman tree.
    /// </summary>
    /// <param name="huffmanTree"></param>
    /// <param name="paths"> variable that holds paths to each character </param>
    private static void GetPathsOfHuffmanTree(HuffmanNode huffmanTree, List<bool>[] paths)
    {
        for (ulong i = 0; i < CountOfCharacters; ++i)
        {
            List<bool> path = new List<bool>();
            bool pathExists = SearchHuffmanTreeForPath(huffmanTree, ref i, path);
            if (pathExists)
                paths[i] = path;
        }
    }

    /// <summary>
    /// Writes header, tree (fills it up) , 64b zero, 
    /// </summary>
    /// <param name="huffmanTree"></param>
    /// <param name="paths"></param>
    /// <param name="ifs"></param>
    /// <param name="ofs"></param>
    private static void GetHuffmanCodingForFile(
        HuffmanNode huffmanTree,
        List<bool>[] paths,
        FileStream ifs,
        FileStream ofs)
    {
        // header
        byte[] header = new byte[] { 0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66 };
        ofs.Write(header, 0, header.Length);

        // tree + 64b zero
        ConstructPrefixOutOfHuffmanTree(huffmanTree, ofs);
        byte[] zero = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
        ofs.Write(zero, 0, zero.Length);

        // text
        const int sizeOfByte = 8;
        byte flusher = 0;
        int validBitsOfFlusher = 0;
        int character;

        while ((character = ifs.ReadByte()) != -1)
        {
            foreach (bool pathBool in paths[character])
            {
                if (validBitsOfFlusher == sizeOfByte)
                {
                    ofs.WriteByte(flusher);
                    flusher = 0;
                    validBitsOfFlusher = 0;
                }

                flusher = (byte)(flusher >> 1);
                if (pathBool)
                    flusher = (byte)(flusher | 128);
                ++validBitsOfFlusher;
            }
        }

        // emptying flusher 
        {
            if (validBitsOfFlusher != 0)
            {
                int mod = validBitsOfFlusher % 8;

                while (mod % 8 != 0)
                {
                    flusher = (byte)(flusher >> 1);
                    mod++;
                }
                ofs.WriteByte(flusher);
            }
        }
    }

    /// <summary>
    /// Creates Huffman tree out of input file and saves it in binary prefix notation into output file.
    /// </summary>
    /// <param name="nameOfInputFile"></param>
    /// <param name="nameOfOutputFile"></param>
    public static void Encode(string nameOfInputFile, string nameOfOutputFile)
    {
        if (!File.Exists(nameOfInputFile))
            Error.Message("File", "Input file does not exist");

        try
        {
            // read input first time and construct Huffman tree
            FileStream ifs = new FileStream(nameOfInputFile, FileMode.Open, FileAccess.Read);
            if (ifs.Length == 0)
                Error.Message("File", "Input file is empty");
            Queue<HuffmanNode> leaves = GetLeaves(ifs);
            ifs.Close();

            HuffmanNode huffmanTree = MergeForestIntoNode(leaves);
            List<bool>[] pathsToLeavesInHuffmanTree = new List<bool>[CountOfCharacters];
            GetPathsOfHuffmanTree(huffmanTree, pathsToLeavesInHuffmanTree);
            foreach (List<bool> path in pathsToLeavesInHuffmanTree)
                if (path != null)
                    // paths are constructed in reverse order (in recursion)
                    path.Reverse();

            // read input second time and encode text
            ifs = new FileStream(nameOfInputFile, FileMode.Open, FileAccess.Read);
            FileStream ofs = new FileStream(nameOfOutputFile, FileMode.Create, FileAccess.Write);
            GetHuffmanCodingForFile(huffmanTree, pathsToLeavesInHuffmanTree, ifs, ofs);
            ifs.Close();
            ofs.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Probably File Name Error. Check it out");
            throw;
        }
    }


}
