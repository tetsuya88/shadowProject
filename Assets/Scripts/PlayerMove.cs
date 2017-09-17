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

	void FixedUpdate(){
		Move ();
	}

	void Move () {
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			x = Input.GetAxis ("Horizontal");
			z = Input.GetAxis ("Vertical");
            var cameraPosition = Camera.main.transform.position;
            var forwardVec = new Vector3((this.transform.position - cameraPosition).x, 0f,(this.transform.position - cameraPosition).z);
            forwardVec = forwardVec.normalized;
            var rightVec = Vector3.Cross(forwardVec, Vector3.up);

            this.transform.forward = z * forwardVec + -1f*x*rightVec;
            rb.MovePosition(transform.position + z*Time.deltaTime * forwardVec*speed + -1f*x *Time.deltaTime * rightVec*speed);
			//rb.MovePosition (transform.position + new Vector3 (x * Time.deltaTime * speed, 0f, z * Time.deltaTime * speed));
			if (x != 0 || z != 0) {
				transform.rotation = Quaternion.LookRotation (transform.position +
				Vector3.right * x + Vector3.forward * z - transform.position);
			}
		}
	}
		
}
