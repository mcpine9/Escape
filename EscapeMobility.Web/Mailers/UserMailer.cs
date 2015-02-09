using System.Web.Mail;
using EscapeMobility.Web.Models;
using Mvc.Mailer;

namespace EscapeMobility.Web.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}

        public virtual MvcMailMessage SendQuoteEmail(QuoteViewModel vm)
		{
			//ViewBag.Data = someObject;
            ViewData.Model = vm;
			return Populate(x =>
			{
                x.Subject = "QUOTE REQUEST FROM ESCAPE-MOBILITY-USA.COM";
				x.ViewName = "SendQuoteEmail";
                x.To.Add("burak@escape-mobility.net");
                x.Bcc.Add("mcpine@gmail.com");
			});
		}

        public virtual MvcMailMessage SendContactEmail(ContactFormViewModel vm)
        {
            //ViewBag.Data = someObject;
            ViewData.Model = vm;
            return Populate(x =>
            {
                x.Subject = "CONTACT FORM REQUEST FROM ESCAPE-MOBILITY-USA.COM";
                x.ViewName = "SendContactEmail";
                x.To.Add("burak@escape-mobility.net");
                x.Bcc.Add("mcpine@gmail.com");
            });
        }
 
		public virtual MvcMailMessage PasswordReset()
		{
			//ViewBag.Data = someObject;
			return Populate(x =>
			{
				x.Subject = "PasswordReset";
				x.ViewName = "PasswordReset";
				x.To.Add("some-email@example.com");
			});
		}
 	}
}