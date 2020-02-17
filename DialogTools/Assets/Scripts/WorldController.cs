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


    [Header("Prefabs")]
    public GameObject optionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ReadPage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Updates the current page and runs the read page function
    /// Called outside
    /// </summary>
    public void UpdatePage(Page _newPage)
    {
        currentPage = _newPage;
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
}
