<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parsed.aspx.cs" Inherits="HTMLParser.Example.Parsed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		body {
			width: 600px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
		source<br />
		<textarea id="txtSource" runat="server" style="width: 100%; min-height: 50px;"></textarea><br />

		url parsed
		<div id="ParsedUrl" runat="server" style="width: 100%; min-height: 50px; margin: 5px; padding: 5px; border: 1px solid #ddd" >&nbsp;</div>

		youtube parsed
		<div id="parsedYoutube" runat="server" style="width: 100%; min-height: 50px; margin: 5px; padding: 5px; border: 1px solid #ddd" >&nbsp;</div>

		url and youtube parsed
		<div id="parsedUrlAndYoutube" runat="server" style="width: 100%; min-height: 50px; margin: 5px; padding: 5px; border: 1px solid #ddd" >&nbsp;</div>

		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Parse" />
    </form>
</body>
</html>
