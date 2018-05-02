using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private AudioSource audioS;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //audioS.Play();
        rb.velocity = new Vector2(0f, speed);
        speed = PlaneController.speed;
        Destroy(gameObject, 1f);
	}
}
