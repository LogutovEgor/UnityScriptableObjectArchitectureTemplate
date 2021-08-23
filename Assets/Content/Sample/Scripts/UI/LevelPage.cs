using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.UI;
using UnityEngine.Events;

public class LevelPage : Page
{
    [SerializeField]
    private UnityEvent onAwakeEvent = default;

    private void Awake() => onAwakeEvent.Invoke();

    public override void Hide() => gameObject.SetActive(false);

    public override void Show() => gameObject.SetActive(true);

    public override void Destroy() => Destroy(gameObject);
}
