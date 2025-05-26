namespace Blog.Wasm.Core
{
    public class Post(string fileName, string title, DateTime date, List<string> tags, string content)
    {
        public string FileName { get; set; } = fileName;
        public string Title { get; set; } = title;
        public DateTime Date { get; set; } = date;
        public List<string> Tags { get; set; } = tags;
        public string Content { get; set; } = content;
    }
    public class Index
    {
        public List<Post> Posts { get; set; }
        public Index(List<Post> posts)
        {
            Posts = posts;
        }
    }
}
