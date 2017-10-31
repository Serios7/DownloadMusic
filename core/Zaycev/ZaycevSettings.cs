using System;

namespace DownloadMusic.Core.Zaycev
{
    class ZaycevSettings : IParserSettinds
    {
        public ZaycevSettings(string search, int? currentId)
        {
            Search = search;
            CurrentId = currentId;
        }

        public string BaseUrl { get; set; } = "http://go.mail.ru";

        public string Prefix { get; set; } = "/zaycev?q={CurrentSearch}&page={CurrentId}";

        public string Search { get; set; }

        public int? CurrentId { get; set; }
    }
}
