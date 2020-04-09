using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLoader : MonoBehaviour
{

    [Header("Pages")]
    public GameObject globalPanel;
    public GameObject countryPanel;
    public GameObject statePanel;
    public GameObject infoPanel;

    [Header("Navigation")]
    public Image globalImage;
    public Image countryImage;
    public Image stateImage;
    public Image infoImage;

    [Header("Text")]
    public Text globalText;
    public Text countryText;
    public Text stateText;
    public Text infoText;

    [Header("Images")]
    public Sprite globalSprite;
    public Sprite countrySprite;
    public Sprite stateSprite;
    public Sprite infoSprite;
    public Sprite globalSprite2;
    public Sprite countrySprite2;
    public Sprite stateSprite2;
    public Sprite infoSprite2;

    public static int page = 0;

    void Awake(){
        GlobalPage();
    }

    public void GlobalPage(){
        globalImage.GetComponent<Image>().sprite = globalSprite2;
        countryImage.GetComponent<Image>().sprite = countrySprite;
        stateImage.GetComponent<Image>().sprite = stateSprite;
        infoImage.GetComponent<Image>().sprite = infoSprite;

        globalText.color = new Color(0/255.0f,122/255.0f,255/255.0f);
        infoText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        countryText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        stateText.color = new Color(106/255.0f,105/255.0f,105/255.0f);

        globalPanel.SetActive(true);
        countryPanel.SetActive(false);
        statePanel.SetActive(false);
        infoPanel.SetActive(false);

        page = 0;
    }

    public void CountryPanel(){
        globalImage.GetComponent<Image>().sprite = globalSprite;
        countryImage.GetComponent<Image>().sprite = countrySprite2;
        stateImage.GetComponent<Image>().sprite = stateSprite;
        infoImage.GetComponent<Image>().sprite = infoSprite;

        countryText.color = new Color(0/255.0f,122/255.0f,255/255.0f);
        globalText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        infoText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        stateText.color = new Color(106/255.0f,105/255.0f,105/255.0f);

        globalPanel.SetActive(false);
        countryPanel.SetActive(true);
        statePanel.SetActive(false);
        infoPanel.SetActive(false);

        page = 1;
    }

    public void StatePanel(){
        globalImage.GetComponent<Image>().sprite = globalSprite;
        countryImage.GetComponent<Image>().sprite = countrySprite;
        stateImage.GetComponent<Image>().sprite = stateSprite2;
        infoImage.GetComponent<Image>().sprite = infoSprite;

        stateText.color = new Color(0/255.0f,122/255.0f,255/255.0f);
        globalText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        countryText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        infoText.color = new Color(106/255.0f,105/255.0f,105/255.0f);

        globalPanel.SetActive(false);
        countryPanel.SetActive(false);
        statePanel.SetActive(true);
        infoPanel.SetActive(false);

        page = 2;
    }

    public void InfoPanel(){
        globalImage.GetComponent<Image>().sprite = globalSprite;
        countryImage.GetComponent<Image>().sprite = countrySprite;
        stateImage.GetComponent<Image>().sprite = stateSprite;
        infoImage.GetComponent<Image>().sprite = infoSprite2;

        infoText.color = new Color(0/255.0f,122/255.0f,255/255.0f);
        globalText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        countryText.color = new Color(106/255.0f,105/255.0f,105/255.0f);
        stateText.color = new Color(106/255.0f,105/255.0f,105/255.0f);

        globalPanel.SetActive(false);
        countryPanel.SetActive(false);
        statePanel.SetActive(false);
        infoPanel.SetActive(true);

        page = 3;
    }
}
