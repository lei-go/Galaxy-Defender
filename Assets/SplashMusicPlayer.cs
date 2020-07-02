using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashMusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<SplashMusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    void Start()
    {
        Invoke("LoadFirstScene",5f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
