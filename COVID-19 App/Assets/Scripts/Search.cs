using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject statesField;

    public void Update()
    {
        if (PageLoader.page == 1)
        {
            theName = inputField.GetComponent<Text>().text;

            for(int i = 0; i < GetCountries.countryObjects.Count; i++){
                GameObject countryObj = GetCountries.countryObjects[i];
                Text countryText = countryObj.transform.Find("CountryName").GetComponent<Text>();
                if(countryText.text.ToLower().Contains(theName.ToLower())) countryObj.SetActive(true);
                else countryObj.SetActive(false);
            }
        } else if(PageLoader.page == 2) {
            theName = statesField.GetComponent<Text>().text;

            for(int i = 0; i < GetStates.stateObjects.Count; i++){
                GameObject stateObj = GetStates.stateObjects[i];
                Text stateText = stateObj.transform.Find("StateName").GetComponent<Text>();
                if(stateText.text.ToLower().Contains(theName.ToLower())) stateObj.SetActive(true);
                else stateObj.SetActive(false);
            }
        }
    }
}
