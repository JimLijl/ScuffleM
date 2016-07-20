using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

    private Rigidbody p_Rigidbody;
    private  Animator p_anim;
    private Vector3 p_GroundNormal;

    private GameObject p_Skill;
    private float ColdTime = 25f;
    private float SkillTime = 10f;
    private float OnSkillTime = 0;
    private bool isUseSkill;

    public GameObject savepos;
    public GameObject moveto;
    public GameObject moveback;
    public GameObject onskill;
    public GameObject skillcold;

    private GameObject p_SpeedUp;
    private GameObject p_JumpPowerUp;

    public float p_MoveSpeed = 1f;
    public float p_JumpPower = 10f;
    private bool p_isOnGroundCheck = true;
    private float p_GroundCheckDistance = 0.1f;
    private float p_Gravity = 2f;
    private float p_Turn;
    private float p_Forward;
    private float p_OriGroundCheckDistance;
    private float p_MovingTurnSpeed = 360;
    private float p_StationaryTurnSpeed = 180;

    

    

    // Use this for initialization
    void Start () {
        p_anim = GetComponent<Animator>();
        p_Rigidbody = GetComponent<Rigidbody>();
        p_OriGroundCheckDistance = p_GroundCheckDistance;
        p_Skill = GameObject.FindGameObjectWithTag(Tags.collectskill);
        p_SpeedUp = GameObject.FindGameObjectWithTag(Tags.collectspeed);
        p_JumpPowerUp = GameObject.FindGameObjectWithTag(Tags.collectJump);
    }

    void Update()
    {
        if (!p_SpeedUp)
        {
            p_MoveSpeed = 1.2f;
        }
        if (!p_JumpPowerUp)
        {
            p_JumpPower = 12f;
        }

        speedforce();

        Skill();
        

        
    }

    //角色进行移动
    public void Move(Vector3 move,bool isJump)
    {
        if(move.magnitude > 1)
        {
            move.Normalize();
        }
        move = transform.InverseTransformDirection(move);

        CheckOnGround();
        move = Vector3.ProjectOnPlane(move, p_GroundNormal);
        p_Turn = Mathf.Atan2(move.x, move.z);
        p_Forward = move.z;

        PlayerRota();

        if (p_isOnGroundCheck)
        {
            Jump(isJump);
        }else
        {
            Air();
        }

        SetAnim(move);
    }
    //控制角色动画播放
    void SetAnim(Vector3 move)
    {
        p_anim.SetFloat("Run", p_Forward, 0.1f, Time.deltaTime);
        p_anim.SetFloat("Turn", p_Turn, 0.1f, Time.deltaTime);
        p_anim.SetBool("isGround", p_isOnGroundCheck);
        if (!p_isOnGroundCheck)
        {
            p_anim.SetFloat("vel_y", p_Rigidbody.velocity.y);
        }

        if(p_isOnGroundCheck && move.magnitude > 0)
        {
            p_anim.speed = p_MoveSpeed;
        }else
        {
            p_anim.speed = 1;
        }
        

    

    }

    //角色跳跃
    void Jump(bool isJump)
    {


        if(isJump&& p_anim.GetCurrentAnimatorStateInfo(0).IsName("Ground"))
        {
            

            p_Rigidbody.velocity = new Vector3(p_Rigidbody.velocity.x, p_JumpPower, p_Rigidbody.velocity.z);
            //JumpSpeed = p_Rigidbody.velocity.y * 0.1f;
            p_isOnGroundCheck = false;
            
            p_GroundCheckDistance = 0.1f;
           
            
           
        }
        
        
    }

    void Air()
    {
        Vector3 extraGravityForce = (Physics.gravity * p_Gravity) - Physics.gravity;
        p_Rigidbody.AddForce(extraGravityForce);

        p_GroundCheckDistance = p_Rigidbody.velocity.y < 0 ? p_OriGroundCheckDistance : 0.01f;

        
    }

    

    void PlayerRota()
    {
        float TurnSpeed = Mathf.Lerp(p_StationaryTurnSpeed, p_MovingTurnSpeed, p_Forward);
        transform.Rotate(0, p_Turn * TurnSpeed * Time.deltaTime, 0);
    }

    public void OnAnimatorMove()
    {
        if(p_isOnGroundCheck && Time.deltaTime > 0)
        {
            Vector3 v = (p_anim.deltaPosition * p_MoveSpeed)/Time.deltaTime;

            v.y = p_Rigidbody.velocity.y;
            p_Rigidbody.velocity = v;
        }
    }

    //判断角色是否在地上
    void CheckOnGround()
    {
        RaycastHit hitInfo;

        //Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * p_GroundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, p_GroundCheckDistance))
        {
            p_GroundNormal = hitInfo.normal;
            p_isOnGroundCheck = true;
            
        }else
        {
            
            p_isOnGroundCheck = false;
            p_GroundNormal = Vector3.up;
            
        }

    }
    //角色获得技能即使用
    public void Skill()
    {

        if (!p_Skill)
        {
            
            if (Input.GetButton("Skill"))
            {
                isUseSkill = true;
            }
            


            

            if (isUseSkill == true)
            {
                OnSkillTime += Time.deltaTime;
            }

            if (OnSkillTime != 0 && OnSkillTime <= SkillTime)
            {
                p_JumpPower = 25f;
                iTween.MoveTo(onskill, moveto.transform.position, 0.5f);
            }
            else if(OnSkillTime > SkillTime)
            {
                iTween.MoveTo(onskill, moveback.transform.position, 0.5f);
                iTween.MoveTo(skillcold, moveto.transform.position, 0.5f);
                if (p_JumpPowerUp)
                {
                    p_JumpPower = 10f;
                }
                else
                {
                    p_JumpPower = 12f;
                }

            }

            if (OnSkillTime > ColdTime)
            {
                iTween.MoveTo(skillcold, moveback.transform.position, 0.5f);
                isUseSkill = false;
                OnSkillTime = 0f;
            }

        }
    }

    void speedforce()
    {
        if (Input.GetKey(KeyCode.J))
        {
            this.transform.position = new Vector3(-37.948f, 275.094f, 32.257f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            this.transform.position = new Vector3(-158.5f, 124.98f, 47.9f);
        }
        if (Input.GetKey(KeyCode.L))
        {
            this.transform.position = new Vector3(-172.497f, 96.21f, -64.957f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            this.transform.position = new Vector3(-13, 159, -47);
        }
        if (Input.GetKey(KeyCode.I))
        {
            this.transform.position = new Vector3(-95, 83, -32);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            savepos.transform.position = this.transform.position;
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.position = savepos.transform.position;
        }

        

    }

}
