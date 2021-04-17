public class NetworkPackets
{
    //get send from server to client
    //client has to listen to server packets
    public enum ServerPackets
    {
        SConnectionOk = 1,
        SMessage = 2,
        SInteger = 3,
        SFloat = 4,
    }
        
    //get send from client to server
    //server has to listen to client packets
    public enum ClientPackets
    {
        CThankYou = 1,
        CMessage = 2,
        CInteger = 3,
        CFloat = 4,
    }
}