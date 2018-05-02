using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

    private float consumption;
    private float max;
    private float min;

    RectTransform m_RectTransform;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_RectTransform = GetComponent<RectTransform>();
        max = 80f;
        min = -80f;

    }
	
	// Update is called once per frame
	void Update () {

        consumption = PlaneController.consumption;

        if (isMin() && consumption < 0)
        {
            rb.velocity = new Vector2(0f, 0f);
            PlaneController.gameover = true;
        } else if (isMax() && consumption > 0)
        {
            rb.velocity = new Vector2(0f, 0f);
            //Debug.Log("Max");
        }
        else
        {
            rb.velocity = new Vector2(consumption, 0f);
            //Debug.Log("Consumming");
        }
        //rb.velocity = new Vector2(consumption, 0f);
        //rb.velocity = new Vector2(0f, 0f);
        //Debug.Log(consumption);
    }

    bool isMax()
    {
        return m_RectTransform.anchoredPosition.x >= max;
    }

    bool isMin()
    {
        return m_RectTransform.anchoredPosition.x <= min;
    }
}
