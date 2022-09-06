using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private float scaleMultiplier = 1.2f;
    private RectTransform button;
    private RectTransform buttonText;
    private Image buttonImage;

    private void Awake() {
        button = GetComponent<RectTransform>();
        buttonText = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        buttonImage = GetComponent<Image>();
        buttonImage.color = new Color(255, 255, 255, 0);
    }

    private IEnumerator EnterAnimation() {
        for (float currentScale = 1f; currentScale < scaleMultiplier; currentScale += 0.01f) {
            AnimateButton(currentScale);
            yield return null;
        }
    }

    private IEnumerator ExitAnimation() {
        for (float currentScale = scaleMultiplier; currentScale > 1f; currentScale -= 0.01f) {
            AnimateButton(currentScale);
            yield return null;
        }
    }

    private void AnimateButton(float currentScale) {
        float alpha = (currentScale - 1) * 255 / (scaleMultiplier - 1f);
        buttonImage.color = new Color(255, 255, 255, alpha);
        button.localScale = new Vector3(currentScale, currentScale, currentScale);
        buttonText.localScale = new Vector3(1 / currentScale, 1 / currentScale, 1 / currentScale);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        StopCoroutine(ExitAnimation());
        StartCoroutine(EnterAnimation());
    }

    public void OnPointerExit(PointerEventData eventData) {
        StopCoroutine(EnterAnimation());
        StartCoroutine(ExitAnimation());
    }
}
