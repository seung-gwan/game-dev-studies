using System.Collections;
using UnityEngine;

public class DangerSpawner : MonoBehaviour
{
    [Header("플레이어 참조")]
    public PlayerJump player;

    [Header("떨어지는 물체 프리팹")]
    public GameObject rdfPrefab;   // RDF_1만 사용

    [Header("경고 UI 프리팹")]
    public GameObject ttPrefab;    // TT_1만 사용

    [Header("UI Canvas")]
    public Transform uiCanvasTransform;

    [Header("낙하 위치")]
    public Transform leftPos;
    public Transform centerPos;
    public Transform rightPos;

    [Header("설정")]
    public float spawnY = 20f;
    public float uiLeftX = -300f;
    public float uiCenterX = 0f;
    public float uiRightX = 300f;
    public float uiSpawnY = -200f;

    private bool started = false;

    void Start()
    {
        if (player == null) Debug.LogError(" Player가 연결되지 않았습니다!");
        if (uiCanvasTransform == null) Debug.LogError(" UI Canvas가 연결되지 않았습니다!");
        if (rdfPrefab == null) Debug.LogError(" rdfPrefab이 연결되지 않았습니다!");
        if (ttPrefab == null) Debug.LogError(" ttPrefab이 연결되지 않았습니다!");
    }

    void Update()
    {
        if (player == null) return;

        if (!started && player.GetScore() >= 1000)
        {
            started = true;
            StartCoroutine(SpawnLoop());
        }
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            int lane = Random.Range(0, 3);   // 0=왼쪽, 1=가운데, 2=오른쪽

            // 위치 선택
            Transform targetLane = centerPos;
            float targetUiX = uiCenterX;
            string laneName = "Center";

            if (lane == 0 && leftPos != null)
            {
                targetLane = leftPos;
                targetUiX = uiLeftX;
                laneName = "Left";
            }
            else if (lane == 2 && rightPos != null)
            {
                targetLane = rightPos;
                targetUiX = uiRightX;
                laneName = "Right";
            }

            // ====================== 경고 UI 생성 ======================
            if (ttPrefab != null)
            {
                GameObject warningUI = Instantiate(ttPrefab, uiCanvasTransform);
                RectTransform rect = warningUI.GetComponent<RectTransform>();

                if (rect != null)
                {
                    rect.anchoredPosition = new Vector2(targetUiX, uiSpawnY);
                    rect.localScale = Vector3.one;
                    rect.anchorMin = rect.anchorMax = new Vector2(0.5f, 0.5f);
                }

                Debug.Log($" TT_1 경고 UI 생성 → {laneName}");
                StartCoroutine(AutoDestroyWarning(warningUI, 1f));
            }

            // ====================== RDF_1 투하 ======================
            yield return new WaitForSeconds(1f);

            if (rdfPrefab != null && targetLane != null)
            {
                Vector3 spawnPos = new Vector3(targetLane.position.x, spawnY, 0f);
                Instantiate(rdfPrefab, spawnPos, Quaternion.identity);
                Debug.Log($" RDF_1 투하 → {laneName} | X = {targetLane.position.x}");
            }

            yield return new WaitForSeconds(1.5f);  // 다음 생성 간격
        }
    }

    // UI 자동 삭제
    IEnumerator AutoDestroyWarning(GameObject uiObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (uiObject != null) Destroy(uiObject);
    }
}