﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float speed = 1f;
    public Animator anim;
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
			/*
            var cameraPosition = Camera.main.transform.position;
            var forwardVec = new Vector3((this.transform.position - cameraPosition).x, 0f,(this.transform.position - cameraPosition).z);
            forwardVec = forwardVec.normalized;
            var rightVec = Vector3.Cross(forwardVec, Vector3.up);

            this.transform.forward = z * forwardVec + -1f*x*rightVec;
			rb.MovePosition(transform.position + z*Time.deltaTime * forwardVec*speed + -1f*x *Time.deltaTime * rightVec*speed);
			*/
			rb.MovePosition (transform.position + new Vector3 (x * Time.deltaTime * speed, 0f, z * Time.deltaTime * speed));
			rb.velocity = Vector3.zero;
			if (x != 0 || z != 0)
            {
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Taiki"))
                anim.Play("Hashiri");
				transform.rotation = Quaternion.LookRotation(transform.position+Vector3.right * x + Vector3.forward * z -transform.position);
            }

		}
		else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hashiri"))
		{
			Debug.Log("aa");
			anim.Play("Taiki");
		}
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AA");
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Person"){
            anim.Play("Attack");
            GetComponent<AudioSource>().Play();
        }
    }
}
