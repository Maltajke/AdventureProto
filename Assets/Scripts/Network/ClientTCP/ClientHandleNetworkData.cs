using System.Collections.Generic;
using UnityEngine;

namespace Capybara.Network
{
    public class ClientHandleNetworkData
    {
        private Client _client;

        private delegate void Packet(byte[] data);

        private static Dictionary<int, Packet> _packets;

        public ClientHandleNetworkData(Client client)
        {
            _client = client;
        }

        public void InitializeNetworkPackages()
        {
            Debug.Log("Initialize network packages");
            _packets = new Dictionary<int, Packet>
            {
                {
                    (int) NetworkPackets.ServerPackets.SConnectionOk,
                    HandleConnectionOk
                },
                {
                    (int) NetworkPackets.ServerPackets.SMessage,
                    HandleMessage
                }
            };
        }

        private void HandleMessage(byte[] data)
        {
            var buffer = new PacketBuffer();
            buffer.WriteBytes(data);
            buffer.ReadInteger();
            var msg = buffer.ReadString();
            buffer.Dispose();

            //Add your code want to execute hear:
            Debug.Log(msg);
        }

        public void HandleNetworkInformation(byte[] data)
        {
            int paketNum;
            var buffer = new PacketBuffer();
            buffer.WriteBytes(data);
            paketNum = buffer.ReadInteger();
            buffer.Dispose();
            if (_packets.TryGetValue(paketNum, out Packet packet))
            {
                packet.Invoke(data);
            }
        }

        private void HandleConnectionOk(byte[] data)
        {
            var buffer = new PacketBuffer();
            buffer.WriteBytes(data);
            buffer.ReadInteger();
            var msg = buffer.ReadString();
            buffer.Dispose();

            //Add your code want to execute hear:
            Debug.Log(msg);
            _client.SendCallback();
        }
    }
}