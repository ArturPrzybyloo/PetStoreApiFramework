using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PetStoreApiFramework.Utils
{
    public static class TestData
    {
        public static Dictionary<string, string> DynamicVariables = new Dictionary<string, string>();

        // Method for getting files from TestData directory
        public static string GetFile(string fileName, string extentsion = "json")
        {
            var testDataPath = Path.Combine(Directory.GetCurrentDirectory(), "TestData");
            var searchFile = Directory.GetFiles(testDataPath, $"{fileName}.{extentsion}", SearchOption.AllDirectories);

            searchFile.Should().HaveCount(1);

            return searchFile[0];
        }

        // Method for reading json files
        public static T Read<T>(string fileName)
        {
            var replacedFileContent = ReplaceVariables(File.ReadAllText(GetFile(fileName)));
            return JsonConvert.DeserializeObject<T>(replacedFileContent);
        }

        // Method for replacing variables placed in json default files
        public static string ReplaceVariables(string fileContent)
        {
            var variablesToReplace = new Dictionary<string, string>
            {
                {"{{name}}", Faker.Name.First() },
                {"{{username}}", Faker.Internet.UserName() + Faker.Name.First() },
                {"{{lastname}}", Faker.Name.Last() },
                {"{{email}}", Faker.Internet.Email() },
                {"{{phone}}", Faker.Phone.Number() }
            };

            foreach (var variable in variablesToReplace)
            {
                fileContent = fileContent.Replace(variable.Key, variable.Value);
            }

            foreach (var dynamicVariable in DynamicVariables)
            {
                fileContent = fileContent.Replace(dynamicVariable.Key, dynamicVariable.Value);
            }

            return fileContent;
        }
    }
}
