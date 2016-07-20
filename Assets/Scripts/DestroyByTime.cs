using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float staytime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,staytime);
	}
	

}
