using System;
using System.IO;
using LabWork1.Solution;
using LabWork1.FileWorks;

namespace LabWork1.Input
{
    class FileInput : IInput
    {
        public void Input()
        {
            FileWork fileWork = new FileWork();
            String fileName = fileWork.ReadFromFile();
            StreamReader streamReader = new StreamReader(fileName);
            bool fileIsSaved = false;
            int[] array = new int[1];
            while (!fileIsSaved)
            {
                fileIsSaved = true;
                InputValidation inputValidation = new InputValidation();
                string[] tmpArray = streamReader.ReadLine().Split(' ', '\n');
                array = new int[tmpArray.Length];
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    if (!int.TryParse(tmpArray[i], out array[i]))
                    {
                        Console.WriteLine("Error on symbol number" + (i + 1));
                        Console.WriteLine("Fix this file and then try again");
                        fileName = fileWork.ReadFromFile();
                        streamReader = new StreamReader(fileName);
                        fileIsSaved = false;
                        break;
                    }
                }
            }

            Algorithms algo = new Algorithms(array);
            algo.Algorithm();

            algo.printArr();

            Console.Write(
                "Sum of odd numbers - {0}\nSum of even numbers - {1}\n", algo.getOddSum(), algo.getEvenSum());


            streamReader.Close();
            Confirmation confirmation = new Confirmation();     
            if (confirmation.Confirm("Do you want to save the results? Y/N"))
            {
                fileWork.WriteIntoTheFile(algo);
            }
        }

        public FileInput()
        {
            Input();
        }
    }
}
