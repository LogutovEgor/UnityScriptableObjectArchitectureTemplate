using Core.Events;
using Core.Save;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class PlayerDamagePointsUpgradePanel : MonoBehaviour
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
            stringBuilder.AppendFormat(contentFormatString, playerCharacter.DamagePointsLevel + 1, playerCharacter.DamagePoints);
            content.text = stringBuilder.ToString();

            int price = playerCharacter.DamagePointsUpgradePrice;
            upgradeButton.interactable = saveSystem.Coins >= price;

            stringBuilder.Clear();
            stringBuilder.AppendFormat(upgradePriceFormatString, price);
            upgradePrice.text = stringBuilder.ToString();
        }

        public void UpgradeHealthPoints()
        {
            int price = playerCharacter.DamagePointsUpgradePrice;
            if (saveSystem.Coins < price)
            {
                UpdatePanel();
                return;
            }
            saveSystem.Coins -= price;
            playerCharacter.DamagePointsLevel++;
            userUpgradeCharacterEvent.Raise();
            UpdatePanel();
        }
    }
}
