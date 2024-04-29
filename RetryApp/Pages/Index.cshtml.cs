using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RetryApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public string Data { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientfactory)
        {
            _logger = logger;
            _clientFactory = clientfactory;
        }

        public void OnGet()
        {
            var client = _clientFactory.CreateClient("api");
            Data = client.GetStringAsync("https://localhost:7138/weatherforecast").Result;

        }
    }
}
