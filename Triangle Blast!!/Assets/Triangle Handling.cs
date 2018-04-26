using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//should this be part of the PlayerHandling class? do consider that
public class TriangleHandling : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(TriangleArea(5.7f, 7.0f));
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(TriangleArea(5.7f, 7.0f));
    }

    public float TriangleArea(float b, float h) {
        //calculate the area of the triangle shot
        //Area = 0.5*b*h
        return 0.5f * b * h;
    }

    public float TriangleAngles(float angle1, float angle2, float angle3) {
        //calculate the angles of the triangle and give the player one to solve
        //this may need to be done in PlayerHandling due to all the rays and vectors
        //passing all the data to another script might be troublesome

        //make a random 1 through three to choose an angle to pass 
        float chosenAngle = 180 - angle1 - angle2;

        return 0.0f;
    }

    public string TriangleTypes (float firstAngle, float secondAngle, float thirdAngle) {
        if (firstAngle == 60 
            && secondAngle == 60) {
            return "Equilateral";
        } else if (firstAngle == secondAngle
            && secondAngle != thirdAngle) {
            return "Isosceles";
        } 
        return "Scalene";
    }
}
