using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparent : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Wall") {
			c.gameObject.GetComponent<Renderer> ().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Wall") {
			c.gameObject.GetComponent<Renderer> ().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.On;
		}
	}
}
