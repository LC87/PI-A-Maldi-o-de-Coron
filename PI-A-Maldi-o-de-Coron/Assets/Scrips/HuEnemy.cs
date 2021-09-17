using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int hp = 100;

    [SerializeField]
    float movSpd = -4;

    [SerializeField]
    int canJump = 1;

    [SerializeField]
    public float jumpForce = 15;

    [SerializeField]
    public bool isJumping;

    [SerializeField]
    float InitPos;

    [SerializeField]
    GameObject Player;
    private Animator animationController;
    void Start()
    {
        animationController = GetComponent<Animator>();
        InitPos = transform.position.x;
        Player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        float PlayerXPosition = Player.transform.position.x;
        transform.position += new Vector3(movSpd * Time.deltaTime, 0, 0);
        
        if (transform.position.x <= InitPos-7 && movSpd < 0)
        {
            movSpd = movSpd * -1;
        }
        if (transform.position.x >= InitPos + 7 && movSpd > 0)
        {
            movSpd = movSpd * -1;
        }

        if (canJump == 1 && isJumping == false)
        {
            if (transform.position.x - PlayerXPosition > -2.5f && transform.position.x - PlayerXPosition < 2.5f)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        if (hp <= 0)
        {
            movSpd = 0;
            canJump = 0;
        }

        if (movSpd == 0)
        {
            animationController.SetBool("Moving", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            hp = hp - 25;
            isJumping = true;
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            isJumping = false;
        }
    }
}
