using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Server
    {
        TcpListener Listener;
        public Server (int port)
        {
            Listener = new TcpListener(IPAddress.Any, port);
            Listener.Start();

            while (true)
            {
                new Client(Listener.AcceptTcpClient());
            }

        }

        ~Server() //destructor
        {
            //cleanup statements
            if (Listener != null)
            {
                Listener.Stop();
            }
        }

    }

    class Client
    {
        public Client(TcpClient Client)
        {
            string html = "<html><body><h1>Hallo!!!</body></html>";

            string responce = "HTTP/1.1 200 OK\nContent-type: text/html\nContent-Length:" + html.Length.ToString() + "\n\n" + html;

            byte[] Buffer = Encoding.ASCII.GetBytes(responce);

            Client.GetStream().Write(Buffer, 0, Buffer.Length);

            Client.Close();
        }
    }

}
