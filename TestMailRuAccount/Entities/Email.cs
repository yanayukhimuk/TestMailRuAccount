namespace TestMailRuAccount.Entities
{
    class Email
    {
        private readonly string Topic;
        private readonly string Message;

        public string[] EmailContent { get; private set; }

        public Email(string topic, string message)
        {
            topic = Topic;
            message = Message;
            EmailContent = new[] { this.Topic, this.Message };
        }

    }
}
