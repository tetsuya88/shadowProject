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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
