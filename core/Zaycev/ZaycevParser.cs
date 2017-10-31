using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using System.Text.RegularExpressions;

namespace DownloadMusic.Core.Zaycev
{
    class ZaycevParser : IParser<List<MusicInfo>>
    {
        Regex regex;lkl
        public List<MusicInfo> Parse(IHtmlDocument document)
        {
            regex = new Regex(@"длительность([^\t]+)размер([^\t]+)битрейт([^\t]+)Скачать");
            List<MusicInfo> items = new List<MusicInfo>();
            

            var itemsTitle = document.QuerySelectorAll("li.result__li a.light-link");
            var itemsRecord = document.QuerySelectorAll("li.result__li div.result__snp"); 
            string[] itemsLink = document.QuerySelectorAll("li.result__li a.light-link")
                .Select(m => m.GetAttribute("href")).ToArray();

            for (int i = 0, j = 0, k = 0; (i < itemsLink.Count() && j < itemsRecord.Count() &&  k < itemsTitle.Count()); i++, j++, k++)
            {
                items.AddRange(new MusicInfo[] { new MusicInfo()
                {
                    Author = itemsTitle[k].TextContent.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)[0],
                    Song = itemsTitle[k].TextContent.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)[1],
                    Quality = regex.Split(itemsRecord[j].TextContent.Replace("\n", "").Replace(" ", ""))[3],
                    Duration = regex.Split(itemsRecord[j].TextContent.Replace("\n", "").Replace(" ", ""))[1],
                    Size = regex.Split(itemsRecord[j].TextContent.Replace("\n", "").Replace(" ", ""))[2],
                    Page = itemsLink[i] 
                }});
            }
            
            return items;
        }
    }
}