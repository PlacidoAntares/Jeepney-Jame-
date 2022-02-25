using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsData : MonoBehaviour
{
    [HideInInspector] public PickUpManager PUM;
    [HideInInspector] public ScoreHolder SH;
    [HideInInspector] public float expireTimer;
    public bool isPassenger;
    //

    // Start is called before the first frame update
    void Start()
    {
        SH = GameObject.Find("ScoreManager").GetComponent<ScoreHolder>();
        PUM = GameObject.FindGameObjectWithTag("PickUpManager").GetComponent<PickUpManager>();
        Invoke("DestroyThisObj", expireTimer);
    }

    private void FixedUpdate()
    {
        ItemPickUp();
        
    }

    void ItemPickUp()
    {
        if (isPassenger == true)
        {
            PassengerRayCast();
        }
        
    }

    void PassengerRayCast()
    {
        Vector3 leftRay = transform.TransformDirection(Vector3.left);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, leftRay, out hit,5.0f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Picked Up passenger");
                SH.Score += 10;
                SH.passCount++;
                DestroyThisObj();
            }
        }
            
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isPassenger != true)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Picked up powerup");
                SH.Score++;
                DestroyThisObj();
            }
           else if (collision.gameObject.tag != "Player")
            {
                DestroyThisObj();
            }
        }

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
