using UnityEngine;
using UnityEngine.UI;
using Core.Save;
using System.Text;

namespace Sample.UI
{
    public class CoinsPanel : MonoBehaviour
    {
        [SerializeField]
        private SaveSystem saveSystem = default;
        [SerializeField]
        private Text content = default;

        [SerializeField]
        private string contentFormatString = default;

        private StringBuilder stringBuilder = default;

        private int prevCoinsValue = default;

        private void Awake() => stringBuilder = new StringBuilder();

        private void Update()
        {
            int currentCoinsValue = saveSystem.Coins;
            //if (currentCoinsValue == prevCoinsValue)
            //    return;
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, prevCoinsValue);
            content.text = stringBuilder.ToString();
            prevCoinsValue = currentCoinsValue;
        }
    }
}
