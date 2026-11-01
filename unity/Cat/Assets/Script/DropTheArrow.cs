using UnityEngine;

public class DropTheArrow : MonoBehaviour
{
    GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Player = GameObject.Find("Player");

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임 마다 등속으로 낙하
        transform.Translate(0, -0.05f, 0);

        // 밖으로 나가면 삭제
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;
        Vector2 p2 = this.Player.transform.position;
        Vector2 dir = p1 - p2;

        float d = dir.magnitude;

        float r1 = 0.4f;
        float r2 = 0.1f;

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }


    }
}
