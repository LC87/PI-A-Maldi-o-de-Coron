using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocaDeCena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 138f){
            SceneManager.LoadScene("Fase2-floresta");
        }
    }

    public void TrocarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
