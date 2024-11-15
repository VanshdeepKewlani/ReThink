using Microsoft.Playwright;

namespace PlaywrightFramework.Pages
{
    public class MainMenu
    {
        private readonly IPage _page;

        public MainMenu(IPage page) => _page = page;
        //private ILocator lnkSetup => _page.Locator("a[href='/core/setup']");

        public async Task navigateToSetup()
        {
            await _page.ClickAsync("a[href='/core/setup']");

            // Wait for navigation to the new page after setup
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup");

        }
    }
}