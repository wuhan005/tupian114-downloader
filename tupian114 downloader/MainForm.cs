using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tupian114_downloader
{
    public partial class MainForm : Form
    {
        private string orginalURL;
        public MainForm()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (textURL.Text == "")
            {
                MessageBox.Show("请输入链接！");
            }
            else
            {
                orginalURL = textURL.Text;
                orginalURL = orginalURL.Substring(orginalURL.IndexOf("_") + 1, (orginalURL.IndexOf(".html") - orginalURL.IndexOf("_")));

                backResult.Text = getDownload("http://www.tupian114.com/download/down?tid=" + orginalURL + "&type=2");
            }
            }

        private String getDownload(string url)
        {
            WebClient webConn = new WebClient();
            webConn.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            webConn.Headers.Add("Host", "www.tupian114.com");
            webConn.Headers.Add("Referer", "http://www.tupian114.com/download/" + orginalURL + ".html");

            Stream data = webConn.OpenRead(url);
            StreamReader reader = new StreamReader(data, Encoding.UTF8);
            string backValue = reader.ReadToEnd();
            data.Close();
            reader.Close();
            backValue = backValue.Replace("\"", "");
            return backValue;

        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://wuhan5.cc/");
        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wuhan005/tupian114-downloader");
        }

        private void backResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(backResult.Text);
        }
    }
}
