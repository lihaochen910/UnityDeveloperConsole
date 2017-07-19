using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DeveloperConsole
{
    static class ServerUtil
    {
        public static string Get(string url, Dictionary<string, string> dic)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(builder.ToString());
            //添加参数  
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                //获取内容  
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }
        public static string Post(string url, string postData)
        {
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] postArray = Encoding.Default.GetBytes(postData);

            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            byte[] responseArray = null;

            try
            {
                //UploadData implicitly sets HTTP POST as the request method.
                responseArray = myWebClient.UploadData(url, postArray);
            }
            catch (WebException e)
            {
                ConsoleLog.LogWarrning("使用Post请求时出现错误:");
                ConsoleLog.LogWarrning("响应状态:" + e.Status);
                ConsoleLog.LogWarrning(e.Message);
            }

            //Dispose WebClient
            myWebClient.Dispose();

            if (responseArray != null)
                return Encoding.UTF8.GetString(responseArray);
            else return "error";
        }
    }
}
