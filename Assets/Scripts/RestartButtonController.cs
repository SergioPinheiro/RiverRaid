using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour {

    private Scene scene;

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();
        //gameObject.active = false;
    }

    private void Update()
    {

    }

    // Update is called once per frame
    public void OnClick () {
        Application.LoadLevel(scene.name);
	}
}
