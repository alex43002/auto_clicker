using System;
using WindowsInput;

namespace mouse_clicker_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mouse Clicker App!");
            Console.WriteLine("Enter X coordinate:");
            int xCoord = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate:");
            int yCoord = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of clicks:");
            int clickCount = int.Parse(Console.ReadLine());

            SimulateMouseClick(xCoord, yCoord, clickCount);

            Console.WriteLine("Mouse clicks simulated successfully!");
        }

        static void SimulateMouseClick(int x, int y, int clickCount)
        {
            var inputSimulator = new InputSimulator();
            inputSimulator.Mouse
                .MoveMouseToPositionOnVirtualDesktop(x, y)
                .LeftButtonClick();

            // If you want to perform multiple clicks
            for (int i = 1; i < clickCount; i++)
            {
                inputSimulator.Mouse
                    .MoveMouseToPositionOnVirtualDesktop(x, y)
                    .LeftButtonClick();
            }
        }
    }
}
