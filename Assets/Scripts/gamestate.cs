using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamestate : MonoBehaviour {

    public Text jumppower;
    public Text speed;
    public Text collNum;

    private PlayerCharacter p_char;

    private GameObject collspeed;
    private GameObject colljump;
    private GameObject collskill;

    ArrayList coll = new ArrayList();
    // Use this for initialization
    void Start () {

        p_char = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerCharacter>();
        collspeed = GameObject.FindGameObjectWithTag(Tags.collectspeed);
        colljump = GameObject.FindGameObjectWithTag(Tags.collectJump);
        collskill = GameObject.FindGameObjectWithTag(Tags.collectskill);


        coll.Add(collspeed);
        coll.Add(colljump);
        coll.Add(collskill);
    }
	
	// Update is called once per frame
	void Update () {

        if (!collspeed)
        {
            coll.Remove(collspeed);
        }
        if (!colljump)
        {
            coll.Remove(colljump);
        }
        if (!collskill)
        {
            coll.Remove(collskill);
        }

        

        jumppower.text = "当前角色跳跃力：" + p_char.p_JumpPower;
        speed.text = "当前角色速度：" + p_char.p_MoveSpeed;
        collNum.text = "剩余收集品个数：" + coll.Count;

        if (coll.Count == 0)
        {
            collNum.text = "请前往逃出点";
        }
    }
}
