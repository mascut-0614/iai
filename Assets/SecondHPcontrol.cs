using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondHPcontrol : MonoBehaviour {
	public static int Shp=5;
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;
	public GameObject Star4;
	public GameObject Star5;
	private void Start()
	{
		Star1.SetActive(false);
		Star2.SetActive(false);
		Star3.SetActive(false);
		Star4.SetActive(false);
		Star5.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		if(Shp>=1){
			Star1.SetActive(true);
		}
		if(Shp>=2){
			Star2.SetActive(true);
		}
		if(Shp>=3){
			Star3.SetActive(true);
		}
		if(Shp>=4){
			Star4.SetActive(true);
		}
		if(Shp==5){
			Star5.SetActive(true);
		}
	}
}
