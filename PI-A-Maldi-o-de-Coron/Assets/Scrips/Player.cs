using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int velocidade = 7;

    [SerializeField]
    GameObject Potion;

    [SerializeField]
    GameObject Ref;

    [SerializeField]
    int direction = 1;

    [SerializeField]
    public bool isJumping;

    [SerializeField]
    public bool doubleJump;

    [SerializeField]
    public float jumpForce = 15;

    // vida do player
    [SerializeField]
     public int hp = 5;
    
    // Barra de corações
    [SerializeField]
    Image h1, h2, h3, h4, h5;
    
    //Painel de game over
    [SerializeField]
    GameObject gameOver;
    
    //Se o player está vivo
    bool isAlive = true;

     // Menu de Pausa do game

    [SerializeField]
    private bool isPaused = false;
    public GameObject pausePanel;
    public string cena;

    private Animator animationController;

    void Start()
    {
        animationController = GetComponent<Animator>();

    // menu de pausa do game
       Time.timeScale = 1f;
    //ovo
    }

    // Update is called once per frame
    void Update()
    {
        // morte do player
          if (hp <= 0){
            //Destroy (this.gameObject);
            isAlive = false;
            gameOver.SetActive(true);
            animationController.SetTrigger("death");
        }
        //Corações
        if(hp == 4){
           h5.enabled = false;
        }
        if(hp == 3){
           h4.enabled = false;
        }
        if(hp == 2){
           h3.enabled = false;
        }
        if(hp == 1){
           h2.enabled = false;
        }
        if(hp <= 0){
           h1.enabled = false;
        } 
        
        //menu de pausa
        if (!isPaused && isAlive == true)
        {
            Move();
            Jump();

            //animações do player
            if (Input.GetAxis("Horizontal")< 0 || Input.GetAxis("Horizontal")> 0 )
            {
                animationController.SetBool("moving", true);
            }
            else{
                animationController.SetBool("moving", false);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
                direction = 0;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (direction == 1)
                {
                    GameObject PotionInsta = Instantiate(Potion, Ref.transform.position, Potion.transform.rotation);
                    PotionInsta.GetComponent<Rigidbody2D>().AddForce(new Vector3(5, 5, 0f), ForceMode2D.Impulse);
                }
                else if (direction == 0)
                {
                    GameObject PotionInsta = Instantiate(Potion, Ref.transform.position, Potion.transform.rotation);
                    PotionInsta.GetComponent<Rigidbody2D>().AddForce(new Vector3(-5, 5, 0f), ForceMode2D.Impulse);
                }
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                if (direction == 1)
                {
                    GameObject PotionInsta = Instantiate(Potion, Ref.transform.position, Potion.transform.rotation);
                    PotionInsta.GetComponent<Rigidbody2D>().AddForce(new Vector3(5, 0, 0f), ForceMode2D.Impulse);
                }
                else if (direction == 0)
                {
                    GameObject PotionInsta = Instantiate(Potion, Ref.transform.position, Potion.transform.rotation);
                    PotionInsta.GetComponent<Rigidbody2D>().AddForce(new Vector3(-5, 0, 0f), ForceMode2D.Impulse);
                }
            }

            //menu de pausa
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseScreen();
            }

        }
    }
    //Menu de pausa
    void PauseScreen()
    {
      if (isPaused)
      {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      }
      else
      {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      }
    }
    /*  //Menu de pausa
    public void BackToMenu()
    {
        SceneManager.LoadScene(cena);
    }
    */
    void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * velocidade * Time.deltaTime, 0f);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, transform.rotation.z);
            direction = 0;
            
        }
       
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.z);
            direction = 1;
        }
        
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isJumping)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (isJumping)
            {
                if (doubleJump)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isJumping = false;
        }
         if(collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
        } 
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isJumping = true;
            doubleJump = true;
        }
        
    }
    
}
