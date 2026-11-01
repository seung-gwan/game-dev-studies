using UnityEngine;

public class AroowGenerator : MonoBehaviour
{
    public GameObject ArrowPrefab;
    float span = 0.05f; // 1초에 한번씩 찍어낼 변수
    float delta = 0;   // 현재 시간을 측정할 수 있는 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > span)
        {
            this.delta = 0;
            GameObject go = Instantiate(ArrowPrefab);
            int px = Random.Range(-8, 9);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
