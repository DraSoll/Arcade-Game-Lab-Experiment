using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string WinScreenName = "Win"; 
    public string LoseScreenName = "Lose"; 
    public string StartScreen = "Start"; 
    public string LevelScreen = "Level"; 
    public static GameManager instance;
    public float timeDelay;
   
    public GameObject Tutorial;
    public GameObject exitTutorial;
    public GameObject Bat;
    

    public string sceneName;
   

    void Awake()
    {
       
        if (instance == null) //If instance doesn't exist, it sets this as its instance. 
        {
            instance = this;
        }

        // if (instance != null)
        // {
        //     Destroy.this(gameObject);
        // }
       
        
        DontDestroyOnLoad(this.gameObject); //This is to make sure that the game manager stays active in each scene
        
    }
    
    void Start()
    {
        

        
    }

    // Update is called once per frame
    

    
    public void GoToScene()
    {
       StartCoroutine(DelayScreenLoad());

    }
    public void LoseGame()
    {
        sceneName = LoseScreenName;
        StartCoroutine(DelayScreenLoad());

    }
    public void WinGame()
    {
        sceneName = WinScreenName;
        StartCoroutine(DelayScreenLoad());

    }

    public IEnumerator DelayScreenLoad() //This delays the screen load by whatever number I place in for the time delay
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneName);

    }
    public void QuitGame()
    {      
        // This will only work in a built application, not in the editor.
        Application.Quit(); 
        Debug.Log("Quit button pressed"); 
    }
    
    public void ShowTutorial()
    {
        Tutorial.SetActive(true);
        exitTutorial.SetActive(true);
        Bat.SetActive(false);

    }
    public void HideTutorial()
    {
        Tutorial.SetActive(false);
         exitTutorial.SetActive(false);
         Bat.SetActive(true);

    }



    void Update()
    {

        Scene screen = SceneManager.GetActiveScene();
  
    }


 

}

