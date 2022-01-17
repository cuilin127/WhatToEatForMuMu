using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WhatToEat.Models;
using System.Net.Mail;
using System.Text;
namespace WhatToEat.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult SubmitFood(string food) {
            SendEmailToUser("cuilin940127@gmail.com", food);
            return Redirect("Result");
        }
        private void SendEmailToUser(string toUser, string content)
        {
            string from = "Amy Cui"; //From address
            MailMessage message = new MailMessage(from, toUser);

            string mailbody = content;
            message.Subject = "About Dinner today";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("whattoeattonightformumu@gmail.com", "cuilin19940127");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
