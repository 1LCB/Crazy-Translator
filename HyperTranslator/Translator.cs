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
                language_dicts.Add("Lao", "lo");
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
