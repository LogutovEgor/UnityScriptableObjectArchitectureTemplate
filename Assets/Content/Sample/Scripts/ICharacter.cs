using System;

namespace Sample {
    public interface ICharacter
    {
        public int StartHealthPoints { get; }
        public int HealthPoints { get; set; }
        public int HealthPointsLevel { get; set; }

        public float DamagePoints { get; }
        public int DamagePointsLevel { get; set; }


        public CharacterBehaviour CharacterPrefab { get; }

        public ICharacter Clone();
    }
}
