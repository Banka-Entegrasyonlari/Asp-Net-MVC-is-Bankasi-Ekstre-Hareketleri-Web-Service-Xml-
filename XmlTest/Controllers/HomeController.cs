using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlTest.Models;
using static System.Net.WebRequestMethods;

namespace XmlTest.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            string uid = "xxxx"; // İş bankası kullanıcı adı
            string pwd = "xxxx"; // İş bankası Şifre

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://posmatik2.isbank.com.tr/Authenticate.aspx");
             request.Method = "POST";
            string postData = (Convert.ToString((Convert.ToString("uid=") + uid) + "&pwd=") + pwd) ;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
           
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response__1 = request.GetResponse();
            dataStream = response__1.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream, Encoding.GetEncoding("ISO-8859-9"));
            string tmp = reader.ReadToEnd();

           

            XDocument doc = XDocument.Parse(tmp);
            List<XElement> xElementList = doc.Descendants().ToList();
            List<Hareket> harekets = new List<Hareket>();

            foreach (XElement element in xElementList.Elements("Hareket"))
            {
                // read the element and do with your node
                if (element.HasElements)
                {
                    if (element.Element("ParaBirimi").Value== "TRY")
                    {
                        harekets.Add(new Hareket
                        {
                            IbanNo = "xxxxx",
                            Tarih = Convert.ToString(element.Element("Tarih").Value),
                            ParaBirimi = Convert.ToString(element.Element("ParaBirimi").Value),
                            HareketSirano = Convert.ToString(element.Element("HareketSirano").Value),
                            Miktar = Convert.ToString(element.Element("Miktar").Value),
                            Bakiye = Convert.ToString(element.Element("Bakiye").Value),
                            Aciklama = Convert.ToString(element.Element("Aciklama").Value),
                            IslemTuru = Convert.ToString(element.Element("IslemTuru").Value),
                            KarsiHesapVKN = Convert.ToString(element.Element("KarsiHesapVKN").Value),
                            LehdarHIban = Convert.ToString(element.Element("LehdarHIban").Value),
                            valor = Convert.ToString(element.Element("valor").Value),
                            timeStamp = Convert.ToString(element.Element("timeStamp").Value),
                            ISL_Saat = Convert.ToString(element.Element("ISL_Saat").Value),
                        });
                    }

                    if (element.Element("ParaBirimi").Value == "USD")
                    {
                        harekets.Add(new Hareket
                        {
                            IbanNo = "xxxxx",
                            Tarih = Convert.ToString(element.Element("Tarih").Value),
                            ParaBirimi = Convert.ToString(element.Element("ParaBirimi").Value),
                            HareketSirano = Convert.ToString(element.Element("HareketSirano").Value),
                            Miktar = Convert.ToString(element.Element("Miktar").Value),
                            Bakiye = Convert.ToString(element.Element("Bakiye").Value),
                            Aciklama = Convert.ToString(element.Element("Aciklama").Value),
                            IslemTuru = Convert.ToString(element.Element("IslemTuru").Value),
                            KarsiHesapVKN = Convert.ToString(element.Element("KarsiHesapVKN").Value),
                            LehdarHIban = Convert.ToString(element.Element("LehdarHIban").Value),
                            valor = Convert.ToString(element.Element("valor").Value),
                            timeStamp = Convert.ToString(element.Element("timeStamp").Value),
                            ISL_Saat = Convert.ToString(element.Element("ISL_Saat").Value),
                        });
                    }
                    if (element.Element("ParaBirimi").Value == "EUR")
                    {
                        harekets.Add(new Hareket
                        {
                            IbanNo = "xxxxx",
                            Tarih = Convert.ToString(element.Element("Tarih").Value),
                            ParaBirimi = Convert.ToString(element.Element("ParaBirimi").Value),
                            HareketSirano = Convert.ToString(element.Element("HareketSirano").Value),
                            Miktar = Convert.ToString(element.Element("Miktar").Value),
                            Bakiye = Convert.ToString(element.Element("Bakiye").Value),
                            Aciklama = Convert.ToString(element.Element("Aciklama").Value),
                            IslemTuru = Convert.ToString(element.Element("IslemTuru").Value),
                            KarsiHesapVKN = Convert.ToString(element.Element("KarsiHesapVKN").Value),
                            LehdarHIban = Convert.ToString(element.Element("LehdarHIban").Value),
                            valor = Convert.ToString(element.Element("valor").Value),
                            timeStamp = Convert.ToString(element.Element("timeStamp").Value),
                            ISL_Saat = Convert.ToString(element.Element("ISL_Saat").Value),
                        });
                    }
                }

            }

       
            return View(harekets);


        }
        

    }
}
