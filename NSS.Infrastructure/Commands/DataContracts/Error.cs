namespace NSS.Infrastructure.Commands.DataContracts
{
    public class Error
    {
        public Error(string messageShort, string messageLong = null)
        {
            this.MessageShort = messageShort;
            this.MessageLong = messageLong;
        }

        public string MessageShort { get; }
        public string MessageLong { get; }
    }
}
