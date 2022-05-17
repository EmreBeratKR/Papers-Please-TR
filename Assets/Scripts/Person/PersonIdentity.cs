using Scriptable_Objects;
using UnityEngine;

namespace Person
{
    public class PersonIdentity : MonoBehaviour
    {
        [SerializeField] private StringContainer firstnames;
        [SerializeField] private StringContainer lastnames;
        [SerializeField] private CountryContainer countries;
        
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public Gender Gender { get; private set; }


        public void Generate()
        {
            Firstname = firstnames.Random;
            Lastname = lastnames.Random;

            var randomCountry = countries.Random;
            Country = randomCountry.Name;
            City = randomCountry.RandomCity;

            Gender = Gender.Random();
        }
    }
}
