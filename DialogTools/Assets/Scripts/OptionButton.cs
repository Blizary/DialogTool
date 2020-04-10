using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [HideInInspector]
    public Page nextPage;

    

    /// <summary>
    /// Called on button pressed
    /// </summary>
    public void NextPage()
    {
        GameObject worldController = GameObject.FindGameObjectWithTag("GameController"); //finds the world controller
        worldController.GetComponent<WorldController>().UpdatePage(nextPage); //calls the update page function
    }
}
