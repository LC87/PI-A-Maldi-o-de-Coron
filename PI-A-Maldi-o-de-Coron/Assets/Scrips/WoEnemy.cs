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

    void Start()
    {
        StartCoroutine(EnemyRegen());
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0.78f, hp / 100f, 1);
        float PlayerXPosition = Player.transform.position.x;

        if (Chase)
        {
            transform.position += new Vector3(movSpd * Time.deltaTime, 0, 0);
        }
        if (transform.position.x > PlayerXPosition)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
            if (movSpd > -10)
            {
                movSpd -= 0.05f;
            }
        }
        else if (transform.position.x < PlayerXPosition)
        {
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
            if (movSpd < 10)
            {
                movSpd += 0.05f;
            }
        }

        if (transform.position.x - PlayerXPosition > -10f && transform.position.x - PlayerXPosition < 10f)
        {
            Chase = true;
        }

        if (hp <= 0)
        {
            Chase = false;
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
}
