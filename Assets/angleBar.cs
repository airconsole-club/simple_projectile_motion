using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleBar : MonoBehaviour {
	Transform transform_angle_bar;
	Vector3 rotation_location;
	Vector3 rotation_axis;
	private int movement_flag= 0;
	private float rotation_rate = 1f;
	public float return_angle_val{get ; set ;}
	// Use this for initialization
	void Start () {
		transform_angle_bar = GetComponent<Transform>();
		rotation_location = new Vector3(-30, 1f, 5f);
		rotation_axis = new Vector3(0,0,-0.5f);
	}
	private void anti_clockwiseMotion(){
		transform_angle_bar.RotateAround(rotation_location,rotation_axis,-1*rotation_rate);
	}
	private void clockwiseMotion(){
		transform_angle_bar.RotateAround(rotation_location,rotation_axis,rotation_rate);
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log("r.Lz = " + (360 -transform_angle_bar.localRotation.eulerAngles.z));
		
		//anti_clockwiseMotion();
		//clockwiseMotion();

		if(movement_flag == 0 ){
			// if(	(transform_angle_bar.localEulerAngles.z >= 270)
			// 		 || transform_angle_bar.localEulerAngles.z == 0){
				clockwiseMotion();
			if(transform_angle_bar.localEulerAngles.z < 280){
				//Debug.Log("===================anti_clockwise now!!!==============================");
				movement_flag = 1;
			}
		}
		else if(movement_flag == 1){
			
				anti_clockwiseMotion();
			if(transform_angle_bar.localEulerAngles.z > 355){
				//Debug.Log("===================clockwise now!!!==============================");
				movement_flag = 0;
			}
		}
		if(Input.GetKey(KeyCode.S)){
			movement_flag = 2;
			Debug.Log("return angle:" + (transform_angle_bar.localRotation.eulerAngles.z - 270));
			return_angle_val = (transform_angle_bar.localRotation.eulerAngles.z - 270)	;
		}
		if(Input.GetKey(KeyCode.R)){
			movement_flag = 1;
		}
	
	}
	public float get_angle_val(){return return_angle_val;}
}
