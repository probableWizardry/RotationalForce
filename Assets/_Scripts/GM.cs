using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    //Lives counter
    public int blueLives = 3;
    public int redLives = 3;
    public int yellowLives = 3;
    public int greenLives = 3;
    //how many players there are
    public int players = 4;
    //attachment for the Birds Game object
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;
    //attachment for the text
    public Text blueText;
    public Text redText;
    public Text yellowText;
    public Text greenText;

    //adds static Null to assign to other scripts
    public static GM instance = null;

    //adding winning and Losing elements
    public GameObject winner;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    public void BlueLoseLife()
    {
        if (blueLives > 1)
        {
            blueLives--;
            blueText.text = "Lives: " + blueLives;
        }
        else if (blueLives <= 1)
        {
            blueLives--;
            blueText.text = "Lives: " + blueLives;
            Destroy(blue);
        }
        if (blueLives == 0)
        {
            blueText.text = "Lives: " + "Dead";
        }
    }

    public void RedLoseLife()
    {
        if (redLives > 1)
        {
            redLives--;
            redText.text = "Lives: " + redLives;
        }
        else if (redLives <= 1)
        {
            redLives--;
            redText.text = "Lives: " + redLives;
            Destroy(red);
        }
        if (redLives == 0)
        {
            redText.text = "Lives: " + "Dead";
        }
    }

    public void YellowLoseLife()
    {
        if (yellowLives > 1)
        {
            yellowLives--;
            yellowText.text = "Lives: " + yellowLives;
        }
        else if (yellowLives <= 1)
        {
            yellowLives--;
            yellowText.text = "Lives: " + yellowLives;
            Destroy(yellow);
        }
        if (yellowLives == 0)
        {
            yellowText.text = "Lives: " + "Dead";
        }
    }

    public void GreenLoseLife()
    {
        if (greenLives > 1)
        {
            greenLives--;
            greenText.text = "Lives: " + greenLives;
        }
        else if (greenLives <= 1)
        {
            greenLives--;
            greenText.text = "Lives: " + greenLives;
            Destroy(green);
        }
        if (greenLives == 0)
        {
            greenText.text = "Lives: " + "Dead";
        }
    }


    //Once There is only one person left displays a game over screen
    void CheckGameOver()
    {
        if (players < 2)
        {
            winner.SetActive(true);
            Time.timeScale = .25f;
            SceneManager.LoadScene(0);
        }
    }
}
