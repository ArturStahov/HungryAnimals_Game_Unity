using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class MenuLevelLoad : MonoBehaviour {

	public GameObject CloseLevel_2Informer; // иконка закритого уровня (замок)
	public GameObject CloseLevel_3Informer;
	public GameObject CloseLevel_4Informer;
	public GameObject CloseLevel_5Informer;




	// Use this for initialization
	void Start () {

		if(SaveStaticGameOptions._OpenLevel_2==true){
			CloseLevel_2Informer.SetActive (false);
		}
		if(SaveStaticGameOptions._OpenLevel_3==true){
			CloseLevel_3Informer.SetActive (false);
		}

		if(SaveStaticGameOptions._OpenLevel_4==true){
			CloseLevel_4Informer.SetActive (false);
		}
		if(SaveStaticGameOptions._OpenLevel_5==true){
			CloseLevel_5Informer.SetActive (false);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void ButtonLoadLevel_2(string SceneName){
		if (SaveStaticGameOptions._OpenLevel_2==true) {
			SceneManager.LoadScene (SceneName);

		}
	}

	public void ButtonLoadLevel_3(string SceneName){
		if (SaveStaticGameOptions._OpenLevel_3==true) {
			SceneManager.LoadScene (SceneName);

		}
	}

	public void ButtonLoadLevel_4(string SceneName){
		if (SaveStaticGameOptions._OpenLevel_4==true) {
			SceneManager.LoadScene (SceneName);

		}
	}

	public void ButtonLoadLevel_5(string SceneName){
		if (SaveStaticGameOptions._OpenLevel_5==true) {
			SceneManager.LoadScene (SceneName);

		}
	}









}
