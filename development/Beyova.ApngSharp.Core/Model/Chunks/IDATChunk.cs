using System;
using System.IO;

namespace Beyova.ApngSharp.Core
{
    public class IDATChunk : Chunk
    {
        public IDATChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public IDATChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public IDATChunk(Chunk chunk)
            : base(chunk)
        {
        }

        protected override void ParseData(MemoryStream ms)
        {
            //Do nothing
        }
    }
}