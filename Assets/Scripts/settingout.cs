using UnityEngine;
using System.Collections;

public class settingout : MonoBehaviour {

    public GameObject g_setting;
    public GameObject moveto;

	public void Setting()
    {
        iTween.MoveTo(g_setting, moveto.transform.position, 0.5f);
    }
}
