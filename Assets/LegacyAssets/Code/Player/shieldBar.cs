using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shieldBar : MonoBehaviour
{
	public RectTransform sBar;
	private int maxShield = 1000;
	private int currentShield;
	public GameObject shieldGauge;
	public bool visible = false;
	
	void Start()
	{
		currentShield = maxShield;
	}
	
	void Update()
	{
		var dec = currentShield / (float)maxShield;
		
		sBar.localScale = new Vector3(dec, 1, 1);
		
		//Test
		if(Input.GetKeyDown(KeyCode.Return)){
			//shieldGauge.SetActive(true);
			visible = true;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//shieldGauge.SetActive(false);
			visible = false;
		}
		//
		if (visible)
		{
			shieldGauge.SetActive(true);
			currentShield -= 1;
		}
		else
		{
			shieldGauge.SetActive(false);
			currentShield = maxShield;
		}
		
		//if (shieldGauge.activeSelf == true)
		//{
		//    currentShield -= 1;
		//    visible = true;
		//}
		//else if (shieldGauge.activeSelf == false)
		//{
		//    currentShield = maxShield;
		//    visible = false;
		//}
		
		if (currentShield <= 0)
		{
			currentShield = 0;
			//shieldGauge.SetActive(false);
			visible = false;
		}
	}
	
}