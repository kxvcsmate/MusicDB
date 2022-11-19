using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace C8N5NZ_HFT_2022231.Client
{
    class NonCrudService
    {
        private RestService rest;

        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void ReadBrandStats()
        {
            var items = rest.Get<BrandStatistic>("Stat/ReadBrandStats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void GetCarsByPriceRange()
        {
            Console.WriteLine("Min=");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Max=");
            int max = int.Parse(Console.ReadLine());

            var items = rest.Get<Car>($"Stat/GetCarsByPriceRange?min={min}&max={max}");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void AvgCarPrice()
        {
            double price = rest.GetSingle<double>("Stat/AvgCarPrice");
            Console.WriteLine($"Average car price = {price}");
            Console.ReadLine();
        }
    }
}
}
