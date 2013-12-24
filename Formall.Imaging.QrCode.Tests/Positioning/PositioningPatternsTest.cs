
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Formall.Imaging.QrCode.Encoding.Tests.Alignment
{
    using Formall.Imaging.QrCode.Encoding.Positioning;
    using Formall.Imaging.QrCode.Encoding.Tests.Positioning.TestCases;

    [TestClass, TestFixture]
    public class PositioningPatternsTest
    {

        [Test, TestMethod]
        [TestCaseSource(typeof(PositioningPatternsTestCaseFactory), "TestCasesFromReferenceImplementation")]
        public void Test_against_reference_implementation(int version, TriStateMatrix expected)
        {
      
            TriStateMatrix target = new TriStateMatrix(expected.Width);
            PositioninngPatternBuilder.EmbedBasicPatterns(version, target);
            expected.AssertEquals(target);
        }

        [Test, TestMethod]
        [TestCaseSource(typeof(PositioningPatternsTestCaseFactory), "TestCasesFromTxtFile")]
        public void Test_against_DataSet(int version, TriStateMatrix expected)
        {
            TriStateMatrix target = new TriStateMatrix(expected.Width);
            PositioninngPatternBuilder.EmbedBasicPatterns(version, target);
            expected.AssertEquals(target);
        }

        //[Test, TestMethod]
        public void Generate()
        {
            new PositioningPatternsTestCaseFactory().GenerateMaskPatternTestDataSet();
        }
    }
}
