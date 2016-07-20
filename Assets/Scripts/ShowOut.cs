using UnityEngine;
using System.Collections;

public class ShowOut : MonoBehaviour {

    public GameObject coll;
    public GameObject moveto;
    public GameObject moveback;

    private float Timer;
    private bool isshowout;

	// Use this for initialization
	void Start () {
        isshowout = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!coll && isshowout){
            iTween.MoveTo(this.gameObject, moveto.transform.position, 0.5f);
            Timer += Time.deltaTime;
            if(Timer > 2)
            {
                iTween.MoveTo(this.gameObject, moveback.transform.position, 0.5f);
                isshowout = false;
            }

        }
	}
}
