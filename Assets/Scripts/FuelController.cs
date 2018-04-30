using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

    public float consumption;
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

        if (m_RectTransform.anchoredPosition.x > min && m_RectTransform.anchoredPosition.x < max)
        {
            rb.velocity = new Vector2(consumption, 0f);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        Debug.Log(min);
    }
}
