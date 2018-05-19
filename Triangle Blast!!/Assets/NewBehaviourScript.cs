using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    public static float pixelLengthToScreenLength(float pixelLength, Vector2 worldSize, Vector2 screenSize) {
        float ratio = (worldSize.x / screenSize.x) * pixelLength;        
        return ratio;
    }

    public static Vector2 coordinateShift(float worldWidth, float worldHeight, Vector2 originalPoint) {
        Vector2 dividedRect = new Vector2(worldHeight / 2, worldWidth / 2);
        Vector2 movedPoint = originalPoint - dividedRect;
        return movedPoint;
    } 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
