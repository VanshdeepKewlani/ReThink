using PlaywrightFramework.Pages;
using Bogus;
using NUnit.Framework;


namespace PlaywrightFramework.Tests
{
    [TestFixture]
    public class AddTeamMemberTests
    {

        private readonly AddTeamMemberPage _addTeamMemberPage;

        
        // public AddTeamMemberTests()
        // {
        //     // Setup code here (e.g., initializing objects or dependencies)
        // }

        
        public AddTeamMemberTests(AddTeamMemberPage page)
        {
            _addTeamMemberPage = page;
        }

        [Test]
        public async Task Add_Team_Member()
        {
            var confirmPassword = "";

            //Define the CSV file path
            var csvFilePath = GlobalAppSettings.GetCsvFilePath();

            //Generate fake data
            var faker = new Faker();
            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var email = faker.Internet.Email();
            var cellPhone = faker.Phone.PhoneNumber();
            var username = faker.Internet.UserName();
            var password = faker.Internet.Password();
            confirmPassword = password; //Confirm Password should match the password

            //Write the data to CSV file
            using (var writer = new StreamWriter(csvFilePath, true))
            {
                if (new FileInfo(csvFilePath).Length == 0)
                {
                    //Write the header
                    await writer.WriteLineAsync("FirstName,LastName,Email,CellPhone,Username,Password");
                }

                //Write the fake data as a new row
                await writer.WriteLineAsync($"{firstName},{lastName},{email},{cellPhone},{username},{password}");

                await _addTeamMemberPage.AddNewTeamMember(firstName, lastName, email, cellPhone, username, password);
            }
        }
    }
}