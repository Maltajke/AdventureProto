using System;
using UnityEngine;

namespace Capybara.Network
{
    public class NetworkController : MonoBehaviour
    {
        private bool _isConnected;

        private Client _client;
        private ClientHandleNetworkData _clientHandleNetworkData;

        public Client Client => _client;
        public ClientHandleNetworkData ClientHandleNetworkData => _clientHandleNetworkData;

        private void Start()
        {
            Connect();
        }

        public void Connect()
        {
            if (_isConnected)
            {
                throw new Exception("The connection is already established");
            }

            _client = new Client();
            _clientHandleNetworkData = new ClientHandleNetworkData(_client);
            _client.Init(_clientHandleNetworkData);

            _clientHandleNetworkData.InitializeNetworkPackages();
            _client.ConnectToServer();
        }

        private void OnDestroy()
        {
            _client.Disconnect();
        }
    }
}