using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

[RequireComponent(typeof(CharacterController))]

public class MoveTest : MonoBehaviour {

    private CharacterController controller = null;
    private UnityArmatureComponent armatureComponent = null;
    public GameObject role;

    private const string NORMAL_ANIMATION_GROUP = "normal";
    private const string AIM_ANIMATION_GROUP = "aim";
    private const string ATTACK_ANIMATION_GROUP = "attack";

    //键位
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode DirToLeft = KeyCode.Q;
    public KeyCode DirToRight = KeyCode.E;

    public float walkspeed;

    // Use this for initialization
    void Start () {
        if (controller == null) {
            controller = this.GetComponent<CharacterController>();
        }
        if (armatureComponent == null && role != null) {
            armatureComponent = role.GetComponent<UnityArmatureComponent>();
        }
        walkspeed = 3f;

        //设置当前动画组件的支架中的位置的显示由之前定义的一个正常动画组控制，这是一个String值
        armatureComponent.armature.GetSlot("effects_1").displayController = NORMAL_ANIMATION_GROUP;
        armatureComponent.armature.GetSlot("effects_2").displayController = NORMAL_ANIMATION_GROUP;

    }
	
	// Update is called once per frame
	void Update () {
        if (armatureComponent.animation.isPlaying) {
            Debug.Log("111111111111");
        }
        if (Input.GetKey(left))
        {
            controller.Move(new Vector3(-walkspeed, 0, 0) * Time.deltaTime);
            //armatureComponent.animation.Play("walk",1);
            armatureComponent.animation.FadeIn("walk", -1f, 1, 0, NORMAL_ANIMATION_GROUP);
            armatureComponent.flipX = true;
        }
        else if (Input.GetKey(right))
        {
            controller.Move(new Vector3(walkspeed, 0, 0) * Time.deltaTime);
            //armatureComponent.animation.Play("walk",1);
            armatureComponent.animation.FadeIn("walk", -1f, 1, 0, NORMAL_ANIMATION_GROUP);
            armatureComponent.flipX = true;
        }
        else if (Input.GetKey(up))
        {
            controller.Move(new Vector3(0, 0, walkspeed) * Time.deltaTime);
            //armatureComponent.animation.Play("walk",1);
            armatureComponent.animation.FadeIn("walk", -1f, 1, 0, NORMAL_ANIMATION_GROUP);
            armatureComponent.flipX = true;
        }
        else if (Input.GetKey(down))
        {
            controller.Move(new Vector3(0, 0, -walkspeed) * Time.deltaTime);
            //armatureComponent.animation.Play("walk",1);
            armatureComponent.animation.FadeIn("walk", -1f, 1, 0, NORMAL_ANIMATION_GROUP);
            armatureComponent.flipX = true;
        }
        else {
            //armatureComponent.animation.FadeIn("idle", -1f, 1, 0, NORMAL_ANIMATION_GROUP);
        }



    }
}
