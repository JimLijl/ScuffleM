using UnityEngine;
using System.Collections;

public class CreatePortal : MonoBehaviour {
	
	public GameObject Portal;
	public Transform Portaltran;
	void OnTriggerEnter( Collider other ){
		
		
		if(other.tag == "Player")
		{
			Destroy (gameObject);
			Instantiate(Portal,Portaltran.position,Portaltran.rotation);
		}
		
		
		
	}
}
