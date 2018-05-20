using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(!GameControl.first){
			if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
		}else{
			if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
		}

	}
}
