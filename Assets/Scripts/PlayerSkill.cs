using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {

	public GameObject throwLine;
	public float speed = 1000f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject throwline = GameObject.Instantiate (throwLine)as GameObject;
			throwline.transform.position = transform.position;
			throwline.GetComponent<Rigidbody> ().AddForce (this.transform.forward*speed);
		}
	}
}
