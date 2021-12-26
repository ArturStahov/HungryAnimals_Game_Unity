using UnityEngine;
using System.Collections;

public class BGsoundGame : MonoBehaviour {
	public AudioClip SounFon;
	public float VollumeSoundFon; 
	// Use this for initialization
	void Start () {
		AudioSource audioFon = GetComponent<AudioSource>();
		audioFon.clip = SounFon;
		audioFon.volume = VollumeSoundFon;
		audioFon.loop = true;
		audioFon.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
