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
            Renderer render = new Renderer();

            render.DrawPlayer(player.XCoordinate, player.YCoordinate, player.IconPlayer);
        }

        class Player
        {
            private int _xCoordinate;
            private int _yCoordinate;
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

            public int XCoordinate
            {
                get
                {
                    return _xCoordinate;
                }
                private set
                {
                }
            }

            public int YCoordinate
            {
                get
                {
                    return _yCoordinate;
                }
                private set
                {
                }
            }

            public Player(int xCoordinate, int yCoordinate, char iconPlayer)
            {
                _xCoordinate = xCoordinate;
                _yCoordinate = yCoordinate;
                _iconPlayer = iconPlayer;
            }
        }

        class Renderer
        {
            public void DrawPlayer(int xCoordinate, int yCoordinate, char iconPlayer='@')
            {
                Console.SetCursorPosition(xCoordinate, yCoordinate);
                Console.WriteLine(iconPlayer);
            }
        }
    }
}
