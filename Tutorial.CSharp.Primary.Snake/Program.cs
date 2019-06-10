using System;

namespace Tutorial.CSharp.Primary.Snake {
    class Program {
        const char CH_PANEL = '□';
        const char CH_HEAD = '※';
        const char CH_BODY = '⊙';

        static int rows = 20;
        static int columns = 20;

        static int head_x = 0;
        static int head_y = 1;

        static int[] body_x;
        static int[] body_y;

        static void Main(string[] args) {
            Console.CursorVisible = false;
            DrawPanel();

            for (var key = Console.ReadKey(); key.Key != ConsoleKey.Escape; key = Console.ReadKey()) {
                switch (key.Key) {
                    case ConsoleKey.UpArrow: head_y--; break;
                    case ConsoleKey.DownArrow: head_y++; break;
                    case ConsoleKey.LeftArrow: head_x--; break;
                    case ConsoleKey.RightArrow: head_x++; break;
                    default: break;
                }

                DrawPanel();
            }
        }

        static void DrawPanel() {
            Console.Clear();
            for (var row = 0; row < rows; row++) {
                for (var column = 0; column < columns; column++) {
                    if (row == head_y && column == head_x) {
                        Console.Write(CH_HEAD);
                    } else {
                        Console.Write(CH_PANEL);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
