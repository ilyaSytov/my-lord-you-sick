using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiagnosticBodySelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private GameObject[] bodyZones;
    [SerializeField] private Animator cameraAnimator;
    private GameObject currentZone;
    private void Start() {

    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Yes!");
    }

    public void OnPointerExit(PointerEventData eventData) {
        
    }

    private void FixedUpdate() {

    }
    private void OnMouseEnter() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        currentZone = hit.collider.gameObject;
        SpriteRenderer[] sprites = currentZone.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in sprites) {
            item.color = Color.gray;
        }
    }
    private void OnMouseExit() {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in sprites) {
            item.color = Color.white;
        }
    }

    private void OnMouseDown() {
        Debug.Log("Hit");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        currentZone = hit.collider.gameObject;
        foreach (GameObject zone in bodyZones) {

        }

    }
}
