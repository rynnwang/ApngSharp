using System.IO;

namespace Beyova.ApngSharp.Core
{
    internal class FDATChunk : Chunk
    {
        public FDATChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public FDATChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public FDATChunk(Chunk chunk)
            : base(chunk)
        {
        }

        public uint SequenceNumber { get; private set; }

        public byte[] FrameData { get; private set; }

        protected override void ParseData(MemoryStream ms)
        {
            SequenceNumber = Helper.ConvertEndian(ms.ReadUInt32());
            FrameData = ms.ReadBytes((int)Length - 4);
        }

        public IDATChunk ToIDATChunk()
        {
            uint newCrc;
            using (var msCrc = new MemoryStream())
            {
                msCrc.WriteBytes(new[] {(byte)'I', (byte)'D', (byte)'A', (byte)'T'});
                msCrc.WriteBytes(FrameData);

                newCrc = CrcHelper.Calculate(msCrc.ToArray());
            }

            using (var ms = new MemoryStream())
            {
                ms.WriteUInt32(Helper.ConvertEndian(Length - 4));
                ms.WriteBytes(new[] {(byte)'I', (byte)'D', (byte)'A', (byte)'T'});
                ms.WriteBytes(FrameData);
                ms.WriteUInt32(Helper.ConvertEndian(newCrc));
                ms.Position = 0;

                return new IDATChunk(ms);
            }
        }
    }
}