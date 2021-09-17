using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coron : MonoBehaviour
{
    [SerializeField]
    int hp = 250;

    [SerializeField]
    GameObject PoderCoron;

    [SerializeField]
    float spd;

    private Animator animationController;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
        StartCoroutine(Poder());
        spd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, spd * Time.deltaTime);
        if (transform.position.y >= -2.5)
        {
           if (spd >= -10)
            {
                spd -= 0.05f;
            }
        }
        else if (transform.position.y <= -2.5)
        {
            if (spd <= 10)
            {
                spd += 0.05f;
            }
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
    private IEnumerator Poder()
    {
        while (true)
        {
            float tiro = hp / 50f;
            yield return new WaitForSeconds(tiro);
            animationController.SetTrigger("tiro");
            Instantiate(PoderCoron, transform.position, transform.rotation);
        }
    }
}
