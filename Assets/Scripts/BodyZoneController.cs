using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyZoneController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private string zoneName;
    private bool focused;
    public bool Focused {
        get { return focused; }
        set { focused = value; }
    }
    public string ZoneName => zoneName;

    public void OnPointerEnter(PointerEventData eventData) {
        ObjectHighliter(Color.gray);
    }

    public void OnPointerExit(PointerEventData eventData) {
        ObjectHighliter(Color.white);
    }

    public void ObjectHighliter(Color highlightColor) {
        if (focused == false) {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in sprites) {
                item.color = highlightColor;
            }
        }
    }

}