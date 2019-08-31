using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBar : MonoBehaviour {

	// Use this for initialization
	Transform transform_energyBar; 
	private float changing_rate = 0.025f;
	private float temp_power;
	public float power_val;
	// {
	// 	//get;set;
	// 	get{return temp_power;}
	// 	set{power_val = temp_power;}
	// }// in percentage
	//	0 >> strinking, 
	//	1 >> expending, 
	//	2 >> button pressed, stop movement
	private int direction_up = 0;

	void Start () {
        transform_energyBar = GetComponent<Transform>();
	}
	private void BAR_expending(){
		//expending
		//Debug.Log("expending, scale.y = "+ transform_energyBar.localScale.y+", position.y = "+ transform_energyBar.localPosition.y);
		transform_energyBar.localScale += new Vector3(0,changing_rate,0);
		transform_energyBar.localPosition += new Vector3(0,changing_rate,0);
	}
	private void BAR_strinking(){
		//strinking
		// Debug.Log("strinking, scale.y = "+ transform_energyBar.localScale.y+", position.y = "+ transform_energyBar.localPosition.y);
		transform_energyBar.localScale -= new Vector3(0,changing_rate,0);
		transform_energyBar.localPosition -= new Vector3(0,changing_rate,0);
	
	}
	// Update is called once per frame
	void Update () {
		
			//Debug.Log("power val : "+ transform_energyBar.localScale.y);
		if(direction_up == 1){
			if(transform_energyBar.localScale.y >= 0.2f){
				BAR_strinking();
			}
			else{
				direction_up = 0;
			}
		}else if(direction_up == 0){
			if(transform_energyBar.localScale.y <= 2.0f){
				BAR_expending();
			}
			else{
				direction_up = 1;
			}
		}
		if(Input.GetKey(KeyCode.A)){
			temp_power = transform_energyBar.localScale.y / 2;
			Debug.Log("space bar! return:"+ temp_power);
			
			direction_up = 2;
		}
		if(Input.GetKey(KeyCode.R)){
			Debug.Log("R hit, reset power bar!");
			direction_up = 0;
		}
		
	}

	public float get_power_val(){return temp_power;}
}
