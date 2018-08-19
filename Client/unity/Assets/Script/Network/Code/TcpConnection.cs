//****************************************************************************
// Description:tcp通信逻辑
// Author: hiramtan@qq.com
//****************************************************************************
using GameBox.Framework;
using GameBox.Service.ByteStorage;
using GameBox.Service.NetworkManager;
using HiFramework;
using usercmd;

namespace HiGame
{
    public class TcpConnection : Connection, IProtocolHost
    {
       
        private const string Connected = "connected";
        private const string Connecting = "connecting";
        private const string Disconnected = "disconnected";
        private INetworkManager _iNetworkManager;
        private ISocketChannel _iSocketChannel;
        private bool isSetUp = false;
        public bool IsSetup {
            get {
                return    isSetUp;
            }
        }
        public TcpConnection(string _Ip,string loginName)
        {
         GameWorld.Instance.addInQuitActionList(Disconnect);
            new ServiceTask(new[]
            {
                typeof(IByteStorage),
                typeof(INetworkManager)
            }).Start().Continue(t =>
            {
                _iNetworkManager = ServiceCenter.GetService<INetworkManager>();
                _iSocketChannel = _iNetworkManager.Create("tcp") as ISocketChannel;
                _iSocketChannel.Setup(this);
                _iSocketChannel.OnChannelStateChange = OnServerStateChange;
                var data = _Ip.Split(':');
                var ip = data[0];
                var port = int.Parse(data[1]);
                _iSocketChannel.Connect(ip, port);               
                Login(loginName);
                isSetUp = true;
                return null;
            });
        }
        private void Login(string name)
        {
            LoginC2SMsg msgLogin = new LoginC2SMsg();
            msgLogin.name = name;
            MsgHandler.Send((int)DemoTypeCmd.LoginReq, msgLogin);
        }
        public void Pack(IObjectReader reader, IByteArray writer)
        {
            var message = reader.ReadOne() as SendPackage;
            var byteArray = Pack(message);
            writer.WriteBytes(byteArray.Bytes, 0, byteArray.Length);
        }

        public void Unpack(IByteArray reader, IObjectWriter writer)
        {
            _receiveArray.WriteBytes(reader.ReadBytes());
            Unpack();
#if HShowSocket
            if (cmdId == (int)MsgTypeCmd.SceneUDP)
                Service.UIManager.MoveSocketStr = "当前通信协议:tcp";
#endif
        }

        private void Connect(string ip, int port)
        {
            _iSocketChannel.Connect(ip, port);
        }

        public void Disconnect()
        {
           
            if (_iSocketChannel != null)
            {
                _iSocketChannel.Disconnect();
                _iSocketChannel.Dispose();
                _iSocketChannel = null;
            }
        }

        public void Send(SendPackage obj)
        {
            _iSocketChannel.Send(obj);
        }

        private void OnServerStateChange(string state)
        {
            switch (state)
            {
                case Connected:
                    Debuger.Log("OnTeamServerState" + Connected);
                    break;
                case Connecting:
                    Debuger.Log("OnTeamServerState" + Connecting);
                    break;
                case Disconnected:
                    Debuger.Log("OnTeamServerState" + Disconnected);
                    break;
            }
        }

    }


       
 }
   