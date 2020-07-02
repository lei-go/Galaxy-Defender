using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] float reloadDelay = 1f;
    [Tooltip("FX-prefabs On Player")][SerializeField] GameObject deathFX;
    
        private void OnTriggerEnter(Collider other) 
    {
        print("triggered");     
        SendMessage("OnPlayerDeath");   
        deathFX.SetActive(true);
        Invoke("ReloadScene",reloadDelay);   
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

}
