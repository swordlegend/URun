//****************************************************************************
// Description:接收消息对象
// Author: hiramtan@qq.com
//****************************************************************************
using System.IO;

public class ReceivePackage
{
    private int _cmdId;
    private MemoryStream _bodyStream;

    public ReceivePackage(int cmdId, MemoryStream bodyStream = null)
    {
        _cmdId = cmdId;
        _bodyStream = bodyStream;
    }

    public int CmdId
    {
        get
        {
            return _cmdId;
        }
    }

    public MemoryStream BodyStream
    {
        get
        {
            return _bodyStream;
        }
    }
}
