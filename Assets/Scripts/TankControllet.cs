using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllet : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0f, speed);
        speed = PlaneController.speed;
        //Destroy(gameObject, 15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
