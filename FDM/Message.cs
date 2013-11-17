namespace FDM
{
    public class Message
    {
        public uint FdmId { get; set; }
        public int MessageId { get; set; }
        public string Text { get; set; }
        public string SubSystem { get; set; }
        public MessageType Type { get; set; }
        public bool BVal { get; set; }
        public int IVal { get; set; }
        public double DVal { get; set; }
    }
}