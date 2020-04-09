using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetCountries : MonoBehaviour
{

    private const string URL = "https://corona.lmao.ninja/countries?sort=cases";

    public GameObject countries;
    public GameObject button;
    public List<Sprite> flags = new List<Sprite>();

    public static List<GameObject> countryObjects = new List<GameObject>();

    public void Start()
    {
        button.SetActive(false);
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        if(req.isDone) {
            var data = JsonUtility.FromJson<RootObject>("{ \"countries\": " + req.text + "}");

            for(int i = 0; i < data.countries.Count; i++){
                if(data.countries[i].country.ToLower() != "world") {
                    GameObject newButton = Instantiate(button) as GameObject;
                    newButton.transform.SetParent(countries.transform, false);
                    newButton.SetActive(true);
                    countryObjects.Add(newButton);

                    Text countryText = newButton.transform.Find("CountryName").GetComponent<Text>();
                    if(data.countries[i].country.Length >= 20) countryText.text = i+1 + ". " + data.countries[i].country.Substring(0, 19) + "...";
                    else countryText.text = i+1 + ". " + data.countries[i].country;

                    Text casesText = newButton.transform.Find("Data").transform.Find("Cases").GetComponent<Text>();
                    if(data.countries[i].cases == 1) casesText.text = data.countries[i].cases.ToString("N0") + " case";
                    else casesText.text = data.countries[i].cases.ToString("N0") + " cases";

                    Text deathsText = newButton.transform.Find("Data").transform.Find("Deaths").GetComponent<Text>();
                    if(data.countries[i].deaths == 1) deathsText.text = data.countries[i].deaths.ToString("N0") + " death";
                    else deathsText.text = data.countries[i].deaths.ToString("N0") + " deaths";
                    
                    Text recoveredText = newButton.transform.Find("Data").transform.Find("Recovered").GetComponent<Text>();
                    recoveredText.text = data.countries[i].recovered.ToString("N0") + " recovered";

                    setImage(newButton, data.countries[i].countryInfo.iso2, i);
                }
            }
        }
    }

    private void setImage(GameObject newButton, string iso, int i) {
        Image countryImage = newButton.transform.Find("Image").GetComponent<Image>();
        for (int n = 0; n < flags.Count; n++)
        {   
            if (flags[n].name == iso.ToLower())
            {
                countryImage.sprite = flags[n];
                break;
            }
        }
        if(!countryImage.sprite) newButton.transform.Find("Image").gameObject.SetActive(false);
    }
}


[System.Serializable]
public class CountryInfo
{
    public int? _id;
    public string iso2;
    public string iso3;
    public double lat;
    public double @long;
    public string flag;
}

[System.Serializable]
public class UserObject
{
    public string country;
    public CountryInfo countryInfo;
    public int cases;
    public int todayCases;
    public int deaths;
    public int todayDeaths;
    public int recovered;
    public int active;
    public int critical;
    public double? casesPerOneMillion;
    public double? deathsPerOneMillion;
    public object updated;
}

[System.Serializable]
public class RootObject
{
    public List<UserObject> countries;
}