using RaRat_server.Commnucation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RaRat_server
{
    class Controller
    {
        private static string serverRequestContent = "";
        private static string clientResponseContent = "";

        Thread socketClientThread;

        public Controller() {
            sendCommand("127.0.0.1", 8080, "Test");
            startListening();
        }

        void sendCommand(string IP, int port, string command)
        {
            Task startClient = new Task(() => SocketClient.startClient(IP, port, command));
            startClient.Start();
        }
        private void startListening() {
            Task startServer = new Task(() => SocketServer.SetupServer());
            startServer.Start();
        }

        public static void setServerRequestContent(string text) {
            serverRequestContent = text;
            Console.WriteLine(serverRequestContent);
        }

        public static void setClientResponsContent(string text)
        {
            clientResponseContent = text;
            Console.WriteLine(clientResponseContent);
        }
    }
}
