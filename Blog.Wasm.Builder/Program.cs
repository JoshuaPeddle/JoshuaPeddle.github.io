using Blog.Wasm.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

var projectFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
var postsFolder = Path.Combine(projectFolder, "wwwroot", "_posts");
var indexFile = Path.Combine(postsFolder, "index.json");

var posts = new List<Post>();
var postFiles = Directory.GetFiles(postsFolder, "*.md", SearchOption.TopDirectoryOnly);


foreach (var postFile in postFiles)
{
    var fileContent = File.ReadAllText(postFile);
    var frontmatter = fileContent.GetFrontMatter<BlogFrontMatter>();

    var post = new Post
    {
        FileName = Path.GetFileName(postFile),
        Title = frontmatter.Title,
        Date = frontmatter.Date,
        Tags = frontmatter.Tags,
        Content = String.Join("",fileContent.Split(new[] { "---" }, StringSplitOptions.RemoveEmptyEntries)[1..]).Trim()

    };
    posts.Add(post);
}

var index = new Blog.Wasm.Core.Index
{
    Posts = posts.OrderByDescending(p => p.Date).ToList()
};

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Converters =
    {
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
    }
};
var json = JsonSerializer.Serialize(index, options);
File.WriteAllText(indexFile, json);
Console.WriteLine($"Index file created: {indexFile}. Number of posts: {posts.Count}.");
