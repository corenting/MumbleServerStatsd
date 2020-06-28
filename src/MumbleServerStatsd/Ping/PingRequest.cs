namespace MumbleServerStatsd.Ping
{
    using System;
    using System.IO;
    using BitConverter;

    /// <summary>
    /// Handle the data of a ping request
    /// and the conversion to bytes.
    /// </summary>
    public class PingRequest
    {
        private int requestType;

        /// <summary>
        /// Construct a new ping request.
        /// Identifier and request type are set automatically.
        /// </summary>
        public PingRequest()
        {
            this.requestType = 0;
            this.Identifier = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Gets the request unique identifier.
        /// </summary>
        public long Identifier { get; }

        /// <summary>
        /// Convert the request to a byte array
        /// that can be send to the server.
        /// </summary>
        /// <returns>
        /// The byte array to send for the ping request.
        /// </returns>
        public byte[] ToBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(EndianBitConverter.BigEndian.GetBytes(this.requestType));
                    writer.Write(EndianBitConverter.BigEndian.GetBytes(this.Identifier));
                }

                return stream.ToArray();
            }
        }
    }
}
