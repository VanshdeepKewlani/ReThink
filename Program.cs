// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightFramework.Pages;
using PlaywrightFramework.Tests;
using NUnitLite;
using Microsoft.Extensions.Configuration;

namespace PlaywrightFramework
{
    public static class Program
    {
        // public static IConfiguration Configuration { get; set; }

        // static Program()
        // {
        //     //Setup configuration
        //     Configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //     .Build();
        // }
        // public static int Main(string[] args)
        public static int Main(string[] args)
        {
            // Run the tests programmatically with NUnitLite
           return new AutoRun().Execute(args);
       }




    //     // Initialize Playwright
    //     using var playwright = await Playwright.CreateAsync();

    //     var users = new List<User>
    //     {
    //         new User{FirstName = "Vanshdeep58", LastName = "Kewlani", Email = "test58@test.com", Phone = "9010257263", Username = "vansh58", Password = "Password1!"},
    //         new User{FirstName = "Vanshdeep59", LastName = "Kewlani", Email = "test59@test.com", Phone = "9010357263", Username = "vansh59", Password = "Password1!"}
    //     };

    //     // Define the CSV file path
    //     var csvFilePath = "users.csv";

    //     // Write to CSV
    //     CsvHelperExample.WriteToCSV(csvFilePath, users);

    //     // Read from CSV
    //     var readUsers = CsvHelperExample.ReadFromCSV(csvFilePath);

    //     // Print read users
    //     foreach (var user in readUsers)
    //     {
    //         System.Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Email: {user.Email}, Phone: {user.Phone}, Username: {user.Username}, Password: {user.Password}");
    //     }

    //     // Launch a new browser (Headless mode)
    //     var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

    //     // Create a new page
    //     var page = await browser.NewPageAsync();

    //     // var LoginTests = new LoginTests();

    //     // await LoginTests.Setup();

    //     // await LoginTests.ValidLoginTest();

    //     var SetupTests = new SetupTests();

    //     await SetupTests.Setup();

    //     await SetupTests.AddTeamMemberTest();

    //  //   var addTeamMemberPage = new AddTeamMemberPage(page);

    //     //var addTeamMemberTests = new AddTeamMemberTests(addTeamMemberPage);

    //     //await addTeamMemberPage.Add_Team_Member();

    //     await SetupTests.EditTeamMemberTest();

        // }

    }
}

