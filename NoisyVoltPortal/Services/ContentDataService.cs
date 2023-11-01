

using EPS.Extensions.YamlMarkdown;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Markdig.Syntax;
using NoisyVoltPortal.Data.Blog;

namespace NoisyVoltPortal.Services
{
	public class ContentDataService : IContentDataService
	{

		public List<BlogEntry> GetBlogEntries()
		{
			List<BlogEntry> lstBlog = new List<BlogEntry>();

			var tempDirectory = AppDomain.CurrentDomain.BaseDirectory;

			var dataPath = new DirectoryInfo( Path.Combine(tempDirectory, @"Data\Blog"));

			foreach (var mdFile in dataPath.GetFiles("*.md")){

				var sc = File.ReadAllText(mdFile.FullName);

				var tt =   GetBlogEntryFromMD(sc).Result;

				lstBlog.Add(tt);

			}


			return lstBlog;
		}

		private async Task<BlogEntry> GetBlogEntryFromMD(String markdown)
		{
			BlogEntry bEntry = new BlogEntry();
			string html = "";

			var pipeline = new MarkdownPipelineBuilder().UseYamlFrontMatter().Build();

			var writer = new StringWriter();
			var renderer = new HtmlRenderer(writer);
			pipeline.Setup(renderer);

			var document = Markdown.Parse(markdown, pipeline);

			// extract the front matter from markdown document
			var yamlBlock = document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

			var yaml = yamlBlock.Lines.ToString();

			// deserialize the yaml block into a custom type
			var deserializer = new DeserializerBuilder()
				.WithNamingConvention(CamelCaseNamingConvention.Instance)
				.Build();

			var metadata = deserializer.Deserialize<Dictionary<String, String>>(yaml);

			bEntry.Title = metadata["title"];
			bEntry.Tags = metadata["tags"];

			// finally we can render the markdown content as html if necessary
			renderer.Render(document);
			await writer.FlushAsync();
			  html = writer.ToString();

			bEntry.HtmlContent = html;

			return bEntry;

		}
	}
}