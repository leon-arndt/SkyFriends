namespace Networking.Requests
{
    public interface INetworkRequestType
    {
        public string BasePath { get; set; }
        public string Path { get; set; }
        public object RequestBody { get; set; }
        public Method Method { get; set; }
    }

    /// <summary>
    /// This enum should match whatever networking approach is used e.g. UnityWebRequest.
    /// </summary>
    public enum Method
    {
        Get,
        Post,
        Put,
        Head,
        Custom,
    }
}
