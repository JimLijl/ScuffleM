using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private PlayerCharacter p_Character;
    
    private Transform p_Cam;
    private Vector3 p_CamForward;
    private Vector3 p_move;
    private bool isJump;

    
	// Use this for initialization
	void Start () {
        p_Cam = Camera.main.transform;
        p_Character = GetComponent<PlayerCharacter>();
	}
	
    
	// Update is called once per frame
	void Update () {
        if(isJump == false)
        {
            isJump = Input.GetButtonDown("Jump");
        }
    }

    public void JumpButtonDown()
    {
        if (isJump == false)
        {
            
            isJump = true;
        }
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //float h = playerJoystick.JoystickAxis.x;
        //float v = playerJoystick.JoystickAxis.y;

        p_CamForward = Vector3.Scale(p_Cam.forward, new Vector3(1, 0, 1)).normalized;
        p_move = v * p_CamForward + h * p_Cam.right;

        p_Character.Move(p_move,isJump);
        isJump = false;
    }

   
   
}
