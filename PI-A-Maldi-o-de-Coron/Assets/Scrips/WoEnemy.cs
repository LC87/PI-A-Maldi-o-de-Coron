using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int hp = 50;

    [SerializeField]
    float InitPos;

    [SerializeField]
    public bool Chase;

    [SerializeField]
    float movSpd = 0;

    [SerializeField]
    float dir;

    [SerializeField]
    float PlayerPos;

    [SerializeField]
    GameObject Player;

    private Animator animationController;
    void Start()
    {
        animationController = GetComponent<Animator>();
        Player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        float PlayerX = Player.transform.position.x;

        if (Chase)
        {
            transform.position += new Vector3(movSpd * Time.deltaTime, 0, 0);

            if (transform.position.x > PlayerX)
            {
                transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
                if (movSpd > -10)
                {
                    movSpd -= 0.05f;
                }
            }

            else if (transform.position.x < PlayerX)
            {
                transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
                if (movSpd < 10)
                {
                    movSpd += 0.05f;
                }
            }
        }

        if (transform.position.x - PlayerX > -10f && transform.position.x - PlayerX < 10f)
        {
            Chase = true;
            animationController.SetBool("Moving", true);
        }

        else
        {
            animationController.SetBool("Moving", false);
            Chase = false;
            movSpd = 0;
        }

        if (hp <= 0)
        {
            Chase = false;
            animationController.SetBool("Cured", true);
            gameObject.tag = "Untagged";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
            hp = hp - 25;
        }
    }
}
