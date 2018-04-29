using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public float speed = 1f;
    Rigidbody2D rb;

    public GameObject bullet;
    Vector2 bulletPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(turn * speed, 0f);
        
    }

    bool loaded()
    {
        return (!GameObject.Find("Bullet(Clone)"));
    }

    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(0, 0.04f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
}
