using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    public Page currentPage;
    public float typeTextWaitTime;

    [Header("UI")]
    public GameObject backgroundImage;
    public GameObject mainText;
    public GameObject optionHost;
    public GameObject otherPersonImage;
    public GameObject previousButton;
    public GameObject nextButton;
    public GameObject fadePanel;


    [Header("Prefabs")]
    public GameObject optionPrefab;

    [Header("Music")]
    public AudioClip typingSound;
    [HideInInspector]
    public AudioClip backgroundSound;

    private int currentTextPage;
    private bool typing;
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
            if (currentTextPage ==0)
            {
                previousButton.SetActive(false);
            }
            else
            {
                previousButton.SetActive(true);
            }


            //next button management
            if (currentTextPage == currentPage.numOfPages-1)
            {
                nextButton.SetActive(false);
            }
            else
            {
                nextButton.SetActive(true);
            }
        }

    }


    void TypingSound()
    {
        if(typing)
        {
           
        }
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
    /// Typewriter effect for the main text
    /// </summary>
    /// <returns></returns>
    IEnumerator TypeText()
    {
        typing = true;
        mainText.GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 0; i < currentPage.texts[currentTextPage].Length; i++)
        {
            mainText.GetComponent<TextMeshProUGUI>().text += currentPage.texts[currentTextPage][i];
            yield return new WaitForSeconds(typeTextWaitTime);
        }

        typing = false;
    }



    /// <summary>
    /// Reads the information on the page and displays it on screen 
    /// </summary>
    public void ReadPage()
    {
        //Trigger fade effect
        fadePanel.GetComponent<Animator>().SetBool("FadeIn",true);
        currentTextPage = 0;
        typing = false;
        StartCoroutine(IE_ReadPage());
        
    }

    IEnumerator IE_ReadPage()
    {
        yield return new WaitForSeconds(1.5f);

        ResetPageOfText();
        //Change music
        if(backgroundSound!=null && backgroundSound!= currentPage.pageMusic) //if sound changed on the page
        {
            backgroundSound = currentPage.pageMusic;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = backgroundSound;
            GetComponent<AudioSource>().Play();
        }

        //Change image
        backgroundImage.GetComponent<Image>().sprite = currentPage.backgroundImage;
        //Change maintext
        StopCoroutine("TypeText");
        currentTextPage = 0;
        StartCoroutine("TypeText");
        currentPage.numOfPages = currentPage.texts.Count;

        //Clear old options
        foreach (Transform child in optionHost.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //add new options
        if (currentPage.options.Count != 0)
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
        if (currentPage.talkingToSomeone)
        {
            otherPersonImage.SetActive(true);
            otherPersonImage.GetComponent<Image>().sprite = currentPage.otherPersonSprite;
        }
        else
        {
            otherPersonImage.SetActive(false);
        }


        fadePanel.GetComponent<Animator>().SetBool("FadeIn", false);
    }



    public void NextPageOfText()
    {
        StopCoroutine("TypeText");
        currentTextPage += 1;
        StartCoroutine("TypeText");
    }

    public void PreviousPageOfText()
    {
        StopCoroutine("TypeText");
        currentTextPage -= 1;
        StartCoroutine("TypeText");
    }

  
}
