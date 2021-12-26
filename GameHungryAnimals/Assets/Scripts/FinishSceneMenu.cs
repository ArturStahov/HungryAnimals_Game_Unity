using UnityEngine;
using System.Collections;

public class FinishSceneMenu : MonoBehaviour {
	public AudioClip BGSounds; 
	public Animator SelectLevelPanel;


	// Use this for initialization
	void Start () {


		SelectLevelPanel.enabled = false;

		AudioSource audioFon = GetComponent<AudioSource>();
		audioFon.clip = BGSounds;

		audioFon.loop = true;
		audioFon.Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OpenSelectLevelPanel(){

		SelectLevelPanel.enabled = true;
		SelectLevelPanel.SetBool ("Open", false);

	}

	public void CloseSelectLevelPanel(){


		SelectLevelPanel.SetBool ("Open", true);

	}

	public void ButtonInfo(){
		if (SaveStaticGameOptions._LenguageVallue == 0) {
			Application.OpenURL ("https://www.facebook.com/groups/762601170572112");
		} else {
			Application.OpenURL ("https://vk.com/hungryanimals");
		}
			

	}




}
