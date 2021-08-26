using UnityEngine;
using System;
using Sample.Events;

namespace Sample
{
    public class CharacterHealthBarBehaviour : MonoBehaviour
    {
        [SerializeField]
        private CharacterBehaviour character = default;
        [SerializeField]
        private SpriteRenderer healthBarLine = default;

        private float startWidth = default;
        private void Awake()
        {
            _ = character ?? throw new NullReferenceException($"{nameof(CharacterHealthBarBehaviour)} requires a ref to {nameof(CharacterBehaviour)}.");
            _ = healthBarLine ?? throw new NullReferenceException($"{nameof(CharacterHealthBarBehaviour)} requires a ref to {nameof(SpriteRenderer)} of health bar.");
            startWidth = healthBarLine.size.x;
        }

        public void UpdateHealthBar(CharacterReceivedDamageEvent characterReceivedDamageEvent)
        {
            if (characterReceivedDamageEvent.Target != character)
                return;
            if (character.Character.HealthPoints <= 0)
                Destroy(gameObject);
            else if (character.Character.HealthPoints >= character.Character.StartHealthPoints)
                SetLineFillAmount(1f);
            else
                SetLineFillAmount((float)character.Character.HealthPoints / (float)character.Character.StartHealthPoints);
        }

        private void SetLineFillAmount(float value)
        {
            if (value < 0f || value > 1f)
                throw new ArgumentOutOfRangeException($"SetLineFillAmount {nameof(value)} must be in range from 0f to 1f");

            float width = startWidth * value;
            healthBarLine.size = new Vector2(width, healthBarLine.size.y);
        }
    }
}
