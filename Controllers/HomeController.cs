using Microsoft.AspNetCore.Mvc;
using smtp_1.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace smtp_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(Email model)
        {
            try
            {

                MailMessage em = new MailMessage();
                em.To.Add(model.To);
                MailAddress addr = new MailAddress(model.Emails);
                em.From = addr;
                em.Subject = model.Subject;
                em.Body = model.Body;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                NetworkCredential credential = new NetworkCredential(model.Emails, model.Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;
                smtp.Send(em);
                ViewBag.Message = "Email sent";

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();

          

        }

    }

}
    
