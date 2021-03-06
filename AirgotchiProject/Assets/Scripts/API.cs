﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*ToDO text string floatiksi ja joksuks piste logiikaksi. Toi ulostuleva arvo kerrotaan 
1 000 000 jollon arvo yli 40 on huono.
Jotain kuivaa tietoa aiheesta: 
http://www.who.int/news-room/fact-sheets/detail/ambient-(outdoor)-air-quality-and-health

Mä en tiedä mitä teen, peace and love @venla oli eka kerta Unitylla, jos joku on rikki niin ehkä 
kandee palata siihen aikasempaan zip fileen */

public class API : MonoBehaviour {

    private const string URL = "https://button.kunnas.com/query_no2?latitude=37.7749&longitude=122.4194&duration=7";
    public Text responseText;
    public AirData airData;
    int airPoints;
    GameLogic gameLogic;

    void Start() {
        gameLogic = FindObjectOfType<GameLogic>();
        Request();
    }

    public void Request() {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req) {

        yield return req;

        if (req.text != "{\"error\": \"No data\"}") {
            airData = JsonUtility.FromJson<AirData>(req.text);
            AirDataToAirPoints(airData);
        }
    }

    void AirDataToAirPoints(AirData airData) {
        airPoints = Mathf.RoundToInt(airData.no2_concentration * 1000000);
        gameLogic.airPoints = airPoints;
        responseText.text = "" + airPoints;
    }
}


