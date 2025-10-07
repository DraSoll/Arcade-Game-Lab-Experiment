using UnityEngine;
using static UnityEngine.UI.Image;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float flapStrength = 5f;
    public float speed = 5f;

    SpriteRenderer spriteRenderer;

    public ParticleSystem myParticleSystem;

    private bool KeycardFound = false;
    private bool object2Found = false;
    private bool object3Found = false;
    private int ObjectNumber;


    public GameObject echo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        Instantiate(echo, new Vector3(0, 0, 0), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(echo, new Vector3(0, 0, 0), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(echo, new Vector3(0, 0, 0), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(echo, new Vector3(0, 0, 0), transform.rotation);
    }


    void LateUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0) spriteRenderer.flipX = false;
        if (move < 0) spriteRenderer.flipX = true;
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
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.LoseGame();
            Debug.Log("GameOver");
        }

        if (col.gameObject.CompareTag("Finish"))
        {
            if (KeycardFound = true)
            {
                GameManager.instance.WinGame();
            }
        }
        
    }

}
