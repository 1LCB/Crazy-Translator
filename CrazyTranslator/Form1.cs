using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CrazyTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> Languages_list = new List<string>();
        Random r = new Random();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/1LCB");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Languages_list = GoogleTranslator.Languages.ToList();

            sourceLanguage.Items.AddRange(GoogleTranslator.Languages.ToArray());
            targetLanguage.Items.AddRange(GoogleTranslator.Languages.ToArray());

            sourceLanguage.SelectedItem = "English";
            targetLanguage.SelectedItem = "English";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceText.Text) || times.Value == 1)
                return;

            var sourceCode = GoogleTranslator.GetLanguageCode(sourceLanguage.SelectedItem.ToString());
            var targetCode = GoogleTranslator.GetLanguageCode(targetLanguage.SelectedItem.ToString());

            if (chkBoth.Checked)
                targetCode = GoogleTranslator.GetLanguageCode(sourceLanguage.SelectedItem.ToString());
            

            translatedText.Text = "Translating...";

            progressBar1.Maximum = (int)times.Value;
            progressBar1.Value = 0;

            sourceText.Text = sourceText.Text.Trim().Replace(".", string.Empty);

            var translated_text = GoogleTranslator.Translate(sourceText.Text, sourceCode, targetCode);

            var formated_text = Refinar(translated_text); //get the translation

            string stored_code = targetCode;
            for (int i = 0; i < times.Value; i++)
            {
                Random rand = new Random();
                string random_code = GoogleTranslator.GetLanguageCode(Languages_list[rand.Next(0, Languages_list.Count)]);

                if (random_code == stored_code)
                {
                    if (i == 0)
                        continue;

                    i -= 1;
                    continue;
                } //

                var translated_text2 = GoogleTranslator.Translate(formated_text, stored_code, random_code);
                formated_text = Refinar(translated_text2).Trim();

                if (formated_text.Length < (sourceText.Text.Length / 2) / 2)
                {
                    translated_text2 = GoogleTranslator.Translate(sourceText.Text, sourceCode, targetCode);
                    formated_text = Refinar(translated_text2).Trim();

                    if (i == 0 || progressBar1.Value == 0) 
                        continue;

                    i -= 1;
                    progressBar1.Value -= 1;
                    continue;
                }

                stored_code = random_code;

                progressBar1.Value += 1;
                Thread.Sleep(rand.Next(230, 300));
            }
            var text = GoogleTranslator.Translate(formated_text, stored_code, targetCode);
            string final_text = Refinar(text);

            translatedText.Text = final_text;
            progressBar1.Value = progressBar1.Maximum;
        }

        string Refinar(string translated_text)
        {
            return translated_text
                .Replace("\",\"", "$")
                .Split('$')[0]
                .Substring(4)
                .Replace(".", string.Empty)
                .Replace("?", string.Empty)
                .Replace("!", string.Empty);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string newSourceLanguage = targetLanguage.SelectedItem.ToString();
            string newTargetLanguage = sourceLanguage.SelectedItem.ToString();

            string newSourceText = translatedText.Text;
            string newTargetText = sourceText.Text;

            targetLanguage.SelectedItem = newTargetLanguage;
            sourceLanguage.SelectedItem = newSourceLanguage;

            translatedText.Text = newTargetText;
            sourceText.Text = newSourceText;
        }

        private void chkBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoth.Checked)
            {
                targetLanguage.Enabled = false;
                return;
            }
            targetLanguage.Enabled = true;
        }
    }
}
