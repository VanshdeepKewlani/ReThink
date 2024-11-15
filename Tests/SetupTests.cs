using Microsoft.Playwright;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlaywrightFramework.Factories;
using System.Threading.Tasks;

namespace PlaywrightFramework.Tests
{
    public class SetupTests
    {
        private IPage _page;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private int searchCount = 0;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _page.CloseAsync();
        }

        [Test]
        public async Task AddTeamMemberTest()
        {
            var pageFactory = new PageFactory(_page);

            var loginPage = pageFactory.GetLoginPage();

            await loginPage.GoToAsync();

            await loginPage.LoginAsync("kavithasub", "Welcome123");

            // var dashboardPage = pageFactory.GetDashboardPage();

            // await dashboardPage.GetWelcomeMessageAsync();

            var mainMenuPage = pageFactory.GetMainMenuPage();

            await mainMenuPage.navigateToSetup();

            Console.WriteLine("Setup done");

            var accountSetupPage = pageFactory.GetAccountSetupPage();

            await accountSetupPage.ManageTeamMember();

            await accountSetupPage.AddTeamMember();

            var AddTeamMemberPage = pageFactory.GetAddTeamMemberPage();

            await AddTeamMemberPage.Add_Team_Member();

            var searchTeamMemberPage = pageFactory.GetTeamMemberPage();

            await searchTeamMemberPage.SearchingTeamMember();

        }
    
        [Test]
        public async Task EditTeamMemberTest()
        {
            var pageFactory = new PageFactory(_page);
           
            var mainMenuPage = pageFactory.GetMainMenuPage();

            await mainMenuPage.navigateToSetup();

            Console.WriteLine("Setup done");

            var accountSetupPage = pageFactory.GetAccountSetupPage();

            await accountSetupPage.ManageTeamMember();

            // var loginPage = pageFactory.GetLoginPage();

            // await loginPage.GoToAsync();

            // await loginPage.LoginAsync("kavithasub", "Welcome123");

            // var mainMenuPage = pageFactory.GetMainMenuPage();

            // await mainMenuPage.navigateToSetup();

            // Console.WriteLine("Setup done");

            // var accountSetupPage = pageFactory.GetAccountSetupPage();

            // await accountSetupPage.ManageTeamMember();

            var searchTeamMemberPage = pageFactory.GetTeamMemberPage();

            await searchTeamMemberPage.SearchingTeamMember();

            await searchTeamMemberPage.EditTeamMember();

            var editTeamMemberPage = pageFactory.GetEditTeamMemberPage();

            await editTeamMemberPage.VerifyTeamMemberHeading();

            await editTeamMemberPage.Edit_Team_Member();

            string fname = editTeamMemberPage.GetFirstName();

            // await editTeamMemberPage.EditFirstName("VanshdeepW");

            // await editTeamMemberPage.EditEmail("vanshw@test.com");

            // await editTeamMemberPage.EditPhone("9124609789");

            // await editTeamMemberPage.EditUserName("vanshw");

            await editTeamMemberPage.SubmitEditedDetails();

            await searchTeamMemberPage.SearchingTeamMemberAfterEdit(fname);

            await searchTeamMemberPage.GetCountOfSearchResults();

            searchCount = searchTeamMemberPage.CountOfSearchResults();

            Console.WriteLine("Search Result Count before deletion is " + searchCount);

            await searchTeamMemberPage.EditTeamMember();

            await editTeamMemberPage.DeleteMember();

            await searchTeamMemberPage.SearchingTeamMemberAfterDelete(fname);

            await searchTeamMemberPage.GetCountOfSearchResults();

            Console.WriteLine("Search Result Count after deletion is " + searchTeamMemberPage.CountOfSearchResults());

            Console.WriteLine("SearchCount after deletion is " + searchCount);

            Assert.That(searchCount > searchTeamMemberPage.CountOfSearchResults());


        }
    
    }
}