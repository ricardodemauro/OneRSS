using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OneRSS.ClientConsoleApp
{
    class Program
    {
        static string CaminhoGravacao
        {
            get
            {
                return Path.Combine(ConfigurationManager.AppSettings["caminhoSample"], "sample.xml");
            }
        }
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.CreateHttp(@"http://www.microsoft.com/feeds/msdn/fr-fr/vcsharp/rss.xml");
            var response = request.GetResponse();
            Stream streamResponse = response.GetResponseStream();
            StreamReader reader = new StreamReader(streamResponse);
            //StreamWriter writer = new StreamWriter(CaminhoGravacao);



            //while (reader.Peek() > -1)
            //{
            //    string linha = reader.ReadLine();
            //    Console.WriteLine(linha);
            //    writer.WriteLine(linha);
            //}
            //writer.Close();
            //writer.Dispose();
            XmlReader xmlReader = XmlReader.Create(reader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            Console.WriteLine("Url {0}", feed.BaseUri.ToString());
            foreach (var item in feed.Items)
            {
                Console.WriteLine("Id {0} Title {1}", item.Id, item.Title);
            }
            Console.ReadKey();
        }
    }
}
