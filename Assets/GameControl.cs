using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static bool first=true;
	public static int state = 0;
	public GameObject Ftext;
	public GameObject Stext;
	public GameObject Enemy;
	public GameObject enemy;
	public GameObject cutline;
	public Material bluemat;
	public AudioSource audioSource;
	public AudioClip zan;
	Vector3 targetPos;
	public int damage;
	private void Start()
	{
		if (first)
        {
            Ftext.GetComponent<Text>().text = "攻撃側";
            Stext.GetComponent<Text>().text = "守備側";

        }
        else
        {
            Ftext.GetComponent<Text>().text = "守備側";
            Stext.GetComponent<Text>().text = "攻撃側";
        }
		if(SkillControl.slow){
			if(first){
				SkillControl.Fslow += 1;
			}else{
				SkillControl.Sslow += 1;
			}
			Enemy.transform.position = new Vector3(0, 10f, 0);
		}
		if(SkillControl.counter){
			if(first){
				SkillControl.Scounter += 1;
			}else{
				SkillControl.Fcounter += 1;
			}
			enemy.GetComponent<Renderer>().material = bluemat;
		}
	}
	// Update is called once per frame
	void Update () {
		if(state==0){
			if(first){
				if (Input.GetKeyDown(KeyCode.Space))
				{
					audioSource = gameObject.GetComponent<AudioSource>();
					audioSource.clip = zan;
					audioSource.Play();
					Enemy.GetComponent<Rigidbody>().isKinematic = true;
					targetPos = Enemy.gameObject.transform.position;
					cutline.SetActive(true);
					state = 1;
				}
			}else{
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.clip = zan;
                    audioSource.Play();
					Enemy.GetComponent<Rigidbody>().isKinematic = true;
					targetPos = Enemy.gameObject.transform.position;
					cutline.SetActive(true);
                    state = 1;
				}
			}
			if(Enemy.transform.position.y<=-7){
				if (first)
				{
					Ftext.GetComponent<Text>().text = "Miss!";
					Stext.GetComponent<Text>().text = "Lucky!";
				}
				else
				{
					Stext.GetComponent<Text>().text = "Miss!";
					Ftext.GetComponent<Text>().text = "Lucky!";
				}
				state = 2;
			}
		}else if(state==1){
			DamageCheck();
			state = 2;
		}else if(state==2){
			if(damage==0){
				Ftext.GetComponent<Text>().text = "Miss!!";
                Stext.GetComponent<Text>().text = "Press Enter!!";	
			}
			if (Input.GetKeyDown(KeyCode.Return))
            {
                state = 0;
				if(!SkillControl.counter){
					if (first)
                    {
                        SecondHPcontrol.Shp -= damage;
                    }
                    else
                    {
                        FirstHPcontrol.Fhp -= damage;
                    }
				}else{
					if (first)
                    {
                        FirstHPcontrol.Fhp -= damage;
                    }
                    else
                    {
                        SecondHPcontrol.Shp -= damage;
                    }
				}
                
                if (FirstHPcontrol.Fhp > 0 && SecondHPcontrol.Shp > 0)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        first = true;
                    }
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    SceneManager.LoadScene("GameSet");
                }
            }
		}
	}
	public void DamageCheck(){
		if(targetPos.y>=-0.25&&targetPos.y<=0.25){
			if(first){
				Ftext.GetComponent<Text>().text = "Great Cut!Press Enter!";
				Stext.GetComponent<Text>().text = "You had critical damage!";
				damage=2;
			}else{
				Stext.GetComponent<Text>().text = "Great Cut!Press Enter!";
                Ftext.GetComponent<Text>().text = "You had critical damage!";
				damage = 2;
			}
		}else if(targetPos.y>=-1&&targetPos.y<=1){
			if (first)
            {
                Ftext.GetComponent<Text>().text = "Nice Cut!Press Enter!";
                Stext.GetComponent<Text>().text = "You had damage!";
				damage = 1;
            }
            else
            {
                Stext.GetComponent<Text>().text = "Nice cut!Press Enter!";
                Ftext.GetComponent<Text>().text = "You had damage!";
				damage = 1;
            }
		}else{
			damage = 0;
			state = 2;
		}
	}
}
