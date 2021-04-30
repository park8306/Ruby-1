using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f; // 기본 시간

    Rigidbody2D rigidbody2D;
    float timer;    // 시간체크
    int direction = 1;  // 방향

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y += Time.deltaTime * speed * direction;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x += Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        Animator otheranimator = other.gameObject.GetComponent<Animator>();
        if(player != null)
        {
            otheranimator.SetTrigger("Hit");
            player.ChangeHealth(-1);
            
        }
    }
}
