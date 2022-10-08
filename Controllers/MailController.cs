using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace DotNet_SendGrid_Example.Controllers;
[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly ILogger<MailController> _logger;

    public MailController(ILogger<MailController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(string email, string text, [FromServices] IConfiguration config)
    {
        var apiKey = config.GetValue<string>("SendGrid:ApiKey");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@email.io", "Sender");
        var subject = "Sending with SendGrid is Fun";
        var to = new EmailAddress("contato@test.com.br", "User");
        var plainTextContent = text;
        var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
        return Ok(response);
    }
}
