using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    public Page currentPage;

    [Header("UI")]
    public GameObject backgroundImage;
    public GameObject mainText;
    public GameObject optionHost;
    public GameObject otherPersonImage;
    public GameObject previousButton;
    public GameObject nextButton;


    [Header("Prefabs")]
    public GameObject optionPrefab;


    private string newText;
    // Start is called before the first frame update
    void Start()
    {
        ReadPage();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPageOfText();

    }

    /// <summary>
    /// Sets the page number of the text back to 1
    /// </summary>
    void ResetPageOfText()
    {
        mainText.GetComponent<TextMeshProUGUI>().pageToDisplay = 1;
    }
    

    /// <summary>
    /// Check the current pages of the text and hide and displays the buttons accordingly
    /// </summary>
    void CheckPageOfText()
    {
        if(currentPage.numOfPages ==0)
        {
            previousButton.SetActive(false);
            nextButton.SetActive(false);
        }
        else
        {
            //previous button management
            if (mainText.GetComponent<TextMeshProUGUI>().pageToDisplay == 1)
            {
                previousButton.SetActive(false);
            }
            else
            {
                previousButton.SetActive(true);
            }


            //next button management
            if (mainText.GetComponent<TextMeshProUGUI>().pageToDisplay == currentPage.numOfPages)
            {
                nextButton.SetActive(false);
            }
            else
            {
                nextButton.SetActive(true);
            }
        }


       

    }





    /// <summary>
    /// Updates the current page and runs the read page function
    /// Called outside
    /// </summary>
    public void UpdatePage(Page _newPage)
    {
        currentPage = _newPage;
        ResetPageOfText();
        ReadPage();

    }

    /// <summary>
    /// Reads the information on the page and displays it on screen 
    /// </summary>
    public void ReadPage()
    {
        //Change image
        backgroundImage.GetComponent<Image>().sprite = currentPage.backgroundImage;
        //Change maintext
        mainText.GetComponent<TextMeshProUGUI>().text = currentPage.mainText;
        //Clear old options
        foreach (Transform child in optionHost.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //add new options
        if(currentPage.options.Count!=0)
        {
            for (int i = 0; i < currentPage.options.Count; i++)
            {
                GameObject newOption = Instantiate(optionPrefab, optionHost.transform);
                newOption.GetComponent<OptionButton>().nextPage = currentPage.options[i].nextPage;
                newOption.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentPage.options[i].optionText;

            }
        }
        else
        {
            Debug.Log("THERE ARE NO OPTIONS FOR THIS PAGE");
        }

        //Enable or disable other person image
        if(currentPage.talkingToSomeone)
        {
            otherPersonImage.SetActive(true);
            otherPersonImage.GetComponent<Image>().sprite = currentPage.otherPersonSprite;
        }
        else
        {
            otherPersonImage.SetActive(false);
        }
    }


    public void NextPageOfText()
    {
        mainText.GetComponent<TextMeshProUGUI>().pageToDisplay += 1;
    }

    public void PreviousPageOfText()
    {
        mainText.GetComponent<TextMeshProUGUI>().pageToDisplay -= 1;
    }

  
}
