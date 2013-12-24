using System.Collections.Generic;
using Formall.Imaging.QrCode.Encoding.EncodingRegion;
using Formall.Imaging.QrCode.Encoding.Positioning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Formall.Imaging.QrCode.Encoding.Tests.EncodingRegion
{
	[TestClass, TestFixture]
	public class VersionInfoTest
	{
		[Test, TestMethod]
        [TestCaseSource(typeof(VersionInfoTestCaseFactory), "TestCasesFromReferenceImplementation")]
        public void Test_against_reference_implementation(int version, TriStateMatrix expected)
        {
        	Test_One_Case(version, expected);
        }
        
        [Test, TestMethod]
        [TestCaseSource(typeof(VersionInfoTestCaseFactory), "TestCasesFromTxtFile")]
        public void Test_against_DataSet(int version, TriStateMatrix expected)
        {
        	Test_One_Case(version, expected);
        }
        
        private void Test_One_Case(int version, TriStateMatrix expected)
        {
        	TriStateMatrix target = new TriStateMatrix(expected.Width);
            PositioninngPatternBuilder.EmbedBasicPatterns(version, target);
            target.EmbedVersionInformation(version);
            
        	expected.AssertEquals(target);
        }
        
        //[Test, TestMethod]
        public void Generate()
        {
            new VersionInfoTestCaseFactory().GenerateMaskPatternTestDataSet();
        }
	}
}
