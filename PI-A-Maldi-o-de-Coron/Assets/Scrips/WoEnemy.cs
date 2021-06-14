using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int hp = 50;

    [SerializeField]
    public float jumpForce = 10;

    [SerializeField]
    public bool isJumping;

    [SerializeField]
    public bool canJump = true;

    [SerializeField]
    float dir;

    [SerializeField]
    float PlayerPos;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        StartCoroutine(EnemyRegen());
        StartCoroutine(Jump());
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0.78f, hp / 100f, 1);
        float PlayerXPosition = Player.transform.position.x;

        if (transform.position.x > PlayerXPosition)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
            dir = -1.5f;
        }
        else if (transform.position.x < PlayerXPosition)
        {
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
            dir = 1.5f;
        }

        if (canJump == true && isJumping == false)
        {
            if (transform.position.x - PlayerXPosition > -10f && transform.position.x - PlayerXPosition < 10f)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce * dir, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
                canJump = false;
            }
        }

        if (hp <= 0)
        {
            canJump = false;
            StopAllCoroutines();
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
        if (hp < 50)
        {
            while (true)
            {
                yield return new WaitForSeconds(6f);
                hp = hp + 100 / 4;
            }
        }
    }
    private IEnumerator Jump()
    {
        if (canJump == false)
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                canJump = true;
            }
        }
    }
}
