using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreTxt; //Score
	public Text passTxt; //Passenger

	// Static variables //
	static public int score;
	static public int pass;

	void Update () {
		
		if (score < 0)
			score = 0;
		if (pass < 0)
			pass = 0;

        //Test
        if (Input.GetKey(KeyCode.Alpha5))
            score+=1;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            pass+=1;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            pass-=1;

        scoreTxt.text = "" + score;
        passTxt.text = "" + pass;
	}
}

