using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingBird : MonoBehaviour
{
    [SerializeField]
    float movSpd;

    [SerializeField]
    GameObject PoderPassaro;

    private Animator animationController;

    [SerializeField]
    float InitPos;

    [SerializeField]
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Poder());
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
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
        }
        if (transform.position.x >= InitPos + 7 && movSpd > 0)
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
