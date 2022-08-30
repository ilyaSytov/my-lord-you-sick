using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyZoneController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private bool focused;
    public bool Focused {
        get { return focused; }
        set { focused = value; }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (focused == false) {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in sprites) {
                item.color = Color.gray;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (focused == false) {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in sprites) {
                item.color = Color.white;
            }
        }
    }

}