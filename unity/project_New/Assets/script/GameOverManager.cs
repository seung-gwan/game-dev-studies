using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [Header("점수를 표시할 TMP 텍스트")]
    [SerializeField] private TextMeshProUGUI finalScoreText; 

    [Header("다시 시작할 게임 씬 이름")]
    [SerializeField] private string playSceneName = "Game_Start";

    void Start()
    {
        // 플레이어 스크립트에서 저장했던 점수를 불러옵니다.
        int totalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // 글자로 화면에 출력합니다.
        if (finalScoreText != null)
        {
            finalScoreText.text = "Score : " + totalScore.ToString();
        }
    }

    // 다시 시작 버튼용 함수
    public void OnClickRetry()
    {
        SceneManager.LoadScene(playSceneName);
    }

    // 메인 화면 버튼용 함수
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Game_Start");
    }
}