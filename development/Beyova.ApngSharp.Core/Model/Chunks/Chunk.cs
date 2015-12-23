using System;
using System.IO;
using System.Text;

namespace Beyova.ApngSharp.Core
{
    public class Chunk
    {
        #region Property

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        public uint Length { get; set; }

        /// <summary>
        /// Gets or sets the type of the chunk.
        /// </summary>
        /// <value>The type of the chunk.</value>
        public string ChunkType { get; set; }

        /// <summary>
        /// Gets or sets the chunk data.
        /// </summary>
        /// <value>The chunk data.</value>
        public byte[] ChunkData { get; set; }

        /// <summary>
        /// Gets or sets the CRC.
        /// </summary>
        /// <value>The CRC.</value>
        public uint Crc { get; set; }

        /// <summary>
        ///     Get raw data of the chunk
        /// </summary>
        public byte[] RawData
        {
            get
            {
                using (var ms = new MemoryStream())
                {
                    ms.WriteUInt32(Helper.ConvertEndian(Length));
                    ms.WriteBytes(Encoding.ASCII.GetBytes(ChunkType));
                    ms.WriteBytes(ChunkData);
                    ms.WriteUInt32(Helper.ConvertEndian(Crc));

                    return ms.ToArray();
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk"/> class.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="chunkType">Type of the chunk.</param>
        /// <param name="chunkData">The chunk data.</param>
        /// <param name="crc">The CRC.</param>
        internal Chunk(uint length, string chunkType, byte[] chunkData, uint crc)
        {
            Length = length;
            ChunkType = chunkType;
            ChunkData = chunkData;
            Crc = crc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk"/> class.
        /// </summary>
        internal Chunk()
        {
            Length = 0;
            ChunkType = String.Empty;
            ChunkData = null;
            Crc = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <exception cref="System.Exception">
        /// Chunk length not correct.
        /// or
        /// Chunk data length not correct.
        /// </exception>
        internal Chunk(byte[] bytes)
        {
            var ms = new MemoryStream(bytes);
            InitializeByMemoryStream(ms);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk"/> class.
        /// </summary>
        /// <param name="ms">The ms.</param>
        internal Chunk(MemoryStream ms)
        {
            InitializeByMemoryStream(ms);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Chunk" /> class.
        /// </summary>
        /// <param name="chunk">The chunk.</param>
        internal Chunk(Chunk chunk)
        {
            Length = chunk.Length;
            ChunkType = chunk.ChunkType;
            ChunkData = chunk.ChunkData;
            Crc = chunk.Crc;

            ParseData(new MemoryStream(ChunkData));
        }

        #endregion

        protected void InitializeByMemoryStream(MemoryStream ms)
        {
            Length = Helper.ConvertEndian(ms.ReadUInt32());
            ChunkType = Encoding.ASCII.GetString(ms.ReadBytes(4));
            ChunkData = ms.ReadBytes((int)Length);
            Crc = Helper.ConvertEndian(ms.ReadUInt32());

            if (ms.Position != ms.Length)
            {
                throw new InvalidDataException("Chunk length is not correct.");
            }

            if (Length != ChunkData.Length)
            {
                throw new InvalidDataException("Chunk data length is not correct.");
            }

            ParseData(new MemoryStream(ChunkData));
        }

        /// <summary>
        ///     Modify the ChunkData part.
        /// </summary>
        public void ModifyChunkData(int postion, byte[] newData)
        {
            Array.Copy(newData, 0, ChunkData, postion, newData.Length);

            using (var msCrc = new MemoryStream())
            {
                msCrc.WriteBytes(Encoding.ASCII.GetBytes(ChunkType));
                msCrc.WriteBytes(ChunkData);

                Crc = CrcHelper.Calculate(msCrc.ToArray());
            }
        }

        /// <summary>
        ///     Modify the ChunkData part.
        /// </summary>
        public void ModifyChunkData(int postion, uint newData)
        {
            ModifyChunkData(postion, BitConverter.GetBytes(newData));
        }

        /// <summary>
        /// Parses the data.
        /// </summary>
        /// <param name="ms">The ms.</param>
        protected virtual void ParseData(MemoryStream ms)
        {
            //Do nothing here.
        }
    }
}