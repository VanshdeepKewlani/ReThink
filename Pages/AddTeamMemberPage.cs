using Microsoft.Playwright;
using Bogus;

namespace PlaywrightFramework.Pages
{
    public class AddTeamMemberPage
    {
        private readonly IPage _page;

        public AddTeamMemberPage(IPage page) => _page = page;
        private ILocator _firstName => _page.Locator("#firstName");
        private ILocator _lastName => _page.Locator("#lastName");
        private ILocator _email => _page.Locator("#email");
        private ILocator _cellPhone => _page.Locator("#phone");
        private ILocator _userName => _page.Locator("#username");
        private ILocator _password => _page.Locator("#password");
        private ILocator _confirmPassword => _page.Locator("#confirmPassword");
        private ILocator _saveButton => _page.Locator("button");


        public async Task Add_Team_Member()
        {
         //   var confirmPassword = "";

            // Generate fake data
            var faker = new Faker();
            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var email = faker.Internet.Email();
            var cellPhone = faker.Phone.PhoneNumber();
            var username = faker.Internet.UserName();
            var password = "Test!ng123456";
            var confirmPassword = password; // Confirm password should match the password
                                        
            // Write the data to the CSV file
            var users = new List<User>
            {
            new User{FirstName = firstName, LastName = lastName, Email = email, Phone = cellPhone, Username = username, Password = password}
            };


           

            await _firstName.FillAsync(firstName);
            await _lastName.FillAsync(lastName);
            await _email.FillAsync(email);
            await _cellPhone.FillAsync(cellPhone);
            await _userName.FillAsync(username);
            await _password.FillAsync(password);
            await _confirmPassword.FillAsync(confirmPassword);

            // Locate the button by its text
            var savebtn = _page.Locator("button").GetByText(" Save and Close ");
            // Wait for the button to be visible
            await savebtn.WaitForAsync();
            // Click the button
            await savebtn.ClickAsync();

            // Define the CSV file path
            var csvFilePath = "users.csv";

            // Write to CSV
            CsvHelperExample.WriteToCSV(csvFilePath, users);

            // Read from CSV
            var readUsers = CsvHelperExample.ReadFromCSV(csvFilePath);

            // Print read users
            foreach (var user in readUsers)
            {
                System.Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Email: {user.Email}, Phone: {user.Phone}, Username: {user.Username}, Password: {user.Password}");
            }

            // using (var writer = new StreamWriter(csvFilePath, true))
            // {
            //     if (new FileInfo(csvFilePath).Length == 0)
            //     {
            // Write the header
            // await writer.WriteLineAsync("FirstName,LastName,Email,CellPhone,Username,Password");
            // }
            // Write the fake data as a new row
            // await writer.WriteLineAsync($"{firstName},{lastName},{email},{cellPhone},{username},{password}");
            // }
            // }
            // else
            // {
            //     confirmPassword = faker.Internet.Password(); ;
            // }

            // await _addTeamMemberPage.ClickAddTeamMemberButton();

            // Fill the form with fake data


            // await _addTeamMemberPage.FillForm(firstName, lastName, email, cellPhone, username, password, confirmPassword);

            // Click on the Save button
            // await _addTeamMemberPage.ClickSaveButton();

        }





        public async Task AddNewTeamMember(string firstname, string lastname, string email, string phone, string username, string password)
        {
            await _page.FillAsync("#firstName", firstname);
            await _page.FillAsync("#lastName", lastname);
            await _page.FillAsync("#email", email);
            await _page.FillAsync("#phone", phone);
            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.FillAsync("#confirmPassword", password);

            // Locate the button by its text
            var buttonLocator = _page.Locator("button").GetByText(" Save and Close ");
            // Wait for the button to be visible
            await buttonLocator.WaitForAsync();
            // Click the button
            await buttonLocator.ClickAsync();

            // Define the CSV file path
            var csvFilePath = "users.csv";

            var users = new List<User>
            {
                new User{FirstName = firstname, LastName = lastname, Email = email, Phone = phone, Username = username, Password = password}
            };

            // Write to CSV
            CsvHelperExample.WriteToCSV(csvFilePath, users);

            // Optionally wait for navigation or perform other actions
            // Wait for the navigation to complete using LoadState
            // await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}