using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightFramework.Pages
{
    public class SearchTeamMemberPage
    {
        private readonly IPage _page;
        private static int searchCount = 0;
        public SearchTeamMemberPage(IPage page) => _page = page;
        private ILocator _searchInput => _page.Locator("input.k-input-inner");
        private ILocator _editLinks => _page.Locator("a:has-text('Edit')");
        private ILocator _numberOfRows => _page.Locator("table tr");

        public async Task SearchingTeamMember()
        {
            // Define the CSV file path
            var csvFilePath = "users.csv";

            // Read from CSV
            var readUsers = CsvHelperExample.ReadFromCSV(csvFilePath);

            string name = "";
            // Print read users
            foreach (var user in readUsers)
            {
                name = user.FirstName;
                Console.WriteLine($"FirstName: {name}");
                break;
            }

            await _searchInput.FillAsync(name);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task SearchingTeamMemberAfterEdit(string fname)
        {
            await _searchInput.FillAsync(fname);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            // Wait for the table to have two rows, one for header and one for body
            await _page.WaitForFunctionAsync("() => document.querySelector('table') && document.querySelector('table').rows.length === 2");

        }

        public async Task SearchingTeamMemberAfterDelete(string fname)
        {
            await _searchInput.FillAsync(fname);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            // Wait for the table to have two rows, one for header and one for body
            try
            {
                await _page.WaitForFunctionAsync("() => document.querySelector('table') && document.querySelector('table').rows.length === 1");
            }
            catch (System.TimeoutException e)
            {
                Assert.Fail("The team member " + fname + " is not deleted after performing delete operation");
            }
        }

        public async Task EditTeamMember()
        {
            var firstEditLink = _editLinks.First;
            // Optionally wait for the link to be visible
            await firstEditLink.WaitForAsync();
            // Click the first "Edit" link
            await firstEditLink.ClickAsync();

        }

        public async Task GetCountOfSearchResults()
        {
            //searchCount = await _numberOfRows.CountAsync();
            await _page.WaitForSelectorAsync("table tr");
            searchCount = await _page.Locator("table tr").CountAsync();

            Console.WriteLine("Search count in GetCountOfSearchResults function is " + searchCount);
        }

        public int CountOfSearchResults()
        {
            Console.WriteLine("Search count in CountOfSearchResults function is " + searchCount);
            return searchCount;
        }
    }
}