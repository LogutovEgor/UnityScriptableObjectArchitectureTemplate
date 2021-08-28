using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(EnemyCharacter))]
    public class EnemyCharacter : ScriptableObject, ICharacter
    {
        [SerializeField]
        private AnimationCurve healthPointsCurve = default;
        public int StartHealthPoints => Mathf.RoundToInt(healthPointsCurve.Evaluate(HealthPointsLevel));

        [SerializeField]
        private int healthPoints = default;
        public int HealthPoints { get => healthPoints; set => healthPoints = value; }

        [SerializeField]
        private int healthPointslevel = default;
        public int HealthPointsLevel { get => healthPointslevel; set => healthPointslevel = value; }

        [SerializeField]
        private AnimationCurve damagePointsCurve = default;
        public float DamagePoints => damagePointsCurve.Evaluate(DamagePointsLevel);

        [SerializeField]
        private CharacterBehaviour characterPrefab = default;
        public CharacterBehaviour CharacterPrefab => characterPrefab;

        [SerializeField]
        private int damagePointsLevel = default;
        public int DamagePointsLevel { get => damagePointsLevel; set => damagePointsLevel = value; }

        public void Reset()
        {
            healthPoints = StartHealthPoints;
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
