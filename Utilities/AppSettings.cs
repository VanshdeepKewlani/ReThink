using Microsoft.Extensions.Configuration;

namespace PlaywrightFramework
{
    public static class GlobalAppSettings
    {
      
        private static readonly string CsvFilePath;
        public static IConfiguration Configuration { get; private set; }

        public static string _dataFolderPath { get; private set; }

        public static string _filename { get; private set; }

        public static string _foldername { get; private set; }

        static GlobalAppSettings()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;    //path1

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            
            string fileName = Configuration["test data:file_name"];

            // Log values to debug
            Console.WriteLine($"Base Path: {basePath}");
            Console.WriteLine($"File Name: {fileName}");


             // Validate that fileName is not null or empty
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "File name cannot be null or empty.");
            }   

            CsvFilePath = Path.Combine(basePath, fileName);
            
            // var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configuration = builder.Build();

            // _filename = Configuration["test data:file_name"];

            // _foldername = Configuration["test_data:folder_name"];

            // //Get the current directory
            // var currentDirectory = Directory.GetCurrentDirectory();

            // //find the index of the "bin" folder
            // var binIndex = currentDirectory.IndexOf("bin", StringComparison.OrdinalIgnoreCase);

            // //If "bin" is found, take the path before it
            // string rootPath;

            // if (binIndex >= 0)
            // {
            //     rootPath = currentDirectory.Substring(0, binIndex);
            // }
            // else
            // {
            //     rootPath = currentDirectory; //Fallback to current if "bin" not found
            // }


            // // Define the folder path (e.g., "Data" in the project root folder)
            // _dataFolderPath = Path.Combine(rootPath, _foldername);

            // //Create the folder path if it does not exist
            // if (!Directory.Exists(_dataFolderPath))
            // {
            //     Directory.CreateDirectory(_dataFolderPath);
            // }

            // // var csvFilePath = Path.Combine(_dataFolderPath, _filename);
            // string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _filename);

            // using (var stream = new FileStream(csvFilePath, FileMode.Create, FileAccess.Write))
            // {
            //     //This will truncate the file if it exists or create a new one
            // }

        }

        public static string GetBaseUrl()
        {
            return Configuration["UserCredentials:BaseUrl"];
        }

        public static string GetUsername()
        {
            return Configuration["UserCredentials:Username"];
        }

        public static string GetPassword()
        {
            return Configuration["UserCredentials:Password"];
        }

        //Method to get the CSV filepath
        public static string GetCsvFilePath()
        {
            // string basePath = AppDomain.CurrentDomain.BaseDirectory;
            // string _filename = "test_data/TeamMembers.csv";  // This should be fetched from configuration or set appropriately

            // // Log or debug values
            // Console.WriteLine($"Base Path: {basePath}");
            // Console.WriteLine($"File Name: {_filename}");

            // // Ensure neither of the paths are null
            // //if (string.IsNullOrEmpty(_dataFolderPath) || string.IsNullOrEmpty(_filename))
            // if (string.IsNullOrEmpty(basePath) || string.IsNullOrEmpty(_filename))
            // {
            //     throw new InvalidOperationException("Base path or file name is invalid.");
            // }
            //return Path.Combine(_dataFolderPath, _filename);
            return CsvFilePath;
        }
    }
}