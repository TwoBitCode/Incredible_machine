using UnityEngine;
using TMPro;

public class LevelInstructions : MonoBehaviour
{
    public TextMeshProUGUI instructionsText;    // Instruction text
    public GameObject textBackground;           // Background panel
    public float displayDuration = 3f;         // Duration to display
    public float fadeDuration = 2f;            // Fade-out time

    private void Start()
    {
        ShowInstructions();  // Show instructions at the beginning
    }

    private void ShowInstructions()
    {
        // Activate text and background
        instructionsText.gameObject.SetActive(true);
        textBackground.SetActive(true);

        // Start fade-out after the display duration
        Invoke(nameof(StartFadeOut), displayDuration);
    }

    private void StartFadeOut()
    {
        StartCoroutine(FadeOutElements());
    }

    private System.Collections.IEnumerator FadeOutElements()
    {
        float currentTime = 0f;

        // Save the original colors
        Color textOriginalColor = instructionsText.color;
        CanvasGroup backgroundCanvasGroup = textBackground.GetComponent<CanvasGroup>();

        // Ensure the background has a CanvasGroup component
        if (backgroundCanvasGroup == null)
        {
            backgroundCanvasGroup = textBackground.AddComponent<CanvasGroup>();
        }

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);

            // Apply fade-out effect
            instructionsText.color = new Color(
                textOriginalColor.r, textOriginalColor.g, textOriginalColor.b, alpha);

            backgroundCanvasGroup.alpha = alpha;

            yield return null;
        }

        // Hide both elements after fade-out
        instructionsText.gameObject.SetActive(false);
        textBackground.SetActive(false);
    }
}
