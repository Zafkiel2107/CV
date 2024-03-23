using CV.Extensions;
using MailKit.Net.Smtp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.RegisterAuthentification();
app.RegisterSender();
app.RegisterFiles();
app.RegisterLinks();

app.Map("/Download", async (HttpContext httpContext) =>
{
    byte[] fileContent = await File.ReadAllBytesAsync(Files.CV);
    return Results.File(fileContent, "application/rtf", "CV.rtf");
});

app.Map("/Send", async (HttpContext httpContext) =>
{
    try
    {
        var form = httpContext.Request.Form;
        var emailFrom = MailboxAddressExtension.GetFromAddress(form);
        var emailTo = MailboxAddressExtension.GetToAddress();

        using (var emailMessage = MimeMessageExtension.CreateMessageFromForm(form))
        {
            emailMessage.From.Add(emailFrom);
            emailMessage.To.Add(emailTo);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(Authentification.AuthentificationEmail, Authentification.AuthentificationPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        return Results.Ok();
    }
    catch(Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();