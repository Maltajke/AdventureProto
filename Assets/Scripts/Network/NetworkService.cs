using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Capybara.Network
{
    public class NetworkService : MonoBehaviour
    {
        [FormerlySerializedAs("_networkManager")] [SerializeField]
        private NetworkController networkController;

        private void Update()
        {
            SendString("Pidor");
            SendInt(322);
            SendFloat(322.322f);
        }

        public void SendInt(int value)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteInteger((int) NetworkPackets.ClientPackets.CInteger);
            buffer.WriteInteger(value);
            networkController.Client.SendData(buffer.ToArray);
            buffer.Dispose();
        }

        public void SendFloat(float value)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteInteger((int) NetworkPackets.ClientPackets.CFloat);
            buffer.WriteFloat(value);
            networkController.Client.SendData(buffer.ToArray);
            buffer.Dispose();
        }

        public void SendString(string text)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteInteger((int) NetworkPackets.ClientPackets.CMessage);
            buffer.WriteString(text);
            networkController.Client.SendData(buffer.ToArray);
            buffer.Dispose();
        }
    }
}