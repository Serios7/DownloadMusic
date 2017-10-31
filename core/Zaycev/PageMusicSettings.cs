using System;

namespace DownloadMusic.Core.Zaycev
{
    class PageMusicSettings : IParserSettinds
    {
        public PageMusicSettings(string search)
        {
            Search = search;
        }

        public string BaseUrl { get; set; } = "";

        public string Prefix { get; set; } = "{CurrentSearch}";

        public string Search { get; set; }

        public int? CurrentId { get; set; }
    }
}
