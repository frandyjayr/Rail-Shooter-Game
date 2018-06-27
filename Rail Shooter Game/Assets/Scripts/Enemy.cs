using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int healthPoints = 20;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<BoxCollider>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other) {
        healthPoints--;
        if (healthPoints <= 0) {
            killEnemy();
        }

    }

    private void killEnemy() {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
