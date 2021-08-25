using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample {
    public class TemporaryCharacter : ICharacter
    {
        private int startHealthPoints = default;
        public int StartHealthPoints => startHealthPoints;

        private int healthPoints = default;
        public int HealthPoints { get => healthPoints; set => healthPoints = value; }

        private float damagePoints = default;
        public float DamagePoints => damagePoints;

        private int level = default;
        public int Level { get => level; set => level = value; }

        private CharacterBehaviour characterPrefab = default;
        public CharacterBehaviour CharacterPrefab => characterPrefab; 

        public TemporaryCharacter SetStartHealthPoints(int value)
        {
            startHealthPoints = value;
            healthPoints = startHealthPoints;
            return this;
        }

        public TemporaryCharacter SetStartDamagePoints(float value)
        {
            damagePoints = value;
            return this;
        }

        public TemporaryCharacter SetCharacterPrefab(CharacterBehaviour value)
        {
            characterPrefab = value;
            return this;
        }

        public ICharacter Clone()
        {
            TemporaryCharacter temporaryCharacter =
                new TemporaryCharacter()
                .SetStartHealthPoints(StartHealthPoints)
                .SetStartDamagePoints(DamagePoints)
                .SetCharacterPrefab(CharacterPrefab);
            return temporaryCharacter;
        }
    }
}
