using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using EasyMobile; // include the Easy Mobile namespace to use its scripting API

public class InfoMenedjer : MonoBehaviour {

	//=====статистика при вииграше
	[Space(10)]
	[Header("заноситься авто в каждой сцене с sceneHelpera ")]
	public string SceneName_forLoad;//заноситься авто в каждой сцене сцена которую нужно загрузить при нажатии кнопки следуующий уровень в окне победы



	public Text StatsTextUICoins;
	public Text StatsTextUIRuby;
	public Text StatsTextUIkonfets;
	public Text StatsTextUIStars;

	public Text StatsTextUITimeHours;
	public Text StatsTextUITimeMinuts;
	public Text StatsTextUITimeSeconds;

	 //===============   Индикатор анимация в рюкзаке
	[Space(10)]
	[Header("Индикатор анимация в рюкзаке ")]
	public Animator IndikatorRuby;
	public Animator IndikatorStars;
	public Animator IndikatorKonfets;
	public Animator IndikatorCoins;

	[Space(10)]
	[Header("анимация кнопки в инвентаре открить следующий уровень ")]
	public Animator ButtonOpenNextLevel; // анимация кнопки в инвентаре открить следующий уровень при соответсвии ключей
	[Space(10)]
	[Header("появление кнопки о откритии следующего уровня ")]
	public GameObject BattonInformerYouWIN; // появление кнопки о откритии следующего уровня

	[Space(10)]
	[Header(" панели вииграша с статой ")]
	public GameObject PanelYouWIN;

	[Space(10)]
	[Header(" панели InventoryPanel ")]
	public GameObject InventoryPanel;







	private AudioSource myaudio;
	public AudioClip SoundYouWins;
	public float Vollume;
	public Text NeedItemsInventoryText;





	public Slider InfoItemsSlider;



	bool _isFool;



	bool RybuFool = false;
	bool StarsFool = false;
	bool ConfetsFool = false;
	bool MonetsFool = false;





	//=====================================================================DROP====================
	//public int PlayerItems;       // количество общее в рюкзаке старте игры
	public Text PlayerItemsUI;    // счетчик 


	//public int PlayerClYchik;       // количество нужних итемов для перехода на следующий уровень
	public Text PlayerClYchikUI;    // счетчик дропа
	public Text PlayerInventoryKlychik; // текст инфо с инвентаря



	//public int PlayerStars;       // количество 
	public Text PlayerStarsUI;    // счетчик дропа


	//public int PlayerConfets;       // количество 
	public Text PlayerConfetsUI;    // счетчик дропа


	//public int PlayerMonets;       // количество 
	public Text PlayerMonetsUI;    // счетчик дропа


	//public int PlayerRybu;       // количество 
	public Text PlayerRybuUI;    // счетчик дропа


	//====================================================================












	BGsoundGame _BgSoundGame;
	[Header("сюда таймер")]
	public GameTimer _GameTimer;
	public SceneHelpers _SceneHelper; // заноситься авто в каждой сцене


	public Animator PanelReklams;
	//====================================реклама Адмоб





	//=================================================

	[Space(10)]
	[Header("заноситься авто в каждой сцене с LevelInfo ")]
	public bool ItIsGameScena = false;

	[Space(10)]
	[Header(" сюда добавить SaveLoadGame ")]
	public SaveLoadGame _SaveLoadGame;


	[Header("сюда игровой интерфейс для отключения в ненужные сцены ")]
	public GameObject PlayerCanvas;



void Awake()
{
if (!RuntimeManager.IsInitialized())
RuntimeManager.Init();
}
public void InterestialReklams(){
	bool isReady = Advertising.IsInterstitialAdReady();
// Show it if it's ready
    if (isReady)
		{
			Advertising.ShowInterstitialAd();
			// выдаем итемы за просмотр рекламы
		}
}


public void InterestialReklamsVoznagr(){
	bool isReady = Advertising.IsInterstitialAdReady();
// Show it if it's ready
    if (isReady)
		{
			Advertising.ShowInterstitialAd();
			// выдаем итемы за просмотр рекламы
		}
		SaveStaticGameOptions._PlayerClYchik += 1;
		SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
}

public void ShowReklamsBanner(){
Advertising.ShowBannerAd(BannerAdPosition.Bottom);
}





