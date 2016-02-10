using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine.Network
{
    class Server : Peer
    {


        readonly Game Game;

        internal NetServer NetServer { get { return (NetServer)peer; } }

        readonly HashSet<NetConnection> clients = new HashSet<NetConnection>();


        public Server(Game game)
            : base(new NetServer(new NetPeerConfiguration(AppIdentifier) { Port = NetworkPort }))
        {
            Game = game;
        }


        public override void Update(int msElapsed)
        {
        }


        internal override void OnConnected(NetConnection conn)
        {
            //nqkoi se svurza -> joinni go kam servera ako ima mqsto


            //clients.Add(conn);

        }

        internal override void OnDisconnected(NetConnection conn)
        {
            //vij dali e igral
            if (!clients.Contains(conn))
                return;

        }


        internal override void HandleDataMessage(NetIncomingMessage incomingMessage)
        {
            //try
            {
                var msg = incomingMessage.Data;


                ////check if it's a handshake and if so, ask the server whether to accept it
                //if (msg.Type == MessageType.HandshakeInit)
                //{
                //    handleHandshake(incomingMessage.SenderConnection, (HandshakeInitMessage)msg);
                //    return;
                //}

                ////for all other message types, the client must already have an identity. 
                //var client = clients.TryGet(incomingMessage.SenderConnection);
                //if (client == null)
                //{
                //    Console.WriteLine("nqkav na spami");
                //    return;
                //}

                //client.HandleMessage(msg);
            }
            //catch (Exception e)
            //{
            //    Log.Default.Error("Unhandled exception while handling a data packet: {0}", e.Message);
            //}
        }

        ///// <summary>
        ///// Parses an incoming <see cref="HandshakeInitMessage"></see>
        ///// by handing it over to the server. 
        ///// 
        ///// If the server successfully accepts the user it returns a <see cref="IGameReceptor"/> object
        ///// which is added to the server's list of connected peers. Otherwise the connection is dropped.  
        ///// </summary>
        ///// <param name="peerConnection"></param>
        ///// <param name="msg"></param>
        //void handleHandshake(NetConnection peerConnection, HandshakeInitMessage msg)
        //{
        //    //get the peer data
        //    var client = new NetGameClient(NetServer, peerConnection, msg.PlayerName);


        //    //check if the server accepts it
        //    var receptor = engine.AcceptClient(client);
        //    var accepted = (receptor != null);  //TODO: make an actual check

        //    //if so, add to our list, too
        //    if (accepted)
        //    {
        //        // do our set-up
        //        client.Initialize(receptor);
        //        clients.Add(peerConnection, client);

        //        // inform the engine we'll be playing
        //        // (this step is necessary for single-player, check out LocalShano implementation)
        //        engine.StartPlaying(receptor);

        //        //and raise the client event
        //        ClientConnected?.Invoke(client);
        //    }

        //    Log.Default.Info("Got a handshake from {0}! Do we accept it? {1}", peerConnection.RemoteEndPoint.Address, accepted ? "yep" : "nope");

        //    //prepare and send the handshake reply
        //    receptor.SendHandshake(accepted);

        //    if (!accepted)
        //    {
        //        //TODO: drop connection
        //    }
        //}
    }
}
