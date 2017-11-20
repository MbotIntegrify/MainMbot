using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web.Mvc;

namespace WebCamJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //The argument submit holds the value attribute of input button from the view.
        public ActionResult Robot(string submit)
        {
            byte[] sendbuf;

            switch (submit)
            {
                case "Forward":
                    sendbuf = Encoding.ASCII.GetBytes("1");
                    break;
                case "Back":
                    sendbuf = Encoding.ASCII.GetBytes("2");
                    break;
                case "Go Left":
                    sendbuf = Encoding.ASCII.GetBytes("3");
                    break;
                case "Go Right":
                    sendbuf = Encoding.ASCII.GetBytes("4");
                    break;                
                case "Stop":
                    sendbuf = Encoding.ASCII.GetBytes("5");
                    break;
                default:
                    sendbuf = Encoding.ASCII.GetBytes("0");
                    break;
            }

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
              ProtocolType.Udp);        
            
            IPAddress broadcast = IPAddress.Parse("192.168.4.1");                      
            IPEndPoint ep = new IPEndPoint(broadcast, 1025);
            s.SendTo(sendbuf, ep);
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}