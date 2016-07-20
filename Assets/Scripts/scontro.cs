using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scontro : MonoBehaviour {

    public GameObject cam;
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = cam.GetComponent<AudioSource>();
	}
	
	public void soundcontroller()
    {
        sound.volume = this.GetComponent<Slider>().value;
    }
}
