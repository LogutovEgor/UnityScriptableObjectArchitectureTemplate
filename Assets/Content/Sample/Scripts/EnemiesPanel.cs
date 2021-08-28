using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class EnemiesPanel : MonoBehaviour
    {
        [SerializeField]
        private LevelSystem levelSystem = default;
        [SerializeField]
        private Text content = default;

        [SerializeField]
        private string contentFormatString = default;

        private StringBuilder stringBuilder = default;

        private void Awake()
        {
            stringBuilder = new StringBuilder();
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, levelSystem.GetCurrentLevelRemainingEnemiesCount());
            content.text = stringBuilder.ToString();
        }

        public void UpdatePanel()
        {
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, levelSystem.GetCurrentLevelRemainingEnemiesCount() - 1);
            content.text = stringBuilder.ToString();
        }
    }
}
