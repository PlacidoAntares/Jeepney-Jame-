using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {

    public RectTransform rect;
    public int maxLoad = 100;
    private int currentLoad;

    void Start()
    {
        currentLoad = 0;
    }

    void Update()
    {
        var load = currentLoad / (float)maxLoad;
        rect.localScale = new Vector3(load, 1, 1);

        currentLoad += 1;

        if (currentLoad > maxLoad)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    }
}
