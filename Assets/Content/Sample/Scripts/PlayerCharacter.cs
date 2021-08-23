using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Save;
using System;

namespace Sample
{
    [CreateAssetMenu(menuName = nameof(Sample) + "/" + nameof(PlayerCharacter))]
    public class PlayerCharacter : ScriptableObject, ICharacter
    {
        private const string PLAYER_LEVEL_SAVE_ID = "player_level";
        [SerializeField]
        private SaveSystem saveSystem = default;

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

        public int Level
        {
            get
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                return saveSystem.GetValue<int>(PLAYER_LEVEL_SAVE_ID);
            }
            set
            {
                _ = saveSystem ?? throw new NullReferenceException($"{nameof(PlayerCharacter)} requires a ref to {nameof(SaveSystem)}.");
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(PlayerCharacter)} level must be >= 0");
                saveSystem.SetValue<int>(PLAYER_LEVEL_SAVE_ID, value);
            }
        }



        public void Reset()
        {
            healthPoints = StartHealthPoints;
        }
    }
}
