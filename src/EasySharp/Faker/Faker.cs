using System;

namespace EasySharp.Faker
{
    public class Faker
    {

        /// <summary>
        /// The seed that this generator was initialized with.
        /// </summary>
        public int Seed { get; private set; }

        protected virtual Random Rand { get; }

        /// <summary>
        /// Fake instance for faking
        /// </summary>
        public Faker(int seed)
        {
            this.Seed = seed;
            Rand = new Random(seed);
        }
    }
}
