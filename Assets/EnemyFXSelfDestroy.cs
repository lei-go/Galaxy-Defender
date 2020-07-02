using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFXSelfDestroy : MonoBehaviour
{
    [Tooltip("seconds")][SerializeField] float delayOnDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayOnDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
