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

        private void Awake()
        {
            stringBuilder = new StringBuilder();
            UpdatePanel();
        }

        public void UpdatePanel()
        {
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, saveSystem.Coins);
            content.text = stringBuilder.ToString();
        }
    }
}
