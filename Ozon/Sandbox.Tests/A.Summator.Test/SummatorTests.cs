namespace Ozon.Sandbox.Tests.A.Summator.Test;


using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Ozon.Sandbox.A.Summator;

[TestFixture]

public class SummatorTests
{
    private static string TestDataPath = Path.GetFullPath("../../../Data/");

        private static IEnumerable<TestCaseData> GetTestData()
        {
            string[] inputFiles = Directory.EnumerateFiles(TestDataPath)
                .Where(file => !file.EndsWith(".a"))
                .ToArray();
            foreach (string inputFile in inputFiles)
            {
                string expectedFile = Path.GetFileNameWithoutExtension(inputFile) + ".a";
                string testName = Path.GetFileNameWithoutExtension(inputFile);
                yield return new TestCaseData(inputFile, expectedFile).SetName(testName);
            }
        }

        [TestCaseSource(nameof(GetTestData))]
        public void TestSummatorWithFileInput(string inputFile, string expectedFile)
        {
            string inputFilePath = Path.Combine(TestDataPath, inputFile);
            string expectedFilePath = Path.Combine(TestDataPath, expectedFile);

            using (StringReader inputReader = new StringReader(File.ReadAllText(inputFilePath)))
            using (StringReader expectedOutputReader = new StringReader(File.ReadAllText(expectedFilePath)))
            using (StringWriter outputWriter = new StringWriter())
            {
                Console.SetIn(inputReader);
                Console.SetOut(outputWriter);

                Program.Main(new string[0]);

                string expectedOutput = expectedOutputReader.ReadToEnd();
                string actualOutput = outputWriter.ToString();
                expectedOutput = expectedOutput.Replace("\r\n", "\n");
                actualOutput = actualOutput.Replace("\r\n", "\n");
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }


