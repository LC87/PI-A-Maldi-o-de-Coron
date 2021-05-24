using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int hp = 100;

    [SerializeField]
    float movSpd = -0.02f;

    [SerializeField]
    int canJump = 1;

    [SerializeField]
    public float jumpForce = 20;

    [SerializeField]
    public bool isJumping;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        StartCoroutine(EnemyRegen());
        StartCoroutine(EnemyJump());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movSpd, 0, 0);
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0.78f, hp / 100f, 1);
        float PlayerXPosition = Player.transform.position.x;

        if (transform.position.x <= -14 || transform.position.x >= 14)
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Potion Placeholder(Clone)")
        {
            Destroy(collision.gameObject);
            hp = hp - 25;
        }
        if (collision.gameObject.name != "Player Placeholder" && collision.gameObject.name != "Potion Placeholder(Clone)")
        {
            isJumping = false;
        }
    }
    private IEnumerator EnemyRegen()
    {
        if (hp < 100 && hp > 0)
        {
            while (true)
            {
                yield return new WaitForSeconds(6f);
                hp = hp + 100 / 3;
            }
        }
    }
    private IEnumerator EnemyJump()
    {
        while (hp < 0)
        {
        yield return new WaitForSeconds(3f);
        canJump = 0;
        yield return new WaitForSeconds(3f);
        canJump = 1;
        }
    }
}