using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingBird : MonoBehaviour
{
    [SerializeField]
    float movSpd;

    [SerializeField]
    int direction = 1;

    [SerializeField]
    GameObject PoderPassaro;

    private Animator animationController;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Poder());
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += new Vector3(movSpd * Time.deltaTime, 0f, 0f);

        if (transform.position.x <= 15.98)
        {
            movSpd = movSpd * -1;
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
        }
        if (transform.position.x >= 39.11)
        {
             movSpd = movSpd * -1;
             transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
        }
      
    }

    private IEnumerator Poder(){
        while (true) {

        yield return new WaitForSeconds(2f);
        Instantiate(PoderPassaro, transform.position, PoderPassaro.transform.rotation);
        }
    }
}
