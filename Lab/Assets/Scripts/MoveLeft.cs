using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveLeft : MonoBehaviour
{
    //These are variables that are to be able to be changed if 
    public float speed = 3f;
    public float leftBounds = -11f;
    public float Y = -5f;
    public bool Background = false;
    public float OriginX = 155;
    public GameObject game;
    public string spawner =  "enemy";


    // This is a method that is used to move whatever object left and then destroy it once it is out of the bounds 
    private void moveLeft()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBounds)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == spawner)
        {
            summonNew();
            
        }
    }

    private void summonNew()
    {
        Instantiate(game, new Vector3(OriginX, Y, 0),transform.rotation);
    }
 
    // Update is called once per frame
    // This is just telling the object that every update, either move left or right. Left is the normal gameplay, right is when it is reversed
    void Update()
    {
       moveLeft();

    }
}
