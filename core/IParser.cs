using AngleSharp.Dom.Html;

namespace DownloadMusic.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
