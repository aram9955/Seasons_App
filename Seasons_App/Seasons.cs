using System;
using System.Collections;

namespace Seasons_App
{
    class Seasons
    {
        private string[] _items = new string[] { "Winter", "Spring", "Summer", "Autumn" };
        public IEnumerator GetEnumerator()
        {
            foreach (string item in _items)
            {
                if (item == "Summer")
                {
                    yield return item;
                }
            }
        }
    }
}
