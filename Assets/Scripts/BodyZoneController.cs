using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyZoneController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in sprites) {
            item.color = Color.gray;
        }
        Debug.Log("Yes");
    }

}