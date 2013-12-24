namespace Formall.Imaging.QrCode.Encoding.Masking.Scoring
{
    using Formall.Imaging.QrCode;

	public abstract class Penalty
	{
		internal abstract int PenaltyCalculate(BitMatrix matrix);
	}
}
