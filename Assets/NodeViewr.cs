using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class NodeViewr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        foreach (var nodeTransform in GetComponentsInChildren<Transform>()){
            if (nodeTransform == this.transform) continue;
            Gizmos.DrawSphere(nodeTransform.position, 2f);
        }
    }
}
