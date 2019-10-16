using Practica3_4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Practica3_4
{
    public class TipoCambioService
    {

        public static HttpWebRequest CreateSOAPWebRequestCambioDia()
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://www.banguat.gob.gt/variables/ws/TipoCambio.asmx");
            //SOAPAction    
            Req.Headers.Add(@"SOAPAction:http://www.banguat.gob.gt/variables/ws/TipoCambioDia");
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }
        public static CambioDia InvokeServiceCambioDia()
        {
            CambioDia resultado;
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequestCambioDia();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <TipoCambioDia xmlns=""http://www.banguat.gob.gt/variables/ws/"" />
                  </soap:Body>
                </soap:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    

            string xml = "";
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console    
                    xml += ServiceResult;

                    //Console.ReadLine();
                }
            }

            XDocument doc = XDocument.Parse(xml);

            var VarDolar = doc.Descendants().Where(x => x.Name.LocalName == "VarDolar").Select(y => new {
                fecha = (string)y.Elements().Where(z => z.Name.LocalName == "fecha").FirstOrDefault(),
                cambio = (string)y.Elements().Where(z => z.Name.LocalName == "referencia").FirstOrDefault()
            }).ToList();

            VarDolar.ElementAt(0);

            System.Diagnostics.Debug.WriteLine(xml);
            resultado = new CambioDia(VarDolar.ElementAt(0).fecha, Convert.ToDouble(VarDolar.ElementAt(0).cambio));
            System.Diagnostics.Debug.WriteLine(VarDolar.ElementAt(0).fecha);
            System.Diagnostics.Debug.WriteLine(VarDolar.ElementAt(0).cambio);
            return resultado;
        }

        public static HttpWebRequest CreateSOAPWebRequestCambioFecha()
        {
            //Making Web Request    
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://www.banguat.gob.gt/variables/ws/TipoCambio.asmx");
            //SOAPAction    
            Req.Headers.Add(@"SOAPAction:http://www.banguat.gob.gt/variables/ws/TipoCambioFechaInicial");
            //Content_type    
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method    
            Req.Method = "POST";
            //return HttpWebRequest    
            return Req;
        }
        public static CambioFechaInicial InvokeServiceCambioFecha(string fecha)
        {
            string fecha_ini = fecha;
            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = CreateSOAPWebRequestCambioFecha();

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            SOAPReqBody.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <TipoCambioFechaInicial xmlns=""http://www.banguat.gob.gt/variables/ws/"">
                    <fechainit >"+ fecha_ini +@"</fechainit >
                    </TipoCambioFechaInicial >
                  </soap:Body>
                </soap:Envelope>");


            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }
            //Geting response from request    

            string xml = "";
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    var ServiceResult = rd.ReadToEnd();
                    //writting stream result on console    
                    xml += ServiceResult;

                    //Console.ReadLine();
                }
            }
            System.Diagnostics.Debug.WriteLine(xml);

            XDocument doc = XDocument.Parse(xml);

            var Vars = doc.Descendants().Where(x => x.Name.LocalName == "Var").Select(y => new {

                fecha = (string)y.Elements().Where(a => a.Name.LocalName == "fecha").FirstOrDefault(),
                venta = (string)y.Elements().Where(a => a.Name.LocalName == "venta").FirstOrDefault(),
                compra = (string)y.Elements().Where(a => a.Name.LocalName == "compra").FirstOrDefault(),

            }).ToList();

            var totalitem = doc.Descendants().Where(x => x.Name.LocalName == "TipoCambioFechaInicialResult").Select(y => new {

                TotalItems = (string)y.Elements().Where(a => a.Name.LocalName == "TotalItems").FirstOrDefault(),

            }).ToList();

            CambioFechaInicial fechas = new CambioFechaInicial(Convert.ToInt32(totalitem.ElementAt(0).TotalItems));

            foreach (var variables in Vars)
            {
                System.Diagnostics.Debug.WriteLine("fecha: "+variables.fecha+" venta " +variables.venta+ " compra " +variables.compra);
                fechas.addVar(variables.fecha, Convert.ToDouble(variables.venta) , Convert.ToDouble(variables.compra));

            }

            return fechas;


            

        }




    }
}