	// Use this for initialization
	void Start () {

		PanelYouWIN.SetActive (false);
		// Initialize an InterstitialAd.
		if (ItIsGameScena == true) {
		_BgSoundGame = GameObject.FindObjectOfType<BGsoundGame> ();
		
	}

		InventoryPanel.SetActive (false);
		ButtonOpenNextLevel.enabled=false;
		BattonInformerYouWIN.SetActive (false);


		PanelReklams.enabled = false;




		IndikatorRuby.enabled = false;
		IndikatorStars.enabled = false;
		IndikatorKonfets.enabled = false;
		IndikatorCoins.enabled = false;


ShowReklamsBanner();


	}






	public void buttonLevelExit(){
		_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние
		SceneManager.LoadScene("menu");
	}



	public void openReklamPanel(){

		PanelReklams.enabled = true;// откриваем окно 

		PanelReklams.SetBool ("Open", false);
		_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние
	}

	public void CloseReklamPanel(){

		PanelReklams.SetBool ("Open", true);
	}

	//====================================реклама Адмоб
	public void SeeReklams(){                          //показать рекламу при нажатии на кнопку

			InterestialReklamsVoznagr();

	
	}



	//=============================================================================================================


	// для сохранения с других скриптов кто имеет доятуп к Инфоменеджеру
	public void SaveGame(){
		_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние
	}



	// метод принимает сигнал с скрипта SceneHelper при проиграше
	public void GameOver(bool GamOver){
		if (GamOver) {
			_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние
			SceneManager.LoadScene("menu");
		}

	}



	public void CanvasPlayerActivate(bool activ){
		if (activ == true) {
			PlayerCanvas.SetActive (true);
		}
		if (activ == false) {
			PlayerCanvas.SetActive (false);
		}
	}





	// Update is called once per frame
	void Update () {
		
		if (ItIsGameScena == true) {





			int OstalosbNaitiItems = _SceneHelper.NeedItems - SaveStaticGameOptions._PlayerClYchik;// вичисляем сколько щсталось найти ключиков
		

			InfoItemsSlider.maxValue =_SceneHelper.NeedItems; 
			InfoItemsSlider.value = OstalosbNaitiItems;
		
			NeedItemsInventoryText.text = OstalosbNaitiItems.ToString ();// передаем занчение  в инвентарь

			if (_isFool)
				return;

			if (OstalosbNaitiItems < 0) {
				OstalosbNaitiItems = 0;
			}


			if (OstalosbNaitiItems <= 0) {
			
				ButtonOpenNextLevel.enabled = true;// запускаем анимацию в инвенторе кнопки открить
				BattonInformerYouWIN.SetActive (true);




				_isFool = true;


			}




		}//=====





		// ========================================indikator Ruby==================
		if (SaveStaticGameOptions._PlayerRybu >= 30) {
			RybuFool = true;
			IndikatorRuby.enabled = true;
			IndikatorRuby.SetBool ("On", true);
		} else {
			RybuFool=false;
			IndikatorRuby.SetBool ("On", false);
		}


		// ========================================indikator Stars==================
		if (SaveStaticGameOptions._PlayerStars >= 20) {
			IndikatorStars.enabled =  true;
			IndikatorStars.SetBool ("On", true);
			StarsFool = true;

		} else {
			IndikatorStars.SetBool ("On", false);
			StarsFool = false;
		}

		// ========================================indikator Konfets==================
		if (SaveStaticGameOptions._PlayerConfets >= 40) {
			IndikatorKonfets.enabled = true;
			IndikatorKonfets.SetBool ("On", true);
			ConfetsFool = true;
		} else {
			IndikatorKonfets.SetBool ("On", false);
			ConfetsFool = false;
		}
		// ========================================indikator Coins==================
		if (SaveStaticGameOptions._PlayerMonets >= 50) {
			IndikatorCoins.enabled = true;
			IndikatorCoins.SetBool ("On", true);
			MonetsFool = true;

		} else {
			IndikatorCoins.SetBool ("On", false);
			MonetsFool = false;
		}


	


		PlayerRybuUI.text = SaveStaticGameOptions._PlayerRybu.ToString ();// передаем занчение  в инвентарь
		PlayerMonetsUI.text = SaveStaticGameOptions._PlayerMonets.ToString ();// передаем занчение  в инвентарь
		PlayerConfetsUI.text = SaveStaticGameOptions._PlayerConfets.ToString ();// передаем занчение  в инвентарь
		PlayerStarsUI.text = SaveStaticGameOptions._PlayerStars.ToString ();// передаем занчение  в инвентарь
		PlayerInventoryKlychik.text=SaveStaticGameOptions._PlayerClYchik.ToString(); // передаем занчение ключей в инвентарь
		PlayerClYchikUI.text = SaveStaticGameOptions._PlayerClYchik.ToString();  // передаем занчение ключей для прехода на сл уровень екрана
		PlayerItemsUI.text = SaveStaticGameOptions._PlayerItems.ToString();  // передаем занчение дропа в счетчик сверху екрана	

	}






