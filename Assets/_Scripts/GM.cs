using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public int blueLives = 3;
    public int redLives = 3;
    public int yellowLives = 3;
    public int greenLives = 3;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;
    public Text blueText;
    public Text redText;
    public Text yellowText;
    public Text greenText;

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

    public void RedLoseLife()
    {
      if(redLives > 1)
      {
        redLives--;
        redText.text = "Lives: " + redLives;
      }
      else if(redLives < 1)
      {
        Destroy(red);
      }
    }

    public void YellowLoseLife()
    {
      if(yellowLives > 1)
      {
        yellowLives--;
        yellowText.text = "Lives: " + yellowLives;
      }
      else if(yellowLives < 1)
      {
        Destroy(yellow);
      }
    }

    public void GreenLoseLife()
    {
      if(greenLives > 1)
      {
        greenLives--;
        greenText.text = "Lives: " + greenLives;
      }
      else if(greenLives < 1)
      {
        Destroy(green);
      }
    }

}
