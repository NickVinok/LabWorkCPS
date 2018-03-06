﻿using System;
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
            InputValidation inputValidation = new InputValidation();
            string[] tmpArray = streamReader.ReadLine().Split(' ', '\n');
            int[] array = new int[tmpArray.Length];
            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (!int.TryParse(tmpArray[i], out array[i]))
                {
                    Console.WriteLine("Error on symbol number" + (i + 1));
                }
            }

            Algorithms algo = new Algorithms(array);
            algo.Algorithm();

            Console.Write(
                "Number of positive elements - {0}\nNumber of negative elements - {1}\nAverage of all teh elements - {2}\n",
                algo.GetNumberOfPositives(),algo.GetNumberOfNegatives(),algo.GetAverage());

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