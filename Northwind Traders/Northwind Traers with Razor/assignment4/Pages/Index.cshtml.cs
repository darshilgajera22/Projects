using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment4.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public int NorthwindServiceYear { get; set; }
    
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    int establishedYear = 1994;
    int currentYear = DateTime.Now.Year;

    public void OnGet()
    {
        NorthwindServiceYear = currentYear - establishedYear;
    }
}
