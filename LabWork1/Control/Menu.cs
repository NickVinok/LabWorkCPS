using System;
using LabWork1.Input;

namespace LabWork1.Control
{
    class Menu
    {
        private enum MenuItems { CustomInput = 1, RandomInput, FileInput, Exit}
        private static String MenuItemMessage = "1.Filling the array with numbers from keyboard\n" + 
                    "2.Filling the array with random numbers\n" +
                "3.Filling the array from file\n" + 
            "4.Finish work with programm";

        private void ShowMenu()
        {
            Console.WriteLine(MenuItemMessage);
        }

        private int GetMenuItem()
        {
            InputValidation inputValidation = new InputValidation();
            int item = inputValidation.CorrectIntInput("Enter number of the menu item:",
                (int)MenuItems.CustomInput, (int)MenuItems.Exit);
            return item;
        }

        public Menu()
        {
            bool stopExecution = false;
            while (!stopExecution)
            {
                MenuItems item;
                ShowMenu();
                item = (MenuItems)GetMenuItem();
                IInput input;
                switch (item)
                {
                    case MenuItems.CustomInput:
                        input = new CustomInput();
                        break;
                    case MenuItems.RandomInput:
                        input = new RandomInput();
                        break;
                    case MenuItems.FileInput:
                        input = new FileInput();
                        break;
                    case MenuItems.Exit:
                        stopExecution = true;
                        break;
                }
            }
        }
    }
}
