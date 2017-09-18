using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadowCheck : MonoBehaviour {
	public GameObject lgt = null;
	public GameObject mainui;
	private Vector3 dir;

	Ray ray;
	RaycastHit hit;
	int dis =100;
	int layerNo,layerMask;

	void Start(){
		layerNo = LayerMask.NameToLayer("Wall");
		layerMask = 1 << layerNo;
	}

	void Update (){
		Ray ();
	}

	void Ray () {
		dir = lgt.transform.forward*(-1);
		ray = new Ray (transform.Find("rayAnchor").transform.position, dir);
		Debug.DrawLine (ray.origin, ray.direction * dis, Color.red,Time.deltaTime,true);

		if (Physics.Raycast (ray, out hit, dis,layerMask) && (hit.collider.tag == "Wall") ){
			GetComponent<Renderer> ().material.color = Color.black;
			mainui.GetComponent<Main> ().Recovery ();
		}else {
			GetComponent<Renderer> ().material.color = Color.red;
			mainui.GetComponent<Main> ().Damage ();
		}
	}
}
