using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows for allocating of players so we don't need 4 different player scripts
public enum players
{
    blue, red, green, yellow
}


public class DestructionTest : MonoBehaviour
{
    //Click and drag all pegs into this public to save a load of time.
    public Transform[] pegs;
    //Calls the enum for players
    public players p;
    //inPlay tests if the players have been activated by pressing their respective button
    public bool inPlay = true;
    //stores the player's button
    public KeyCode actionButton;
    //allows adding force to the rigidbody
    public Rigidbody rb;
    //dictates the speed at which players move
    public float speed;
    //dictates the speed at which players rotate
    public float rotateSpeed;
    //This private holds the location of the peg selected by the proximity code;
    private Transform selectedPeg;

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
                selectedPeg = GetClosestHook(pegs);
                rb.velocity = Vector3.zero;
            }

            if (Input.GetKey(actionButton))
            {
                transform.RotateAround(selectedPeg.position, transform.up,90 * Time.deltaTime);
            }

            if (Input.GetKeyUp(actionButton))
            {
                transform.LookAt(selectedPeg);
                transform.Rotate(new Vector3(0, -90, 0));
                rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
            }
        }
        if (inPlay == false)
        {
            inPlay = true;
            rb.AddForce(transform.forward * speed);
        }
    }

    //balls destroy each other
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BlueBird")
        {
            Debug.Log("Blue has Lost Life");
            GM.instance.BlueLoseLife();
        }
        else if(collision.gameObject.tag == "RedBird")
        {
            Debug.Log("Red has Lost Life");
            GM.instance.RedLoseLife();
        }
        else if (collision.gameObject.tag == "GreenBird")
        {
            Debug.Log("Green has Lost Life");
            GM.instance.GreenLoseLife();
        }
        else if (collision.gameObject.tag == "YellowBird")
        {
            Debug.Log("Yeloow has Lost Life");
            GM.instance.YellowLoseLife();
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
