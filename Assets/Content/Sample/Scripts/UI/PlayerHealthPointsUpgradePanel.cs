using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Save;
using System.Text;
using Core.Events;

namespace Sample.UI
{
    public class PlayerHealthPointsUpgradePanel : MonoBehaviour
    {
        [SerializeField]
        private SaveSystem saveSystem = default;
        [SerializeField]
        private GameEvent userUpgradeCharacterEvent = default;

        [SerializeField]
        private PlayerCharacter playerCharacter = default;
        
        [SerializeField]
        private Text content = default;
        [SerializeField]
        private string contentFormatString = default;

        [SerializeField]
        private Button upgradeButton = default;
        [SerializeField]
        private Text upgradePrice = default;
        [SerializeField]
        private string upgradePriceFormatString = default;

        private StringBuilder stringBuilder = default;

        private void Awake()
        {
            stringBuilder = new StringBuilder();
            UpdatePanel();
        }

        public void UpdatePanel()
        {
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, playerCharacter.HealthPointsLevel + 1, playerCharacter.StartHealthPoints);
            content.text = stringBuilder.ToString();

            int price = playerCharacter.HealthPointsUpgradePrice;
            upgradeButton.interactable = saveSystem.Coins >= price;

            stringBuilder.Clear();
            stringBuilder.AppendFormat(upgradePriceFormatString, price);
            upgradePrice.text = stringBuilder.ToString();
        }

        public void UpgradeHealthPoints()
        {
            int price = playerCharacter.HealthPointsUpgradePrice;
            if (saveSystem.Coins < price)
            {
                UpdatePanel();
                return;
            }
            saveSystem.Coins -= price;
            playerCharacter.HealthPointsLevel++;
            userUpgradeCharacterEvent.Raise();
            UpdatePanel();
        }

    }
}
