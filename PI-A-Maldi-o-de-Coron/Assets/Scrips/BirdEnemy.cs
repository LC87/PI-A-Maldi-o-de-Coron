using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
   [SerializeField]
    int hp = 50;

    [SerializeField]
    float movSpd = -6;

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

        if (hp <= 0)
        {
            movSpd = 0;
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
        }
    }
}
