/*
    Author: Jacob Slomp
    Website: www.slomp.ca
    Free to use

    and help write functions to make it better

*/



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


// make sure to change the name space to your project.
namespace word_regonizer
{
    static class php
    {


        static private string rawurlcoderHelper(string Text, int type)
        {
            // add more characters.
            Dictionary<string, string> safeChars = new Dictionary<string, string>();

            if (type == 1)
            {
                safeChars.Add("%", "%25");
            }

            safeChars.Add("#", "%23");
            safeChars.Add("$", "%24");
            safeChars.Add("(", "%28");
            safeChars.Add(")", "%29");
            safeChars.Add("$", "%24");
            safeChars.Add(" ", "%20");
            safeChars.Add("\n", "%0A");
            safeChars.Add("\t", "%09");
            safeChars.Add("\r", "%0D");
            safeChars.Add("'", "%27");
            safeChars.Add("\"", "%22");
            safeChars.Add("&", "%26");
            safeChars.Add("=", "%3D");
            safeChars.Add("\\", "%5C");

            if (type == 2)
            {
                safeChars.Add("%", "%25");
            }

            foreach (KeyValuePair<string, string> entry in safeChars)
            {
                Text = Text.Replace(type == 1 ? entry.Key : entry.Value, type == 2 ? entry.Key : entry.Value);
            }
            return Text;
        }


        static public string rawurlencode(string text)
        {
            return rawurlcoderHelper(text, 1);
        }

        static public string rawurldecode(string text)
        {
            return rawurlcoderHelper(text, 2);
        }

        static public string substr(string Text, int Offset, int Lenght=0)
        {
            int TotalChars = Text.Length;

            if (Offset < 0)
            {
                Offset = Text.Length - Offset;
            }

            TotalChars = Offset + Lenght;

            if(TotalChars > Text.Length)
            {
                TotalChars = Text.Length;
            }

            return Text.Substring(Offset, TotalChars);
        }
        static public List<string> explode(string Seperator, string Text)
        {
            string[] res = Text.Split(new string[] { Seperator }, StringSplitOptions.None);

            return new List<string>(res);
        }

        static public string implode(string glue, List<string> Pieces)
        {
            return String.Join(glue, Pieces.ToArray());
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

        
        static private string htmlEncoderHelper(string Text, int type)
        {
            // add more characters.
            Dictionary<string, string> safeChars = new Dictionary<string, string>();
            if (type == 1)
            {
                safeChars.Add("&", "&amp;");
            }
            safeChars.Add("<", "&lt;");
            safeChars.Add(">", "&gt;");
            safeChars.Add("\"", "&quot;");

            if (type == 2)
            {
                safeChars.Add("&", "&amp;");
            }

            foreach (KeyValuePair<string, string> entry in safeChars)
            {
                    Text = Text.Replace(type == 1 ? entry.Key : entry.Value, type == 2 ? entry.Key : entry.Value);
            }
            return Text;
        }

        static public string htmlentities(string Text)
        {
            return php.htmlEncoderHelper(Text, 1);
        }

        static public string html_entity_decode(string Text)
        {
            return php.htmlEncoderHelper(Text, 2); ;
        }


        public static string md5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


    }
}
