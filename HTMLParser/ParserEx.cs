using System;
using System.Text.RegularExpressions;

namespace HTMLParser
{
    public class ParserEx
    {
		public string ParseUrl(string article)
		{
			if (string.IsNullOrEmpty(article)) return string.Empty;

			string Pttrn = @"(((http|https|ftp|telnet|news)://|www\.)[^youtube][a-z0-9-]+.[][a-zA-Z0-9:&#@=_~%;?/.+-]+)";
			string Lnk = "<a href=\"$1\" target=\"_blank\">$1</a>";

			return Regex.Replace(article, Pttrn, Lnk, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150)).Replace("href=\"www.", "href=\"http://www.");
		}

		public string ParseYoutube(string article)
		{
			if (string.IsNullOrEmpty(article)) return string.Empty;

			string pttrn = @"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)";
			string script = "<div class=\"youtube\" ><iframe width=\"600\" height=\"338\" src=\"https://www.youtube.com/embed/$1\" frameborder=\"0\" allowfullscreen></iframe></div>";

			return Regex.Replace(article, pttrn, script, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150)).Replace("https://<div class=\"youtube\"", "<div class=\"youtube\"");
		}

		public string ParseUrlAndYoutube(string article)
		{
			return this.ParseYoutube(this.ParseUrl(article));
		}
	}
}
