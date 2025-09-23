using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float flapStrength = 5f;
    public float yBounds = -5f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        

       
    }
   

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) //This checks if the left mouse button has been clicked, and if so, flap. 
        {
           flap();

        }



    }



    private void flap () //This is a method that allows me to control how the bird flaps 
     {
         rb.linearVelocity = Vector2.up * flapStrength;
     }
     



}
