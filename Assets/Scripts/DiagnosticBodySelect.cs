using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiagnosticBodySelect : MonoBehaviour {
    [SerializeField] private GameObject backButton;
    [SerializeField] private Animator cameraAnimator;
    private BodyZoneController currentZone;
    private DefaultInputActions inputAction;
    private bool mouseDown = false;

    private void Awake() {
        inputAction = new DefaultInputActions();
        backButton.SetActive(false);
    }

    private void OnEnable() {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    private void Update() {
        if (inputAction.UI.Click.ReadValue<float>() == 1 && mouseDown == false) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit == true && hit.collider.gameObject.TryGetComponent<BodyZoneController>(out currentZone)) {
                currentZone.ObjectHighliter(Color.white);
                currentZone.Focused = true;
                backButton.SetActive(true);
                Debug.Log("Set");
                cameraAnimator.SetTrigger(currentZone.ZoneName + "Enter");
                Debug.Log("Anim");
            }
            mouseDown = true;
        }
        if (inputAction.UI.Click.ReadValue<float>() == 0 && mouseDown == true) {
            mouseDown = false;
        }
    }

    public void ExitAnimation() {
        backButton.SetActive(false);
        cameraAnimator.SetTrigger(currentZone.ZoneName + "Exit");
        currentZone.Focused = false;

    }

}
