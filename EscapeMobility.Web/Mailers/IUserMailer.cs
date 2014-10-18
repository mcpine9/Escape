using Mvc.Mailer;

namespace EscapeMobility.Web.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage PasswordReset();
	}
}