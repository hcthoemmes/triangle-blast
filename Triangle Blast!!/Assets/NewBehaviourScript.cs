using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{

    public static Vector2 pixelVectorToWorldVector(Vector2 pixelVector, Vector2 worldSize, Vector2 screenSize) { //pixelvector being the x and y size of the screen in pixels, worldvector being that in some sort of unit
        float worldX = (worldSize.x / screenSize.x) * pixelVector.x;
        float worldY = (worldSize.y / screenSize.y) * pixelVector.y;
        Vector2 worldVector = new Vector2(worldX, worldY);
        return worldVector;
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
