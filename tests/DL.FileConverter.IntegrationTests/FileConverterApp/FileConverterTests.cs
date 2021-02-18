using DL.FileConverter.Console;
using DL.FileConverter.Console.Configuration;
using DL.FileConverter.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace DL.FileConverter.IntegrationTests.FileConverterApp
{
    public class FileConverterTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;
        private readonly FileConfiguration _config;
        public FileConverterTests()
        {
            _fixture = new TestServerFixture();
            _config = _fixture.Configuration.Value;
        }

        [Fact]
        public void FileConverter_CsvFileTosXmlFile_AppEnds()
        {
            //Arrange
            string name = "Tom",
                address1 = "1 Test Road",
                address2 = "1 Test Street",
                path = $"{_config.OutputDirectory}//File{name}{_config.OutputFileExtension}";
            FileHelper.CreateCsvFile(name, address1, address2, _config.InputDirectory);

            //Act
            GetApp().Run();
            var readFile = FileHelper.XmlFileReader(path);

            //Assert
            Assert.True(File.Exists(path));
            Assert.Contains(name, readFile);
            Assert.Contains(address1, readFile);
            Assert.Contains(address2, readFile);
            ClearFiles();
        }

        [Fact]
        public void FileConverter_NoFiles_AppEnds()
        {
            //Arrange
            string inputPath = $"{_config.InputDirectory}",
                outputPath = $"{_config.OutputDirectory}";

            //Act
            GetApp().Run();

            //Assert
            Assert.Empty(Directory.GetFiles(inputPath));
            Assert.Empty(Directory.GetFiles(outputPath));
            ClearFiles();
        }

        private void ClearFiles()
        {
            var filePaths = new string[] { _config.InputDirectory, _config.OutputDirectory };
            foreach(var path in filePaths)
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path).ToList();
                    files.ForEach(x => File.Delete(x));
                }         
            }
        }

        private App GetApp()
        {
            return new App(_fixture.Configuration, _fixture.GetFilesUseCase, 
                _fixture.ConvertFileUseCase, _fixture.MockConsoleWriter.Object);
        }
    }
}
