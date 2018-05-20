using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(SecondHPcontrol.Shp<=0){
			GetComponent<Text>().text = "1P Win!";
		}else if(FirstHPcontrol.Fhp<=0){
			GetComponent<Text>().text = "2P Win!";
		}else{
			GetComponent<Text>().text = "Draw!!";
		}
	}

}
