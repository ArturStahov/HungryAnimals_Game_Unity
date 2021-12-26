using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {



	//скрипт отображает какой загружен уровень для отключения обектов которые преходят со сцены в сцену(етот скрипт должен быть в каждой сцене!!!!!!!!!!!!!!!!)
	//а также сохраняет что текущий уровень уже открыт для доступности его в меню
	[Header("если игровой уровень то отметить")]
	public bool ItIsLevelGame;

	[Header("если игровой уровень то отметить Какой именно")]
	public bool Level_1 = false;

	public bool Level_2 = false;

	public bool Level_3 = false;

	public bool Level_4 = false;

	public bool Level_5= false;

	// Use this for initialization

	InfoMenedjer _InfoMenedjer;


	void Start () {
		if(_InfoMenedjer==null){
		_InfoMenedjer=GameObject.FindObjectOfType<InfoMenedjer>();
		}

		if(_InfoMenedjer!=null){
			_InfoMenedjer.ItIsGameScena = ItIsLevelGame;

			_InfoMenedjer.CanvasPlayerActivate (ItIsLevelGame);

		}


		if (Level_1 == true) {
			SaveStaticGameOptions._OpenLevel_1 = true;
			_InfoMenedjer.SaveGame ();// сохраняемся
		}
		if (Level_2 == true) {
			SaveStaticGameOptions._OpenLevel_2 = true;
			_InfoMenedjer.SaveGame ();// сохраняемся
		}
		if (Level_3 == true) {
			SaveStaticGameOptions._OpenLevel_3 = true;
			_InfoMenedjer.SaveGame ();// сохраняемся
		}
		if (Level_4 == true) {
			SaveStaticGameOptions._OpenLevel_4 = true;
			_InfoMenedjer.SaveGame ();// сохраняемся
		}

		if (Level_5 == true) {
			SaveStaticGameOptions._OpenLevel_5 =true;
			_InfoMenedjer.SaveGame ();// сохраняемся
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
