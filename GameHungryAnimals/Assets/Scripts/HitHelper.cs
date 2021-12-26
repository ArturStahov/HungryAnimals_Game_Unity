using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class HitHelper : MonoBehaviour {


	[SerializeField] private GameObject ThisMobs;  //ссылдка на весь обект етого моба с родителем для полного удаления

	private AudioSource myaudio;


	public bool MobsSound=false;
	public AudioClip SoundAnimalStart; // звук при появлении на сцене
	public AudioClip SoundWIN;// звук при уходе со сцены сцене

	public float VollumeMobsSound;
	public float VollumeWin;

	//=========================================DROPS==============





	public int ClYchikDrop = 1; // количество  при дропе
	public int  ClYchikChanse;//шанс выдачи gold
	public GameObject ClYchikPrefab;    // дроп префаб


	public int _PlayerStars;  
	public int  StarsChanse;//шанс выдачи 
	public GameObject PlayerStarsPrefab;    // дроп префаб


	public int _PlayerConfets;
	public int  PlayerConfetsChanse;//шанс выдачи 
	public GameObject PlayerConfetsPrefab;    // дроп префаб


	public int _PlayerMonets;
	public int  PlayerMonetsChanse;//шанс выдачи 
	public GameObject PlayerMonetsPrefab;    // дроп префаб


	public int _PlayerRybu;
	public int  PlayerRybuChanse;//шанс выдачи 
	public GameObject PlayerRybuPrefab;    // дроп префаб





	public Transform Start_Drop_Position_ClYchik;//позиция(координаты) появления дропа 
	public Transform Start_Drop_Position_Stars;//позиция(координаты) появления дропа 
	public Transform Start_Drop_Position_PlayerConfets;//позиция(координаты) появления дропа 
	public Transform Start_Drop_Position_PlayerMonets;//позиция(координаты) появления дропа 
	public Transform Start_Drop_Position_PlayerRybu;//позиция(координаты) появления дропа 

	//=========================================DROPS==============


	public Animator AnimatorFinishMobs;

	public int MaxHealth;

	public int Health=4;
	bool _isDead;

	SceneHelpers _SceneHelper;
	//InfoMenedjer _InfoMenedjer;






	void Start () {





		Health = MaxHealth;

		_SceneHelper = GameObject.FindObjectOfType<SceneHelpers>();
		//_InfoMenedjer=GameObject.FindObjectOfType<InfoMenedjer>(); уже ненада все записуем в SaveStaticGameOptions.

		if (MobsSound == true) {
			myaudio = GetComponent<AudioSource> ();
			myaudio.PlayOneShot (SoundAnimalStart, VollumeMobsSound);

		}

	}


	
	// Update is called once per frame
	void Update () {




		if (_isDead)
			return;


		if (Health<=0) {

			_isDead = true;


			myaudio = GetComponent<AudioSource> ();
			myaudio.PlayOneShot (SoundWIN, VollumeWin);
			AnimatorFinishMobs.SetBool ("Finish", true);// зверь уходит анимация

			//=============================================SpawnDROP======================================
			//==============================Take Ключики

			int random1 = Random.Range(0, 100);          //рандомная ыдача ключей с установленным шансом 
			if (random1 < ClYchikChanse){
				//_SceneHelper.NeedItems -= 1; // отнимаем в нифоменеджере ключики(значит нам нужно найти на 1 меньше уже если есть дроп ключа)
				SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
				SaveStaticGameOptions._PlayerClYchik += ClYchikDrop; // дроп ключиков



				GameObject ClYchikObj = Instantiate(ClYchikPrefab) as GameObject;
				ClYchikObj.transform.position = Start_Drop_Position_ClYchik.transform.position;
				Destroy(ClYchikObj, 5);   //удаляем обект со сцены через 5 секунды 
				_SceneHelper.Go=true;
			}
			//==============================Take Stars

			int random2 = Random.Range(0, 100);          //рандомная ыдача ключей с установленным шансом 
			if (random2 < StarsChanse){

				SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
				SaveStaticGameOptions._PlayerStars += _PlayerStars; // дроп 

				GameObject StarsObj = Instantiate(PlayerStarsPrefab) as GameObject;
				StarsObj.transform.position = Start_Drop_Position_Stars.transform.position;
				Destroy(StarsObj, 5);   //удаляем обект со сцены через 5 секунды 
				_SceneHelper.Go=true;
			}

			//==============================Take PlayerConfets


			int random3 = Random.Range(0, 100);          //рандомная ыдача ключей с установленным шансом 
			if (random3 < PlayerConfetsChanse){

				SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
				SaveStaticGameOptions._PlayerConfets += _PlayerConfets; // дроп 

				GameObject ConfetsObj = Instantiate(PlayerConfetsPrefab) as GameObject;
				ConfetsObj.transform.position = Start_Drop_Position_PlayerConfets.transform.position;
				Destroy(ConfetsObj, 5);   //удаляем обект со сцены через 5 секунды 
				_SceneHelper.Go=true;
			}


			//==============================Take PlayerMonets


			int random4 = Random.Range(0, 100);          //рандомная ыдача ключей с установленным шансом 
			if (random4 < PlayerMonetsChanse){

				SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
				SaveStaticGameOptions._PlayerMonets += _PlayerMonets; // дроп 

				GameObject MonetsObj = Instantiate(PlayerMonetsPrefab) as GameObject;
				MonetsObj.transform.position = Start_Drop_Position_PlayerMonets.transform.position;
				Destroy(MonetsObj, 5);   //удаляем обект со сцены через 5 секунды 
				_SceneHelper.Go=true;
			}

			//==============================Take PlayerRybu

			int random5 = Random.Range(0, 100);          //рандомная ыдача ключей с установленным шансом 
			if (random5 < PlayerRybuChanse){

				SaveStaticGameOptions._PlayerItems += 1;    //добавляем +1 при дропе чего либо в счетчик всех предметов
				SaveStaticGameOptions._PlayerRybu += _PlayerRybu; // дроп 

				GameObject RybuObj = Instantiate(PlayerRybuPrefab) as GameObject;
				RybuObj.transform.position = Start_Drop_Position_PlayerRybu.transform.position;
				Destroy(RybuObj, 5);   //удаляем обект со сцены через 5 секунды 
				_SceneHelper.Go=true;
			}




			Destroy (ThisMobs,2f);

	}




			





}




			









}
