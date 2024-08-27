using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBulletDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Bullet") || coll.CompareTag("Enemy"))
        {
            coll.gameObject.SetActive(false);
            GameObject.DestroyObject(coll.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
