using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace network9
{
    class ClientObject
    {
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter? Writer { get; }
        protected internal StreamReader? Reader { get; }

        private TcpClient? client;
        private ServerObject? server;
    }
}
