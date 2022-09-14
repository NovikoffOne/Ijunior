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

            render.Draw(player.XCoordinate, player.YCoordinate, player.Icon);
        }
    }

    class Player
    {
        public char Icon { get; private set; }

        public int XCoordinate { get; private set; }

        public int YCoordinate { get; private set; }

        public Player(int xCoordinate, int yCoordinate, char iconPlayer)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Icon = iconPlayer;
        }
    }

    class Renderer
    {
        public void Draw(int xCoordinate, int yCoordinate, char iconPlayer = '@')
        {
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.WriteLine(iconPlayer);
        }
    }
}
