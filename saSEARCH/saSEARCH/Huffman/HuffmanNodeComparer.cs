using System.Collections.Generic;

namespace saSEARCH
{
    class HuffmanNodeComparer : IComparer<HuffmanNode>
    {
        readonly private bool _charCompare;
        readonly private bool _countCompare;

        /// <summary>
        /// If both parameters are true then compares primary due to count, secondary due to character.
        /// If both parameters are false then always returns 0.
        /// </summary>
        /// <param name="cCompare"> compare counts </param>
        /// <param name="charCompare"> compare characters </param>
        public HuffmanNodeComparer(bool cCompare, bool charCompare)
        {
            _countCompare = cCompare;
            _charCompare = charCompare;
        }

        public int Compare(HuffmanNode x, HuffmanNode y)
        {
            int cComp = x.Count.CompareTo(y.Count);
            int charComp = x.Char.CompareTo(y.Char);

            if (_countCompare && _charCompare)
                return cComp != 0 ? cComp : charComp;
            if (_countCompare)
                return cComp;
            if (_charCompare)
                return charComp;
            return 0;
        }
    }
}