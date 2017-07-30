﻿using System.Collections;
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
    public bool faceDir;//false是右边，true是左边

    // Use this for initialization
    void Start () {
        if (controller == null) {
            controller = this.GetComponent<CharacterController>();
        }
        if (armatureComponent == null && role != null) {
            armatureComponent = role.GetComponent<UnityArmatureComponent>();
        }
        walkspeed = 3f;
        faceDir = false;
        armatureComponent.armature.flipX = false;
        armatureComponent.animation.Play("idle", -1);
    }
	
	// Update is called once per frame
	void Update () {

        bool moveKeyPressed = Input.GetKeyDown(left) || Input.GetKeyDown(right) || Input.GetKeyDown(up) || Input.GetKeyDown(down);
        bool moveKeyUp = Input.GetKeyUp(left) || Input.GetKeyUp(right) || Input.GetKeyUp(up) || Input.GetKeyUp(down);
        bool moving = Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(up) || Input.GetKey(down);
        // if any move key was pressed down this frame, start walk animation
        if (moveKeyPressed)
        {
            armatureComponent.animation.Play("walk", -1);
           
        }
        // else if not moving at all and a movement key was released
        else if (!moving && moveKeyUp)
        {
            armatureComponent.animation.Play("idle", -1);
        }
        if (moving) {
            if (Input.GetKey(left))
            {
                MoveCtrl("left");
                faceDir = true;
            }
            else if (Input.GetKey(right))
            {
                MoveCtrl("right");
                faceDir = false;
            }
            else if (Input.GetKey(up))
            {
                MoveCtrl("up");
            }
            else if (Input.GetKey(down))
            {
                MoveCtrl("down");
            }
        }
        if (faceDir)
        {
            armatureComponent.armature.flipX = true;
        }
        else {
            armatureComponent.armature.flipX = false;
        }
    
    }

    void MoveCtrl(string dir) {
        switch(dir){
            case "left":
                controller.Move(new Vector3(-walkspeed, 0, 0) * Time.deltaTime);
                break;
            case "right":
                controller.Move(new Vector3(walkspeed, 0, 0) * Time.deltaTime);
                break;
            case "up":
                controller.Move(new Vector3(0, 0, walkspeed) * Time.deltaTime);
                break;
            case "down":
                controller.Move(new Vector3(0, 0, -walkspeed) * Time.deltaTime);
                break;
        }
    }

}
