using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        private static TcpClient _clientSocket = null;
        private static Stream _nstream = null;
        private static StreamWriter _sWriter = null;
        private static StreamReader _sReader = null;
        static void Main(string[] args)
        {
            try
            {

                using (_clientSocket = new TcpClient("127.0.0.1", 254))
                {
                    using (_nstream = _clientSocket.GetStream())
                    {
                        while (true)
                        {
                            _sWriter = new StreamWriter(_nstream) { AutoFlush = true };

                            Console.WriteLine("Your message: ");
                            string clientMessage = Console.ReadLine();

                            _sWriter.WriteLine(clientMessage);


                            _sReader = new StreamReader(_nstream);
                            string readServerMessage = _sReader.ReadLine();
                            if (readServerMessage != null)
                            {

                                Console.WriteLine("Client has received a message: " + readServerMessage);
                                Console.WriteLine(".....................................................");

                            }
                            else
                            {
                                Console.WriteLine("Client has not received a message ");
                            }
                        }

                    }
                }
                Console.WriteLine("Press enter to stop the client!");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
