using System.IO;

namespace Beyova.ApngSharp.Core
{
    public class FCTLChunk : Chunk
    {
        /// <summary>
        /// Enum DisposeOps
        /// </summary>
        public enum DisposeOps
        {
            /// <summary>
            /// The apng dispose op none
            /// </summary>
            APNGDisposeOpNone = 0,
            /// <summary>
            /// The apng dispose op background
            /// </summary>
            APNGDisposeOpBackground = 1,
            /// <summary>
            /// The apng dispose op previous
            /// </summary>
            APNGDisposeOpPrevious = 2,
        }

        /// <summary>
        /// Enum BlendOps
        /// </summary>
        public enum BlendOps
        {
            APNGBlendOpSource = 0,
            APNGBlendOpOver = 1,
        }

        #region

        /// <summary>
        ///     Sequence number of the animation chunk, starting from 0
        /// </summary>
        public uint SequenceNumber { get; private set; }

        /// <summary>
        ///     Width of the following frame
        /// </summary>
        public uint Width { get; private set; }

        /// <summary>
        ///     Height of the following frame
        /// </summary>
        public uint Height { get; private set; }

        /// <summary>
        ///     X position at which to render the following frame
        /// </summary>
        public uint XOffset { get; private set; }

        /// <summary>
        ///     Y position at which to render the following frame
        /// </summary>
        public uint YOffset { get; private set; }

        /// <summary>
        ///     Frame delay fraction numerator
        /// </summary>
        public ushort DelayNumerator { get; private set; }

        /// <summary>
        ///     Frame delay fraction denominator
        /// </summary>
        public ushort DelayDenominator { get; private set; }

        /// <summary>
        ///     Type of frame area disposal to be done after rendering this frame
        /// </summary>
        public DisposeOps DisposeOp { get; private set; }

        /// <summary>
        ///     Type of frame area rendering for this frame
        /// </summary>
        public BlendOps BlendOp { get; private set; }

        #endregion

        #region Constructor

        public FCTLChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public FCTLChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public FCTLChunk(Chunk chunk)
            : base(chunk)
        {
        }

        #endregion

        /// <summary>
        /// Parses the data.
        /// </summary>
        /// <param name="ms">The ms.</param>
        protected override void ParseData(MemoryStream ms)
        {
            SequenceNumber = Helper.ConvertEndian(ms.ReadUInt32());
            Width = Helper.ConvertEndian(ms.ReadUInt32());
            Height = Helper.ConvertEndian(ms.ReadUInt32());
            XOffset = Helper.ConvertEndian(ms.ReadUInt32());
            YOffset = Helper.ConvertEndian(ms.ReadUInt32());
            DelayNumerator = Helper.ConvertEndian(ms.ReadUInt16());
            DelayDenominator = Helper.ConvertEndian(ms.ReadUInt16());
            DisposeOp = (DisposeOps)ms.ReadByte();
            BlendOp = (BlendOps)ms.ReadByte();
        }
    }
}