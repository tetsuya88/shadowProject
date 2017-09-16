using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadowCheck : MonoBehaviour {
	public Component light =null;
	private Vector3 dir;

	Ray ray;
	RaycastHit hit;
	int dis =100;

	void Update (){
		Ray ();
	}

	void Ray () {
		dir = light.transform.forward*(-1);
		ray = new Ray (transform.Find("rayAnchor").transform.position, dir);
		//Debug.DrawLine (ray.origin, ray.direction * dis, Color.red,Time.deltaTime,true);

		if (Physics.Raycast (ray, out hit, dis) && (hit.collider.tag == "Wall") ){
			GetComponent<Renderer> ().material.color = Color.black;
		}else {
			GetComponent<Renderer> ().material.color = Color.red;
		}
	}
}
