using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsData : MonoBehaviour
{
    [HideInInspector] public PickUpManager PUM;
    [HideInInspector] public float expireTimer;
    // Start is called before the first frame update
    void Start()
    {
        PUM = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<PickUpManager>();
        Invoke("DestroyThisObj", expireTimer);
    }


    void DestroyThisObj()
    {
        PUM.removePickUpList.Add(this.gameObject);
        foreach (GameObject pickUps in PUM.removePickUpList)
        {
            PUM.pickUpList.Remove(pickUps);
            Destroy(this.gameObject);
        }
    }
}
