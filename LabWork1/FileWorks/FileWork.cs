using System;
using System.IO;
using LabWork1.Solution;
using LabWork1.Input;

namespace LabWork1.FileWorks
{
    class FileWork : IFileWork
    {
        private string[] ReservedFileNames = { "con.", "nul.", "prn.", "aux.", "com1.", "com2.", "com3.", 
                     "com4.", "com5.", "com6.", "com7.", "com8.", "com9.", "lpt1.", "lpt2.", "lpt3.",
                        "lpt4.", "lpt5.", "lpt6.","lpt7.", "lpt8.", "lpt9."};

        public String ReadFromFile()
        {
            String fileName;
            Console.Write("Enter the name of file: ");
            while (true)
            {
                fileName = Console.ReadLine();
                if (!File.Exists(fileName))
                {
                    Console.Write("File wasn't found, try again: ");
                }
                else
                {
                    return fileName;
                }
            }
        }

        public void WriteIntoTheFile(Algorithms algo)
        {
            String fileName;
            FileStream fileStream;
            Confirmation confirmation = new Confirmation();
            bool saveArrayToFile = confirmation.Confirm("Do you want to additionally save the array to file? Y/N");
            StreamWriter streamWriter;
            InputValidation inputValidation = new InputValidation();

            Console.WriteLine("Enter the name of file");
            Console.WriteLine("You need to point the extension of the file");
            while (true)
            {
                fileName = Console.ReadLine();
                if (!fileName.Contains(".txt"))
                {
                    fileName += ".txt";
                }
                bool isReserved = false;
                foreach(String name in ReservedFileNames)
                {
                    if (fileName.Contains("//" + name) || fileName.Substring(0,4).Equals(name) || fileName.Substring(0, 5).Equals(name))
                    {
                        Console.WriteLine("You can't save file, with prohibitted or reserved names, like " + name);
                        Console.Write("Try again: ");
                        isReserved = true;
                        break;
                    }
                }
                if (!isReserved) { break; }
            }

            if (File.Exists(fileName))
            {      
                if (confirmation.Confirm("Do you want to rewrite the file? Y/N"))
                {
                    fileStream = new FileStream(fileName, FileMode.Open);
                }
                else
                {
                    fileStream = new FileStream(fileName, FileMode.Append);
                }
            }
            else if(fileName.StartsWith("C:\\") || fileName.StartsWith( "J:\\"))
            {
                fileStream = new FileStream(fileName, FileMode.Create);
            }
            else
            {
                fileName = "J:\\" + fileName;
                fileStream = new FileStream(fileName, FileMode.Create);
            }

            streamWriter = new StreamWriter(fileStream);
            if (saveArrayToFile)
            {
                for (int i = 0; i < algo.GetArray().Length; i++)
                {
                    streamWriter.Write(algo.GetArray()[i] + " ");
                }
            }

            streamWriter.WriteLine("\nNumber of positive numbers: " + algo.GetNumberOfPositives());
            streamWriter.WriteLine("Number of negative numbers: " + algo.GetNumberOfNegatives());
            streamWriter.WriteLine("Average of all array numbers: " + algo.GetAverage());
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
