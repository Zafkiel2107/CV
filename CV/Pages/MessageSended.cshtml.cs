using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV.Pages
{
    public class MessageSendedModel : PageModel
    {
        private readonly ILogger<MessageSendedModel> _logger;

        public MessageSendedModel(ILogger<MessageSendedModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
