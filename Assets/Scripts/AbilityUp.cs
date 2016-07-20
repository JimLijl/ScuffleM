using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityUp : MonoBehaviour {
    public string ANumberRead;
    public int ANumber;
    public int ANumberUp;
    public string ANumberIn;
	// Use this for initialization
	void Start () {
        ANumberRead = GameObject.Find("Text").GetComponent<Text>().text;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Text").GetComponent<Text>().text = ANumberIn;
	}

    public void OnClick()
    {
        ANumber = int.Parse(ANumberRead);
        ANumberUp = ANumber + 1;
        ANumberIn = ANumberUp.ToString();
    }
    
}
