﻿namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList(Random random)
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {

            int index = rnd.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;

        }
    }
}
