using System.IO;

namespace Beyova.ApngSharp.Core
{
    /// <summary>
    /// Class ACTLChunk.
    /// </summary>
    public class ACTLChunk : Chunk
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk" /> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        public ACTLChunk(byte[] bytes)
            : base(bytes)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk" /> class.
        /// </summary>
        /// <param name="ms">The ms.</param>
        public ACTLChunk(MemoryStream ms)
            : base(ms)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk" /> class.
        /// </summary>
        /// <param name="chunk">The chunk.</param>
        public ACTLChunk(Chunk chunk)
            : base(chunk)
        {
        }

        /// <summary>
        /// Gets the number frames.
        /// </summary>
        /// <value>The number frames.</value>
        public uint NumFrames { get; private set; }

        /// <summary>
        /// Gets the number plays.
        /// </summary>
        /// <value>The number plays.</value>
        public uint NumPlays { get; private set; }

        /// <summary>
        /// Parses the data.
        /// </summary>
        /// <param name="ms">The ms.</param>
        protected override void ParseData(MemoryStream ms)
        {
            NumFrames = Helper.ConvertEndian(ms.ReadUInt32());
            NumPlays = Helper.ConvertEndian(ms.ReadUInt32());
        }
    }
}