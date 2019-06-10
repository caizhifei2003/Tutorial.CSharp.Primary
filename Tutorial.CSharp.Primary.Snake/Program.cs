using System;

namespace Tutorial.CSharp.Primary.Snake {
    class Program {
        const char CH_PANEL = '□';
        const char CH_HEAD = '※';
        const char CH_BODY = '⊙';
        const char CH_BEAN = '⊙';

        const ConsoleColor COLOR_PANEL = ConsoleColor.White;
        const ConsoleColor COLOR_HEAD = ConsoleColor.Blue;
        const ConsoleColor COLOR_BODY = ConsoleColor.Yellow;
        const ConsoleColor COLOR_BEAN = ConsoleColor.Red;

        static int rows = 20;
        static int columns = 20;

        static int head_x = 0;
        static int head_y = 0;

        static int[] body_x;
        static int[] body_y;

        static int? bean_x = null;
        static int? bean_y = null;

        static void Main(string[] args) {
            Console.CursorVisible = false;
            GenBean();
            Draw();

            for (var key = Console.ReadKey(); key.Key != ConsoleKey.Escape; key = Console.ReadKey()) {
                switch (key.Key) {
                    case ConsoleKey.UpArrow: head_y--; break;
                    case ConsoleKey.DownArrow: head_y++; break;
                    case ConsoleKey.LeftArrow: head_x--; break;
                    case ConsoleKey.RightArrow: head_x++; break;
                    default: break;
                }

                Draw();
            }
        }

        static void GenBean() {
            var rand = new Random();
            bean_x = rand.Next(columns);
            bean_y = rand.Next(rows);
        }

        static void DrawHead() {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = COLOR_HEAD;
            Console.Write(CH_HEAD);
            Console.ForegroundColor = old;
        }

        static void DrawBody() {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = COLOR_BODY;
            Console.Write(CH_BODY);
            Console.ForegroundColor = old;
        }

        static void DrawPanel() {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = COLOR_PANEL;
            Console.Write(CH_PANEL);
            Console.ForegroundColor = old;
        }

        static void DrawBean() {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = COLOR_BEAN;
            Console.Write(CH_BEAN);
            Console.ForegroundColor = old;
        }

        static void Draw() {
            Console.Clear();
            for (var y = 0; y < rows; y++) {
                for (var x = 0; x < columns; x++) {
                    if (y == head_y && x == head_x) {
                        DrawHead();
                    } else if (body_x != null && body_y != null) {
                        for (var i = 0; i < body_x.Length; i++) {
                            if (body_x[i] == x && body_y[i] == y) {
                                DrawBody();
                            }
                        }
                    } else if (bean_x != null
                        && bean_x.Value == x
                        && bean_y != null
                        && bean_y.Value == y) {
                        DrawBean();
                    } else {
                        DrawPanel();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
