using Filmju.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Filmju.utiles;

internal class classes
{
	public string PostData(string url, string args)
	{
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            args += "&" + CreateArgs("body", Global.Congigur);
            args += "&" + CreateArgs("font_size", Settings.Default.FontSizeS);
            args += "&" + CreateArgs("user_name", Global.user_name_config);
            args += "&" + CreateArgs("token", Global.token_config);
            args += "&" + CreateArgs("langueg", Global.Langueg_Title_Movies);
            args += "&" + CreateArgs("apname", "Fj");

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
            using StreamReader reader = new StreamReader(response.GetResponseStream());

            return reader.ReadToEnd();
        }
		catch (Exception)
		{
			return "Error";
		}
	}

	public string CreateArgs(string title, string value)
	{
        return $"{title}={Uri.EscapeDataString(value)}";
    }

    public string GetPage(string url)
    {
        try
        {
            using WebClient client = new WebClient();
            return client.DownloadString(url);
        }
        catch (Exception)
        {
            return "Error";
        }
    }

    public async Task<Image> LoadImageAsync(string url)
	{
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
