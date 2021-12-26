using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemHelper : MonoBehaviour {



	
	public float ItemsSpeedtransform;

	public string TargetTagName;
	private GameObject Target;
	public bool ItsObezjanka = false;
	public GameObject BananSkyrkaPrefab;
	public float AttacTime; // Период между атаками 
	private float t; // второстипенная переменная необходимая для выполнения логики 

	// Use this for initialization
	void Start () {
		
		Target=GameObject.FindGameObjectWithTag(TargetTagName);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, Target.transform.position ,Time.deltaTime * ItemsSpeedtransform);

		if (Vector2.Distance(transform.position, 
			Target.transform.position) < 0.1f)

		{
			

			GetComponent<Animator> ().enabled = false;
			Destroy(gameObject,0.2f);
			if(ItsObezjanka == true){
				Banan_Skyrka_Instatiate ();
			}


		}


	}





	 void Banan_Skyrka_Instatiate(){
		if (Time.time - t > AttacTime){ // алгоритм задержки между отниманием жизней
			GameObject BananSkyrka= Instantiate(BananSkyrkaPrefab,Target.transform.position, Quaternion.identity)as GameObject;
			Destroy (BananSkyrka, 3f);
			t = Time.time; // завершение задержки

	}


}
}
