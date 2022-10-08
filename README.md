# DotNet_SendGrid_Example
A simple example of how to integrate with sendgrid

```csharp
var apiKey = config.GetValue<string>("SendGrid:ApiKey");
var client = new SendGridClient(apiKey);
var from = new EmailAddress("no-reply@email.io", "Sender");
var subject = "Sending with SendGrid is Fun";
var to = new EmailAddress("contato@test.com.br", "User");
var plainTextContent = text;
var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
var response = await client.SendEmailAsync(msg);
```
