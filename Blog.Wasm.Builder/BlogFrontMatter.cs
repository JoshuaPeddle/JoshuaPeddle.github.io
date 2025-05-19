// Accepts an argument to specify the path to the project folder.

// The project folder should contain a wwwroot/_posts folder with .md files.

// This program creates an index.json file in the wwwroot/posts folder, which contains a list of all the .md files in the folder.

// The index.json file is used by the Blazor WebAssembly app to display the list of posts.

using YamlDotNet.Serialization;

public class BlogFrontMatter
{
    [YamlMember(Alias = "title")]
    public string Title { get; set; }
    [YamlMember(Alias = "date")]
    public DateTime Date { get; set; }
    [YamlMember(Alias = "tags")]
    public List<string> Tags { get; set; }
}
