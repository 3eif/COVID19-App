using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppLoader : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject navigation;

    private void OnApplicationPause()
    {
        StartApp();
    }

    public void Awake(){
        StartApp();
    }

    private void StartApp(){
        loadPanel.SetActive(true);
        navigation.SetActive(false);
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(4);
        loadPanel.SetActive(false);
        navigation.SetActive(true);
    }
    
}
