using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class SceneHelpers : MonoBehaviour {
	public string _SceneName_forLoad;// сцена которую нужно загрузить при нажатии кнопки следуующий уровень в окне победы
	public GameObject StartLevelInfoPanel;

	public GameObject[] MonstersPrefabs;    // массив с мобамы
	public Transform StartPosition;     // позициия спавна мобов





	public GameObject TextInfoEnglish;
	public GameObject TextInfoUkrainian;
	public GameObject TextInfoRussian;




	public bool Go=false;



	public bool BGSoundFon;
	public AudioClip BGFon;
	public float VollumeBGFon;


	public string TagName3 = "AnimalHit";
	public string TagName1 = "Animals";
	public string TagName2 = "Ground";

	private AudioSource myaudio;

	public AudioClip SoundAnimalHit; 
	public AudioClip SoundPromazal;
	public AudioClip ObezjankaHit;

	public float Vollume;
	public Camera Main_camera;
	public GameObject BananPrefab;
	public GameObject BananEMPrefab;


	//=====================================================================DROP====================
	[Space(10)]
	[Header("количество нужних итемов для перехода на следующий уровень ")]
	public int NeedItems;

	//public int _PlayerClYchik;       // количество нужних итемов для перехода на следующий уровень

	//=====================================реализация гейм овера и пропуска пищи при кормлении
	[Space(10)]
	[Header(" количество пропущеной пищи при которой забереться у игрока ключик ")]
	public int FoodChendjeForDeleteKey=25;

	[Header(" количество пропущеной пищи которую споймал и сьел обезянка ")]
	public int FoodChendje=0;

	[Header(" текст информер пропущеной пищи")]
	public Text FoodChendjeText_informer;

	[Header("панель появляеться при старте игры с инфой от обезянки ")]
	public GameObject StartPanel_ChendjeFood_Info;

	[Header("панель появляеться при пропуске пищи больше чем установленное количество ")]
	public GameObject Panel_ChendjeFood_Info;

	[Header("место вывода картинкы  в окне о том что забрала обезянка ")]
	public Image Shablon_ItemInpanel;
	[Header("изображение ключика итема для показа что забрали етот итем ниже также ")]
	public Sprite ImageItemClychik;
	[Header("изображение Stars итема ")]
	public Sprite ImageItemStars;
	[Header("изображение Confets итема ")]
	public Sprite ImageItemConfets;
	[Header("изображение Monets итема ")]
	public Sprite ImageItemMonets;
	[Header("изображение Rybu итема ")]
	public Sprite ImageItemRybu;

	[Space(10)]
	[Header("панель инфо GameOver ")]
	public GameObject PanelInfo_GameOver;

	//==================================================


	public int Damage=10;



	public Animator ObezjankaAnimation;  // аниматор  поедатора итемов

	public Slider HealthSlider;



	public bool NewsItemsQwestPrefab=false;    
	public Sprite NewItemsSprite;     	// ====реализация подмены спрайтов в префабе дропа
	public Sprite ItemsSprite;





	public HitHelper _HitHelperss;

	InfoMenedjer _InfoMenedjer;

	RaycastHit2D hitinfo;


	void Awake(){
		_InfoMenedjer=GameObject.FindObjectOfType<InfoMenedjer>();


		_InfoMenedjer._SceneHelper = this.gameObject.GetComponent<SceneHelpers> ();// заносим самы себя 

	}



	void Start () {
		TextInfoEnglish.SetActive (false);
		TextInfoUkrainian.SetActive (false);
		TextInfoRussian.SetActive (false);
		StartLevelInfoPanel.SetActive (true);
		StartPanel_ChendjeFood_Info.SetActive (false);
		Panel_ChendjeFood_Info.SetActive (false);
		PanelInfo_GameOver.SetActive (false);

		_InfoMenedjer.SceneName_forLoad=_SceneName_forLoad;// передаем какую загружать следующюю сцену


		SpawnMonster ();
		_HitHelperss = GameObject.FindObjectOfType<HitHelper> ();





		if (BGSoundFon == true) {
			AudioSource audioBGFon = GetComponent<AudioSource>();
			audioBGFon.clip = BGFon;
			audioBGFon.volume = VollumeBGFon;
			audioBGFon.loop = true;
			audioBGFon.Play ();

		}


		if (SaveStaticGameOptions._LenguageVallue == 0) {
			TextInfoEnglish.SetActive (true);
		}
		if (SaveStaticGameOptions._LenguageVallue == 1) {
			TextInfoUkrainian.SetActive (true);
		}
		if (SaveStaticGameOptions._LenguageVallue == 2) {
			TextInfoRussian.SetActive (true);
		}





	}




	public void SpawnMonster(){
		int index = Random.Range(0, MonstersPrefabs.Length);        //выбираем рандомный индекс монстра с массива мобов
		GameObject monsterObj = Instantiate (MonstersPrefabs [index])   //виводим рандомный префаб моба на сцену
			as GameObject;

		monsterObj.transform.position = StartPosition.position;       // позициия спавна мобов
		Go=false;

	}






	public void Close_Start_LEvel_InfoPanel(){

		StartLevelInfoPanel.SetActive (false);
		StartPanel_ChendjeFood_Info.SetActive (true);// выключаем первую инфо про уровень и показуем вторую панель инфо от обезянки
	}

	// метод закрития стартовой инфо панели от обезянкы
	public void Close_ChendjeFood_Info_InfoStartPanel(){
		StartPanel_ChendjeFood_Info.SetActive (false);
	}

	// метод закрития инфо панели от обезянкы
	public void Close_ChendjeFood_Info(){
		Panel_ChendjeFood_Info.SetActive (false);
	}




	// Update is called once per frame
	void Update () {
		







		// ====реализация подмены спрайтов в префабе дропа
		if(_HitHelperss != null){
		if (NewsItemsQwestPrefab == true ) {
			_HitHelperss.ClYchikPrefab.GetComponent<SpriteRenderer> ().sprite = NewItemsSprite;
		} else {
			_HitHelperss.ClYchikPrefab.GetComponent<SpriteRenderer> ().sprite = ItemsSprite;
		}

		}





		if (_HitHelperss == null) {
			
			_HitHelperss = GameObject.FindObjectOfType<HitHelper> ();

		} else {
			
			HealthSlider.maxValue = _HitHelperss.MaxHealth;
			HealthSlider.value = _HitHelperss.Health;

		}
		
		if (Go==true)

		{ 
			SpawnMonster ();


		}




	

		if (Input.GetMouseButtonDown (0))   //и если ето не слой юи
			{

			hitinfo = Physics2D.Raycast (Main_camera.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			 


		
			if ((hitinfo.collider.tag == TagName3) && (Input.GetMouseButtonDown (0))) {

				hitinfo.transform.GetComponent<Animator> ().SetTrigger ("Hit");
				myaudio = GetComponent<AudioSource> ();
				myaudio.PlayOneShot (ObezjankaHit, Vollume);
			} 




			if ((hitinfo.collider.tag == TagName1) && (Input.GetMouseButtonDown (0))) {
				myaudio = GetComponent<AudioSource> ();
				myaudio.PlayOneShot (SoundAnimalHit, Vollume);
				hitinfo.transform.GetComponent<Animator> ().SetTrigger ("Click");
				GameObject BananEM= Instantiate(BananEMPrefab,hitinfo.point, Quaternion.identity)as GameObject;
				Destroy (BananEM, 0.2f);
				HitHelper _HitHelper = (HitHelper)hitinfo.transform.GetComponent<HitHelper> ();
				_HitHelper.Health=_HitHelper.Health-Damage;//передаем дамаг обекту

			}



			if ((hitinfo.collider.tag == TagName2) && (Input.GetMouseButtonDown (0))){

				GameObject Banan= Instantiate(BananPrefab,hitinfo.point, Quaternion.identity)as GameObject;
				myaudio = GetComponent<AudioSource> ();
				myaudio.PlayOneShot (SoundPromazal, Vollume);
				ObezjankaAnimation.SetTrigger ("EM");					
				FoodChendje += 1;//  прибавляем 1 к пропущеной еде щетчику
			}
				
	}



		FoodChendjeText_informer.text = FoodChendje.ToString ();// передаем занчение  количества пропущеной текущее пищи




		// метод выводит инво и заберает ключики при пропуске еды при кормлении животных 
		//а также если нету ключей то итемы и если итемов стало 0 то ГеймОвер
		if (FoodChendje >= FoodChendjeForDeleteKey) {
			FoodChendje = 0;

			if(SaveStaticGameOptions._PlayerClYchik>=1){
			    SaveStaticGameOptions._PlayerClYchik -= 1;// забераем 1 ключь если пропустили еду
				SaveStaticGameOptions._PlayerItems-=1;// уменьшаем общый счетчик итемов в рюкзаке
				Shablon_ItemInpanel.sprite=ImageItemClychik;// показуем какой итем забрали картинку
				Panel_ChendjeFood_Info.SetActive (true);
				return;
			}


			if (SaveStaticGameOptions._PlayerClYchik <= 0) {
				SaveStaticGameOptions._PlayerClYchik = 0;// чтоб не ушло в минус

				if (SaveStaticGameOptions._PlayerStars >= 1) {
					int Count = SaveStaticGameOptions._PlayerStars;
					if (Count <= 10) {
						SaveStaticGameOptions._PlayerStars -= Count;
						SaveStaticGameOptions._PlayerItems -= Count;
					} else {
						SaveStaticGameOptions._PlayerStars -= 10;// забераем 10 звезд
						SaveStaticGameOptions._PlayerItems-=10;// уменьшаем общый счетчик итемов в рюкзаке
					}


					Shablon_ItemInpanel.sprite=ImageItemStars;// показуем какой итем забрали картинку
					Panel_ChendjeFood_Info.SetActive (true);
					if(SaveStaticGameOptions._PlayerStars <=0){
						SaveStaticGameOptions._PlayerStars = 0;// чтоб не ушло в минус
					}
					if(SaveStaticGameOptions._PlayerItems <=0){
						SaveStaticGameOptions._PlayerItems = 0;// чтоб не ушло в минус
						PanelInfo_GameOver.SetActive (true);// итемы в окне все кончились оповещаем что персонаж проиграл
					}

					return;
				}



				if (SaveStaticGameOptions._PlayerConfets >= 1) {

					int Count = SaveStaticGameOptions._PlayerConfets;
					if (Count <= 10) {
						SaveStaticGameOptions._PlayerConfets -= Count;
						SaveStaticGameOptions._PlayerItems-=Count;
					}else {
						SaveStaticGameOptions._PlayerConfets -= 10;// забераем 10 звезд
						SaveStaticGameOptions._PlayerItems-=10;// уменьшаем общый счетчик итемов в рюкзаке
					}
					Shablon_ItemInpanel.sprite=ImageItemConfets;// показуем какой итем забрали картинку
					Panel_ChendjeFood_Info.SetActive (true);
					if(SaveStaticGameOptions._PlayerConfets <=0){
						SaveStaticGameOptions._PlayerConfets = 0;// чтоб не ушло в минус
					}
					if(SaveStaticGameOptions._PlayerItems <=0){
						SaveStaticGameOptions._PlayerItems = 0;// чтоб не ушло в минус
						PanelInfo_GameOver.SetActive (true);// итемы в окне все кончились оповещаем что персонаж проиграл
					}
					return;
				}

				if (SaveStaticGameOptions._PlayerMonets >= 1) {
					int Count = SaveStaticGameOptions._PlayerMonets;
					if (Count <= 10) {
						SaveStaticGameOptions._PlayerMonets -= Count;
						SaveStaticGameOptions._PlayerItems-=Count;
					}else {
						SaveStaticGameOptions._PlayerMonets -= 10;// забераем 10 звезд
						SaveStaticGameOptions._PlayerItems-=10;// уменьшаем общый счетчик итемов в рюкзаке
					}
					Shablon_ItemInpanel.sprite=ImageItemMonets;// показуем какой итем забрали картинку
					Panel_ChendjeFood_Info.SetActive (true);
					if(SaveStaticGameOptions._PlayerMonets <=0){
						SaveStaticGameOptions._PlayerMonets = 0;// чтоб не ушло в минус
					}
					if(SaveStaticGameOptions._PlayerItems <=0){
						SaveStaticGameOptions._PlayerItems = 0;// чтоб не ушло в минус
						PanelInfo_GameOver.SetActive (true);// итемы в окне все кончились оповещаем что персонаж проиграл
					}
					return;
				}

				if (SaveStaticGameOptions._PlayerRybu >= 1) {
					int Count = SaveStaticGameOptions._PlayerRybu;
					if (Count <= 10) {
						SaveStaticGameOptions._PlayerRybu -= Count;
						SaveStaticGameOptions._PlayerItems-=Count;
					}else {
						SaveStaticGameOptions._PlayerRybu -= 10;// забераем 10 звезд
						SaveStaticGameOptions._PlayerItems-=10;// уменьшаем общый счетчик итемов в рюкзаке
					}
					Shablon_ItemInpanel.sprite=ImageItemRybu;// показуем какой итем забрали картинку
					Panel_ChendjeFood_Info.SetActive (true);
					if(SaveStaticGameOptions._PlayerRybu <=0){
						SaveStaticGameOptions._PlayerRybu = 0;// чтоб не ушло в минус
					}
					if(SaveStaticGameOptions._PlayerItems <=0){
						SaveStaticGameOptions._PlayerItems = 0;// чтоб не ушло в минус
						PanelInfo_GameOver.SetActive (true);// итемы в окне все кончились оповещаем что персонаж проиграл
					}
					return;
				}
					
			}


		}
			
	}//===And Update




	// кнопка в окне ГейОвер тут перекидает персонажа в меню
	public void ButtonGameOver_CloseInfo(){
		_InfoMenedjer.GameOver (true);// передаем сигнал что гейм овер
	}




}
