using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<BoxCollider>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other) {
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        print("Destroyed Enemy" + gameObject.name);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