	public void ExchendeItems(){  // метод при нажатии на кнопу обменивает итемы на ключикы


		if (RybuFool == true && StarsFool == true && ConfetsFool == true && MonetsFool == true) {
			//_SceneHelper.NeedItems -= 1;
			SaveStaticGameOptions._PlayerClYchik += 1;
			SaveStaticGameOptions._PlayerRybu -= 30;
			SaveStaticGameOptions._PlayerStars -= 20;
			SaveStaticGameOptions._PlayerConfets -= 40;
			SaveStaticGameOptions._PlayerMonets -= 50;
			SaveStaticGameOptions._PlayerItems -= 140;
			SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов

			_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние

		}

	}










	public void ClickedOpenInventory(){      //реализация включения и отключения  одной кнопкой

		InventoryPanel.SetActive (true);
	}


	public void ButtonCloseInventory(){

		InventoryPanel.SetActive (false);
	}




	public void OpenNextLevelButton(){   // при нажатии на кнопку Открить при достижении цели уровня

		if (_isFool == true) {

			InterestialReklams();//  показуем рекламу

		PanelYouWIN.SetActive (true);

		BattonInformerYouWIN.SetActive (false);

		InventoryPanel.SetActive (false);


		SaveStaticGameOptions._PlayerClYchik -= _SceneHelper.NeedItems;// отнимаем у персонажа все ключики которые необходимы для перехода на следующий уровень

		SaveStaticGameOptions._PlayerItems -= _SceneHelper.NeedItems;
		StatsTextUICoins.text = SaveStaticGameOptions._PlayerMonets.ToString ();// передаем занчение  в окно о вииграше в статистику
		StatsTextUIRuby.text = SaveStaticGameOptions._PlayerRybu.ToString ();// передаем занчение
		StatsTextUIkonfets.text = SaveStaticGameOptions._PlayerConfets.ToString ();// передаем занчение
		StatsTextUIStars.text = SaveStaticGameOptions._PlayerStars.ToString ();// передаем занчение

		StatsTextUITimeHours.text = _GameTimer.HoursTime.ToString ();
		StatsTextUITimeMinuts.text = _GameTimer.minedgametime.ToString ();
		StatsTextUITimeSeconds.text = _GameTimer.timersecond.ToString ();

		myaudio = GetComponent<AudioSource> ();
		myaudio.PlayOneShot (SoundYouWins, Vollume);// проигруем звук вииграша

		ButtonOpenNextLevel.enabled = false;// анимацию в инвенторе кнопки открить
							}
	}


	public void ButtonGONEXT(){

		if (_isFool == true) {
			_isFool = false;

			_GameTimer.HoursTime = 0;
			_GameTimer.minedgametime = 0;// обнуляем таймер
			_GameTimer.timersecond = 0;

			PanelYouWIN.SetActive (false);

			_SaveLoadGame.SaveGameScore (true);// сохраняем игровое состояние

			SceneManager.LoadScene(SceneName_forLoad);
		}




	}








}
