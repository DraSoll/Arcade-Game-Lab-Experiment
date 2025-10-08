using UnityEngine;

public class EchoMovements : MonoBehaviour
{
    private bool movingLeft = false;
    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (movingLeft == true)
        //{
        //    transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}
        //if (movingLeft == false)
        //{
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);

        //}
        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
