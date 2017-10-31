namespace DownloadMusic.Core
{
    interface IParserSettinds
    {
        string BaseUrl { get; set; }

        string Prefix { get; set; }

        string Search { get; set; }

        int? CurrentId { get; set; }
    }
}
