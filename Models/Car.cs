using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Threads.Models
{
    internal class Car
    {
        public static int CarIdIncrementer { get; set; } = 1;
        public int CarId { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public double DistanceTraveled { get; set; }
        public bool CarInTrouble {  get; set; }

        public Car(string name, int speed = 120) 
        {
            CarId = CarIdIncrementer;
            Name = name;
            Speed = speed;
            CarIdIncrementer++;
        }

        public async Task DistanceMeter(CancellationToken ct)
        {
            Task t = Task.Run(() => Trouble());
            while (Race.RaceIsRunning)
            {
                while (!CarInTrouble && Race.RaceIsRunning)
                {
                    await Task.Delay(50);
                    DistanceTraveled += Speed / 10;
                    if (DistanceTraveled > 10000 || ct.IsCancellationRequested)
                    {
                        Race.RaceIsRunning = false;
                        Race.Cts.Cancel();
                        Task.WaitAny(t);
                        return;
                    }
                }
            }
        }

        public async Task Trouble()
        {
            Random r = new Random();
            await Task.Delay(5000);
            while (Race.RaceIsRunning)
            {
                int ranIntoTrouble = r.Next(1, 51);
                CarInTrouble = true;

                switch (ranIntoTrouble)
                {
                    case 1:
                        // Out of gas
                        await Console.Out.WriteLineAsync($"{Name} ran out of gas");
                        await Task.Delay(10000);
                        break;
                    case 2:
                    case 3:
                        // Flat tire
                        await Console.Out.WriteLineAsync($"{Name} got a flat tire");
                        await Task.Delay(5000);
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        // Bird on windscreen
                        await Console.Out.WriteLineAsync($"{Name} has a bird on the windscreen!");
                        await Task.Delay(3000);
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        // Engine malfunction
                        await Console.Out.WriteLineAsync($"{Name} had an engine malfunction. Top speed lowered.");
                        Speed -= 5;
                        break;
                }
                CarInTrouble = false;
                await Task.Delay(5000);
            }
            return;
        }


    }
}
