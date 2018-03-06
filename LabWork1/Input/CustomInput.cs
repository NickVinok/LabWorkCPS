using System;
using LabWork1.Solution;
using LabWork1.FileWorks;

namespace LabWork1.Input
{
    class CustomInput : IInput
    {
        public void Input()
        {
            FileWork fileWork = new FileWork();
            InputValidation inputValidation = new InputValidation();
            int size = inputValidation.CorrectIntInput("Enter size of an array: ");
            int[] array = new int[size];
            for(int i = 0; i < size; i++)
            {
                array[i] = inputValidation.CorrectIntInput("Enter number: ");
            }

            Algorithms algo = new Algorithms(array);
            algo.Algorithm();

            Console.Write(
                "Number of positive elements - {0}\nNumber of negative elements - {1}\nAverage of all teh elements - {2}\n",
                algo.GetNumberOfPositives(), algo.GetNumberOfNegatives(), algo.GetAverage());

            Confirmation confirmation = new Confirmation();
            if (confirmation.Confirm("Do you want to save the results? Y/N"))
            {
                fileWork.WriteIntoTheFile(algo);
            }
        }

        public CustomInput()
        {
            Input();
        }
    }
}
