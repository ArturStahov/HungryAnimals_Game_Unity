using UnityEngine;
using System.Collections;

public class DontDestroyScript : MonoBehaviour {
	static private GameObject firstInstance = null;
	// Use this for initialization



	void Awake() {
		if (firstInstance == null)                  //проверяем есть ли на сцене такой же обект  если есть то уничтожаем етот  что бы небыло 2 одинаковых
			firstInstance = gameObject;
		else if (gameObject != firstInstance)
			Destroy(gameObject);                 // самоуничтожение
	}


	void Start () {
		DontDestroyOnLoad (this);          //   обект  не будет удалятся на всех сценах игры
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
