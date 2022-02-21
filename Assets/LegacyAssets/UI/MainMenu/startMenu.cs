using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startMenu : MonoBehaviour {

    public Image bg;
    public Text progress;
    public GameObject progressBar;

	void Start () {
        bg.enabled = false;
        progress.enabled = false;
        progressBar.SetActive(false);
	}

    public void goNext()
    {
        StartCoroutine(DisplayLoadingScreen());
    }

    IEnumerator DisplayLoadingScreen()
    {
        bg.enabled = true;
        progress.enabled = true;
        progressBar.SetActive(true);
        yield return new WaitForSeconds(2);
        Application.LoadLevel (Application.loadedLevel + 1);
    }
}
