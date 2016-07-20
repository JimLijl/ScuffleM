using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {
	public GameObject EndUI1;
	public Transform EndPro;
	void OnTriggerEnter( Collider other ){

		if(other.tag == "Player")
		{
			iTween.MoveTo (EndUI1, iTween.Hash ("x",EndPro.position.x,"y",EndPro.position.y,"time",0.5f));
			StartCoroutine(Timer());

		}
	}
	IEnumerator Timer() {
		while (true) {
			yield return new WaitForSeconds(0.5f);
			//			Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time));
			if(Time.time > 0.5 )
			{
				Time.timeScale = 0;
			}
		}
	}

}
