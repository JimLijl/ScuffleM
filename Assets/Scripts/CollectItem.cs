using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour {


	void OnTriggerEnter( Collider other ){
		
		
		if(other.tag == "Player")
		{
			Destroy (gameObject);
		}

		
		
	}
}