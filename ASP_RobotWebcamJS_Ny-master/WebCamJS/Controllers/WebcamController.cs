using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebCamJS.Controllers
{
    public class WebcamController : Controller
    {

        public byte[] sendbuf;
        // GET: Webcam
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ReloadWebcam()
        {
            return View("Index");
        }

        public ActionResult TestingAction(int? id)
        {
            ViewBag.Key = id.ToString();
            sendbuf = Encoding.ASCII.GetBytes(id.ToString());

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
              ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.4.1");
            IPEndPoint ep = new IPEndPoint(broadcast, 1025);
            s.SendTo(sendbuf, ep);

            return View();
        }
    }
}