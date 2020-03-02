using System;
namespace AuroraBorealis
{
    public static class Values
    {
        public static Random Rng { get; private set; }

        static Values()
        {
            Rng = new Random();
        }
    }
}
