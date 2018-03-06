using System;

namespace LabWork1.Greetings
{
    class Greeting
    {
        private const String Message = "This programm was developed by Nickita Vinokurov \n" +
            "Student of SPBSTI(TU)'s group 465.\n" + 
            "Programm's purpose is counting negative and positive numbers in an array\n" +
            "and calculating average of this numbers.\n" + 
            "The result of the programms's work is displayed in a console." +
            "User can choose different types of filling an array:\n" + 
            "1.Custom Input\n" + "2.Random Input\n" + "3.Input from a file";
        public Greeting()
        {
            Console.WriteLine(Message);
            for(int i = 0;i < 20; i++) { Console.Write("-"); }
            Console.WriteLine();
        }
    }
}
