using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI;
using UnityEngine.Events;
using UnityEngine.UI;
using Sample;
using System.Text;

namespace Sample.UI
{
    public class LevelResultPage : Page
    {
        [SerializeField]
        private UnityEvent onAwakeEvent = default;
        [SerializeField]
        private LevelSystem levelSystem = default;

        [SerializeField]
        private Text header = default;
        [SerializeField]
        private string headerVictoryFormatString = default;
        [SerializeField]
        private string headerLoseFormatString = default;

        [SerializeField]
        private Button nextButton = default;

        private StringBuilder stringBuilder = default;

        private void Awake() 
        { 
            onAwakeEvent.Invoke();
            stringBuilder = new StringBuilder();
            UpdatePage();
        }

        public override void Hide() => gameObject.SetActive(false);

        public override void Show() => gameObject.SetActive(true);

        public override void Destroy() => Destroy(gameObject);

        public void UpdatePage()
        {
            stringBuilder.Clear();
            stringBuilder.AppendFormat(levelSystem.LastLevelResult ? headerVictoryFormatString : headerLoseFormatString, levelSystem.GetCurrentLevelDisplayName());
            header.text = stringBuilder.ToString();
            nextButton.interactable = levelSystem.LastLevelResult && levelSystem.NextLevelExists;
        }
    }
}
