using UnityEngine;
using Core.Save;
using System;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(PlayerCharacter))]
    public class PlayerCharacter : ScriptableObject, ICharacter
    {
        private const string PLAYER_HEALTH_POINTS_LEVEL_SAVE_ID = "player_health_points_level";
        private const string PLAYER_DAMAGE_POINTS_LEVEL_SAVE_ID = "player_damage_points_level";

        [SerializeField]
        private SaveSystem saveSystem = default;

        [SerializeField]
        private AnimationCurve healthPointsCurve = default;
        public int StartHealthPoints => Mathf.RoundToInt(healthPointsCurve.Evaluate(HealthPointsLevel));
        [SerializeField]
        private AnimationCurve healthPointsUpgradePriceCurve = default;
        public int HealthPointsUpgradePrice => Mathf.RoundToInt(healthPointsUpgradePriceCurve.Evaluate(HealthPointsLevel));

        [SerializeField]
        private int healthPoints = default;
        public int HealthPoints { get => healthPoints; set => healthPoints = value; }
        public int HealthPointsLevel
        {
            get
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                return saveSystem.GetValue<int>(PLAYER_HEALTH_POINTS_LEVEL_SAVE_ID);
            }
            set
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(PlayerCharacter)} level must be >= 0");
                saveSystem.SetValue<int>(PLAYER_HEALTH_POINTS_LEVEL_SAVE_ID, value);
            }
        }

        [SerializeField]
        private AnimationCurve damagePointsCurve = default;
        public float DamagePoints => damagePointsCurve.Evaluate(DamagePointsLevel);
        [SerializeField]
        private AnimationCurve damagePointsUpgradePriceCurve = default;
        public int DamagePointsUpgradePrice => Mathf.RoundToInt(damagePointsUpgradePriceCurve.Evaluate(DamagePointsLevel));

        public int DamagePointsLevel
        {
            get
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                return saveSystem.GetValue<int>(PLAYER_DAMAGE_POINTS_LEVEL_SAVE_ID);
            }
            set
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(PlayerCharacter)} level must be >= 0");
                saveSystem.SetValue<int>(PLAYER_DAMAGE_POINTS_LEVEL_SAVE_ID, value);
            }
        }

        [SerializeField]
        private CharacterBehaviour characterPrefab = default;
        public CharacterBehaviour CharacterPrefab => characterPrefab;

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
