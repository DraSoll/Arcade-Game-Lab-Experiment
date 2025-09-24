using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float flapStrength = 5f;
    public float yBounds = -5f;
    public float speed = 5f;
    SpriteRenderer spriteRenderer;

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


        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            flap();
        }
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
    }


    private void flap() //This is a method that allows me to control how the bird flaps 
    {
        rb.linearVelocity = Vector2.up * flapStrength;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //GameManager.Instance.GameOver();
            Debug.Log("GameOver");
        }
    }


















}
