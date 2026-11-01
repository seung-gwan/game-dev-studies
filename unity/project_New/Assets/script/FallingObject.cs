using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Header("튕김 힘")]
    public float bounceForce = 30f;

    private Rigidbody2D rb;

    // 위로 튕기는 중인지 확인
    private bool isBouncingUp = false;

    public bool destroyedByAttack = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 물체가 멈추지 않도록 설정
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleBounce(collision.gameObject);
    }

    private bool alreadyDamaged = false;

    void OnCollisionStay2D(Collision2D collision)
    {
        PlayerJump player =
            collision.gameObject.GetComponent<PlayerJump>();

        if (player != null)
        {
            // 플레이어가 바닥 위에 있는지 확인
            bool grounded = Physics2D.Raycast(
                player.transform.position,
                Vector2.down,
                5f,
                player.groundLayer
            );

            // 캐릭터 바로 위에 있는 오브젝트인지 확인
            bool isDirectlyAbove =
                transform.position.y >
                player.transform.position.y;

            // 압사 조건
            if (grounded && isDirectlyAbove)
            {
                // 이미 데미지 줬으면 중복 방지
                if (alreadyDamaged)
                    return;

                alreadyDamaged = true;

                player.TakeDamage(1);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerJump player =
            collision.gameObject.GetComponent<PlayerJump>();

        if (player != null)
        {
            alreadyDamaged = false;
        }
    }

    // 플레이어 머리나 다른 물체 위에서 떨어지면 다시 튕김 가능

    private void HandleBounce(GameObject obj)
    {
        PlayerJump player = obj.GetComponent<PlayerJump>();


        // 플레이어와 충돌

        if (player != null)
        {
            // 방어 성공
            if (player.isBlocking && !isBouncingUp)
            {
                isBouncingUp = true;

                Bounce();
            }

            // 공격 성공
            if (player.isAttacking)
            {

                // 점수 처리


                destroyedByAttack = true;

                Destroy(gameObject);
            }

            return;
        }


        // 다른 낙하물과 충돌

        FallingObject 다른물체 =
            obj.GetComponent<FallingObject>();

        if (다른물체 != null)
        {
            PlayerJump 플레이어확인 =
                Object.FindFirstObjectByType<PlayerJump>();

            if (플레이어확인 != null &&
                플레이어확인.isBlocking &&
                !isBouncingUp)
            {
                isBouncingUp = true;

                Bounce();
            }
        }
    }


    // 튕김 처리


    private void Bounce()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;

            rb.AddForce(
                Vector2.up * bounceForce,
                ForceMode2D.Impulse
            );
        }
    }

    void Update()
    {
        // 아래로 떨어지면 다시 튕김 가능
        if (rb != null &&
            rb.linearVelocity.y < -0.1f)
        {
            isBouncingUp = false;
        }
    }


    // 점수 증가 처리


    void OnDestroy()
    {
        if (!destroyedByAttack)
            return;

        PlayerJump player =
            Object.FindFirstObjectByType<PlayerJump>();

        if (player != null)
        {
            player.AddScore(100);
        }
    }
}