using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadGameScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	// здесь передать все сигнали для сохранения при выходе с игры 
	void OnApplicationQuit()
	{

		SaveGameScore (true);

	}

	void OnApplicationPause(bool paused)
	{
		if(paused)
			OnApplicationQuit();
	}



	public void SaveGameScore(bool save){
		if (save) {

			ES3.Save<bool> ("_SoundOn", SaveStaticGameOptions._SoundOn);

			ES3.Save<int> ("_LenguageVallue", SaveStaticGameOptions._LenguageVallue); 
			ES3.Save<int> ("_PlayerStars", SaveStaticGameOptions._PlayerStars); 
			ES3.Save<int> ("_PlayerConfets", SaveStaticGameOptions._PlayerConfets); 
			ES3.Save<int> ("_PlayerMonets", SaveStaticGameOptions._PlayerMonets); 
			ES3.Save<int> ("_PlayerRybu", SaveStaticGameOptions._PlayerRybu); 
			ES3.Save<int> ("_PlayerItems", SaveStaticGameOptions._PlayerItems); 
			ES3.Save<int> ("_PlayerClYchik", SaveStaticGameOptions._PlayerClYchik); 

			ES3.Save<bool> ("_OpenLevel_1", SaveStaticGameOptions._OpenLevel_1);
			ES3.Save<bool> ("_OpenLevel_2", SaveStaticGameOptions._OpenLevel_2);
			ES3.Save<bool> ("_OpenLevel_3", SaveStaticGameOptions._OpenLevel_3);
			ES3.Save<bool> ("_OpenLevel_4", SaveStaticGameOptions._OpenLevel_4);
			ES3.Save<bool> ("_OpenLevel_5", SaveStaticGameOptions._OpenLevel_5);
		}

	}


		public void LoadGameScore(){
		

		if (ES3.KeyExists ("_LenguageVallue")) {
			SaveStaticGameOptions._LenguageVallue = ES3.Load<int> ("_LenguageVallue");
		}

		if (ES3.KeyExists ("_SoundOn")) {
			SaveStaticGameOptions._SoundOn = ES3.Load<bool> ("_SoundOn");
		}


		if (ES3.KeyExists ("_PlayerStars")) {
			SaveStaticGameOptions._PlayerStars = ES3.Load<int> ("_PlayerStars");
		}

		if (ES3.KeyExists ("_PlayerConfets")) {
			SaveStaticGameOptions._PlayerConfets = ES3.Load<int> ("_PlayerConfets");
		}
		if (ES3.KeyExists ("_PlayerMonets")) {
			SaveStaticGameOptions._PlayerMonets = ES3.Load<int> ("_PlayerMonets");
		}
		if (ES3.KeyExists ("_PlayerRybu")) {
			SaveStaticGameOptions._PlayerRybu = ES3.Load<int> ("_PlayerRybu");
		}
		if (ES3.KeyExists ("_PlayerItems")) {
			SaveStaticGameOptions._PlayerItems = ES3.Load<int> ("_PlayerItems");
		}
		if (ES3.KeyExists ("_PlayerClYchik")) {
			SaveStaticGameOptions._PlayerClYchik = ES3.Load<int> ("_PlayerClYchik");
		}


		if (ES3.KeyExists ("_OpenLevel_1")) {
			SaveStaticGameOptions._OpenLevel_1 = ES3.Load<bool> ("_OpenLevel_1");
		}
		if (ES3.KeyExists ("_OpenLevel_2")) {
			SaveStaticGameOptions._OpenLevel_2 = ES3.Load<bool> ("_OpenLevel_2");
		}
		if (ES3.KeyExists ("_OpenLevel_3")) {
			SaveStaticGameOptions._OpenLevel_3 = ES3.Load<bool> ("_OpenLevel_3");
		}
		if (ES3.KeyExists ("_OpenLevel_4")) {
			SaveStaticGameOptions._OpenLevel_4 = ES3.Load<bool> ("_OpenLevel_4");
		}
		if (ES3.KeyExists ("_OpenLevel_5")) {
			SaveStaticGameOptions._OpenLevel_5 = ES3.Load<bool> ("_OpenLevel_5");
		}




	}
		


}
