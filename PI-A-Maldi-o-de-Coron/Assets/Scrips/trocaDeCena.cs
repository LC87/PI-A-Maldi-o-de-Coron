using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trocaDeCena : MonoBehaviour
{   
    [SerializeField]
    float position;

    [SerializeField]
    string nomeDaCena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > position){
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    public void TrocarCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
