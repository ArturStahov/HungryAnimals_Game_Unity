using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyMobile; // include the Easy Mobile namespace to use its scripting API




public class ScreenLoader : MonoBehaviour {

	public Slider LoadSlider; //сщздаем обеккт слайдер загрузки
	public float timer;   //создаем таймер
	public string SceneName_forLoad;
	public GameObject ButtonGo;

	public AudioClip BGSounds; 



	//=================================================


void Awake()
{
if (!RuntimeManager.IsInitialized())
RuntimeManager.Init();
}

//метод показует выдеорекламу
public void InterestialReklams(){
	bool isReady = Advertising.IsInterstitialAdReady();
// Show it if it's ready
    if (isReady)
		{
			Advertising.ShowInterstitialAd();
		}
}


public void ShowReklamsBanner(){
Advertising.ShowBannerAd(BannerAdPosition.Bottom);
}




	// Use this for initialization
	void Start () {

		InterestialReklams();// показуем рекламу


		ButtonGo.SetActive (false);

		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = BGSounds;
		audio.Play ();


	}


















	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((timer>=0)&&(timer<=2)) {    //если значение таймера от

			LoadSlider.value = 25;    // то значение слайдера 25

		}


		if ((timer>=2)&&(timer<=3)) {

			LoadSlider.value = 50;

		}


		if ((timer>=3)&&(timer<=5)) {

			LoadSlider.value = 75;

		}

		if ((timer>=5)&&(timer<=6)) {

			LoadSlider.value = 100;

		}


		if ((timer>=6)&&(timer<=7)) {

             
		        	ShowReklamsBanner();// показуем баннерную рекламу

			ButtonGo.SetActive (true);



		}

	}



	public void ButtonStartUp(){
		
		SceneManager.LoadScene(SceneName_forLoad);

	}







}
