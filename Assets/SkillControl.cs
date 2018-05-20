using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SkillControl : MonoBehaviour {
	public static bool counter = false;
	public static bool slow = false;
	public static int Fcounter = 0;
	public static int Fslow = 0;
	public static int Scounter = 0;
	public static int Sslow = 0;
	public GameObject FText;
	public GameObject SText;
	private void Start()
	{
		slow = false;
		counter = false;
		if(GameControl.first){
			if(Fslow==0){
				FText.GetComponent<Text>().text = "Z=slow X=slow cancel";
			}else{
				FText.GetComponent<Text>().text = "You Can't slow";
			}
			if (Scounter == 0)
            {
                SText.GetComponent<Text>().text = "Left=counter Right=counter cancel";
            }
            else
            {
                SText.GetComponent<Text>().text = "You Can't counter";
            }
		}else
        {
			if (Fcounter == 0)
            {
                FText.GetComponent<Text>().text = "Z=counter X=counter cancel";
            }
            else
            {
                FText.GetComponent<Text>().text = "You Can't counter";
            }
            if (Sslow == 0)
            {
                SText.GetComponent<Text>().text = "Left=slow Right=slow cancel";
            }
            else
            {
                SText.GetComponent<Text>().text = "You Can't slow";
            }
        }
	}
	// Update is called once per frame
	void Update () {
		if(GameControl.first){
			if(Input.GetKeyDown(KeyCode.Return)){
				SceneManager.LoadScene("Main");
			}
			if(Fslow==0){
				if (Input.GetKeyDown(KeyCode.Z))
                {
					slow = true;
                }
				if(Input.GetKeyDown(KeyCode.X)){
					slow = false;
				}
			}
			if(Scounter==0){
				if(Input.GetKeyDown(KeyCode.LeftArrow)){
					counter = true;
				}
				if(Input.GetKeyDown(KeyCode.RightArrow)){
					counter = false;
				}
			}
		}else
        {
			if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Main");
            }
			if (Fcounter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
					counter = true;
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
					counter = false;
                }
            }
            if (Sslow == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
					slow = true;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
					slow = false;
                }
            }
        }
	}
}
