namespace Formall.Imaging.QrCode.Encoding.Positioning
{
    using Formall.Imaging.QrCode;
    using Formall.Imaging.QrCode.Encoding.Positioning.Stencils;

    internal static class PositioninngPatternBuilder
    {
        internal static void EmbedBasicPatterns(int version, TriStateMatrix matrix)
        {
            new PositionDetectionPattern(version).ApplyTo(matrix);
            new DarkDotAtLeftBottom(version).ApplyTo(matrix);
            new AlignmentPattern(version).ApplyTo(matrix);
            new TimingPattern(version).ApplyTo(matrix);
        }
    }
}