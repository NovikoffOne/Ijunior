using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workProprties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(3,8, '#');
            Render render = new Render();

            render.DrawPlayer(player.X, player.Y, player.IconPlayer);
        }

        class Player
        {
            private int _x;
            private int _y;
            private char _iconPlayer;

            public char IconPlayer
            {
                get
                {
                    return _iconPlayer;
                }
                private set 
                {}
            }

            public int X
            {
                get
                {
                    return _x;
                }
                private set
                {
                }
            }

            public int Y
            {
                get
                {
                    return _y;
                }
                private set
                {
                }
            }

            public Player(int x, int y, char iconPlayer)
            {
                _x = x;
                _y = y;
                _iconPlayer = iconPlayer;
            }
        }

        class Render
        {
            public void DrawPlayer(int x, int y, char iconPlayer='@')
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(iconPlayer);
            }
        }
    }
}
