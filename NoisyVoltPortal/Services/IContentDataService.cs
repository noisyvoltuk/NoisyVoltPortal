using NoisyVoltPortal.Data;
using NoisyVoltPortal.Data.Blog;

namespace NoisyVoltPortal.Services
{
	public interface IContentDataService
	{
		public List<BlogEntry> GetBlogEntries();
	}
}
