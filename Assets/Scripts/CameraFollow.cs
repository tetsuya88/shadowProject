using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
	private Vector3 pos;

	void Start () {
        pos = this.transform.position - player.transform.position;
		//transform.rotation = Quaternion.LookRotation (player.transform.position - transform.position);
	}

	void FixedUpdate () {
     
        //transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		this.transform.position = player.transform.position + pos;
	}
}
