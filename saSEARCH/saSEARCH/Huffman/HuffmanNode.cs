namespace saSEARCH
{
    /// <summary>
    /// Represents node of binary tree.
    /// </summary>
    class HuffmanNode
    {
        public bool IsLeaf;

        /// <summary> 
        /// if ( IsLeaf) then its character is written here
        /// if (!IsLeaf) then value is not important
        /// </summary>
        public byte Char;

        /// <summary>
        /// if ( IsLeaf) then it's count of occurences of its character is written here
        /// if (!IsLeaf) then it's sum of counts of its childs is written here
        /// </summary>
        public long Count;

        public HuffmanNode Right;

        public HuffmanNode Left;

        /// <summary>
        /// Constructor of leaf node.
        /// </summary>
        /// <param name="ch"> character </param>
        /// <param name="c"> count of occurences </param>
        public HuffmanNode(byte ch, long c)
        {
            IsLeaf = true;
            Char = ch;
            Count = c;
            Right = null;
            Left = null;
        }

        /// <summary>
        /// Constructor of inner node.
        /// </summary>
        /// <param name="l"> left node </param>
        /// <param name="r"> right node </param>
        public HuffmanNode(HuffmanNode l, HuffmanNode r)
        {
            IsLeaf = false;
            Count = r.Count + l.Count;
            Right = r;
            Left = l;
        }
    }
}