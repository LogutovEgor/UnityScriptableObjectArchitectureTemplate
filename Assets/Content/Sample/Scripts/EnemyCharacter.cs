using UnityEngine;

namespace Sample
{
    public class EnemyCharacter : ScriptableObject, ICharacter
    {
        [SerializeField]
        private AnimationCurve healthPointsCurve = default;
        public int StartHealthPoints => Mathf.RoundToInt(healthPointsCurve.Evaluate(Level));

        [SerializeField]
        private int healthPoints = default;
        public int HealthPoints { get => healthPoints; set => healthPoints = value; }

        [SerializeField]
        private AnimationCurve damagePointsCurve = default;
        public float DamagePoints => damagePointsCurve.Evaluate(Level);

        [SerializeField]
        private CharacterBehaviour characterPrefab = default;
        public CharacterBehaviour CharacterPrefab => characterPrefab;

        [SerializeField]
        private int level = default;
        public int Level { get => level; set => level = value; }

        public void Reset()
        {
            healthPoints = StartHealthPoints;
        }
    }
}
