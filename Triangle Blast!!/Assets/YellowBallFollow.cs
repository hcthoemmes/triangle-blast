using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//could the issue with mousePosition be related to the EventSystem? investigate further

public class YellowBallFollow : MonoBehaviour {

    Camera camera;

    // Use this for initialization
    void Start () {
        camera = Camera.main;
        Debug.Log(camera.pixelRect);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Input.mousePosition;
	}
}
