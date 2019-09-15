using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyBirds : MonoBehaviour
{

    public int blueLives = 3;
    public int redLives = 3;
    public int greenLives = 3;
    public int yellowLives = 3;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;
    public Text blueText;
    public Text redText;
    public Text yellowText;
    public Text greenText;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void BlueLoseLife()
    {
        if(blueLives > 1)
        {
            blueLives--;
            blueText.text = "Lives: " + blueLives;
        }
        else if(blueLives < 1)
        {
            Destroy(blue);
        }
    }
}
