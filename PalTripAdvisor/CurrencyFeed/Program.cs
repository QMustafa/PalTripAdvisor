using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceWithTopshelf;

namespace CurrencyFeed
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureService.Configure();
        }
    }
}
