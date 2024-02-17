using ImagePrintedTextRecognitionShared;
using ImageRecognitionEngine;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace ImagePrintedTextRecognitionUnitTests
{
    [TestClass]
    public class ImagePrintedTextRecognitionServiceTest
    {
        [TestMethod]
        public async Task WhenValidImageWithWithPrintedTextUploaded_ThenPrintedTextInImageReturnedSuccessfully()
        {
            string CleanPrintedTextInImage(string printedTextInImage) => printedTextInImage
                            .Replace("\r\n", string.Empty)
                            .Replace("t ", string.Empty)
                            .Replace("\n", string.Empty);

            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string imageFilePath = @"C:\Apps\ComputerVisionReceiptScanner\ReceiptComputerVision\ReceiptComputerVision\ReceiptComputerVision\images\printed_text.jpg";

                using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = config["AzureSubscriptionKey"],
                        AzureEndpointURL = config["AzureEndpointURL"],
                        UploadImageFileStream = fileStream,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    string testPrintedTextOutput = @"Nutrition Facts Amount Per Serving
Serving size: 1 bar (40g)
Serving Per Package: 4
Total Fat 13g
Saturated Fat 1.5g
Amount Per Serving
Trans Fat 0g
alories 190
Cholesterol Omg
ories from Fat 110
Sodium 20mg
nt Daily Values are based on
Vitamin A 50%
calorie diet";

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsTrue(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.ErrorMessage));

                    Assert.AreEqual(
                        CleanPrintedTextInImage(testPrintedTextOutput)
                        , CleanPrintedTextInImage(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }

        [TestMethod]
        public async Task WhenImageFileUploadedWithWithNoPrintedText_ThenPrintedTextInImageIsEmpty()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string imageFilePath = @"C:\Users\jtomlinson\OneDrive - Brightree\Pictures\ProfilePic.jpg";

                using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = config["AzureSubscriptionKey"],
                        AzureEndpointURL = config["AzureEndpointURL"],
                        UploadImageFileStream = fileStream,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsFalse(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }

        [TestMethod]
        public async Task WhenNonImageFileUploaded_ThenErrorMessage()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string nonImageFilePath = @"C:\Apps\ComputerVisionReceiptScanner\ReceiptComputerVision\ReceiptComputerVision\ReceiptComputerVision\images\Receipt25thJun01.pdf";

                using (var fileStream = new FileStream(nonImageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = config["AzureSubscriptionKey"],
                        AzureEndpointURL = config["AzureEndpointURL"],
                        UploadImageFileStream = fileStream,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsFalse(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(imageRecognitionOutput.ErrorMessage));
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }

        [TestMethod]
        public async Task WhenNoAzureSubscriptionKey_ThenErrorMessage()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string nonImageFilePath = @"C:\Apps\ComputerVisionReceiptScanner\ReceiptComputerVision\ReceiptComputerVision\ReceiptComputerVision\images\printed_text.jpg";

                using (var fileStream = new FileStream(nonImageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = string.Empty,
                        AzureEndpointURL = config["AzureEndpointURL"],
                        UploadImageFileStream = fileStream,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsFalse(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(imageRecognitionOutput.ErrorMessage));
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }

        [TestMethod]
        public async Task WhenNoAzureEndpointURL_ThenErrorMessage()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string nonImageFilePath = @"C:\Apps\ComputerVisionReceiptScanner\ReceiptComputerVision\ReceiptComputerVision\ReceiptComputerVision\images\printed_text.jpg";

                using (var fileStream = new FileStream(nonImageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = config["AzureSubscriptionKey"],
                        AzureEndpointURL = string.Empty,
                        UploadImageFileStream = fileStream,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsFalse(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(imageRecognitionOutput.ErrorMessage));
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }

        [TestMethod]
        public async Task WhenNoUploadImageFileStream_ThenErrorMessage()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                                           .SetBasePath($"{Directory.GetCurrentDirectory()}/../../..")
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                var config = builder.Build();

                string nonImageFilePath = @"C:\Apps\ComputerVisionReceiptScanner\ReceiptComputerVision\ReceiptComputerVision\ReceiptComputerVision\images\printed_text.jpg";

                using (var fileStream = new FileStream(nonImageFilePath, FileMode.Open, FileAccess.Read))
                {
                    var imageRecognitionInput = new ImageRecognitionInput()
                    {
                        SubscriptionKey = config["AzureSubscriptionKey"],
                        AzureEndpointURL = config["AzureEndpointURL"],
                        UploadImageFileStream = null,
                    };

                    var imagePrintedTextRecognitionService = new ImagePrintedTextRecognitionService();
                    var imageRecognitionOutput = await imagePrintedTextRecognitionService.UploadFileAndConvertToText(imageRecognitionInput);

                    Assert.IsNotNull(imageRecognitionOutput);
                    Assert.IsFalse(imageRecognitionOutput.IsSuccesful);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(imageRecognitionOutput.ErrorMessage));
                    Assert.IsTrue(string.IsNullOrWhiteSpace(imageRecognitionOutput.PrintedTextInImage));
                }
            }
            catch (FileNotFoundException ioEx)
            {

            }
        }
    }
}