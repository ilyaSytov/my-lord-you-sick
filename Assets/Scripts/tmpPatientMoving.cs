using System.Collections;
using UnityEngine;

public class tmpPatientMoving : MonoBehaviour {

    private void Start() {
        StartCoroutine(MovePatient());
    }

    private IEnumerator MovePatient() {
        float newPosition = transform.position.x + 4f;
        for (float i = transform.position.x; i <= newPosition; i += 0.05f) {
            transform.position = new Vector3(i, transform.position.y, transform.position.z);
            yield return null;
        }
    }

}
