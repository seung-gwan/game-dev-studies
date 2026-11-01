using UnityEngine;

public class DangerFallingObject : MonoBehaviour
{
    [Header("낙하 속도")]
    public float fallSpeed = 35f;

    [Header("공격 가능 여부 (체크=DF, 해제=RDF)")]
    public bool canDestroy = true;

    // 중복 데미지 및 판정 처리 방지
    private bool alreadyHit = false;

    void Update()
    {
        // 빠르게 아래로 이동
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // 화면 아래 삭제
        if (transform.position.y < -20f)
        {
            Destroy(gameObject);
        }
    }


    // 플레이어 몸체(Collider) 충돌 처리

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerJump player = other.GetComponent<PlayerJump>();
        if (player == null || alreadyHit) return;

        // [유저 이득 판정] 플레이어가 마침 타이밍 맞춰 공격(Z) 중이었고, 
        // 이 오브젝트가 공격 가능(DF)한 오브젝트였다면 데미지를 입히지 않고 파괴해 줍니다.
        if (player.isAttacking && canDestroy)
        {
            alreadyHit = true;
            player.AddScore(150);
            Destroy(gameObject);
            return;
        }

        // [데미지 판정] 그 외의 모든 상황에서는 무조건 피해야 합니다.
        // 그냥 서있거나, 방어(X) 중이거나, 공격이 불가능한 RDF라면 예외 없이 플레이어 체력을 깎습니다.
        alreadyHit = true;
        player.TakeDamage(1);
    }
}