using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparent : MonoBehaviour {
    public GameObject player;
    void Start(){
        player.transform.LookAt(new Vector3(player.transform.position.x - this.transform.position.x, 0f,player.transform.position.z-this.transform.position.z));
    }
    void Update(){

        this.transform.rotation = Quaternion.identity;
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
