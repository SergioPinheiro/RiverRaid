using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public static float speed;
    private float angle = 1f;
    private Rigidbody2D rb;
    public static float consumption;
    private float defaultConsumption = -0.01f;
    private float defaultRefuel= 0.05f;

    public GameObject bullet;
    private Vector2 bulletPos;
    public float reloadTime = 0.5f;
    private float nextBullet = 0.0f;

    public Sprite toRight;
    public Sprite toLeft;
    private Sprite forward;

    public static string text;

    public static bool gameover;

    private AudioSource audioS;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        consumption = defaultConsumption;
        speed = -0.5f;
        forward = gameObject.GetComponent<SpriteRenderer>().sprite;
        text = "";
        gameover = false;
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && Time.time > nextBullet)
        {
            if (bulletEnd())
            {
                nextBullet = Time.time + reloadTime;
                fire();
            }   
        }
		
	}

    private void FixedUpdate()
    {
        float turn = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(turn * angle, 0f);
        if (turn > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = toRight;
        }
        else if (turn == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forward;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = toLeft;
        }

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
        if (gameover)
        {
            gameOver();
        }


    }

    bool bulletEnd()
    {
        return (!GameObject.Find("Bullet(Clone)"));
    }

    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(0, 0.14f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
        audioS.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            gameover = true;
            gameOver();
        }

        if (collision.gameObject.CompareTag("FuelTank"))
        {
            consumption = defaultRefuel;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FuelTank"))
        {
           consumption = defaultConsumption;
        }
    }

    public void gameOver()
    {
        speed = 0f;
        text = "Game Over!";
        consumption = 0f;
        Destroy(gameObject);
        GameObject.Find("EnemySpawner").active = false;
    }
}
