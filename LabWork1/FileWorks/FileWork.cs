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
            bool fileIsSaved = false;
            StreamWriter streamWriter;
            InputValidation inputValidation = new InputValidation();
            while (!fileIsSaved)
            {
                fileIsSaved = true;
                Console.WriteLine("Enter the name of file");
                Console.WriteLine("You need to point the extension of the file");
                while (true)
                {
                    fileName = Console.ReadLine();
                    bool isReserved = false;
                    foreach (String name in ReservedFileNames)
                    {
                        if (fileName.Contains("//" + name) || fileName.Substring(0, 4).Equals(name) || fileName.Substring(0, 5).Equals(name))
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
                        fileIsSaved = false;
                        Console.WriteLine("Choose another file");
                        continue;
                    }
                }
                else
                {
                    fileStream = new FileStream(fileName, FileMode.Create);
                }

                streamWriter = new StreamWriter(fileStream);
                if (saveArrayToFile)
                {
                    for (int i = 0; i < algo.GetArray().Length; i++)
                    {
                        streamWriter.Write(algo.GetArray()[i]);
                        if(i != algo.GetArray().Length - 1)
                        {
                            streamWriter.Write(' ');
                        }
                    }
                }
                streamWriter.WriteLine();

                streamWriter.Write("Odd array: ");
                for (int i = 0; i < algo.GetOddArray().Length; i++)
                {
                    streamWriter.Write(algo.GetOddArray()[i] + " ");
                }
                streamWriter.WriteLine();
                streamWriter.Write("Even array: ");
                for (int i = 0; i < algo.GetEvenArray().Length; i++)
                {
                    streamWriter.Write(algo.GetEvenArray()[i] + " ");
                }
                streamWriter.WriteLine();


                streamWriter.Close();
                fileStream.Close();
            }
        }
    }
}
