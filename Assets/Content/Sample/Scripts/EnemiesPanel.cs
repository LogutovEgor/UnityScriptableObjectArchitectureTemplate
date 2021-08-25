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

        private int prevRemainingEnemiesCountValue = default;

        private void Awake() => stringBuilder = new StringBuilder();

        private void Update()
        {
            int currentRemainingEnemiesCount = levelSystem.GetCurrentLevelRemainingEnemiesCount();
            if (currentRemainingEnemiesCount == prevRemainingEnemiesCountValue)
                return;
            stringBuilder.Clear();
            stringBuilder.AppendFormat(contentFormatString, currentRemainingEnemiesCount);
            content.text = stringBuilder.ToString();
            prevRemainingEnemiesCountValue = currentRemainingEnemiesCount;
        }
    }
}
