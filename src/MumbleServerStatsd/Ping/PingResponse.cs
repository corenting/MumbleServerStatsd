using System.IO;
using System.Linq;
using BitConverter;

namespace MumbleServerStatsd.Ping
{
    public class PingResponse
    {
        private PingResponse() { }


        public string Version { get; private set;}
        public long Identifier { get; private set;}
        public int ConnectedUsers { get; private set;}
        public int MaximumUsers { get; private set;}
        public int AllowedBandwith { get; private set;}

        public static PingResponse FromBytes(byte[] bytes)
        {
            return new PingResponse {
                Version = $"{bytes[1]}.{bytes[2]}.{bytes[3]}",
                Identifier = EndianBitConverter.BigEndian.ToInt64(bytes, 4),
                ConnectedUsers = EndianBitConverter.BigEndian.ToInt32(bytes, 12),
                MaximumUsers = EndianBitConverter.BigEndian.ToInt32(bytes, 16),
                AllowedBandwith = EndianBitConverter.BigEndian.ToInt32(bytes, 20),
            };
        }
    }
}
