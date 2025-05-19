namespace Blog.Wasm.Client
{
    public class Post
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<string> Tags { get; set; }
        public string Content { get; set; }
    }
    public class Index
    {
        public List<Client.Post> Posts { get; set; }
    }

}
