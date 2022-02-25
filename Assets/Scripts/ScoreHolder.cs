using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score;
    public int passCount;
    public Text ScoreTxt;
    public Text passCountTxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = Score.ToString();
        passCountTxt.text = passCount.ToString();
    }
}
