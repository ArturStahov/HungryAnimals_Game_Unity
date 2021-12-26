using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile; // include the Easy Mobile namespace to use its scripting API
public class StartMenuMenedjer : MonoBehaviour {



	public GameObject ButtonPlayEnglish;
	public GameObject ButtonPlayRussian;
	public GameObject ButtonPlayUkrainian;


	public GameObject ButtonSettingsEnglish;
	public GameObject ButtonSettingsRussian;
	public GameObject ButtonSettingsUkrainian;

	public GameObject ButtonExitEnglish;
	public GameObject ButtonExitRussian;
	public GameObject ButtonExitUkrainian;



	public GameObject ButtonAdwentureEnglish;
	public GameObject ButtonAdwentureRussian;
	public GameObject ButtonAdwentureUkrainian;







	public Animator SelectLevelPanel;
	public Animator SettingsPanel;

	public AudioClip BGSounds; 

	public Toggle SoundToggle;




	public Dropdown DropdownLenguage;  



void Awake()
{
if (!RuntimeManager.IsInitialized())
RuntimeManager.Init();
}

public void ShowReklamsBanner(){
Advertising.ShowBannerAd(BannerAdPosition.Bottom);
}


	// Use this for initialization
	void Start () {
		ShowReklamsBanner();// показуем баннерную рекламу


		
		SelectLevelPanel.enabled = false;
		SettingsPanel.enabled = false;

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = BGSounds;
		audio.Play ();



		ButtonPlayEnglish.SetActive (false);
		ButtonPlayRussian.SetActive (false);
		ButtonPlayUkrainian.SetActive (false);


		ButtonSettingsEnglish.SetActive (false);
		ButtonSettingsRussian.SetActive (false);
		ButtonSettingsUkrainian.SetActive (false);

		ButtonExitEnglish.SetActive (false);
		ButtonExitRussian.SetActive (false);
		ButtonExitUkrainian.SetActive (false);

		ButtonAdwentureEnglish.SetActive (false);
		ButtonAdwentureRussian.SetActive (false);
		ButtonAdwentureUkrainian.SetActive (false);

		SoundToggle.isOn=SaveStaticGameOptions._SoundOn;
		DropdownLenguage.value=SaveStaticGameOptions._LenguageVallue;


	}
	
	// Update is called once per frame
	void Update () {
	


		SaveStaticGameOptions._SoundOn = SoundToggle.isOn;
		SaveStaticGameOptions._LenguageVallue = DropdownLenguage.value;





		if (SaveStaticGameOptions._SoundOn == false) {

			AudioListener.volume = 0;
		} else {

			AudioListener.volume = 1;
		}




		if (SaveStaticGameOptions._LenguageVallue == 0) {
			ButtonPlayEnglish.SetActive (true);
			ButtonSettingsEnglish.SetActive (true);
			ButtonExitEnglish.SetActive (true);
			ButtonPlayRussian.SetActive (false);
			ButtonPlayUkrainian.SetActive (false);
			ButtonSettingsRussian.SetActive (false);
			ButtonSettingsUkrainian.SetActive (false);
			ButtonExitRussian.SetActive (false);
			ButtonExitUkrainian.SetActive (false);

			ButtonAdwentureEnglish.SetActive (true);
			ButtonAdwentureRussian.SetActive (false);
			ButtonAdwentureUkrainian.SetActive (false);


		}
		if (SaveStaticGameOptions._LenguageVallue  == 1) {
			ButtonPlayUkrainian.SetActive (true);
			ButtonSettingsUkrainian.SetActive (true);
			ButtonExitUkrainian.SetActive (true);
			ButtonPlayEnglish.SetActive (false);
			ButtonPlayRussian.SetActive (false);
			ButtonSettingsEnglish.SetActive (false);
			ButtonSettingsRussian.SetActive (false);
			ButtonExitEnglish.SetActive (false);
			ButtonExitRussian.SetActive (false);

			ButtonAdwentureEnglish.SetActive (false);
			ButtonAdwentureRussian.SetActive (false);
			ButtonAdwentureUkrainian.SetActive (true);
		}
		if (SaveStaticGameOptions._LenguageVallue  == 2) {
			ButtonPlayRussian.SetActive (true);
			ButtonSettingsRussian.SetActive (true);
			ButtonExitRussian.SetActive (true);
			ButtonPlayEnglish.SetActive (false);
			ButtonPlayUkrainian.SetActive (false);
			ButtonSettingsEnglish.SetActive (false);
			ButtonSettingsUkrainian.SetActive (false);
			ButtonExitEnglish.SetActive (false);
			ButtonExitUkrainian.SetActive (false);

			ButtonAdwentureEnglish.SetActive (false);
			ButtonAdwentureRussian.SetActive (true);
			ButtonAdwentureUkrainian.SetActive (false);
		}







	}










	public void OpenSelectLevelPanel(){

		SelectLevelPanel.enabled = true;
		SelectLevelPanel.SetBool ("Open", false);

	}

	public void CloseSelectLevelPanel(){


		SelectLevelPanel.SetBool ("Open", true);

	}


	public void OpenSettingsPanel(){

		SettingsPanel.enabled = true;
		SettingsPanel.SetBool ("Open", false);

	}

	public void CloseSettingsPanel(){


		SettingsPanel.SetBool ("Open", true);

	}


	public void ExitGamesButton(){
		

			Application.Quit();


	}


	public void ButtonInfo(){
		
			Application.OpenURL ("https://www.facebook.com/groups/762601170572112");


	}





}
