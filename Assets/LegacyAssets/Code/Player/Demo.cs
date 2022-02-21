using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

	public float WaitTimer;
	public bool RunCoroutine;
	// Use this for initialization
	void Start () {
		//StartCoroutine(Go (WaitTimer,"Hello","this came a few seconds later")); //calls the coroutine
	
	}
	
	// Update is called once per frame
	void Update () {
		if(RunCoroutine == true)
		{
		StartCoroutine(Go(WaitTimer,"Hello","this came a few seconds later"));
		}
	}

	IEnumerator Go(float wait,string text1,string text2)
	{
		print(Time.time + " " + text1);	
		//---Happens in the first frame
		RunCoroutine = false;
		yield return new WaitForSeconds(wait);
		//----waits for a timer to run out before running.
		print(Time.time + " " + text2);
		RunCoroutine = true;
	}
}
