using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparent : MonoBehaviour {
    void Start(){
        
    }
    void Update(){

    }
	void OnTriggerEnter(Collider c){
        if (LayerMask.LayerToName(c.gameObject.layer) == "Wall" ) {
			var parent = c.gameObject.transform.parent;
			foreach (var child in parent.transform.GetComponentsInChildren<Renderer>())
			{
                child.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			}

		}
	}

	void OnTriggerExit(Collider c){
		if (LayerMask.LayerToName(c.gameObject.layer) == "Wall") {
            var parent = c.gameObject.transform.parent;
            foreach (var child in parent.transform.GetComponentsInChildren<Renderer>()) {
                child.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

		}
	}
}
