using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    [SerializeField] private float speed;
    //private BoxCollider2D box_coll;
    //private Rigidbody2D body;
    	
	void Start()
    {
        //box_coll = GetComponent<BoxCollider2D>();
        //body = GetComponent<Rigidbody2D>();
    }
	void Update () {
        Move();
	}
   void Move()
    {
        Vector2 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
}
