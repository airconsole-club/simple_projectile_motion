using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckYouAndy : MonoBehaviour {

	// Use this for initialization
    Rigidbody rigidBody;
    Transform transform;
	bool flyingFlag = false;
	[SerializeField]    float CONST_full_launch_force = 50f;
	float test_flying_force_x = 0.1f;
	float test_flying_force_y = 10f;
	energyBar someEnergy;
	angleBar someangle;
	public GameObject dicked_ass_force;
	public GameObject dicked_ass_angle;
	private Vector3 game_start_location;

	float temp_angle = 0;
	float temp_power = 0;
	void Start () {
		// game_start_location = transform.localPosition;
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
		dicked_ass_force = GameObject.Find("energy_bar");
		dicked_ass_angle = GameObject.Find("angle_bar");
		someEnergy = dicked_ass_force.GetComponent<energyBar>();
		someangle = dicked_ass_angle.GetComponent<angleBar>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			Debug.Log("fly key is hit,power: "+ someEnergy.get_power_val()+"angle: "+ someangle.get_angle_val());
			temp_power = someEnergy.get_power_val();
			temp_angle = someangle.get_angle_val() * Mathf.PI /180;

			Debug.Log("power value" +temp_power);
			Debug.Log("angle value" +temp_angle);
				test_flying_force_x = Mathf.Sin(temp_angle) * CONST_full_launch_force;
				test_flying_force_y = Mathf.Cos(temp_angle) * CONST_full_launch_force;
			Debug.Log("test_flying_force_x value = " + test_flying_force_x);
			Debug.Log("test_flying_force_y value = " + test_flying_force_y);
			flyingFlag = true;
		}
		if(flyingFlag){
			// test_flying_force_x = 25;
			// test_flying_force_y = 25;
			rigidBody.AddRelativeForce(new Vector3(test_flying_force_x,test_flying_force_y,0));
			//rigidBody.AddRelativeForce(new Vector3(-50,0,0));
			
			while(test_flying_force_y >=1){
				//Debug.Log("x="+test_flying_force_x + ", y="+ test_flying_force_y);
				test_flying_force_y *= 0.8f;
				test_flying_force_x *= 0.8f;

			}
		}
		if(Input.GetKey(KeyCode.R)){
			Debug.Log("reset all.....");
			flyingFlag = false;
			test_flying_force_y = 10f;
			transform.localPosition = new Vector3(-20,5,0);
		}
	}
}
