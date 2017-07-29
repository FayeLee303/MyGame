using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBonesTest : MonoBehaviour {

    public UnityDragonBonesData ubbieData;
	// Use this for initialization
	void Start () {
        // 读取数据
        UnityFactory.factory.LoadData(ubbieData); // DragonBones file path (without suffix)
       // UnityFactory.factory.LoadTextureAtlasData("Ubbie/texture"); //Texture atlas file path (without suffix) 
        // Create armature.
        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Ubbie"); // Input armature names                                                                                     
        armatureComponent.animation.Play("walk");// Play animation.

        // Change armatureposition.
        armatureComponent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        // Set flip.
        armatureComponent.armature.flipX = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
