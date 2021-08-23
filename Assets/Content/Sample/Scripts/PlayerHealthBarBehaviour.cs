using UnityEngine;
using UnityEngine.UI;
using System;

namespace Sample
{
    public class PlayerHealthBarBehaviour : MonoBehaviour
    {
        [SerializeField]
        private PlayerCharacter playerCharacter = default;
        [SerializeField]
        private Image healthBarLine = default;

        private void Awake()
        {
            _ = playerCharacter ?? throw new NullReferenceException($"{nameof(PlayerHealthBarBehaviour)} requires a ref to {nameof(PlayerCharacter)}.");
            _ = healthBarLine ?? throw new NullReferenceException($"{nameof(PlayerHealthBarBehaviour)} requires a ref to {nameof(Image)} of health bar.");
        }

        void Update()
        {
            if (playerCharacter.HealthPoints < 0)
                healthBarLine.fillAmount = 0f;
            else if (playerCharacter.HealthPoints >= playerCharacter.StartHealthPoints)
                healthBarLine.fillAmount = 1f;
            else
                healthBarLine.fillAmount = (float)playerCharacter.HealthPoints / (float)playerCharacter.StartHealthPoints;
        }
    }
}
