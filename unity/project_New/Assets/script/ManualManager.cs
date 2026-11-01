using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualManager : MonoBehaviour
{
    [Header("Game_Play")]
    [SerializeField] private string playSceneName = "Game_Play";

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 플레이 씬으로 화면을 전환
            SceneManager.LoadScene(playSceneName);
        }
    }
}