using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("소환할 물체 프리팹")]
    public GameObject fallingObjectPrefab;

    [Header("소환 주기 (초)")]
    public float spawnInterval = 1.5f;

    [Header("소환할 Y축 높이")]
    public float spawnYPosition = 100f;

    [Header("레인 설정 (PlayerJump의 laneDistance와 맞추세요)")]
    public float laneDistance = 0f;

    [Header("💥 최대 소환 제한 개수")]
    [Tooltip("현재 맵에 이 개수 이상의 물체가 있으면 더 이상 소환하지 않습니다.")]
    public int maxObjectCount = 3;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            // 현재 맵에 존재하는 FallingObject의 개수를 실시간으로 셉니다.
            int currentCount = Object.FindObjectsByType<FallingObject>(FindObjectsSortMode.None).Length;

            // 현재 개수가 지정한 최대 개수(maxObjectCount)보다 적을 때만 소환을 진행합니다.
            if (currentCount < maxObjectCount)
            {
                SpawnObject();
            }
            else
            {
               
            }

            timer = 0f; // 소환을 했든 안 했든 타이머는 리셋하여 주기를 유지합니다.
        }
    }

    void SpawnObject()
    {
        if (fallingObjectPrefab == null)
        {
            Debug.LogWarning("스폰러에 소환할 물체(Prefab)가 등록되지 않았습니다!");
            return;
        }

        // 왼쪽(-1), 중앙(0), 오른쪽(1) 레인 중 하나를 랜덤으로 선택
        int randomLane = Random.Range(-1, 2);

        float spawnXPosition = randomLane * laneDistance;
        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0f);

        GameObject newObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        newObject.name = "FallingObject";
    }
}