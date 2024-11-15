// using Microsoft.Playwright;
// using NUnit.Framework;
// using NUnit.Framework.Internal;
// using PlaywrightFramework.Factories;

// namespace PlaywrightFramework.Tests
// {
//     public class LoginTests
//     {

//         private IPage _page;
//         private IPlaywright _playwright;
//         private IBrowser _browser;
//     //    private object expect;
// //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.



//         [SetUp]
//         public async Task Setup()
//         {
//             _playwright = await Playwright.CreateAsync();
//             _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
//             _page = await _browser.NewPageAsync();
           
//         }

//          [TearDown]
//         public async Task TearDown()
//         {
//             await _page.CloseAsync();
//         }

//         [Test]
//         public async Task ValidLoginTest()
//         {
//           //   const { Test, expect } = require('@playwright/test');
            
//             var pageFactory = new PageFactory(_page);

//             var loginPage = pageFactory.GetLoginPage();

//             await loginPage.GoToAsync();

//             await loginPage.LoginAsync("kavithasub", "Welcome123");

//             var dashboardPage = pageFactory.GetDashboardPage();

//             await dashboardPage.GetWelcomeMessageAsync();

//            // await _page.GotoAsync("https://rta-edu-stg-web-03.azurewebsites.net/core"); // Complete URL here
            
//             // Assuming these selectors are correct for the input fields and button
//             // await _page.FillAsync("#signInName", "kavithasub"); // Replace with actual username

//             // await _page.FillAsync("#password", "Welcome123"); // Replace with actual password

//             // await _page.ClickAsync("#next");

//             // Wait for navigation to the new page after login
//           //  await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/reports/overview");

//             // Wait for the page to load completely
//           //  await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

//             // Check for the presence of inner text "Welcome"
//             // var locator = _page.Locator("body"); // You can adjust the selector as needed
//             // string bodyText = await locator.InnerTextAsync();

//             // if (bodyText.Contains("Welcome"))
//             // {
//             //     Console.WriteLine("The page contains 'Welcome, Roman Dev-db1'.");
//             // }
//             // else
//             // {
//             //     Console.WriteLine("The page does not contain 'Welcome'.");
//             // }

//          //   await _browser.CloseAsync();

//             // Verify successful login
//      //       var welcomeMessage = await _page.InnerTextAsync(" Welcome"); // Replace with actual selector

            

//             //Assert.toBeTruthy(welcomeMessage.Contains("Welcome"), "User is not logged in successfully.");

//             // const softExpect = expect.configure({ soft: true });
//             // await softExpect(locator).toHaveText('Submit');
//         }

//         //  [Test]
//         // public async Task SoftAssertionExample()
//         // {
//         //     await _page.GotoAsync("https://rta-edu-stg-web-03.azurewebsites.net/core");

//         //     var locator = _page.Locator("#signInName");

//         // }

        
//     }
// }