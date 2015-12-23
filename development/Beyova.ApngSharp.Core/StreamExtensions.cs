using System;
using System.IO;

namespace Beyova.ApngSharp.Core
{
    /// <summary>
    /// Class StreamExtensions.
    /// </summary>
    internal static class StreamExtensions
    {
        #region Peek

        /// <summary>
        /// Peeks the bytes.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] PeekBytes(this Stream ms, int position, int count)
        {
            long prevPosition = ms.Position;

            ms.Position = position;
            byte[] buffer = ReadBytes(ms, count);
            ms.Position = prevPosition;

            return buffer;
        }

        /// <summary>
        /// Peeks the character.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>System.Char.</returns>
        public static char PeekChar(this Stream ms)
        {
            return PeekChar(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the character.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>System.Char.</returns>
        public static char PeekChar(this Stream ms, int position)
        {
            return BitConverter.ToChar(PeekBytes(ms, position, 2), 0);
        }

        /// <summary>
        /// Peeks the int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int16.</returns>
        public static Int16 PeekInt16(this Stream ms)
        {
            return PeekInt16(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>Int16.</returns>
        public static Int16 PeekInt16(this Stream ms, int position)
        {
            return BitConverter.ToInt16(PeekBytes(ms, position, 2), 0);
        }

        /// <summary>
        /// Peeks the int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int32.</returns>
        public static Int32 PeekInt32(this Stream ms)
        {
            return PeekInt32(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>Int32.</returns>
        public static Int32 PeekInt32(this Stream ms, int position)
        {
            return BitConverter.ToInt32(PeekBytes(ms, position, 4), 0);
        }

        /// <summary>
        /// Peeks the int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int64.</returns>
        public static Int64 PeekInt64(this Stream ms)
        {
            return PeekInt64(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>Int64.</returns>
        public static Int64 PeekInt64(this Stream ms, int position)
        {
            return BitConverter.ToInt64(PeekBytes(ms, position, 8), 0);
        }

        /// <summary>
        /// Peeks the u int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt16.</returns>
        public static UInt16 PeekUInt16(this Stream ms)
        {
            return PeekUInt16(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the u int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>UInt16.</returns>
        public static UInt16 PeekUInt16(this Stream ms, int position)
        {
            return BitConverter.ToUInt16(PeekBytes(ms, position, 2), 0);
        }

        /// <summary>
        /// Peeks the u int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt32.</returns>
        public static UInt32 PeekUInt32(this Stream ms)
        {
            return PeekUInt32(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the u int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>UInt32.</returns>
        public static UInt32 PeekUInt32(this Stream ms, int position)
        {
            return BitConverter.ToUInt32(PeekBytes(ms, position, 4), 0);
        }

        /// <summary>
        /// Peeks the u int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt64.</returns>
        public static UInt64 PeekUInt64(this Stream ms)
        {
            return PeekUInt64(ms, (int)ms.Position);
        }

        /// <summary>
        /// Peeks the u int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <returns>UInt64.</returns>
        public static UInt64 PeekUInt64(this Stream ms, int position)
        {
            return BitConverter.ToUInt64(PeekBytes(ms, position, 8), 0);
        }

        #endregion Peek

        #region Read

        /// <summary>
        /// Reads the bytes.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.Exception">End reached.</exception>
        public static byte[] ReadBytes(this Stream ms, int count)
        {
            var buffer = new byte[count];

            if (ms.Read(buffer, 0, count) != count)
                throw new Exception("End reached.");

            return buffer;
        }

        /// <summary>
        /// Reads the character.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>System.Char.</returns>
        public static char ReadChar(this Stream ms)
        {
            return BitConverter.ToChar(ReadBytes(ms, 2), 0);
        }

        /// <summary>
        /// Reads the int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int16.</returns>
        public static Int16 ReadInt16(this Stream ms)
        {
            return BitConverter.ToInt16(ReadBytes(ms, 2), 0);
        }

        /// <summary>
        /// Reads the int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int32.</returns>
        public static Int32 ReadInt32(this Stream ms)
        {
            return BitConverter.ToInt32(ReadBytes(ms, 4), 0);
        }

        /// <summary>
        /// Reads the int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>Int64.</returns>
        public static Int64 ReadInt64(this Stream ms)
        {
            return BitConverter.ToInt64(ReadBytes(ms, 8), 0);
        }

        /// <summary>
        /// Reads the u int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt16.</returns>
        public static UInt16 ReadUInt16(this Stream ms)
        {
            return BitConverter.ToUInt16(ReadBytes(ms, 2), 0);
        }

        /// <summary>
        /// Reads the u int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt32.</returns>
        public static UInt32 ReadUInt32(this Stream ms)
        {
            return BitConverter.ToUInt32(ReadBytes(ms, 4), 0);
        }

        /// <summary>
        /// Reads the u int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <returns>UInt64.</returns>
        public static UInt64 ReadUInt64(this Stream ms)
        {
            return BitConverter.ToUInt64(ReadBytes(ms, 8), 0);
        }

        #endregion Read

        #region Write

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteByte(this Stream ms, int position, byte value)
        {
            long prevPosition = ms.Position;

            ms.Position = position;
            ms.WriteByte(value);
            ms.Position = prevPosition;
        }

        /// <summary>
        /// Writes the bytes.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteBytes(this Stream ms, byte[] value)
        {
            ms.Write(value, 0, value.Length);
        }

        /// <summary>
        /// Writes the bytes.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteBytes(this Stream ms, int position, byte[] value)
        {
            long prevPosition = ms.Position;

            ms.Position = position;
            ms.Write(value, 0, value.Length);
            ms.Position = prevPosition;
        }

        /// <summary>
        /// Writes the int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt16(this Stream ms, Int16 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 2);
        }

        /// <summary>
        /// Writes the int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt16(this Stream ms, int position, Int16 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes the int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt32(this Stream ms, Int32 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 4);
        }

        /// <summary>
        /// Writes the int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt32(this Stream ms, int position, Int32 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes the int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt64(this Stream ms, Int64 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 8);
        }

        /// <summary>
        /// Writes the int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteInt64(this Stream ms, int position, Int64 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes the u int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt16(this Stream ms, UInt16 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 2);
        }

        /// <summary>
        /// Writes the u int16.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt16(this Stream ms, int position, UInt16 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes the u int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt32(this Stream ms, UInt32 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 4);
        }

        /// <summary>
        /// Writes the u int32.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt32(this Stream ms, int position, UInt32 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes the u int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt64(this Stream ms, UInt64 value)
        {
            ms.Write(BitConverter.GetBytes(value), 0, 8);
        }

        /// <summary>
        /// Writes the u int64.
        /// </summary>
        /// <param name="ms">The ms.</param>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public static void WriteUInt64(this Stream ms, int position, UInt64 value)
        {
            WriteBytes(ms, position, BitConverter.GetBytes(value));
        }

        #endregion Write
    }
}