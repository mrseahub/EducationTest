using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Education.Models
{
    public class NewsSingleModel
    {
        [JsonProperty("DateTime")]
        public DateTime Date { get; set; }

        public int Id { get; set; }
        public string MainImagePath { get; set; }
        public string PreviewPath { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }

        [JsonConstructor]
        public NewsSingleModel(string Text)
        {
            GetText(Text);
            GetShortText(Text);
        }

        void GetText(string text)
        {
            Text = Regex.Replace(text, @"<.*?emoji.*?alt=""(.*?)"".*?/>", "$1");
        }

        void GetShortText(string text)
        {
            ShortText = Regex.Replace(text, @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", string.Empty);
            ShortText = Regex.Replace(ShortText, @"&\w+;", string.Empty);
            ShortText = Regex.Replace(ShortText, @"\p{Cs}", string.Empty);
        }
    }
}
