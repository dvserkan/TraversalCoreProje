using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.IO.Packaging;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
            //Install-Package MailKit
            //Install - Package MimeKit

            MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "serkancakirr28@gmail.com");

			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = mailRequest.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = mailRequest.Subject;


			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("serkancakirr28@gmail.com", "x");
			client.Send(mimeMessage);
			client.Disconnect(true);
			return View();
		}
	}
}
