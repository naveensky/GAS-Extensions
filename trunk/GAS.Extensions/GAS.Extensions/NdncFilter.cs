using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GAS {
    public class NdncFilter {
        private string checkUrl = @"http://ndncregistry.gov.in/ndncregistry/saveSearchSub.misc";
        private string resultRegex = @"(<td.*>)<b>(.*)</b>(</td>)";


        public bool CheckIfNumberDnc(string phoneNumber) {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentException("Invalid phone number", "phoneNumber");


            WebRequest request = WebRequest.Create(checkUrl);
            request.Method = "POST";

            string postData = string.Format("phoneno={0}", phoneNumber);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            if (dataStream != null) dataStream.Close();
            response.Close();

            Match matches = Regex.Match(responseFromServer, resultRegex, RegexOptions.IgnoreCase);
            if (matches.Success) {
                string matchValue = matches.Groups[0].Value;
                return !matchValue.ToLower().Contains("not");
            }

            throw new FormatException("No Matching string found");
        }
    }
}