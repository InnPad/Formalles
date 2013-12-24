using System;
using System.IO;
using com.google.zxing.qrcode.encoder;
using Formall.Imaging.QrCode.Encoding.Masking;
using Formall.Imaging.QrCode.Encoding.Positioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Formall.Imaging.QrCode.Encoding.Tests.Masking
{
    [TestClass, TestFixture]
    public class MaskPatternTest
    {

        [Test, TestMethod]
        [TestCaseSource(typeof(MaskPatternTestCaseFactory), "TestCasesFromReferenceImplementation")]
        public void Test_against_reference_implementation(TriStateMatrix input, MaskPatternType patternType, BitMatrix expected)
        {
            Pattern pattern = new PatternFactory().CreateByType(patternType);

            BitMatrix result = input.Apply(pattern, ErrorCorrectionLevel.H);

            expected.AssertEquals(result);
        }

        [Test, TestMethod]
        [TestCaseSource(typeof(MaskPatternTestCaseFactory), "TestCasesFromTxtFile")]
        public void Test_against_DataSet(TriStateMatrix input, MaskPatternType patternType, BitMatrix expected)
        {
            Pattern pattern = new PatternFactory().CreateByType(patternType);

            BitMatrix result = input.Apply(pattern, ErrorCorrectionLevel.H);

            expected.AssertEquals(result);
        }

        //[Test, TestMethod]
        public void Generate()
        {
            new MaskPatternTestCaseFactory().GenerateMaskPatternTestDataSet();
        }
    }
}
