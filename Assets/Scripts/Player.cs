using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTO
{
    [System.Serializable]
    public class Player 
    {
        public string name;
        public List<Hero> heroes;
        public int id;
        public string email;
        public string username;
        public int points;
        public int platformIndex;
        public string platformName;
        public int countryIndex;
        public string countryName;

        public override string ToString()
        {
            return $"DTO.Player {name} {countryName} {id} {email} {username} {points} {platformName}";
        }
    }
}
