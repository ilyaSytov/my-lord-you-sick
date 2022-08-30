using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiagnosticBodySelect : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject[] bodyZones;
    [SerializeField] private Animator cameraAnimator;
    private GameObject currentZone;

    public void OnPointerClick(PointerEventData eventData) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        foreach (GameObject zone in bodyZones) {
            zone.GetComponent<BodyZoneController>().Focused = true;
            if (zone == hit.collider.gameObject) {

            }
        }
    }

}
