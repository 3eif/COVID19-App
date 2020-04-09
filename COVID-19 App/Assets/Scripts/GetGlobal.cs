using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetGlobal : MonoBehaviour
{

    public Text cases;
    public Text deaths;
    public Text recovered;
    public Text active;
    public Text affectedCountries;

    public Text lastUpdated;

    Data api;
    private const string URL = "https://corona.lmao.ninja/all";

    public void Start()
    {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;

        if(req.isDone) {
            api = JsonUtility.FromJson<Data>(req.text);

            string confirmedCases = api.cases.ToString("N0");
            string totalDeaths = api.deaths.ToString("N0");
            string totalRecovered = api.recovered.ToString("N0");
            string totalActive = api.active.ToString("N0");

            cases.text = confirmedCases;
            deaths.text = totalDeaths;
            recovered.text = totalRecovered;
            active.text = totalActive;
            affectedCountries.text = api.affectedCountries.ToString();

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(api.updated);
            long unixTimeStampInMilliseconds= dateTimeOffset.ToUnixTimeMilliseconds();

            DateTime epoch = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
            long ms = (long) (DateTime.UtcNow - epoch).TotalMilliseconds;

            int timeSinceUpdated = Convert.ToInt32(ms - unixTimeStampInMilliseconds)/60000;
            if(timeSinceUpdated == 0) lastUpdated.text = (Convert.ToInt32(ms - unixTimeStampInMilliseconds)/1000).ToString() + " seconds ago";
            else if(timeSinceUpdated == 1) lastUpdated.text = timeSinceUpdated.ToString() + " minute ago";
            else lastUpdated.text = timeSinceUpdated.ToString() + " minutes ago";
        }
    }

}

[System.Serializable]
public class Data
{
    public int cases;
    public int deaths;
    public int recovered;
    public long updated;
    public int active;
    public int affectedCountries;
}
