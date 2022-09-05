using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[System.Serializable]
public class MenuEntry {
    public string entryName;
    public UnityEvent Callback;
}
[RequireComponent(typeof(UIDocument))]
public class MenuSystem : MonoBehaviour {
    [SerializeField] private List<MenuEntry> _menuEntries;
    [SerializeField] private float _transitionDuration;
    [SerializeField] private EasingMode _easing;
    [SerializeField] private float _buttonDelay;
    [SerializeField] private VisualTreeAsset _buttonTemplate;
    private VisualElement _container;
    private WaitForSeconds _pause;
    private void Start() {
        _pause = new WaitForSeconds(_buttonDelay);
        StartCoroutine(CreateMenu());
    }

    private IEnumerator CreateMenu() {
        _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("container");
        yield return new WaitForSeconds(2);
        foreach (MenuEntry entry in _menuEntries) {
            VisualElement newElement = _buttonTemplate.CloneTree();
            Button button = newElement.Q<Button>("menu-button");
            button.Q<Label>("label").text = entry.entryName;
            _container.Add(newElement);
            newElement.style.transitionDuration = new List<TimeValue>() { new TimeValue(_transitionDuration, TimeUnit.Second) };
            newElement.style.transitionTimingFunction = new StyleList<EasingFunction>(new List<EasingFunction> { new EasingFunction(_easing) });
            newElement.style.marginTop = 100;
            yield return null;
            newElement.style.marginTop = 0;
            yield return _pause;
        }
    }

}
