using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Core.UI
{
    [CreateAssetMenu(menuName = nameof(Core) + "/" + nameof(UI) + "/" + nameof(CanvasUISystem))]
    public class CanvasUISystem : UISystem
    {
        [Serializable]
        private class UIPefabEntry
        {
            [SerializeField]
            private string id = default;
            public string ID => id;

            [SerializeField]
            private Page prefab = default;
            public Page Prefab => prefab;
        }

        [SerializeField]
        private UIPefabEntry[] UIPefabEntries = null;

        private Canvas activeCanvas = null;
        private List<Page> activeUIs = new List<Page>();

        public override void ShowUI(string id)
        {
            _ = UIPefabEntries ?? throw new Exception($"{nameof(UIPefabEntries)} are null.");

            UIPefabEntry UIPefabEntry = UIPefabEntries.FirstOrDefault(prefab => prefab.ID.Equals(id));

            _ = UIPefabEntry ?? throw new NullReferenceException($"Unable to find {nameof(UIPefabEntry)} with id {id}.");

            Page prefab = UIPefabEntry.Prefab;

            _ = prefab ?? throw new NullReferenceException($"{nameof(UIPefabEntry)} with id {id} prefab missing.");

            if (activeCanvas == null)
            {
                //_ = canvasPrefab ?? throw new NullReferenceException($"{nameof(canvasPrefab)} is null.");
                //activeCanvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
                activeCanvas = FindObjectOfType<Canvas>();
            }

            Page newUI = Instantiate(prefab.gameObject, activeCanvas.transform).GetComponent<Page>();
            newUI.Initialize(this);

            if (activeUIs.Count != 0)
                activeUIs.Last().Hide();

            activeUIs.Add(newUI);
            //return newUI;
        }

        public override void CloseTopUI()
        {
            if (activeUIs.Count == 0)
                return;

            int lastIndex = activeUIs.Count - 1;
            activeUIs[lastIndex].Destroy();
            activeUIs.RemoveAt(lastIndex);

            if (activeUIs.Count > 0)
                activeUIs.Last().Show();
        }

        private void OnDisable()
        {
            ClearActiveUIsStack();
        }

        private void OnDestroy()
        {
            ClearActiveUIsStack();
        }

        private void ClearActiveUIsStack()
        {
            foreach (var ui in activeUIs)
                if (ui != default)
                    Destroy(ui.gameObject);
            activeUIs.Clear();
        }
    }
}
