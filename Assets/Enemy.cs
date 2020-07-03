using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 20;
    [SerializeField] int health = 2;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        //print("Particle collided with enemy " + gameObject.name);
        health--;
        scoreBoard.ScoreHit(scorePerHit);
        //todo find a new FX for getting hit
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
