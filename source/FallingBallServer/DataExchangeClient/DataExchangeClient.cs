using System.Net;
using System.Net.Sockets;

namespace DataExchangeClient
{
    public class DataExchangeClient : SocketClient
    {
        protected override int bufferSize { get; set; }
        public int Port { get; }

        public DataExchangeClient(int port, int bufferSize = 256)
        {
            this.bufferSize = bufferSize;

            Port = port;
        }

        public void Connect()
        {
            IPAddress ipAddr = IPAddress.Loopback;
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Port);

            Socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket.Connect(ipEndPoint);
        }
    }
}
