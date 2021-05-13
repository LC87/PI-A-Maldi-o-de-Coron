using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int velocidade = 20;
    [SerializeField]
    float initialRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initialRotation == 0)
        {
            transform.position += new Vector3(-velocidade * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(+velocidade * Time.deltaTime, 0, 0);
        }
    }
}
