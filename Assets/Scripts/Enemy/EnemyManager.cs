using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    private float MAX_X;
    private float MAX_Y;
    private float current_spawnTime;
    private bool canSpawn;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject EnemyPrefeb;


	// Use this for initialization
	void Start () {
        spawnTime = 0.70f;
        current_spawnTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime += Time.deltaTime;
        if(spawnTime > current_spawnTime)
        {
            canSpawn = true;
        }
        if (canSpawn == true)
        {
            float y = Random.Range(-4.20f, 4.20f);
            float x = 9.50f;
            SpawnEnemy(EnemyPrefeb, new Vector3(x, y, 90));
            canSpawn = false;
            spawnTime = 0f;
        }
	}

    void SpawnEnemy(GameObject prefeb, Vector2 position){
        Instantiate(prefeb, position, Quaternion.identity);
    }
}
