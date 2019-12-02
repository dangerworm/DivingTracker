namespace CommonCode.Web.Models
{
    public class MessageViewModel
    {
        public string Class { get; set; }
        public string Message { get; set; }
        public int TimesSeen { get; set; }

        public MessageViewModel Clone()
        {
            return new MessageViewModel
            {
                Class = Class,
                Message = Message,
                TimesSeen = TimesSeen
            };
        }
    }
}