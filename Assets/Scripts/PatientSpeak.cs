using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpeak : MonoBehaviour {
    public DialogueTrigger trigger;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Dialogue Started!");
        if (other.gameObject.CompareTag("Player") == true) {
            trigger.StartDialogue();
        }
    }
}
