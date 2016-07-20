using UnityEngine;
using System.Collections;

public class testbottom : MonoBehaviour {

	public Transform b;
	public Transform tar;
	public float speed = 3;
	
	void OnMouseOver()
	{
		b.rotation = Quaternion.Slerp(b.rotation, Quaternion.LookRotation(tar.position - b.position), speed * Time.deltaTime);
	}

}
