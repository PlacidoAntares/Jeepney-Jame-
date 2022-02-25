using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingShed : MonoBehaviour
{
    [HideInInspector] ScoreHolder SH;
    // Start is called before the first frame update
    void Start()
    {
        SH = GameObject.Find("ScoreManager").GetComponent<ScoreHolder>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 leftRay = transform.TransformDirection(Vector3.left);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, leftRay, out hit,5.0f))
        {
            if (hit.collider.gameObject.tag == "Player" && SH.passCount >= 5)
            {
                Debug.Log("Deposited Passengers");
                SH.Score *= SH.passCount;
                SH.passCount = 0;
            }
        }
    }
}
