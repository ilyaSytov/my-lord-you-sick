using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyZoneController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in sprites) {
            item.color = Color.gray;
        }
        Debug.Log("Yes");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Yes");
    }

    void Update() {
        //Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

}