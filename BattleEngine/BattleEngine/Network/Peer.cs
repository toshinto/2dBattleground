using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine.Network
{
    /// <summary>
    /// Manqk koito uchastva v network raotata. 
    /// </summary>
    public abstract class Peer
    {
        public const string AppIdentifier = "BattleHarabiq";
        public const int NetworkPort = 1234;

        internal NetPeer peer;

        public Peer(NetPeer peer)
        {
            this.peer = peer;

            //start the client
            peer.Start();
        }

        /// <summary>
        /// Reads incoming messages. To be called continuously. 
        /// </summary>
        public virtual void Update(int msElapsed)
        {
            NetIncomingMessage msg;
            while ((msg = peer.ReadMessage()) != null)
            {
                HandleIncomingMessage(msg);
                peer.Recycle(msg);
            }
        }

        internal void HandleIncomingMessage(NetIncomingMessage msg)
        {
            switch (msg.MessageType)
            {
                case NetIncomingMessageType.VerboseDebugMessage:
                case NetIncomingMessageType.DebugMessage:
                    Console.WriteLine("[DEBUG] {0}", msg.ReadString());
                    break;
                case NetIncomingMessageType.WarningMessage:
                    Console.WriteLine("[WARNING] {0}", msg.ReadString());
                    break;
                case NetIncomingMessageType.ErrorMessage:
                    Console.WriteLine("[ERROR] {0}", msg.ReadString());
                    break;

                // data messages
                case NetIncomingMessageType.Data:
                    //HandleDataMessage(msg);
                    break;

                // client connect / disconnect
                case NetIncomingMessageType.StatusChanged:
                    NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();

                    if (status == NetConnectionStatus.Connected)
                        OnConnected(msg.SenderConnection);
                    else if (status == NetConnectionStatus.Disconnected)
                        OnDisconnected(msg.SenderConnection);

                    string reason = msg.ReadString();
                    Console.WriteLine("[CONN] {0}", status.ToString() + ": " + reason);
                    break;

                default:
                    Console.WriteLine("[ERROR] Unhandled message type: {0} ({1} bytes)", msg.MessageType, msg.LengthBytes);
                    break;
            }
        }

        internal abstract void HandleDataMessage(NetIncomingMessage msg);

        internal virtual void OnConnected(NetConnection conn) { }
        internal virtual void OnDisconnected(NetConnection conn) { }

    }
}
