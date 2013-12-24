using System;

namespace Formall.Imaging.QrCode.Encoding
{
    using Formall.Imaging.QrCode;
    using Formall.Imaging.QrCode.Encoding.DataEncodation;
    using Formall.Imaging.QrCode.Encoding.ErrorCorrection;
    using Formall.Imaging.QrCode.Encoding.Positioning;
    using Formall.Imaging.QrCode.Encoding.EncodingRegion;
    using Formall.Imaging.QrCode.Encoding.Masking;
    using Formall.Imaging.QrCode.Encoding.Masking.Scoring;

	internal static class QRCodeEncode
	{
		internal static BitMatrix Encode(string content, ErrorCorrectionLevel errorLevel)
		{
			EncodationStruct encodeStruct = DataEncode.Encode(content, errorLevel);
			
			BitList codewords = ECGenerator.FillECCodewords(encodeStruct.DataCodewords, encodeStruct.VersionDetail);
			
			TriStateMatrix triMatrix = new TriStateMatrix(encodeStruct.VersionDetail.MatrixWidth);
			PositioninngPatternBuilder.EmbedBasicPatterns(encodeStruct.VersionDetail.Version, triMatrix);
			
			triMatrix.EmbedVersionInformation(encodeStruct.VersionDetail.Version);
			triMatrix.EmbedFormatInformation(errorLevel, new Pattern0());
			triMatrix.TryEmbedCodewords(codewords);
			
			return triMatrix.GetLowestPenaltyMatrix(errorLevel);
			
		}
		
	}
}
