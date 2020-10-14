using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JeepLaneMovement : MonoBehaviour {

    //Do not modify private variables 
    private float minSwipeDistY;
    private float minSwipeDistX;
    private Vector2 startPos;

    //other declarations
    //
	public int currentHealth; //Current health
    public int maxHealth = 10; //Max health
	//
	public GameObject BG_MusicPrefab;
	GameObject BG_Music;
    public GameObject JeepModel; //Use a Jeepney Prefab
    public GameObject TargetJeep; //The Jeep the code will be using
	public GameObject JeepTriggerC; //Trigger Collider Spawned with Jeep
	public GameObject AssignedJeepTC; //Trigger Collider to be used when checking trigger based collisions
    public GameObject Point; //Use a empty gameobject prefab
    public int JeepPointID;
    public float SwapSpeed; //how fast the jeep changes lanes.
	public float LaneWidth;
	public bool IsInLane;
    private GameObject FaceTowardsPoint;
    public GameObject [] LaneSlots = new GameObject [3]; //0 Leftside,1 middle,2 rightside
    public GameObject[] LookAtPoints = new GameObject[3]; //0 Leftside,1 middle,2 rightside
    private Vector3 JeepVector;
	private Vector3 CameraVector;
    private Vector3 [] LookPointVectors = new Vector3[3];
    private Vector3[] JeepSlotVectors = new Vector3[3];
	private Vector3[] CameraSlotVectors = new Vector3[3];

    //Multiplier
    public int currentMulti; //current multiplier
    private int minMulti = 1; //min multiplier
    private int maxMulti = 10; //max multiplier
    //UI
    public Image sun1, sun2, sun3, sun4, sun5, sun6, sun7, sun8, sun9, sun10, sun11;
    public Image star1, star2, star3, star4, star5, star6, star7, star8, star9, star10;
    public Image x2, x3, x4, x5, x6, x7, x8, x9, x10;
    public bool pop = false;
    public Animation anim;
    public GameObject panel;
    public AudioClip clip;

	// Use this for initialization
	void Start () {
		BG_Music = Instantiate(BG_MusicPrefab,this.gameObject.transform.position,this.gameObject.transform.rotation) as GameObject;
		currentHealth = maxHealth;
        currentMulti = minMulti;
        panel.SetActive(false);
        Time.timeScale = 1;
        //
		//CameraObj = GameObject.FindWithTag("MainCamera");
        JeepVector = this.gameObject.transform.position;
		//CameraVector = JeepVector + new Vector3(0,5,-5);
		//CameraObj.transform.position = CameraVector;
        TargetJeep = Instantiate(JeepModel, JeepVector, this.gameObject.transform.rotation) as GameObject;
		AssignedJeepTC = Instantiate(JeepTriggerC,JeepVector,this.gameObject.transform.rotation) as GameObject;
        //
        JeepSlotVectors[0] = this.gameObject.transform.position + new Vector3(-LaneWidth, 0, 0);
        JeepSlotVectors[1] = this.gameObject.transform.position;
        JeepSlotVectors[2] = this.gameObject.transform.position + new Vector3(LaneWidth, 0, 0);
        //
        LaneSlots[0] = Instantiate(Point, JeepSlotVectors[0], this.gameObject.transform.rotation) as GameObject;
        LaneSlots[1] = Instantiate(Point, JeepSlotVectors[1], this.gameObject.transform.rotation) as GameObject;
        LaneSlots[2] = Instantiate(Point, JeepSlotVectors[2], this.gameObject.transform.rotation) as GameObject;
        //
		LookPointVectors[0] = this.gameObject.transform.position + new Vector3(-LaneWidth, 0, 5);
        LookPointVectors[1] = this.gameObject.transform.position + new Vector3(0, 0, 5);
		LookPointVectors[2] = this.gameObject.transform.position + new Vector3(LaneWidth, 0, 5);
        //
        LookAtPoints[0] = Instantiate(Point, LookPointVectors[0], this.gameObject.transform.rotation) as GameObject;
        LookAtPoints[1] = Instantiate(Point, LookPointVectors[1], this.gameObject.transform.rotation) as GameObject;
        LookAtPoints[2] = Instantiate(Point, LookPointVectors[2], this.gameObject.transform.rotation) as GameObject;
        //
        FaceTowardsPoint = Instantiate(Point, LookPointVectors[1], this.gameObject.transform.rotation) as GameObject;

    }
	
	// Update is called once per frame
	void Update () {
        TouchInput();
        JeepRotation();
        JeepLaneSwap();
		HandleHealth();
        HandleMultiplier();
		if (currentHealth >= 0) {
			//ScoreManager.score += 1;
		}
	}
    //Handles Limit
    void HandleHealth()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentHealth += 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentHealth -= 1;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            //panel.SetActive(true);
            //Time.timeScale = 0;
        }
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth == maxHealth)
        {
            sun1.enabled = true;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 9){
            sun1.enabled = false;
            sun2.enabled = true;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 8){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = true;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 7){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = true;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 6){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = true;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 5){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = true;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 4){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = true;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 3){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = true;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 2){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = true;
            sun10.enabled = false;
            sun11.enabled = false;
        }
        else if (currentHealth == 1){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = true;
            sun11.enabled = false;
        }
        else if (currentHealth <= 0){
            sun1.enabled = false;
            sun2.enabled = false;
            sun3.enabled = false;
            sun4.enabled = false;
            sun5.enabled = false;
            sun6.enabled = false;
            sun7.enabled = false;
            sun8.enabled = false;
            sun9.enabled = false;
            sun10.enabled = false;
            sun11.enabled = true;

            currentHealth = 0;
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void JeepLaneSwap()
    { 
    
        if(TargetJeep.transform.position != LaneSlots[JeepPointID].transform.position)
        {

            TargetJeep.transform.position = Vector3.MoveTowards(TargetJeep.transform.position, LaneSlots[JeepPointID].transform.position,SwapSpeed * Time.deltaTime);
			AssignedJeepTC.transform.position = Vector3.MoveTowards(AssignedJeepTC.transform.position, LaneSlots[JeepPointID].transform.position,SwapSpeed * Time.deltaTime);
			IsInLane = false;

        }
        LaneSlots[JeepPointID].transform.position = new Vector3(JeepSlotVectors[JeepPointID].x, TargetJeep.transform.position.y, JeepSlotVectors[JeepPointID].z);
    }

    void JeepRotation()
    {
        LookAtPoints[JeepPointID].transform.position = new Vector3(LookPointVectors[JeepPointID].x,TargetJeep.transform.position.y, LookPointVectors[JeepPointID].z);
        FaceTowardsPoint.transform.position = Vector3.MoveTowards(FaceTowardsPoint.transform.position,LookAtPoints[JeepPointID].transform.position,(SwapSpeed + 0.5f) * Time.deltaTime);
        TargetJeep.transform.LookAt(FaceTowardsPoint.transform.position);
		AssignedJeepTC.transform.LookAt(FaceTowardsPoint.transform.position);
		//CameraObj.transform.LookAt(FaceTowardsPoint.transform.position);
    }
	
    void TouchInput()
    {
        //#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0)//up swipe	
                        {
                            //Up Swipe Commands here;	
                        }
                        else if (swipeValue < 0)//down swipe							
                        {
                            //Down Swipe command here;
                        }
                    }
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)//right swipe
                        {
                            if (JeepPointID < 2)
                            {
                                JeepPointID += 1;
                            }
                        }
                        else if (swipeValue < 0)//left swipe
                        {
                            if (JeepPointID > 0)
                            {
                                JeepPointID -= 1;
                            }
                        }
                    }
                    break;
            }
        }

    }

    //Handles Limit
    void HandleMultiplier()
    {
        //Test
        if (Input.GetKeyDown(KeyCode.X))
            currentMulti += 1;
        if (Input.GetKeyDown(KeyCode.Z))
            currentMulti -= 1;
        //

        if (currentMulti > maxMulti)
            currentMulti = maxMulti;
        else if (currentMulti < minMulti)
            currentMulti = minMulti;

        if (currentMulti == minMulti)
        {
            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;
        }
        else if (currentMulti == 2)
        {
            star1.enabled = false;
            star2.enabled = true;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = true;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 3)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = true;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = true;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 4)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = true;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = true;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 5)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = true;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = true;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 6)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = true;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = true;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 7)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = true;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = true;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 8)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = true;
            star9.enabled = false;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = true;
            x9.enabled = false;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 9)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = true;
            star10.enabled = false;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = true;
            x10.enabled = false;

            disAble();
        }
        else if (currentMulti == 10)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
            star5.enabled = false;
            star6.enabled = false;
            star7.enabled = false;
            star8.enabled = false;
            star9.enabled = false;
            star10.enabled = true;

            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = true;

            disAble();
        }
    }

    void disAble()
    {
        if (pop)
        {
            anim.Play();
            StartCoroutine(iStop());
        }
        else
        {
            x2.enabled = false;
            x3.enabled = false;
            x4.enabled = false;
            x5.enabled = false;
            x6.enabled = false;
            x7.enabled = false;
            x8.enabled = false;
            x9.enabled = false;
            x10.enabled = false;
        }
    }

    IEnumerator iStop()
    {
        yield return new WaitForSeconds(0.35f);
        anim.Stop();
        pop = false;
        StopAllCoroutines();
    }

    public void b_Retry()
    {
		Destroy (BG_Music);
        Application.LoadLevel(Application.loadedLevel - 1);
    }

    //Movement for jeep using UI Button
    public void goLeft()
    {
        if (JeepPointID > 0)
        {
            JeepPointID -= 1;
        }
    }
    public void goRight()
    {
        if (JeepPointID < 2)
        {
            JeepPointID += 1;
        }
    }
}
