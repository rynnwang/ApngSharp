using System;
using System.IO;

namespace Beyova.ApngSharp.Core
{
    public class IENDChunk : Chunk
    {
        public IENDChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public IENDChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public IENDChunk(Chunk chunk)
            : base(chunk)
        {
        }

        protected override void ParseData(MemoryStream ms)
        {
            //Do nothing
        }
    }
}