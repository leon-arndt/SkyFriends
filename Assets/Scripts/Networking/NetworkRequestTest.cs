using Networking.Model;
using Networking.Requests;
using UnityEngine;

namespace Networking
{
    public class NetworkRequestTest : MonoBehaviour
    {
        private void Start()
        {
            var player = new Player{name = "NetworkRequestTest"};
            NetworkRequest.HandleNetworkRequest(new SavePlayer(player));
        }
    }
}