using UnityEngine;
using static UnityEngine.UI.Image;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float flapStrength = 5f;
    public float speed = 5f;

    SpriteRenderer spriteRenderer;
    private bool facingright;

    public ParticleSystem myParticleSystem;

    private bool KeycardFound = false;
    private bool UniformFound = false;
    private bool KnifeFound = false;
    private int ObjectNumber;
    public MoveLeft MovementOfEcho;

    public GameObject echo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        facingright = true;
    }


    // Update is called once per frame
    void Update()
    {
    
        BatMove();


       
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Echo());

        }
        
    }


    IEnumerator Echo()
    {
        Vector3 position = transform.position;


        
        
        if (facingright == true)
        {
            Instantiate(echo, position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, transform.rotation);
        } else
        {
            Instantiate(echo, position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.5f);
            Instantiate(echo, position, Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(0.5f);
        }
    }


    void LateUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0)
        {
            spriteRenderer.flipX = false;
            MovementOfEcho.SetDirection("Right");
            facingright = true;


        }
           
        if (move < 0)
        {
            spriteRenderer.flipX = true;
            MovementOfEcho.SetDirection("Left");
            facingright = false;

        }
    }



    private void BatMove()
    {
        float move = Input.GetAxis("Horizontal"); // A/D 
        transform.Translate(Vector2.right * move * speed * Time.deltaTime); //Use Vector3 for 3D games
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            flap();
        }
    }


    private void flap() //This is a method that allows me to control how the bird flaps 
    {
        rb.linearVelocity = Vector2.up * flapStrength;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Keycard"))
        {
            KeycardFound =true;
            
            Debug.Log("Object 1 Found!");
            GameManager.instance.KeycardObject1Found();

        }
        if (col.gameObject.CompareTag("Uniform"))
        {
            UniformFound =true;
            
            Debug.Log("Object 2 Found!");
            GameManager.instance.UniformObject2Found();

        }
        if (col.gameObject.CompareTag("Knife"))
        {
            KnifeFound =true;
            
            Debug.Log("Object 3 Found!");
            GameManager.instance.KnifeObject3Found();

        }
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.LoseGame();
            Debug.Log("GameOver");
        }

        if (col.gameObject.CompareTag("Finish"))
        {
            if (KeycardFound == true)
            {
                
                        GameManager.instance.WinGame();
                    
                
                
            }
        }
        
    }

}
