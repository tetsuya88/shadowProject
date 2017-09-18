﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class SetBuildTileEasy : MonoBehaviour {
    public int _x;
    public int _z;
    public Material _material;
    private void OnValidate()
    {
        foreach(var textureTiler in GetComponentsInChildren<TextureTiler>()){
            textureTiler.x_num = _x;
            textureTiler.z_num = _z;
            textureTiler.UpdateMesh();
            if (_material != null)
            {
                textureTiler.transform.GetComponent<MeshRenderer>().material = _material;
            }
        }
    }
    // Use this for initialization
    void Start () {
        if (!Application.isPlaying) return;
        var collider = GetComponent<BoxCollider>();
        if(collider == null){
            collider = gameObject.AddComponent<BoxCollider>();
        }

        collider.center = new Vector3(((float)_x / 2f)*transform.lossyScale.x, ((float)transform.childCount / 2f)* transform.lossyScale.y , ((float)_z / 2f)*transform.lossyScale.z);
        collider.size = new Vector3(((float)_x)*transform.lossyScale.x, ((float)transform.childCount)* transform.lossyScale.y, ((float)_z)*transform.lossyScale.z);

		foreach(var textureTiler in GetComponentsInChildren<TextureTiler>()){
			textureTiler.x_num = _x;
			textureTiler.z_num = _z;
			textureTiler.UpdateMesh();
			if (_material != null)
			{
				textureTiler.transform.GetComponent<MeshRenderer>().material = _material;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying) return;


        for (int i = 0; i < this.transform.childCount;i++){
            this.transform.GetChild(i).transform.localPosition = new Vector3(0f, (float)(i * this.transform.lossyScale.y), 0f);
        }
		foreach(var textureTiler in GetComponentsInChildren<TextureTiler>()){
			textureTiler.x_num = _x;
			textureTiler.z_num = _z;
			textureTiler.UpdateMesh();
			if (_material != null)
			{
				textureTiler.transform.GetComponent<MeshRenderer>().material = _material;
			}
		}

	}


}
