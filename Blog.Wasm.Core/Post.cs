namespace Blog.Wasm.Core
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
        public List<Post> Posts { get; set; }
    }

}
