using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetStates : MonoBehaviour
{

    private const string URL = "https://corona.lmao.ninja/states";
    private const string imageURL = "https://cdn.civil.services/us-states/flags/";

    public GameObject states;
    public GameObject button;
    public List<Sprite> flags = new List<Sprite>();

    public static List<GameObject> stateObjects = new List<GameObject>();

    public void Start()
    {
        button.SetActive(false);
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        if (req.isDone)
        {
            var data = JsonUtility.FromJson<States>("{ \"states\": " + req.text + "}");

            for (int i = 0; i < data.states.Count; i++)
            {
                GameObject newButton = Instantiate(button) as GameObject;
                newButton.transform.SetParent(states.transform, false);
                newButton.SetActive(true);
                stateObjects.Add(newButton);

                Text stateText = newButton.transform.Find("StateName").GetComponent<Text>();
                if(data.states[i].state.Length >= 20) stateText.text = i+1 + ". " + data.states[i].state.Substring(0, 20) + "...";
                else stateText.text = i+1 + ". " + data.states[i].state;

                Text casesText = newButton.transform.Find("Data").transform.Find("Cases").GetComponent<Text>();
                casesText.text = data.states[i].cases.ToString("N0") + " cases";
                Text deathsText = newButton.transform.Find("Data").transform.Find("Deaths").GetComponent<Text>();
                deathsText.text = data.states[i].deaths.ToString("N0") + " deaths";
                Text recoveredText = newButton.transform.Find("Data").transform.Find("Recovered").GetComponent<Text>();
                int recovered = data.states[i].cases - data.states[i].active - data.states[i].deaths;
                recoveredText.text = recovered.ToString("N0") + " recovered";

                setImage(newButton, data.states[i].state, i);
            }
        }
    }

    private void setImage(GameObject newButton, string stateName, int i) {
        Image stateImage = newButton.transform.Find("Image").GetComponent<Image>();
        for (int n = 0; n < flags.Count; n++)
        {
            if (flags[n].name.Contains(stateName.ToLower().Replace(" ", "_")) || flags[n].name.Contains(stateName.ToLower().Replace(" ", "-")))
            {
                stateImage.sprite = flags[n];
            }
        }
        if(!stateImage.sprite) newButton.transform.Find("Image").gameObject.SetActive(false);
    }
}

[System.Serializable]
public class StateObject
{
    public string state;
    public int cases;
    public int todayCases;
    public int deaths;
    public int todayDeaths;
    public int active;
}

[System.Serializable]
public class States
{
    public List<StateObject> states;
}