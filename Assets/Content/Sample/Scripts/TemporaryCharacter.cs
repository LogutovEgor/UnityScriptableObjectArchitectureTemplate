using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample {
    public class TemporaryCharacter : ICharacter
    {

        public int StartHealthPoints => throw new System.NotImplementedException();

        public int HealthPoints { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public float DamagePoints => throw new System.NotImplementedException();

        public int Level { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public CharacterBehaviour CharacterPrefab => throw new System.NotImplementedException(); 

        public TemporaryCharacter(int startHealthPoints, int damagePoints, CharacterBehaviour characterPrefab)
        {
        }

    }
}
