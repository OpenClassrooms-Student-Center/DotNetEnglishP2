using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Components
{
    public class LanguageSelectorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ILanguageService languageService)
        {
            return View(languageService);
        }
    }
}
