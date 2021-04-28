using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;   // 루비의 최대 체력
    public int currentHealth;   // 루비의 현재 체력

    public float timeInvincible = 2.0f; // 무적시간
    public bool isInvincible;  // 무적인지 아닌지 확인하는 변수
    private float invincibleTimer;  // 현재 무적 가능한 시간

    public float speed = 3.0f;

    new Rigidbody2D rigidbody2D;

    
    // Start는 처음 시작되는 부분 - Git테스트중
    // 가사가 다시 수정
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // 화면 갱신될때마다 호출됨 - git테스트중
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeHealth(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeHealth(-2);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(vertical < 0)
        {
            vertical = -1;
        }
        if(vertical >0)
        {
            vertical = 1;
        }
        if (horizontal > 0)
        {
            horizontal = 1;
        }
        if (horizontal < 0)
        {
            horizontal = -1;
        }

        Vector2 position = rigidbody2D.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rigidbody2D.MovePosition(position);

        // 무적시간인지 확인하는 함수
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if(isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
}
