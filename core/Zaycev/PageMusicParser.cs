using System.Linq;
using AngleSharp.Dom.Html;
using Newtonsoft.Json;
using System.Net;

namespace DownloadMusic.Core.Zaycev
{
    class PageMusicParser : IParser<string>
    {
        WebClient client;

        public string Parse(IHtmlDocument document)
        {
            client = new WebClient();
            string search = document.QuerySelectorAll("div.audiotrack-page>div.musicset-track-list__items>div").Select(m => m.GetAttribute("data-url")).ToArray()[0];
            return JsonConvert.DeserializeObject<Uri>(client.DownloadString("http://zaycev.net" + search)).Url;            
        }
    }
}
