/*
    Author: Jacob Slomp
    Website: www.slomp.ca


*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace word_regonizer
{
    static class php
    {
        static public string rawurlencode(string text)
        {
            text = text.Replace(" ", "%20");
            text = text.Replace("\n", "%0A");
            text = text.Replace("\t", "%09");
            text = text.Replace("\r", "%0D");
            text = text.Replace("'", "%27");
            text = text.Replace("\"", "%22");
            text = text.Replace("&", "%26");
            text = text.Replace("=", "%3D");
            text = text.Replace("\\", "%5C");
            text = text.Replace("\\", "%5C");

            return text;
        }

        static public string substr(string Text, int Offset, int Lenght=0)
        {
            int TotalChars = Text.Length;

            if (Offset < 0)
            {
                Offset = Text.Length - Offset;
            }

            TotalChars = Offset + Lenght;



            return Text.Substring(Offset, TotalChars);
        }
        static public List<string> explode(string Seperator, string Text)
        {
            string[] res = Text.Split(new string[] { Seperator }, StringSplitOptions.None);

            return new List<string>(res);
        }

        static public string file_get_contents(string file_or_url)
        {
            if (php.substr(file_or_url, 0, 7) == "http://" || php.substr(file_or_url, 0, 8) == "https://")
            {
                WebClient client = new WebClient();
                return client.DownloadString(file_or_url);
            }
            else
            {
                return File.ReadAllText(file_or_url);
            }

        }
        static public Boolean file_exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
