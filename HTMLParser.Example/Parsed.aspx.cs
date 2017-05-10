using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HTMLParser;
using System.Text.RegularExpressions;

namespace HTMLParser.Example
{
	public partial class Parsed : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			ParserEx parse = new ParserEx();

			this.ParsedUrl.InnerHtml = parse.ParseUrl(this.txtSource.Value);
			this.parsedYoutube.InnerHtml = parse.GenerateYoutubeScripts(this.txtSource.Value).FirstOrDefault() ?? "";
			this.parsedUrlAndYoutube.InnerHtml = parse.ParseUrlAndYoutube(this.txtSource.Value);
		}
	}
}