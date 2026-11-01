using UnityEngine;
using UnityEngine.EventSystems;

public class PixelButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rect;
    private Vector3 originalScale;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        originalScale = rect.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.localScale = originalScale * 1.00f;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        rect.localScale = originalScale;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        rect.localScale = originalScale * 1.00f;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        rect.localScale = originalScale * 1.00f;
    }
}