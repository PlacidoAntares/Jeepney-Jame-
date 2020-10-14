using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

    public Image bg;
    public Text progress;
    public GameObject progressBar;

    private int loadProgress = 0;

    void Start()
    {
        bg.enabled = false;
        progress.enabled = false;
        progressBar.SetActive(false);
    }

    public void goNext()
    {
        StartCoroutine(DisplayLoadingScreen(Application.loadedLevel + 1));
    }

    IEnumerator DisplayLoadingScreen(int level)
    {
        bg.enabled = true;
        progress.enabled = true;
        progressBar.SetActive(true);

        progressBar.GetComponent<RectTransform>().localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        progress.text = "Loading Progress " + loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            progress.text = "Loading Progress " + loadProgress + "%";
            progressBar.GetComponent<RectTransform>().localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
            yield return null;   
        }
    }
}
