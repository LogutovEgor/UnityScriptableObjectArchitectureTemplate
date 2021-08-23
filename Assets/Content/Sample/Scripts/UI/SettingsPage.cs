using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI;

namespace Sample.UI
{
    public class SettingsPage : Page
    {
        public override void Hide() => gameObject.SetActive(false);

        public override void Show() => gameObject.SetActive(true);

        public override void Destroy() => Destroy(gameObject);
    }
}
