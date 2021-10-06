using Seasons_App;
using System;

namespace Seasons_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Seasons seasons = new Seasons();
            foreach (string item in seasons)
            {
                Console.WriteLine(item);
            }
        }
    }
}