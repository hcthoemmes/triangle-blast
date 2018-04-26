using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandling : MonoBehaviour {

    TriangleHandling triHandling = new TriangleHandling();

    public EnemyHandling enemy;

    public Button optionOne; //use for difficulty selection as well as questions
    public Button optionTwo;
    public Button optionThree;

    public CanvasGroup buttons;

    private LineRenderer aimLine; //draw a line
    public RaycastHit hit;
    public Ray shot;

    // Use this for initialization
    void Start() {
        Button option1Button = optionOne.GetComponent<Button>();
        string option1Text = optionOne.GetComponentInChildren<Text>().text;

        Button option2Button = optionTwo.GetComponent<Button>();
        string option2Text = optionTwo.GetComponentInChildren<Text>().text;

        Button option3Button = optionThree.GetComponent<Button>();
        string option3Text = optionThree.GetComponentInChildren<Text>().text;

        option1Text = "Start Game: Mode 1";
        option1Button.onClick.AddListener(GameStart);

        option2Text = "Start Game: Mode 2";
    }
    //write a function to make new sides as needed (or do we just get the one triangle?)

    void GameStart() {
        buttons.alpha = 0;
        PlayerTurn();
    }

    public void PlayerTurn() {
        GameObject player = GameObject.Find("LaserShooter");

        Vector2 side1; //side from shot to first point of impact
        Vector2 side2; //side from first p.o.i. to second p.o.i.
        Vector2 side3; //side from second p.o.i. to shot position
        Vector2 laserDirection = Input.mousePosition; //where the cursor is pointing, use for direction in RaycastHit2D statements
        Vector2 laserLocation = player.transform.localPosition;
                
        Debug.Log("It is now the player's turn");
        buttons.alpha = 0;
        if (Input.GetButtonDown("Fire")) {

            Debug.Log("Fire button pressed");

           RaycastHit2D shot = Physics2D.Raycast(laserLocation, laserDirection);
           Ray2D ray = new Ray2D(shot.point, laserDirection);

            //Ray shot = Camera.main.ScreenPointToRay(Input.mousePosition); this doesnt work (however do use this for wandering)
            //do something here that shoots along the xy axis rather than the z

            if (shot.transform.tag == "Wall")/*cast the ray at the specified direction*/ {
                Debug.Log("Shot hit wall");

                side1 = laserDirection;

                //put the reflection stuff from studio41 back here
                laserDirection = Vector2.Reflect(laserDirection, shot.normal);
                side2 = laserDirection;

                laserDirection = Vector2.Reflect(laserDirection, shot.normal);

                Ray2D side3ray = new Ray2D(shot.point, laserDirection);
                side3 = laserDirection;

                RaycastHit2D hit;

                float angle1 = Vector2.Angle(side1, side2);
                float angle2 = Vector2.Angle(side2, side3);
                float angle3 = Vector2.Angle(side3, side1);

                if (triHandling.TriangleTypes(angle1, angle2, angle3) == "Equilateral") {
                    System.Random rand1 = new System.Random();
                } else if (triHandling.TriangleTypes(angle1, angle2, angle2) == "Isoceles") {
                    System.Random rand2 = new System.Random();
                }
            }
            enemy.EnemyTurn();
        }
    }

    public void GameOver() {
        Debug.Log("Game Over!!");
        //print gameover to screen, display buttons to play
    }
}