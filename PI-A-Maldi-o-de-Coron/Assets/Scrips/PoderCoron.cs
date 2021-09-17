using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderCoron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Activate", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -60)
        {
            Destroy(this.gameObject);
        }
        transform.position += new Vector3(-5f*Time.deltaTime, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(this.gameObject);
    }
    void Activate()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
