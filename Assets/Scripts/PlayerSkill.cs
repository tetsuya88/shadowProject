using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {

	public GameObject batCircle;
	public float speed=3f;
	public float minpos=2f;
	public float maxpos=5f;

	private GameObject batcircle;
	private Vector3 startpos;
	private float dis = 0f;

	void Start () {
		
	}

	void Update () {
		startpos = transform.forward * minpos+ new Vector3(0,-1f,0);
		if (Input.GetKeyDown (KeyCode.Space)) {
			dis = 0f;
			batcircle = Instantiate (batCircle) as GameObject;
			batcircle.transform.position = transform.position + transform.forward*dis + startpos;
		}else if (Input.GetKeyUp (KeyCode.Space)) {
			Destroy (batcircle);
		}else if(Input.GetKey(KeyCode.Space)){
			if (dis < maxpos-minpos) {
				dis += Time.deltaTime * speed;
			} 
			batcircle.transform.position = transform.position + transform.forward * dis + startpos;
		}
	}
}
