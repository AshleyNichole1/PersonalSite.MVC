using PersonalsiteConverted.Models;//Added for contactAction
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalsiteConverted.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }


        //GET -- This is so people can contact you via your website
        public ActionResult ContactAction()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactAction(ContactAction cam)
        {
            //If NOT valid
            if (!ModelState.IsValid)
            {
                return View(cam);
            }

            string message = $"You have received an email from {cam.Name} with a subject:" +
                $"{cam.Subject}. Please respond to {cam.Email} with your response to the " +
                $"following message: <br/>{cam.Message}";

            MailMessage mm = new MailMessage(

                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                cam.Subject,
                message);

            mm.IsBodyHtml = true;

            mm.Priority = MailPriority.High; //Not sure if I want to keep this

            mm.ReplyToList.Add(cam.Email);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(),
            ConfigurationManager.AppSettings["EmailPass"].ToString());
            client.Port = 8889;

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"Sorry, We are working on Email Functionality. Please try again later.<br/>Error Message:" +
                    $"<br/>{ex.StackTrace}";

                return View(cam);
            }



            return View("EmailConfirmation", cam);
        }
               
    }
}