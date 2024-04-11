using System;
using WindowsInput;

namespace mouse_clicker_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mouse Clicker App!");

            // Get input from the user
            int xCoord = GetUserInput("Enter X coordinate:");
            int yCoord = GetUserInput("Enter Y coordinate:");
            int clickCount = GetUserInput("Enter number of clicks:");

            // Simulate mouse clicks
            SimulateMouseClick(xCoord, yCoord, clickCount);

            Console.WriteLine("Mouse clicks simulated successfully!");
        }

        // Method to get user input
        static int GetUserInput(string prompt)
        {
            int input;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        // Method to simulate mouse clicks
        static void SimulateMouseClick(int x, int y, int clickCount)
        {
            var inputSimulator = new InputSimulator();
            for (int i = 0; i < clickCount; i++)
            {
                inputSimulator.Mouse
                    .MoveMouseToPositionOnVirtualDesktop(x, y)
                    .LeftButtonClick();

                // Add a small delay between clicks
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
