﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace typing
{
    /// <summary>
    /// ResultPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultPage : Page
    {
        string date;
        public ResultPage()
        {
            date = DateTime.Now.ToString();
            InitializeComponent();
            show();
        }
        private void Go_home(object sender, RoutedEventArgs e)
        {
            var tpage = new HomePage();
            NavigationService.Navigate(tpage);
        }
        private void copyr_text(object sender, RoutedEventArgs e)
        {
            string resdic = "`～～～～～～～～～～～～`\n" + "[" + date + "]\n" + sdic_to_string(calcr(get(),1),":","\n") + "`～～～～～～～～～～～～`";
            Clipboard.SetData(DataFormats.Text, resdic);
        }
        public Dictionary<string,string> calcr(Dictionary<string, string> dic,int _case=0)
        {

            int allcnt = int.Parse(dic["allcnt"]);
            int typecnt = int.Parse(dic["typecnt"]);
            int miscnt = int.Parse(dic["miscnt"]);
            double time = double.Parse(dic["time"]);

            Dictionary<string, string> resdic = new Dictionary<string, string>();

            if (_case == 0)
            {
                resdic = new Dictionary<string, string>()
                {
                    {"allcnt",dic["allcnt"]},
                    {"typecnt",dic["typecnt"]},
                    {"miscnt",dic["miscnt"]},
                    {"time",cutnumber(double.Parse(dic["time"]),1000).ToString()},
                    {"speed",cutnumber(((typecnt-miscnt)/time),1000).ToString()},
                    {"rerate",cutnumber((((double)(typecnt-miscnt)/(double)(typecnt))*100),1000).ToString()},
                };
            }
            else if (_case == 1) {
                resdic = new Dictionary<string, string>()
                {
                    {"速さ　　　　",cutnumber(((typecnt-miscnt)/time),1000).ToString()+"/s"},
                    {"正解率　　　",cutnumber((((double)(typecnt-miscnt)/(double)(typecnt))*100),1000).ToString()+"%"},
                    {"合計時間　　",cutnumber(double.Parse(dic["time"]),1000).ToString()+"s"},
                    {"問題数　　　",dic["allcnt"]},
                    {"タイプ数　　",dic["typecnt"]},
                    {"ミスタイプ数",dic["miscnt"]},
                };
            }
            return resdic;
        }
        public void show()
        {
            Dictionary<string, string> resdic = calcr(get());

            allcntv.Text = resdic["allcnt"];
            typecntv.Text = resdic["typecnt"];
            miscntv.Text = resdic["miscnt"];
            timev.Text = resdic["time"];
            speedv.Text = resdic["speed"];
            raratev.Text = resdic["rerate"];
        }
        public string sdic_to_string(Dictionary<string, string> dic,string j1 = ":",string j2 = ";")
        {
            string rt = "";
            string[] dickeys = new string[dic.Count];
            dic.Keys.CopyTo(dickeys, 0);
            foreach (string key in dickeys)
            {
                rt += key + j1 + dic[key] + j2;
            }
            return rt;
        }
        public Dictionary<string,string> get()
        {
            string strdata = ((string)Application.Current.Properties["Result"]);

            Dictionary<string,string> dic = new Dictionary<string, string>()
            {
                {"allcnt","0"},
                {"typecnt","0"},
                {"miscnt","0"},
                {"time","0"},
            };
            string[] sstrdata = strdata.Split(';');
            foreach (string s in sstrdata)
            {
                string[] ss = s.Split(':');
                if (ss.Length > 1)
                {
                    dic[ss[0]] = ss[1];
                }
            }
            return dic;
        }
        private double cutnumber(double num, int len)
        {
            return ((double)((int)(num*len))/len);
        }
    }
}
