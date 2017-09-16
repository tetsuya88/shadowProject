using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float speed = 1f;
	private float x = 0f, z = 0f;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
			x = Input.GetAxis ("Horizontal");
			z = Input.GetAxis ("Vertical");
			rb.MovePosition(transform.position+new Vector3(x * Time.deltaTime * speed, 0f, z * Time.deltaTime * speed));

			transform.rotation = Quaternion.LookRotation(transform.position + 
				Vector3.right * x + Vector3.forward * z - transform.position);
		}
	}
}
