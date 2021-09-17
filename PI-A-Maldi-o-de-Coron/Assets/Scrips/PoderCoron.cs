using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderCoron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(collision.gameObject);
    }
}
