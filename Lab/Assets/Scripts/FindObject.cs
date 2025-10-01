using UnityEngine;

public class FindObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem myParticleSystem;

    void Start()
    {


    
}

// Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the colliding object has the tag "Player"
        {
            myParticleSystem.Play();
            Debug.Log("Particle System played on collision!");
        }
    }



}
