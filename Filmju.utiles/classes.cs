using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Filmju.Properties;

namespace Filmju.utiles;

internal class classes
{
	public string PostData(string url, string args)
	{
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			string Reqii = CreateArgs("body", Global.Congigur);
			string font_size = CreateArgs("font_size", Settings.Default.FontSizeS);
			string user_name = CreateArgs("user_name", Global.user_name_config);
			string token = CreateArgs("token", Global.token_config);
			string langueg = CreateArgs("langueg", Global.Langueg_Title_Movies);
			string apname = CreateArgs("apname", "Fj");
			args = args + "&" + Reqii;
			args = args + "&" + font_size;
			args = args + "&" + user_name;
			args = args + "&" + token;
			args = args + "&" + langueg;
			args = args + "&" + apname;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			byte[] data = Encoding.ASCII.GetBytes(args);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;
			using (Stream stream = request.GetRequestStream())
			{
				stream.Write(data, 0, data.Length);
			}
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			return new StreamReader(response.GetResponseStream()).ReadToEnd();
		}
		catch (Exception)
		{
			return "Error";
		}
	}

	public string CreateArgs(string title, string val)
	{
		return title + "=" + Uri.EscapeDataString(val);
	}

	public string GetPage(string url)
	{
		string Res = "";
		try
		{
			using WebClient client = new WebClient();
			Res = client.DownloadString(url);
		}
		catch (Exception)
		{
			Res = "Error";
		}
		return Res;
	}

	public async Task<Image> LoadImageAsync(string url)
	{
		int num = default;
		_ = num;
		_ = 0;
		try
		{
			WebRequest request = WebRequest.Create(url);
			using WebResponse response = await request.GetResponseAsync();
			using Stream stream = response.GetResponseStream();
			return Image.FromStream(stream);
		}
		catch (Exception)
		{
			return Resources.placeholder;
		}
	}
}
