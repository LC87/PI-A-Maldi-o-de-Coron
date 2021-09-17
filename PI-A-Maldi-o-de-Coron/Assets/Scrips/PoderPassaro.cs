using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderPassaro : MonoBehaviour
{
    [SerializeField]
    float velocidade;
    
    Player SP;

    // Start is called before the first frame update
    void Start()
    {
        SP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
         // para lancar e rotacionar o poder
        transform.position += new Vector3(0f, velocidade* Time.deltaTime, 0f);

        // para destruir o poder quando chegar ao chão
        if (transform.position.y < -4.7f)
        {
            Destroy(this.gameObject);
        }
    }
    // Deteccao de colisao do poder
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            SP.hp -= 1;
            Destroy(this.gameObject);
        }

    }
}
