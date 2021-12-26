using UnityEngine;
using System.Collections;

public class SettingsReader : MonoBehaviour {




	// етот класс многоцелевой , он также весит междууровневих заставках меняя перевод и в Донт дестрой для смены текста перевода в игровых сценах


	//public bool TranslateReklamPanel = false;



	public GameObject TextReklamPanelEnglish;
	public GameObject TextReklamPanelUkrainian;
	public GameObject TextReklamPanelRussian;











	// Use this for initialization
	void Start () {



		TextReklamPanelEnglish.SetActive (false);
		TextReklamPanelUkrainian.SetActive (false);
		TextReklamPanelRussian.SetActive (false);



		if (SaveStaticGameOptions._SoundOn == false) {

			AudioListener.volume = 0;
		} else {

			AudioListener.volume = 1;
		}







			

			if (SaveStaticGameOptions._LenguageVallue == 0) {
				TextReklamPanelEnglish.SetActive (true);
			}
			if (SaveStaticGameOptions._LenguageVallue == 1) {
				TextReklamPanelUkrainian.SetActive (true);
			}
			if (SaveStaticGameOptions._LenguageVallue == 2) {
				TextReklamPanelRussian.SetActive (true);
			}




	}
	
	// Update is called once per frame
	void Update () {

		if (SaveStaticGameOptions._LenguageVallue == 0) {
			TextReklamPanelEnglish.SetActive (true);

			TextReklamPanelUkrainian.SetActive (false);
			TextReklamPanelRussian.SetActive (false);
			return;
		}
		if (SaveStaticGameOptions._LenguageVallue == 1) {
			TextReklamPanelUkrainian.SetActive (true);
			TextReklamPanelEnglish.SetActive (false);

			TextReklamPanelRussian.SetActive (false);
			return;
		}
		if (SaveStaticGameOptions._LenguageVallue == 2) {
			TextReklamPanelRussian.SetActive (true);
			TextReklamPanelEnglish.SetActive (false);
			TextReklamPanelUkrainian.SetActive (false);
			return;

		}


		if (SaveStaticGameOptions._SoundOn == false) {

			AudioListener.volume = 0;
		} else {

			AudioListener.volume = 1;
		}


	
	}
}
