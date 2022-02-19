using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Administrador_SAR.Services
{
    public class ReportService
    {
        private string _urlBasic = "https://recuentosar.azurewebsites.net/api/v1/";



        public async Task<byte[]> getReport(int id)
        {
            byte[] b;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(_urlBasic + $"Reports/createpdf?id={id}");
            WebResponse myResp = myReq.GetResponse();

            Stream stream = myResp.GetResponseStream();
            using (BinaryReader br = new BinaryReader(stream))
            {
                b = br.ReadBytes(int.Parse(myResp.ContentLength.ToString()));
                br.Close();
            }
            myResp.Close();
            return b;
        }
    }


    
}