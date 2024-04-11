using System;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace mouse_clicker_app
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        struct POINT
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mouse Clicker App!");

            // Capture cursor position when the user clicks down
            Console.WriteLine("Click down anywhere on the screen to select the location.");

            POINT cursorPosition;
            while (!GetCursorPos(out cursorPosition))
            {
                // Wait for the user to click down
                System.Threading.Thread.Sleep(100);
            }

            // Extract cursor position and normalize to current screen
            int xCoord = cursorPosition.X * UInt16.MaxValue / Screen.PrimaryScreen.Bounds.Width;
            int yCoord = cursorPosition.Y * UInt16.MaxValue / Screen.PrimaryScreen.Bounds.Height;

            Console.WriteLine($"Selected location: X = {xCoord}, Y = {yCoord}");

            // Get number of clicks
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
                    Console.WriteLine("Input :" + input);
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
