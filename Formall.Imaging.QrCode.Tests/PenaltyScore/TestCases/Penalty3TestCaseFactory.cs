using NUnit.Framework;
using com.google.zxing.qrcode.encoder;
using Formall.Imaging.QrCode.Encoding.Masking;
using Formall.Imaging.QrCode.Encoding.Masking.Scoring;


namespace Formall.Imaging.QrCode.Encoding.Tests.PenaltyScore
{
	public class Penalty3TestCaseFactory : PenaltyScoreTestCaseFactory
	{
		protected override string TxtFileName { get { return "Penalty3TestDataSet.txt"; } }
		
		protected override NUnit.Framework.TestCaseData GenerateRandomTestCaseData(int matrixSize, System.Random randomizer, MaskPatternType pattern)
		{
			return base.GenerateRandomTestCaseData(matrixSize, randomizer, pattern, PenaltyRules.Rule03);
		}
		
	}
}