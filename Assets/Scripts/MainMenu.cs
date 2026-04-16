using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    // Start Button - starts our game on Scene 1
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    // Quit Button - exits the program
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public GameObject controlsPanel;
    public CanvasGroup controlsGroup;   

    public float fadeDuration = 0.25f; 

    // Controls Button - opens the controls panel
    public void OpenControls()
    {
        controlsPanel.SetActive(true);
        StartCoroutine(Fade(0f, 1f));
    }

    // Close Button - closes the controls panel
    public void CloseControls()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    // Fade system for panel
    IEnumerator Fade(float start, float end)
    {
        float time = 0f;

        controlsGroup.alpha = start;

        // Ensure panel is active before fading in
        if (end > start)
        {
            controlsPanel.SetActive(true);
        }

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            controlsGroup.alpha = Mathf.Lerp(start, end, time / fadeDuration);
            yield return null;
        }

        controlsGroup.alpha = end;

        // Disable panel after fade out
        if (end == 0f)
        {
            controlsPanel.SetActive(false);
        }
    }
}