using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SetBuildTileEasy : MonoBehaviour {
    public int _x;
    public int _z;
    private void OnValidate()
    {
        foreach(var textureTiler in GetComponentsInChildren<TextureTiler>()){
            textureTiler.x_num = _x;
            textureTiler.z_num = _z;
            textureTiler.UpdateMesh();
        }
    }
    // Use this for initialization
    void Start () {
        if (!Application.isPlaying) return;
        var collider = GetComponent<BoxCollider>();
        if(collider == null){
            collider = gameObject.AddComponent<BoxCollider>();
        }

        collider.center = new Vector3((float)_x / 2f, (float)transform.childCount / 2f + 1f, (float)_z / 2f);
        collider.size = new Vector3((float)_x, (float)transform.childCount, (float)_z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
