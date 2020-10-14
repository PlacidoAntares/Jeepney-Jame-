using UnityEngine;
using System.Collections;

public class toLoad : MonoBehaviour {

    public void goNext()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
