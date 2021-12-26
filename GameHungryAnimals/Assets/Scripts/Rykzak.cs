using UnityEngine;
using System.Collections;

public class Rykzak : MonoBehaviour {








	public Animator RykzakAnimator;

	ItemHelper _ItemHelper;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (_ItemHelper == null) {
			_ItemHelper = GameObject.FindObjectOfType<ItemHelper> ();
		} else {
			
			if (Vector2.Distance (transform.position, _ItemHelper.transform.position) < 0.3f) {
				RykzakAnimator.SetTrigger ("Hit");

			}
		}

			
	}
}
