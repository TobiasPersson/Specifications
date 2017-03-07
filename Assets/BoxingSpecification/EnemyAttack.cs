using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject LeftHand; //Object for the left hand. -Tobias
    public GameObject RightHand; //Object for the right hand. -Tobias
    public float maxTimer = 4; //Max allowed time for the timer. -Tobias
    public float punchSpeed = 0.5f; //Speed factor for the punches. -Tobias
    bool isLeft = false; //If it is the left hands turn to punch. -Tobias
    bool isPunching = false; //is it punching. -Tobias
    float timer;
    float maxTime;

	// Use this for initialization
	void Start () {
        maxTime = Random.Range(1.1f, maxTimer); //Sets time goal for the timer to a random number between 1 and specified max time. -Tobias
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime; //Increases the timer by 1 every second. -Tobias
        if (timer >= maxTime && !isPunching) //If the timer is equal to or more than the maxtime and it is not punching already. - Tobias
        {
            if (isLeft) //If it is the left hand's turn to punch. -Tobias
            {
                StartCoroutine(Punch(LeftHand,new Vector3(2,0,0)));
            }
            else //Otherwise it must be the right hand's turn to punch. -Tobias
            {
                StartCoroutine(Punch(RightHand, new Vector3(-2, 0, 0)));
            }
            isPunching = true; //Sets isPunching to true. To stop the program from punching with both hands at the same time. -Tobias
            maxTime = Random.Range(1, 5); //Sets new max time. -Tobias
            timer = 0; //Resets timer. -Tobias
            isLeft = !isLeft; //Changes which hand will punch next. -Tobias
        }
	}

    IEnumerator Punch(GameObject handObject, Vector3 originalPos) //Function for punching. -Tobias
    {
        while (Vector3.Distance(handObject.transform.position, Camera.main.transform.position) >= 1) { //If the distance between the camera and the hand is more than 1.-Tobias
            float step = punchSpeed * Time.deltaTime;
            handObject.transform.position = Vector3.MoveTowards(handObject.transform.position, Camera.main.transform.position, step); //Moves the hand towards the camera. -Tobias
            yield return null;
        }
        if (Vector3.Distance(handObject.transform.position, Camera.main.transform.position) <= 1f) //If the distance between the camera and the hand is less than 1. -Tobias
        {
            yield return new WaitForSeconds(0.5f); //Wait for half a second. -Tobias.
            isPunching = false;
            handObject.transform.position = originalPos; //Puts the hand back to its original position. -Tobias.
        }
    }
}
