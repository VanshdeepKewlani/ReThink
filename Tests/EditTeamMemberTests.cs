using System.Globalization;
using CsvHelper;
using Bogus;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    public class EditTeamMemberTests
    {
        protected SearchTeamMemberPage _searchPage;

        protected EditTeamMemberPage _editPage;

        public EditTeamMemberTests(SearchTeamMemberPage searchPage, EditTeamMemberPage editPage)
        {
            _searchPage = searchPage;
            _editPage = editPage;
        }

        public class SearchData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string CellPhone { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public async Task Edit_Team_Member()
        {
            var filePath = GlobalAppSettings.GetCsvFilePath();
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var SearchDataList = csv.GetRecords<SearchData>().ToList();
            foreach (var searchData in SearchDataList)
            {
                var faker = new Faker();
              //  var cellPhone = faker.Phone.PhoneNumber();
                //await _searchPage.SearchingTeamMember($"{searchData.FirstName}, {searchData.LastName}");
                await _searchPage.EditTeamMember();
                

            }
        }
    }
}
