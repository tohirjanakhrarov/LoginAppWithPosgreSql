using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace LoginAppWithPosgreSql
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       
        public Window1()
        {
            InitializeComponent();
        }

        
        private void get_button_Click(object sender, RoutedEventArgs e)
        {
            string urlfortest = "http://api.openweathermap.org/data/2.5/weather?q=Tashkent&appid=07bdeab56b19a65145aa3def82f1253c";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlfortest);
            request.Method = "Post";
            request.ContentType = "application/json";
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Add("Authorization", "Basic SUIjdW5pY29uMTAxODpBYTEyMzQ1Njo2ODI2");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string newresponse;
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {   
                newresponse = streamReader.ReadToEnd();

            }

            newtextbox.Text = newresponse;


            request.Method = "Post";
            request.ContentType  = "application/json";
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Add("Authorization", "Basic SUIjdW5pY29uMTAxODpBYTEyMzQ1Njo2ODI2");

            /*request.Headers.Add("Content-Type", "application/json");*/

           

            
        }
    }
}
