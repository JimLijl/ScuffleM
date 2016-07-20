using UnityEngine;
using System.Collections;

public class textvideo : MonoBehaviour {

	//电影纹理
	public MovieTexture movTexture;
	
	void Start()
	{
		//设置电影纹理播放模式为循环
		movTexture.loop = true;
	}
	
	void OnGUI()
	{
		//绘制电影纹理
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);  

		if (!movTexture.isPlaying) {
			movTexture.Play ();
		}
	}
}
