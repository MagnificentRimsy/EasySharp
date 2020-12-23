using EasySharp.Faker.Option;
using EasySharp.Faker.Store;
using System;
using System.Collections.Generic;
using System.Text;

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


        /// <summary>
        /// Pick a random name suffix like "Jr.", "II" etc.
        /// </summary>
        /// <returns></returns>
        public string NameSuffix()
        {
            return PickOne(Data.Suffixes);
        }

        /// <summary>
        /// Pick a random full name.
        /// </summary>
        /// <param name="gender">Pick for a specific gender. Default is any.</param>
        /// <param name="prefix"></param>
        /// <param name="middle"></param>
        /// <param name="middleInitial"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public string FullName(Gender gender = (Gender)~0, bool prefix = false,
            bool middle = false, bool middleInitial = false, bool suffix = false)
        {
            Person person = Person(gender: gender);
            return person.FullName(prefix, middle, middleInitial, suffix);
        }



        /// <summary>
        /// The default seed value is derived from the system clock and has finite resolution. As a result, different Faker objects that are created in close succession
        /// by a call to the default constructor will have identical default seed values and, therefore, will produce identical sets of random numbers. 
        /// <para>To create multiple Faker objects without a seed, it is recommended that you use the Faker.New() method.</para>
        /// </summary>
        public Faker() : this(Environment.TickCount) { }

        /// <summary>
        /// Initialize a new Faker generator from a string seed.
        /// </summary>
        /// <param name="seed"></param>
        public Faker(string seed)
        {
            this.Seed = 0;

            for (int i = 0; i < seed.Length; i++)
            {
                this.Seed = (int)seed[i] + (this.Seed << 6) + (this.Seed << 16) - this.Seed;
            }

            Rand = new Random(this.Seed);
        }

        /// <summary>
        /// Get the underlying seed of this Faker instance.
        /// </summary>
        /// <returns></returns>
        public int GetSeed()
        {
            return Seed;
        }

    }
}
