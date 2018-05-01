using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public static float speed;
    private float angle = 1f;
    private Rigidbody2D rb;
    public static float consumption;

    public GameObject bullet;
    private Vector2 bulletPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        consumption = -25f;
        speed = -0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            if (loaded())
            {
                fire();
            }   
        }
		
	}

    private void FixedUpdate()
    {
        float turn = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(turn * angle, 0f);

        float throttle = Input.GetAxisRaw("Vertical");
        if (throttle > 0)
        {
            speed = -0.7f;
        } else if(throttle == 0)
        {
            speed = -0.4f;
        } else
        {
            speed = -0.2f;
        }

    }

    bool loaded()
    {
        return (!GameObject.Find("Bullet(Clone)"));
    }

    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(0, 0.14f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("FuelTank"))
        {
            consumption = 75f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FuelTank"))
        {
           consumption = -25f;
        }
    }
}
