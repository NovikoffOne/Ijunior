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
            int bossDamage;
            int minBossDamage = 80;
            int maxBossDamage = 400;
            string playerInput;
            int playerHp = 1000;
            int playerHealing = 250;
            int playerBaseDamage = 200;
            bool bladeLight = false;
            bool paladinShield = false;
            bool shieldPush = false;
            int moreBladeLightDamage = 100;
            int moreShieldDamage = 100;
            int paladnaPushArrmorBaf = 2;

            Console.WriteLine("Вы спускайетсь в темное подземелье Двух Главого Огра");
            Console.WriteLine("Да начнется битва!");

            while ((bossHp > 0) & (playerHp > 0))
            {
                Console.WriteLine("Выберите умение : ");
                Console.WriteLine($"1. Обнажить клинок света (+{moreBladeLightDamage} к умениям на 1 ход)" +
                    $"\n2. Удар света (наносит {playerBaseDamage} урона)" +
                    $"\n3. Поднять щит паладина (+{playerHealing}хп, неуязвимость и -{moreShieldDamage} урона на один ход)" +
                    $"\n4. Толчок паладина (наносит {playerBaseDamage} урона, если щит поднят наносит {playerBaseDamage + moreShieldDamage} урона, снижает получаемый урон в 2 раза)");
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
                                bossHp -= playerBaseDamage + moreBladeLightDamage - moreShieldDamage;
                            }
                            else
                            {
                                bossHp -= playerBaseDamage + moreShieldDamage;
                            }
                        }
                        else if (paladinShield)
                        {
                            bossHp -= playerBaseDamage - moreShieldDamage;
                        }
                        else
                        {
                            bossHp -= playerBaseDamage;
                        }
                        
                        bladeLight = false;
                        paladinShield = false;

                        Console.WriteLine("Удар света!");
                        break;
                    
                    case "3":
                        paladinShield = true;
                        
                        if (bladeLight)
                        {
                            playerHealing += moreBladeLightDamage;
                            playerHp += playerHealing;
                        }
                        else
                        {
                            playerHp += playerHealing;
                        }

                        Console.WriteLine("Вы прикрылись щитом паладина");
                        Console.WriteLine("+" + playerHealing + "hp");
                        break;

                    case "4":

                        if (paladinShield)
                        {
                            if (bladeLight)
                            {
                                bossHp -= playerBaseDamage + moreBladeLightDamage + moreShieldDamage;
                            }
                            else
                            {
                                bossHp -= playerBaseDamage + moreShieldDamage;
                            }

                            shieldPush = true;
                        }
                        else if (bladeLight)
                        {
                            bossHp -= playerBaseDamage + moreBladeLightDamage;
                        }
                        else
                        {
                            bossHp -= playerBaseDamage;
                        }

                        Console.WriteLine("Толчок щитом");

                        bladeLight = false;
                        paladinShield = false;
                        break;
                }

                bossDamage = random.Next(minBossDamage, maxBossDamage);

                if (paladinShield)
                {
                    continue;
                }
                else if (shieldPush)
                {
                    bossDamage /= paladnaPushArrmorBaf;
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
                Console.WriteLine("\nВы погибли в этом нелегком бою...");
                Console.WriteLine("GAME OVER");
                Console.ReadKey();
            }
            else if (bossHp < 0)
            {
                Console.WriteLine("\nУра!!! Вы победили!!!!!!");
                Console.ReadKey();
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            