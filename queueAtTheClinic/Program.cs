using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queueAtTheClinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int appointmentTimePerPerson = 10;
            int minutesInAnHour = 60;

            Console.Write("Сколько людей перед вами в очереди? : ");
            int amountOfPeopleInLine = Convert.ToInt32(Console.ReadLine());
 
            int waitingTime = amountOfPeopleInLine * appointmentTimePerPerson;
            int waitForHours = waitingTime / minutesInAnHour;
            int waitMinutes = waitingTime % minutesInAnHour;

            Console.WriteLine($"Время ожидания в очереди {waitForHours} ч {waitMinutes} м.");
        }
    }
}
