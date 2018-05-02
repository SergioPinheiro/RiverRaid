using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllet : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private AudioSource audioS;

    public GameObject explosion;
    private Vector2 explosionPos;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0f, speed);
        speed = PlaneController.speed;
        //Destroy(gameObject, 15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioS.Play();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreController.score += 20;
            Destroy(gameObject);
            explosionPos = transform.position;
            explosionPos += new Vector2(0f, 0f);
            Instantiate(explosion, explosionPos, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioS.Stop();
        }
    }
}
