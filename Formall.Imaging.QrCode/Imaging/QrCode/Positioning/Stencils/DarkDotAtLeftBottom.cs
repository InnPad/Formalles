using System;

namespace Formall.Imaging.QrCode.Encoding.Positioning.Stencils
{
    using Formall.Imaging.QrCode;

    internal class DarkDotAtLeftBottom : PatternStencilBase
    {
        public DarkDotAtLeftBottom(int version) : base(version)
        {
        }

        public override bool[,] Stencil
        {
            get { throw new NotImplementedException(); }
        }

        public override void ApplyTo(TriStateMatrix matrix)
        {
            matrix[8, matrix.Width - 8, MatrixStatus.NoMask] = true;
        }
    }
}
