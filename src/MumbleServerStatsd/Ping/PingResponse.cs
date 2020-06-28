namespace MumbleServerStatsd.Ping
{
    using BitConverter;

    /// <summary>
    /// Handle the data of a ping response
    /// and the conversion from bytes.
    /// </summary>
    public class PingResponse
    {
        /// <summary>
        /// No constructor, initialize with
        /// FromBytes() .
        /// </summary>
        private PingResponse()
        {
        }

        /// <summary>
        /// Gets the version of the Mumble server
        /// (like "1.3.0").
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Gets the unique identifier matching the one
        /// from the ping request.
        /// </summary>
        public long Identifier { get; private set; }

        /// <summary>
        /// Gets the unique identifier matching the one
        /// from the ping request.
        /// </summary>
        public int ConnectedUsers { get; private set; }

        /// <summary>
        /// Gets the unique identifier matching the one
        /// from the ping request.
        /// </summary>
        public int MaximumUsers { get; private set; }

        /// <summary>
        /// Gets the unique identifier matching the one
        /// from the ping request.
        /// </summary>
        public int AllowedBandwith { get; private set; }

        /// <summary>
        /// Create an instance of PingResponse
        /// from the request bytes response.
        /// </summary>
        /// <param name="bytes">The response as bytes.</param>
        /// <returns>
        /// An instance of PingResponse.
        /// </returns>
        public static PingResponse FromBytes(byte[] bytes)
        {
            return new PingResponse
            {
                Version = $"{bytes[1]}.{bytes[2]}.{bytes[3]}",
                Identifier = EndianBitConverter.BigEndian.ToInt64(bytes, 4),
                ConnectedUsers = EndianBitConverter.BigEndian.ToInt32(bytes, 12),
                MaximumUsers = EndianBitConverter.BigEndian.ToInt32(bytes, 16),
                AllowedBandwith = EndianBitConverter.BigEndian.ToInt32(bytes, 20),
            };
        }
    }
}
