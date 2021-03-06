/*
    Author: Jacob Slomp
    Website: www.slomp.ca
    Free to use

    and help write functions to make it better

*/


// because php works always with scalable arrays we use List<string> instead of string[]
// so explode() will return a list
// end( input will be list or string[] )
// usage:
// List<string> myArray = php.explode(" ","this is a text");
// Console.WriteLine( php.end(myArray) ); // will return text
// just like PHP




using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;




namespace PHPFunctions
{
    static class php
    {

        static public string str_repeat(string sText, int times)
        {
            string output = "";
            for(int i=0; i < times; i++)
            {
                output += sText;
            }
            return output;

        }
        static public string print_r(Dictionary<string,string> aArray, Boolean returnOutput = false, int tabs =0)
        {
            string echo = "Dictionary<string,string>\n(";
            foreach (KeyValuePair<string,string> valpair in aArray)
            {
                echo += "\t"+ str_repeat("\t", tabs)+ "[" + valpair.Key + "] => "+valpair.Value+"\n";
            }
            echo += ")";
            if(returnOutput == false)
            {
                Console.WriteLine(echo);
                echo = "";
            }
            return echo;
        }
        static public string print_r(Dictionary<string, Dictionary<string,string>> aArray, Boolean returnOutput = false)
        {
            string echo = "Dictionary<string,string>\n(";
            foreach (KeyValuePair<string, Dictionary<string,string>> valpair in aArray)
            {
                echo += "\t[" + valpair.Key + "] =>  Dictionary<string,string>\n\t ( \n";
                echo += print_r(valpair.Value, true,1);
                echo += "\t)\n";

            }
            echo += ")\n";
            if (returnOutput == false)
            {
                Console.WriteLine(echo);
                echo = "";
            }
            return echo;
        }
        static public string print_r(List<string> aArray, Boolean returnOutput = false)
        {
            string echo = "List<string>\n(";
            int i = 0;
            foreach (string val in aArray)
            {
                echo += "\t[" + i.ToString() + "] => " + aArray[i] + "\n";
                i++;
            }
            echo += ")";
            if (returnOutput == false)
            {
                Console.WriteLine(echo);
                echo = "";
            }
            return echo;
        }

        static public string print_r(KeyValuePair<string,string> aArray, Boolean returnOutput = false)
        {
            string echo = "KeyValuePair<string,string>\n(";
            echo += "\t[" + aArray.Key + "] => " + aArray.Value + "\n";
            echo += ")\n";
            if (returnOutput == false)
            {
                Console.WriteLine(echo);
                echo = "";
            }
            return echo;
        }

        static public string print_r(string[] aArray, Boolean returnOutput = false)
        {
            return print_r(aArray.ToList(), returnOutput);
        }

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

        static public DateTime strtotime(string date)
        {

            // todo:
            // Accept these formats:
            /*
             * echo strtotime("now"), "\n";
            echo strtotime("10 September 2000"), "\n";
            echo strtotime("+1 day"), "\n";
            echo strtotime("+1 week"), "\n";
            echo strtotime("+1 week 2 days 4 hours 2 seconds"), "\n";
            echo strtotime("next Thursday"), "\n";
            echo strtotime("last Monday"), "\n";
            ?>
            */


            if(date.ToLower() == "now")
            {
                return DateTime.Now;
            }


            // format: year-mm-dd 00:00:00
            // format: year-mm-dd 00:00:00

            if (date.Contains("-"))
            {
                List<string> the_date = explode(" ", date);
                List<string> datestamp = explode("-", the_date[0]);

                int year = Int32.Parse(datestamp[0]);
                int month = Int32.Parse(datestamp[1]);
                int day = Int32.Parse(datestamp[2]);

                int hour = 0;
                int minute = 0;
                int second = 0;
                if (date.Contains(":"))
                {
                    List<string> timestamp = explode(":", the_date[1]);
                    hour = Int32.Parse(timestamp[0]);
                    minute = Int32.Parse(timestamp[1]);
                    second = Int32.Parse(timestamp[2]);
                }


                return new DateTime(year, month, day, hour, minute, second);

            }

            // format: mm/day/year hh:mm:ss am
            // format: mm/day/year hh:mm:ss pm

            if (date.Contains("/")) { 
                List<string> the_date = explode(" ", date);
                List<string> datestamp = explode("/", the_date[0]);

                int year = Int32.Parse(datestamp[2]);
                int month = Int32.Parse(datestamp[0]);
                int day = Int32.Parse(datestamp[1]);


                int hour = 0;
                int minute = 0;
                int second = 0;
                if (date.Contains(":")) { 
                    List<string> timestamp = explode(":", the_date[1]);
                    hour = Int32.Parse(timestamp[0]);
                    if (date.ToLower().EndsWith(" pm"))
                    {
                        if (the_date[2].ToLower() == "pm")
                        {
                            hour += 12;
                        }

                    }
                    minute = Int32.Parse(timestamp[1]);
                    second = Int32.Parse(timestamp[2]);
                }
                return new DateTime(1970, 1, 1, 0, 0, 0);

            }

            return DateTime.Now;
        }
        static public string addslashes(string text)
        {
            text = text.Replace("\"", "\\\"");
            return text;
        }
        static public List<string> scandir(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            string[] files = Directory.GetFiles(dir);
            List<string> res = new List<string>();

            // we all hate this dont we?
            // enable if you like it...
            // res.Add("."); 
            // res.Add(".."); 

            foreach (string d in dirs)
            {
                res.Add(php.end(php.explode("\\", d)));
            }
            foreach (string f in files)
            {
                res.Add(php.end(php.explode("\\", f)));
            }

            return res;

        }
        static public Boolean is_dir(string dirName)
        {
            return Directory.Exists(dirName);
        }
        static public Boolean is_file(string fileName)
        {
            return File.Exists(fileName);
        }

