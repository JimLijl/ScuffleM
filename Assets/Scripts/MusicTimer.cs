using UnityEngine;
using System.Collections;

public class MusicTimer : MonoBehaviour {

	// Use this for initialization
	void Start() {
		StartCoroutine(Timer());
	}
	
	IEnumerator Timer() {
		while (true) {
			yield return new WaitForSeconds (1.0f);
			//			Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time));
			
			if (Time.time >= 5 && Time.time < 6) {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
