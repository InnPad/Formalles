﻿using System.Collections;

namespace Custom.Algebra.QrCode.Encoding.DataEncodation
{
    public abstract class EncoderBase
    {
        internal EncoderBase()
        {
        }

        internal abstract Mode Mode { get; }

        protected virtual int GetDataLength(string content)
        {
            return content.Length;
        }

        /// <summary>
        /// Returns the bit representation of input data.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        internal abstract BitList GetDataBits(string content);


        /// <summary>
        /// Returns bit representation of <see cref="Mode"/> value.
        /// </summary>
        /// <returns></returns>
        /// <remarks>See Chapter 8.4 Data encodation, Table 2 — Mode indicators</remarks>
        internal BitList GetModeIndicator()
        {
            BitList modeIndicatorBits = new BitList();
            modeIndicatorBits.Add((int)this.Mode, 4);
            return modeIndicatorBits;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterCount"></param>
        /// <returns></returns>
        internal BitList GetCharCountIndicator(int characterCount, int version)
        {
            BitList characterCountBits = new BitList();
            int bitCount = GetBitCountInCharCountIndicator(version);
            characterCountBits.Add(characterCount, bitCount);
            return characterCountBits;
        }

        /// <summary>
        /// Defines the length of the Character Count Indicator, 
        /// which varies according to themode and the symbol version in use
        /// </summary>
        /// <returns>Number of bits in Character Count Indicator.</returns>
        /// <remarks>
        /// See Chapter 8.4 Data encodation, Table 3 — Number of bits in Character Count Indicator.
        /// </remarks>
        protected abstract int GetBitCountInCharCountIndicator(int version);

        
    }
}