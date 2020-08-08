using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace DataExchangeClient
{
    public abstract class SocketClient
    {
        protected abstract int bufferSize { get; set; }

        public Socket Socket { get; protected set; }

        public void Send(string response)
        {
            Socket.Send(Encoding.UTF8.GetBytes(response));
        }

        public string Receive()
        {
            while (true)
            {
                byte[] buffer = new byte[bufferSize];
                List<byte> data = new List<byte>();
                int bytes, bytesTotal = 0;

                do
                {
                    bytes = Socket.Receive(buffer);
                    bytesTotal += bytes;
                    data.AddRange(buffer.Take(bytes));
                }
                while (Socket.Available > 0);

                return Encoding.UTF8.GetString(data.ToArray());
            }
        }

        public void Close()
        {
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
        }
    }
}