        static public string base64_encode(string originalString)
        {
            var bytes = Encoding.UTF8.GetBytes(originalString);

            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
            }
            static public string base64_decode(string encodedString)
            {
            string decodedString = "";
            try
            {
                var bytes = Convert.FromBase64String(encodedString);
                decodedString = Encoding.UTF8.GetString(bytes);
            }catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return decodedString;
        }


        static public string rawurlencode(string text)
        {
            return rawurlcoderHelper(text, 1);
        }

        static public string rawurldecode(string text)
        {
            return rawurlcoderHelper(text, 2);
        }

        static public string substr(string Text, int Offset, int Lenght = 0)
        {
            int TotalChars = Lenght;

            if (Offset < 0)
            {
                Offset = Text.Length + Offset;
            }

            if (TotalChars + Offset > Text.Length)
            {
                TotalChars = Text.Length - Offset;
            }

            return Text.Substring(Offset, TotalChars);
        }

        static public int count(List<int> l)
        {
            return l.Count;
        }
        static public int count(Dictionary<string,string> l)
        {
            return l.Count;
        }
        static public int count(string[] arr)
        {
            return arr.Length;
        }
        static public int count(List<string> l)
        {
            return l.Count;
        }

        static public List<string> explode(string Seperator, string Text)
        {
            return Text.Split(new string[] { Seperator }, StringSplitOptions.None).ToList();
        }

        static public string implode(string glue, List<string> Pieces)
        {
            return String.Join(glue, Pieces.ToArray());
        }
        static public string implode(string glue, string[] Pieces)
        {
            return String.Join(glue, Pieces);
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
        static public void file_put_contents(string file_name, string content = "")
        {
            File.WriteAllText(file_name, content);
        }
        static public Boolean file_exists(string fileName)
        {
            return File.Exists(fileName);
        }


        static private string htmlEncoderHelper(string Text, int type)
        {
            if(Text == null)
            {
                return "";
            }
        // add more characters.
            Dictionary<string, string> safeChars = new Dictionary<string, string>();
            if (type == 1)
            {
                safeChars.Add("&", "&amp;");
            }
            safeChars.Add("'", "&#039;");
            safeChars.Add("<", "&lt;");
            safeChars.Add(">", "&gt;");
            safeChars.Add("??", "&reg;");
            safeChars.Add("??", "&copy;");
            safeChars.Add("???", "&trade;");
            safeChars.Add("???", "&bull;");
            safeChars.Add("??", "&frac14;");
            safeChars.Add("??", "&frac12;");
            safeChars.Add("\"", "&quot;");

            if (type == 2)
            {
                //
                safeChars.Add(" ", "&nbsp;");

                safeChars.Add("&", "&amp;");
            }

            foreach (KeyValuePair<string, string> entry in safeChars)
            {
                Text = Text.Replace(type == 1 ? entry.Key : entry.Value, type == 2 ? entry.Key : entry.Value);
                if (type == 2)
                {
                    // uppercase has to be replaced too.
                    Text = Text.Replace(entry.Value.ToUpper(), entry.Key);
                }
            }
            return Text;
        }
        static public string end(List<string> aArray)
        {
            return aArray[aArray.Count - 1];
        }
        static public string end(string[] aArray)
        {
            return aArray[aArray.Length - 1];
        }
        static public string trim(string sText, char[] chars = null)
        {
            if (sText == null)
            {
                return "";
            }
          
            if(chars == null)
            {
                return sText.Trim();
            }
            return sText.Trim(chars);
        }

        static public string htmlentities(string Text)
        {
            return php.htmlEncoderHelper(Text, 1);
        }

        static public string html_entity_decode(string Text)
        {
            return php.htmlEncoderHelper(Text, 2); 
        }

        static public string str_replace(string text, string oldStr, string newStr)
        {
            text = text.Replace(oldStr, newStr);
            return text;
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
