using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalculatorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public CalculatorModel? Calculator { get; set; }
        [BindProperty]
        public char Operation { get; set; }
        [BindProperty]
        public List<SelectListItem> Operations { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            List<OperationModel> operationModels = new() {
                new OperationModel() { Name = "сложение", Symbol = '+' },
                new OperationModel() { Name = "вычитание", Symbol = '-' }
                };
            Operations = operationModels.Select(x => new SelectListItem { Text = x.Name, Value = x.Symbol.ToString() }).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            if (Calculator == null)
            {
               return RedirectToPage("./Index");
            }
            return RedirectToPage("./Result", new CalculatorModel() { 
                Operation = Operation,
                Value1 = Calculator.Value1,
                Value2 = Calculator.Value2
            });
        }
    }
}