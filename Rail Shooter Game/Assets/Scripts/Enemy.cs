using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<BoxCollider>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other) {
        print("Destroyed Enemy" + gameObject.name);
        Destroy(gameObject);
    }
}
