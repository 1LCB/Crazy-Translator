using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CrazyTranslator
{
    public class GoogleTranslator
    {
        private static Dictionary<string, string> language_dicts;
        public static IEnumerable<string> Languages
        {
            get {
                MakeDictionary();
                return language_dicts.Keys.OrderBy(p => p);
            }
        }
        public static string Translate(string sourceText, string sourceLanguage, string targeLanguage)
        {
            string translation = "";

            try
            {
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targeLanguage}&dt=t&q={HttpUtility.UrlEncode(sourceText)}";

                string outputFile = Path.GetTempFileName();

                using (WebClient wbclient = new WebClient())
                {
                    wbclient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wbclient.DownloadFile(url, outputFile);
                    translation = File.ReadAllText(outputFile);
                    //MessageBox.Show(url);
                    //Process.Start(outputFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return translation;

        }
        public static string GetLanguageCode(string LanguageName)
        {
            MakeDictionary();
            language_dicts.TryGetValue(LanguageName, out string mode);
            return mode;
        }
        private static void MakeDictionary()
        {
            if (language_dicts == null)
            {
                language_dicts = new Dictionary<string, string>();


                //NEW LANGUAGES
                language_dicts.Add("Lingala", "ln");
                language_dicts.Add("Luxembourgish", "lb");
                language_dicts.Add("Maithili", "mai");
                language_dicts.Add("Malagasy", "mg");
                language_dicts.Add("Malayalam", "ml");
                language_dicts.Add("Maori", "mi");
                language_dicts.Add("Marathi", "mr");
                language_dicts.Add("Mizo", "lus");
                language_dicts.Add("Mongolian", "mn");
                language_dicts.Add("Myanmar (Burmese)", "my");
                language_dicts.Add("Nepali", "ne");
                language_dicts.Add("Nyanja (Chichewa)", "ny");
                language_dicts.Add("Odia (Oriya)", "or");
                language_dicts.Add("Oromo", "om");
                language_dicts.Add("Pashto", "ps");
                language_dicts.Add("Punjabi", "pa");
                language_dicts.Add("Quechua", "qu");
                language_dicts.Add("Samoan", "sm");
                //language_dicts.Add("Sanskrit", "sa");
                language_dicts.Add("Shona", "sn");
                language_dicts.Add("Sesotho", "st");
                language_dicts.Add("Sindhi", "sd");
                language_dicts.Add("Tajik", "tg");
                language_dicts.Add("Tigrinya", "ti");
                language_dicts.Add("Tsonga", "ts");
                language_dicts.Add("Turkmen", "tk");
                language_dicts.Add("Twi (Akan)", "ak");
                language_dicts.Add("Somali", "so");
                language_dicts.Add("Kyrgyz", "ky");
                language_dicts.Add("Igbo", "ig");
                language_dicts.Add("Hmong", "hmn");
                language_dicts.Add("Hawaiian", "haw");
                language_dicts.Add("Gujarati", "gu");
                language_dicts.Add("Guarani", "gn");
                language_dicts.Add("Bhojpuri", "bho");
                language_dicts.Add("Bosnian", "	bs");
                language_dicts.Add("Amharic", "am");
                language_dicts.Add("Bambara", "bm");
                language_dicts.Add("Cebuano", "ceb");
                language_dicts.Add("Corsican", "co");
                language_dicts.Add("Dhivehi", "dv");
                language_dicts.Add("Dogri", "doi");
                language_dicts.Add("Ewe", "ee");
                language_dicts.Add("Frisian", "fy");
                language_dicts.Add("Ilocano", "ilo");
                language_dicts.Add("Javanese", "jv");
                language_dicts.Add("Kannada", "kn");
                language_dicts.Add("Kazakh", "kk");
                language_dicts.Add("Kinyarwanda", "rw"); 
                language_dicts.Add("Krio", "kri");
                language_dicts.Add("Zulu", "zu");
                language_dicts.Add("Xhosa", "xh");
                language_dicts.Add("Yoruba", "yo");
                language_dicts.Add("Uyghur", "ug");
                language_dicts.Add("Uzbek", "uz");





















                language_dicts.Add("Afrikaans", "af");
                language_dicts.Add("Albanian", "sq");
                language_dicts.Add("Arabic", "ar");
                language_dicts.Add("Armenian", "hy");
                language_dicts.Add("Azerbaijani", "az");

                language_dicts.Add("Basque", "eu");
                language_dicts.Add("Belarusian", "be");
                language_dicts.Add("Bengali", "bn");
                language_dicts.Add("Bulgarian", "bg");

                language_dicts.Add("Catalan", "ca");
                language_dicts.Add("Chinese", "zh-CN");
                language_dicts.Add("Croatian", "hr");
                language_dicts.Add("Czech", "cs");

                language_dicts.Add("Danish", "da");
                language_dicts.Add("Dutch", "nl");

                language_dicts.Add("English", "en");
                language_dicts.Add("Esperanto", "eo");
                language_dicts.Add("Estonian", "et");

                language_dicts.Add("Filipino", "tl");
                language_dicts.Add("Finnish", "fi");
                language_dicts.Add("French", "fr");

                language_dicts.Add("Galician", "gl");
                language_dicts.Add("German", "de");
                language_dicts.Add("Georgian", "ka");
                language_dicts.Add("Greek", "el");

                language_dicts.Add("Haitian Creole", "ht");
                language_dicts.Add("Hebrew", "iw");
                language_dicts.Add("Hindi", "hi");
                language_dicts.Add("Hungarian", "hu");

                language_dicts.Add("Icelandic", "is");
                language_dicts.Add("Indonesian", "id");
                language_dicts.Add("Irish", "ga");
                language_dicts.Add("Italian", "it");

                language_dicts.Add("Japanese", "ja");

                language_dicts.Add("Korean", "ko");

                language_dicts.Add("Lao", "lo"); //
                language_dicts.Add("Latin", "la");
                language_dicts.Add("Latvian", "lv");
                language_dicts.Add("Lithuanian", "lt");

                language_dicts.Add("Macedonian", "mk");
                language_dicts.Add("Malay", "ms");
                language_dicts.Add("Maltese", "mt");

                language_dicts.Add("Norwegian", "no");

                language_dicts.Add("Persian", "fa");
                language_dicts.Add("Polish", "pl");
                language_dicts.Add("Portuguese", "pt");

                language_dicts.Add("Romanian", "ro");
                language_dicts.Add("Russian", "ru");

                language_dicts.Add("Serbian", "sr");
                language_dicts.Add("Slovak", "sk");
                language_dicts.Add("Slovenian", "sl");
                language_dicts.Add("Spanish", "es");
                language_dicts.Add("Swahili", "sw");
                language_dicts.Add("Swedish", "sv");

                language_dicts.Add("Tamil", "ta");
                language_dicts.Add("Telugu", "te");
                language_dicts.Add("Thai", "th");
                language_dicts.Add("Turkish", "tr");

                language_dicts.Add("Ukrainian", "uk");
                language_dicts.Add("Urdu", "ur");

                language_dicts.Add("Vietnamese", "vi");

                language_dicts.Add("Welsh", "cy");

                language_dicts.Add("Yiddish", "yi");
            }
        }
    }
}
