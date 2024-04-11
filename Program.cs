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
            int.TryParse(Console.ReadLine(), out int xCoord);

            Console.WriteLine("Enter Y coordinate:");
            int.TryParse(Console.ReadLine(), out int yCoord);

            Console.WriteLine("Enter number of clicks:");
            int.TryParse(Console.ReadLine(), out int clickCount);

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
