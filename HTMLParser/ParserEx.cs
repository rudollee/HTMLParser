using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace HTMLParser
{
    public class ParserEx
    {
		/// <summary>
		/// Prevent use of Html tags
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		public string PreventHTML(string article)
		{
			return article.Replace("<", "&lt;").Replace(">", "&gt;");
		}

		/// <summary>
		/// Prevent use of Risky Tags
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		public string PreventRiskyTag(string article)
		{
			return article.Replace("script", "").Replace("iframe", "").Replace("object", "");
		}

		/// <summary>
		/// Parse Url
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		public string ParseUrl(string article)
		{
			if (string.IsNullOrEmpty(article)) return string.Empty;

			string pttrn = @"((?:(?:https?|http|ftp|gopher|telnet|file|notes|ms-help):(?://|\\\\)(?:www\.)?|www\.)[\w\d:#@%/;$()~_?\+,\-=\\.&]+)";
			string lnk = "<a href=\"$1\" target=\"_blank\">$1</a>";

			return Regex.Replace(article, pttrn, lnk, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150)).Replace("href=\"www.", "href=\"http://www.");
		}

		/// <summary>
		/// Parse Youtube Url to script
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		public string ParseYoutube(string article)
		{
			if (string.IsNullOrEmpty(article)) return string.Empty;

			string pttrn = @"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)";
			string script = "<div class=\"youtube\" ><iframe width=\"600\" height=\"338\" src=\"https://www.youtube.com/embed/$1\" frameborder=\"0\" allowfullscreen></iframe></div>";

			return Regex.Replace(article, pttrn, script, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150)).Replace("https://<div class=\"youtube\"", "<div class=\"youtube\"");
		}

		public List<string> GenerateYoutubeScripts(string article)
		{
			if (string.IsNullOrEmpty(article)) return new List<string>(new string[] { "" });

			Regex regex = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");
			Match match = regex.Match(article);
			List<string> scripts = new List<string>();
			while (match.Success)
			{
				scripts.Add(string.Format("<div class=\"youtube\" ><iframe src=\"https://www.youtube.com/embed/{0}\" frameborder=\"0\" allowfullscreen></iframe></div>", match.Value.Replace("youtu.be/", "")));
				match = match.NextMatch();
			}

			return scripts;
		}

		public string ParseUrlAndYoutube(string article)
		{
			return this.GenerateYoutubeScripts(article).FirstOrDefault() ?? "" + this.ParseUrl(article);
		}
	}
}
