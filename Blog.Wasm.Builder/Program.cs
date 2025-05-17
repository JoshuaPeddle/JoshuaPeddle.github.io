// Accepts an argument to specify the path to the project folder.

// The project folder should contain a wwwroot/posts folder with .md files.

// This program creates an index.json file in the wwwroot/posts folder, which contains a list of all the .md files in the folder.

// The index.json file is used by the Blazor WebAssembly app to display the list of posts.

using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;


var projectFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
var postsFolder = Path.Combine(projectFolder, "wwwroot", "posts");
var indexFile = Path.Combine(postsFolder, "index.json");

var posts = new List<Post>();
var postFiles = Directory.GetFiles(postsFolder, "*.md", SearchOption.TopDirectoryOnly);
foreach (var postFile in postFiles)
{
    var post = new Post
    {
        FileName = Path.GetFileName(postFile),
        //Title = GetTitle(postFile),
        //Date = GetDate(postFile),
        //Tags = GetTags(postFile),
        //Content = GetContent(postFile)
    };
    posts.Add(post);
}

var index = new Index
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
Console.WriteLine($"Index file created: {indexFile}");

Console.WriteLine($"Number of posts: {posts.Count}");
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