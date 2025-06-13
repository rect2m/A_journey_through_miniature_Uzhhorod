using System.Net;
using System.Net.Mail;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model
{
    public static class EmailHelper
    {
        public static void SendVerificationCode(string toEmail, string verificationCode, string actionTitle, string contextText)
        {
            string fromEmail = "YOUR_ADDRESS";
            string password = "YOUR_PASSWORD";

            string subject = "🔐 Код підтвердження";
            string body = $@"
    <div style='font-family: Arial, sans-serif; padding: 20px; background-color: #f4f4f4;'>
        <div style='max-width: 500px; margin: auto; background: white; padding: 20px; border-radius: 10px; box-shadow: 0px 0px 10px rgba(0,0,0,0.1);'>
            <h2 style='color: #c78c54; text-align: center;'>🔐 {actionTitle}</h2>
            <p style='font-size: 16px; color: #333;'>Вітаємо!</p>
            <p style='font-size: 16px; color: #333;'>{contextText}</p>
            <p style='font-size: 18px; font-weight: bold; text-align: center; color: #c78c54;'>
                Ваш код підтвердження:
            </p>
            <div style='font-size: 24px; font-weight: bold; text-align: center; padding: 10px; background-color: #c78c54; color: white; border-radius: 5px;'>
                {verificationCode}
            </div>
            <p style='font-size: 14px; color: #666; text-align: center; margin-top: 20px;'>Цей код дійсний протягом 10 хвилин.</p>
            <p style='font-size: 14px; color: #999; text-align: center;'>Якщо ви не надсилали запит на {actionTitle.ToLower()}, просто проігноруйте цей лист.</p>
        </div>
    </div>
";

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(toEmail);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true
            };

            smtp.Send(mail);
        }
    }
}
