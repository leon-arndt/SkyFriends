using Networking.Model;

namespace Networking.Requests
{
    public struct SavePlayer : INetworkRequestType
    {
        public SavePlayer(Player player)
        {
            Player = player;
            BasePath = NetworkRequest.GameServerBaseUrl;
            Path = "player/save";
            Method = Method.Post;
            RequestBody = player;
        }

        private Player Player { get; set; }
        public string BasePath { get; set; }
        public string Path { get; set; }
        public object RequestBody { get; set; }
        public Method Method { get; set; }
    }
}