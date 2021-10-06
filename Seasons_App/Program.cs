using Seasons_App;
using System;

namespace Seasons_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Seasons<string> seasons = new Seasons<string>();

            foreach (var item in seasons)
            {
                Console.WriteLine(item);
            }
        }
    }
}