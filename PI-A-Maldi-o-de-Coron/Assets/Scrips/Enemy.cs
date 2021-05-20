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
    void Start()
    {
        StartCoroutine(EnemyMov());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movSpd, 0, 0);
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0.78f, hp / 100f, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Potion Placeholder(Clone)")
        {
            hp = hp - 100 / 3;
            Destroy(collision.gameObject);
        }
    }
    private IEnumerator EnemyMov()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            movSpd = movSpd * -1;
        }
    }
}
