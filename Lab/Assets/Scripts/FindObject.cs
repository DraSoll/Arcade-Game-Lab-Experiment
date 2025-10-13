using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem myParticleSystem;
    public GameObject flashingLight;




    

 

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Echo")) // Assuming the colliding object has the tag "Player"
        {
            myParticleSystem.Play();
            StartCoroutine(FlashOn());
            Debug.Log("Particle System played on collision!");
        }
        if (other.CompareTag("Player")) // Assuming the colliding object has the tag "Player"
        {
           StartCoroutine(Player());
        }
    }
  
    IEnumerator Player()
    {
        
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }



 IEnumerator FlashOn()
    {
        flashingLight.active = true;
        yield return new WaitForSeconds(1);
        flashingLight.active = false; 

    }



}
