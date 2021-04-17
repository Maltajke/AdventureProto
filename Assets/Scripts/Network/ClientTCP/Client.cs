using System;
using System.Net.Sockets;
using UnityEngine;

namespace Capybara.Network
{
    public class Client
    {
        private ClientHandleNetworkData _clientHandleNetworkData;

        public void Init(ClientHandleNetworkData clientHandleNetworkData)
        {
            _clientHandleNetworkData = clientHandleNetworkData;
        }

        public const string IP_ADDRESS = "127.0.0.1";
        public const int PORT = 5555;

        public Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] _asyncBuffer = new byte[1024];

        public void ConnectToServer()
        {
            Debug.Log("Connecting to server...");
            _clientSocket.BeginConnect(IP_ADDRESS, PORT, ConnectCallback, _clientSocket);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            _clientSocket.EndConnect(ar);
            while (true)
            {
                OnReceive();
            }
        }

        private void OnReceive()
        {
            var sizeInfo = new byte[4];

            int totalRead;
            int currentRead;

            try
            {
                currentRead = totalRead = _clientSocket.Receive(sizeInfo);

                if (totalRead <= 0)
                {
                    Console.WriteLine("Yor are not connected to the server");
                }
                else
                {
                    while (totalRead < sizeInfo.Length && currentRead > 0)
                    {
                        currentRead = _clientSocket.Receive(sizeInfo, totalRead, sizeInfo.Length - totalRead,
                            SocketFlags.None);
                        totalRead += currentRead;
                    }

                    var messageSize = 0;
                    messageSize |= sizeInfo[0];
                    messageSize |= sizeInfo[1] << 8;
                    messageSize |= sizeInfo[2] << 16;
                    messageSize |= sizeInfo[3] << 24;

                    var data = new byte[messageSize];

                    totalRead = 0;
                    currentRead = totalRead =
                        _clientSocket.Receive(data, totalRead, data.Length - 0, SocketFlags.None);
                    while (totalRead < messageSize && currentRead > 0)
                    {
                        currentRead = _clientSocket.Receive(data, totalRead, data.Length - totalRead, SocketFlags.None);
                        totalRead += currentRead;
                    }

                    _clientHandleNetworkData.HandleNetworkInformation(data);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Yor are not connected to the server");
            }
        }

        public void SendData(byte[] data)
        {
            _clientSocket.Send(data);
        }

        public void SendCallback()
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteInteger((int) NetworkPackets.ClientPackets.CThankYou);
            buffer.WriteString("Successful connection!");
            SendData(buffer.ToArray);
            buffer.Dispose();
        }

        public void Disconnect()
        {
            _clientSocket.Disconnect(false);
        }
    }
}