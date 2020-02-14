using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GetCurrentMousePosition
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "GetCurrentMousePosition";

            Console.WriteLine("Tecle Insert para capturar a posição do mouse.");

            while (true)
            {
                var keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Insert)
                {
                    var pos = GetCursorPosition();
                    var text = $"AutoItX.MouseClick(\"LEFT\", {pos.X}, {pos.Y}, 1);";

                    Console.WriteLine(text);
                    TextCopy.Clipboard.SetText(text);
                    Console.WriteLine("Texto copiado para o clipboard");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
    }
}
