using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passengerData : MonoBehaviour
{
    [HideInInspector] public PickUpManager PUM;
    [HideInInspector] public float expireTimer;
    // Start is called before the first frame update
    void Start()
    {
        PUM = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<PickUpManager>();
        Invoke("DestroyThisObj", expireTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyThisObj()
    {
        PUM.removePickUpList.Add(this.gameObject);
        foreach (GameObject setPiece in PUM.removePickUpList)
        {
            PUM.removePickUpList.Remove(setPiece);
            Destroy(this.gameObject);
        }
    }
}
