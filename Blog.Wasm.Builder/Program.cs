using Blog.Wasm.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

var projectFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
var postsFolder = Path.Combine(projectFolder, "wwwroot", "_posts");
var indexFile = Path.Combine(postsFolder, "index.json");

var posts = new List<Post>();
foreach (var postFile in Directory.GetFiles(postsFolder, "*.md", SearchOption.TopDirectoryOnly))
{
    var fileContent = File.ReadAllText(postFile);
    var frontmatter = fileContent.GetFrontMatter<BlogFrontMatter>();

    posts.Add(new Post(
        Path.GetFileName(postFile),
        frontmatter.Title ?? "",
        frontmatter.Date,
        frontmatter.Tags,
        String.Join("", fileContent.Split(new[] { "---" }, StringSplitOptions.RemoveEmptyEntries)[1..]).Trim()
    ));
}

var index = new Blog.Wasm.Core.Index
(
    posts.OrderByDescending(p => p.Date).ToList()
);

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
