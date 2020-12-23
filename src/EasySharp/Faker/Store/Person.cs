using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Faker.Store
{
    public struct Person
    {
        public readonly Gender Gender;
        public readonly string NamePrefix;
        public readonly string FirstName;
        public readonly string MiddleName;
        public readonly string LastName;
        public readonly string NameSuffix;
        public readonly string SSN;
        public readonly DateTime Birthday;
        public readonly string Phone;
        public readonly string Email;

        /// <summary>
        /// Get Age of a person
        /// </summary>
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                    age--;
                return age;
            }
        }

        public char MiddleInitial
        {
            get
            {
                return MiddleName[0];
            }
        }

        internal Person(Faker fake, AgeRanges ageRange = AgeRanges.Any, Gender? gender = null, string emailDomain = null)
        {
            Gender = gender ?? fake.Gender();

            NamePrefix = fake.NamePrefix(Gender);
            FirstName = fake.FirstName(Gender);
            MiddleName = fake.FirstName(Gender);
            LastName = fake.LastName();
            NameSuffix = fake.NameSuffix();
            SSN = fake.SSN();
            Birthday = fake.Birthday(ageRange);
            Phone = fake.Phone();
            Email = fake.Email(domain: emailDomain);
        }

        public string FullName(bool prefix = false, bool middle = false, bool middleInitial = false, bool suffix = false)
        {
            StringBuilder name = new StringBuilder();

            if (prefix)
            {
                name.Append(NamePrefix);
                name.Append(' ');
            }

            name.Append(FirstName);
            name.Append(' ');

            if (middle && middleInitial)
            {
                name.Append(MiddleInitial);
                name.Append(". ");
            }
            else if (middle)
            {
                name.Append(MiddleName);
                name.Append(' ');
            }

            name.Append(LastName);

            if (suffix)
            {
                name.Append(' ');
                name.Append(NameSuffix);
            }

            return name.ToString();
        }
    }
}
