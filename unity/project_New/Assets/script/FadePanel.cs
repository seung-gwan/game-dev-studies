using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed = 2f;

    private float alpha = 0f;

    private void OnEnable()
    {
        alpha = 0f;
        SetAlpha(alpha);
    }

    private void Update()
    {
        alpha += Time.deltaTime * fadeSpeed;
        SetAlpha(alpha);
    }

    private void SetAlpha(float value)
    {
        if (fadeImage == null) return;

        Color c = fadeImage.color;
        c.a = Mathf.Clamp01(value);
        fadeImage.color = c;
    }
}