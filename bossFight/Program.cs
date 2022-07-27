using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int bossHp = 1500;
            int playerHp = 1000;
            int bossDamage;
            string playerInput;
            int playerHealing = 0;
            bool bladeLight = false;
            bool paladinShield = false;
            bool shieldPush = false;


            Console.WriteLine("Вы спускайетсь в темное подземелье Двух Главого Огра");
            Console.WriteLine("Да начнется битва!");

            while ((bossHp > 0) & (playerHp > 0))
            {
                Console.WriteLine("Выберите умение : ");
                Console.WriteLine("1. Обнажить клинок света (+100 к умениям на 1 ход)" +
                    "\n2. Удар света (наносит 200 урона)" +
                    "\n3. Поднять щит паладина (+250хп, неуязвимость и -100 урона на один ход)" +
                    "\n4. Толчок паладина (наносит 150 урона, если щит поднят наносит 250 урона, снижает получаемый урон в 2 раза)");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case "1":
                        bladeLight = true;
                        Console.WriteLine("Вы обнажили клинок света\n");
                        break;
                    
                    case "2":
                        
                        if (bladeLight)
                        {
                            if (paladinShield == true)
                            {
                                bossHp -= 200;
                            }
                            else
                            {
                                bossHp -= 200;
                            }
                        }
                        else if (paladinShield)
                        {
                            bossHp -= 100;
                        }
                        else
                        {
                            bossHp -= 200;
                        }
                        
                        bladeLight = false;
                        paladinShield = false;

                        Console.WriteLine("Удар света!");
                        break;
                    
                    case "3":
                        paladinShield = true;
                        
                        if (bladeLight)
                        {
                            playerHealing += 350;
                        }
                        else
                        {
                            playerHealing += 250;
                        }

                        Console.WriteLine("Вы прикрылись щитом паладина");
                        break;

                    case "4":

                        if (paladinShield)
                        {
                            if (bladeLight)
                            {
                                bossHp -= 350;
                            }
                            else
                            {
                                bossHp -= 250;
                            }

                            shieldPush = true;
                        }
                        else if (bladeLight)
                        {
                            bossHp -= 250;
                        }
                        else
                        {
                            bossHp -= 150;
                        }

                        Console.WriteLine("Толчок щитом");

                        bladeLight = false;
                        paladinShield = false;
                        break;
                }

                bossDamage = random.Next(80, 400);

                if (paladinShield)
                {
                    continue;
                }
                else if (shieldPush)
                {
                    bossDamage /= 2;
                    playerHp -= bossDamage;
                }
                else
                {
                    playerHp -= bossDamage;
                }

                Console.WriteLine($"Огр наносит {bossDamage} урона \n");
                Console.WriteLine($"Паладин {playerHp} жизней\nОгр {bossHp} жизней");
            }

            if (playerHp < 0)
            {
                Console.WriteLine("Вы погибли в этом нелегком бою...");
                Console.WriteLine("GAME OVER");
            }
            else if (bossHp < 0)
            {
                Console.WriteLine("Ура!!! Вы победили!!!!!!");
            }
        }
    }
}
