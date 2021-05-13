using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int Velocidade;
    [SerializeField]
    GameObject Potion;
    [SerializeField]
    GameObject Ref;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal") * Velocidade * Time.deltaTime;
        float VerticalMovement = Input.GetAxis("Vertical") * Velocidade * Time.deltaTime;
        transform.position += new Vector3(HorizontalMovement, VerticalMovement, 0);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Potion, Ref.transform.position, Potion.transform.rotation);
        }
    }
}
