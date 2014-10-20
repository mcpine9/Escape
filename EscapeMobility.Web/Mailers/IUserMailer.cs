using EscapeMobility.Web.Models;
using Mvc.Mailer;

namespace EscapeMobility.Web.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage SendQuoteEmail(QuoteViewModel vm);
			MvcMailMessage PasswordReset();
	}
}