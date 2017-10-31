using AngleSharp.Parser.Html;
using System;

namespace DownloadMusic.Core
{
    class ParserWorker<T> where T : class
    {
        IParserSettinds parserSettings;
        HtmlLoader loader;

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public bool IsActive { get; set; }

        public IParser<T> Parser { get; set; }
        
        public IParserSettinds Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        
        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettinds parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            IsActive = true;
            Worker();
        }

        public void Abort()
        {
            IsActive = false;
        }

        private async void Worker()
        {
            if (!IsActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            OnNewData?.Invoke(this, Parser.Parse(await new HtmlParser().ParseAsync(await loader.GetSourseBySearch(parserSettings.Search, parserSettings.CurrentId))));

            OnCompleted?.Invoke(this);
            IsActive = false;
        }
    }
}
