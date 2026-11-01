using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Game_manual")]
    // Game_manual
    [SerializeField] private string gameSceneName = "Game_manual";

    [Header("UI")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject fadePanel;

    public void OnClickStart()
    {
        StartCoroutine(StartGameRoutine());
    }

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private System.Collections.IEnumerator StartGameRoutine()
    {
        if (fadePanel != null)
            fadePanel.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene(gameSceneName);
    }
}