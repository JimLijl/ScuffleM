using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
    private Vector3 offsetPosition;//位置偏移
    private bool isRota; //是否进行旋转
    
    public float scrollSpeed = 10;
    public float rotateSpeed = 3;
     
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = offsetPosition + player.position;

        rota();
        
    }
    //通过鼠标左键或手指点击触摸屏旋转视角
    void rota()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRota = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isRota = false;
        }

        if(isRota == true)
        {
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));
        }
        offsetPosition = transform.position - player.position;
    }
}
    

