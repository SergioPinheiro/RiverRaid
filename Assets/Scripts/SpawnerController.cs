using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject ship;
    public GameObject chopper;
    public GameObject tank;

    public float spawnRate = 1f;
    private Vector2 spawnPos;
    private float nextSpawn = 0.0f;
    private float randomX;

    private int score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score = ScoreController.score;
        if (Time.time > nextSpawn)
        {
            
            nextSpawn = (Time.time + spawnRate)/(score * 0.00001f + 1);
            randomX = Random.Range(-6.9f, -5.15f);
            spawnPos = new Vector2(randomX, transform.position.y);
            Instantiate(randomObj(), spawnPos, Quaternion.identity);

        }

    }

    GameObject randomObj()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                return ship;
            case 2:
                return chopper;
            default:
                return tank;
                break;
        }
    }
}
