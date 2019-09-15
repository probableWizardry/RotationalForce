using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows for allocating of players so we don't need 4 different player scripts
public enum players
{
    blue, red, green, yellow
}


public class Players : MonoBehaviour
{
    //Click and drag all pegs into this public to save a load of time.
    public Transform[] pegs;
    //Calls the enum for players
    public players p;
    //inPlay tests if the players have been activated by pressing their respective button
    public bool inPlay = false;
    //stores the player's button
    public KeyCode actionButton;
    //allows adding force to the rigidbody
    private Rigidbody rb;
    //dictates the speed at which players move
    public float speed;
    //private Transform targetHook;

    private void Start()
    {
        //Allocates each players hook key
        if (p == players.blue)
        {
            actionButton = KeyCode.Q;
        }
        else if (p == players.red)
        {
            actionButton = KeyCode.Z;
        }
        else if (p == players.green)
        {
            actionButton = KeyCode.P;
        }
        else if (p == players.yellow)
        {
            actionButton = KeyCode.M;
        }
    }

    void Update()
    {
        if (inPlay == true)
        {
            if (Input.GetKeyDown(actionButton))
            {
                //Run GetClosestHook and, well, GetClosestHook
                //Get the Vector3 Position of the closestHook from the result of GetClosest Hook
                
                //  !!FIGURE OUT HOW TO DETECT WHICH WAY THE PLAYER SHOULD ROTATE DEPENDING ON THEIR POSITION RELATIVE TO THE PEG!!

                transform.RotateAround(/*Vector3PositionOfClosestHook*/,/*Vector3Axis(probably Y)*/,speed * Time.deltaTime);
            }
        }
        if (inPlay == false)
        {
            inPlay = true;
            rb.AddForce(transform.forward * speed);
        }
    }

    
    //This code tests for the closest, I believe they are referred to as "pegs" in the scene, then returns the closest target. Don't entirely know how though
    Transform GetClosestHook(Transform[] hook)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in hook)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
