using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyHandling : MonoBehaviour {

    public int health = 1;
    public Vector2 position = new Vector2();
    public PlayerHandling player;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
	    
	}

    public void EnemyTurn() {
        Vector2 playerPos = player.transform.localPosition;
        if (health == 0) {
            Destroy(this);
        }

        if (position == playerPos) {
            player.GameOver();
        }

        player.PlayerTurn();
    }
}
