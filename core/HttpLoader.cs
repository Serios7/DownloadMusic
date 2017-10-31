using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DownloadMusic.Core
{
    class HtmlLoader
    {
        readonly WebClient client;
        readonly string url;

        public HtmlLoader(IParserSettinds settings)
        {
            client = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            url = $"{settings.BaseUrl}{settings.Prefix}";
        }

        public async Task<string> GetSourseBySearch(string search, int? currentId = null)
        {
            var currentUrl = url.Replace("{CurrentSearch}", search).Replace("{CurrentId}", currentId.ToString());
            return await client.DownloadStringTaskAsync(currentUrl);
        }
    }
}
