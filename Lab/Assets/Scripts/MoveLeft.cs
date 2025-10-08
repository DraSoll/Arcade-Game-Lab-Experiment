using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveLeft : MonoBehaviour
{
    //These are variables that are to be able to be changed if 
    public float speed = 3f;
    private bool movingLeft = false;
    SpriteRenderer spriteRenderer;



    // This is a method that is used to move whatever object left and then destroy it once it is out of the bounds 
    private void moveLeft()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Debug.Log("movingLeft");

    }

    private void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Debug.Log("movingRight");
    }

    public void SetDirection(string Direction)
    {
        Debug.Log("SetDirection: " + Direction);
        if (Direction == "Left")
        {
            movingLeft = true;
        }
        if (Direction == "Right")
        {
            movingLeft = false;
        }
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall")) // Assuming the colliding object has the tag "Player"
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
      
        moveRight();
        spriteRenderer.flipX = false;


    }

    
}
