using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//could the issue with mousePosition be related to the EventSystem? investigate further

public class YellowBallFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Input.mousePosition.normalized;
	}
}
