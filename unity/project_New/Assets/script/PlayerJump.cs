using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{
    [Header("위치 이동")]
    public float laneDistance = 6f;

    [Header("점프력")]
    public float jumpForce = 32f;

    [Header("바닥 확인")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 4f;
    public float rayOffset = 0.1f;

    [Header("공격 및 방어 범위 설정 (공유)")]
    public Vector2 attackOffset = new Vector2(0f, 2f);
    public Vector2 attackBoxSize = new Vector2(3f, 2f);

    [Header("튕김 힘")]
    public float bounceForce = 25f;

    [Header("캐릭터 이미지")]
    public Sprite idleSprite;
    public Sprite jumpSprite;
    public Sprite landingSprite;
    public Sprite attackSprite1;
    public Sprite attackSprite2;
    public Sprite blockSprite;

    [Header("체력")]
    public int hp = 3;
    private bool isDead = false;
    private bool canTakeDamage = true;

    [Header("하트 UI")]
    public Image heart1;
    public Image heart2;
    public Image heart3;

    [Header("점수 UI")]
    public Text scoreText;
    private int score = 0;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool isGrounded;
    private bool wasGrounded;

    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isBlocking = false;

    private int currentLane = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 2.5f;

        UpdateHeartUI();
        UpdateScoreUI();
    }

    void Update()
    {
        if (isDead)
            return;

        // 1. 방어 키(X) 입력 처리
        if (Input.GetKey(KeyCode.X) && !isAttacking)
        {
            isBlocking = true;
            sr.sprite = blockSprite;

            ExecuteBlockCheck();
        }
        else
        {
            isBlocking = false;
        }

        // 2. 공격 키(Z) 입력 처리
        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            StartCoroutine(Attack());
        }

        // 3. 공격이나 방어 중이 아닐 때만 이동 및 점프 가능
        if (!isAttacking && !isBlocking)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentLane--;
                if (currentLane < -1) currentLane = -1;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentLane++;
                if (currentLane > 1) currentLane = 1;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                sr.sprite = jumpSprite;
            }
        }

        // 이동 처리
        Vector3 targetPosition = transform.position;
        targetPosition.x = currentLane * laneDistance;
        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        // 바닥 체크
        wasGrounded = isGrounded;
        Vector2 origin = (Vector2)transform.position + Vector2.down * rayOffset;
        isGrounded = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, groundLayer);

        // 점프 높이 보조
        if (Input.GetKey(KeyCode.UpArrow) && rb.linearVelocity.y > 0 && !isAttacking && !isBlocking)
        {
            rb.linearVelocity += new Vector2(0, 1.5f * Time.deltaTime);
        }

        // 착지 연출
        if (!wasGrounded && isGrounded && !isAttacking && !isBlocking)
        {
            sr.sprite = landingSprite;
            Invoke(nameof(ReturnIdle), 0.3f);
        }

        // 복구 안전장치
        if (!Input.anyKey && isGrounded && !isAttacking && !isBlocking)
        {
            sr.sprite = idleSprite;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!canTakeDamage)
            return;

        if (isDead)
            return;

        hp -= damage;

        UpdateHeartUI();

        Debug.Log("현재 체력 : " + hp);

        StartCoroutine(DamageCooldown());

        // 게임 오버
        if (hp <= 0)
        {
            hp = 0;
            isDead = true;

            // 현재 점수를 "FinalScore"라는 이름으로 저장

            PlayerPrefs.SetInt("FinalScore", score);
            PlayerPrefs.Save();

            // 게임 오버로 이동
            SceneManager.LoadScene("Game_Over");
        }
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE : " + score;
        }
    }

    void UpdateHeartUI()
    {
        if (heart1 != null) heart1.enabled = hp >= 1;
        if (heart2 != null) heart2.enabled = hp >= 2;
        if (heart3 != null) heart3.enabled = hp >= 3;
    }


    // 방어 체크

    void ExecuteBlockCheck()
    {
        Vector2 attackPosition = (Vector2)transform.position + attackOffset;
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(attackPosition, attackBoxSize, 0f);

        foreach (Collider2D obj in hitObjects)
        {
            if (obj.gameObject == this.gameObject) continue;

            FallingObject fallingObj = obj.GetComponent<FallingObject>();
            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();

            if (fallingObj != null && objRb != null)
            {
                if (objRb.linearVelocity.y <= 0.1f)
                {
                    Debug.Log($" {obj.gameObject.name}를 방어합니다.");

                    Vector2 castOrigin = (Vector2)obj.transform.position + Vector2.up * 0.5f;
                    RaycastHit2D[] upperHits = Physics2D.RaycastAll(castOrigin, Vector2.up, 2.0f);

                    foreach (RaycastHit2D upperHit in upperHits)
                    {
                        if (upperHit.collider != null && upperHit.collider.gameObject != obj.gameObject && upperHit.collider.gameObject != this.gameObject)
                        {
                            Rigidbody2D upperRb = upperHit.collider.GetComponent<Rigidbody2D>();
                            if (upperRb != null)
                            {
                                upperRb.linearVelocity = Vector2.zero;
                                upperRb.angularVelocity = 0f;
                            }
                        }
                    }

                    objRb.linearVelocity = Vector2.zero;
                    objRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                    break;
                }
            }
        }
    }

    void ReturnIdle()
    {
        if (isBlocking || isAttacking) return;
        sr.sprite = idleSprite;
    }


    // 공격 처리

    IEnumerator Attack()
    {
        isAttacking = true;
        isBlocking = false;

        Vector2 attackPosition = (Vector2)transform.position + attackOffset;
        Collider2D[] hitObjects = Physics2D.OverlapBoxAll(attackPosition, attackBoxSize, 0f);

        foreach (Collider2D obj in hitObjects)
        {
            if (obj.gameObject == this.gameObject) continue;

            FallingObject fallingObj = obj.GetComponent<FallingObject>();
            if (fallingObj != null)
            {
                AddScore(100);
                Destroy(obj.gameObject);
                continue;
            }

            DangerFallingObject dangerObj = obj.GetComponent<DangerFallingObject>();
            if (dangerObj != null)
            {
                if (dangerObj.canDestroy)
                {
                    AddScore(150);
                    Destroy(obj.gameObject);
                }
            }
        }

        sr.sprite = attackSprite1;
        yield return new WaitForSeconds(0.06f);

        sr.sprite = attackSprite2;
        yield return new WaitForSeconds(0.06f);

        isAttacking = false;

        if (Input.GetKeyDown(KeyCode.X))
        {
            isBlocking = true;
            sr.sprite = blockSprite;
        }
        else
        {
            sr.sprite = isGrounded ? idleSprite : jumpSprite;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * rayOffset;
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(origin, origin + Vector2.down * groundCheckDistance);

        Gizmos.color = Color.red;
        Vector2 attackPosition = (Vector2)transform.position + attackOffset;
        Gizmos.DrawWireCube(attackPosition, attackBoxSize);
    }
}