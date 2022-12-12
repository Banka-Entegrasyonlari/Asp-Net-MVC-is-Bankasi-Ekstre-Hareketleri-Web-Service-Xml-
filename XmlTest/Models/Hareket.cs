using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XmlTest.Models
{
    public class Hareket
    {
        public string IbanNo { get; set; }
        public string ParaBirimi { get; set; }
        public string Tarih { get; set; }
        public string HareketSirano { get; set; }
        public string Miktar { get; set; }
        public string Bakiye { get; set; }
        public string Aciklama { get; set; }
        public string IslemTuru { get; set; }
        public string KarsiHesapVKN { get; set; }
        public string LehdarHIban { get; set; }
        public string valor { get; set; }
        public string timeStamp { get; set; }
        public string ISL_Saat { get; set; }
    }
}