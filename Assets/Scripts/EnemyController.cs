using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;

    public GameObject explosion;
    private Vector2 explosionPos;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0f, speed);
        speed = PlaneController.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
            explosionPos = transform.position;
            explosionPos += new Vector2(0f, 0f);
            Instantiate(explosion, explosionPos, Quaternion.identity);
        }
    }
}
