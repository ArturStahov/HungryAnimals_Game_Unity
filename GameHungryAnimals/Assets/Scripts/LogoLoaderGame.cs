using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogoLoaderGame : MonoBehaviour {

	// Use this for initialization
	public string SceneName_forLoad;
	public float timer;   //создаем таймер

	public GameObject panelLogo;
	public GameObject panelText;
	public GameObject panelGameLogo;






	// Use this for initialization
	void Start () {
		panelLogo.SetActive (false);
		panelText.SetActive (false);
		panelGameLogo.SetActive (false);






	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((timer>=0)&&(timer<=2)) {    //если значение таймера от

			panelLogo.SetActive (true);

		}


		if ((timer>=2)&&(timer<=3)) {

			panelLogo.SetActive (false);
			panelText.SetActive (true);



		}


		if ((timer>=3)&&(timer<=5)) {


			panelText.SetActive (false);
			panelGameLogo.SetActive (true);




		}

		if ((timer>=5)&&(timer<=7)) {

			SceneManager.LoadScene(SceneName_forLoad);

		}




	}









}
