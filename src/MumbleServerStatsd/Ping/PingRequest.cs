using System;
using System.IO;
using BitConverter;

namespace MumbleServerStatsd.Ping
{
    public class PingRequest
    {
        public PingRequest()
        {
            this.RequestType = 0;
            this.Identifier = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        private int RequestType;
        public long Identifier { get; }

        public byte[] ToBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(EndianBitConverter.BigEndian.GetBytes(this.RequestType));
                    writer.Write(EndianBitConverter.BigEndian.GetBytes(this.Identifier));
                }
                return stream.ToArray();
            }
        }
    }
}
