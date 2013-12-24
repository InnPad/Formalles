namespace Formall.Imaging.QrCode.Encoding.Versions
{
    using Formall.Imaging.QrCode;

	internal struct VersionControlStruct
	{
		internal VersionDetail VersionDetail { get; set; }
		internal bool isContainECI { get; set; }
		internal BitList ECIHeader { get; set; }
	}
}
