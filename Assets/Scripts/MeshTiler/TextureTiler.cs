using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
[ExecuteInEditMode]
public class TextureTiler : MonoBehaviour {
    public int x_num;
    public int z_num;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Vector3 prevScale;
    public Material _material;
	// Update is called once per frame
    void OnValidate(){
        UpdateMesh();
    }
    public void UpdateMesh(){

		if (Application.isPlaying) return;
		if (meshFilter == null)
		{
			meshFilter = GetComponent<MeshFilter>();
			return;
		}
		if (meshRenderer == null)
		{
			meshRenderer = GetComponent<MeshRenderer>();
			return;
		}
		var mesh = new Mesh();
		var tempVerticleList = new List<Vector3>();

		for (int z = 0; z < z_num; z++)
		{
			for (int x = 0; x < x_num; x++)
			{
				tempVerticleList.AddRange(ReturnListVerticle(x, z));
			}
		}

		mesh.vertices = tempVerticleList.ToArray();

		var tempTrianglesList = new List<int>();

		var tmpUvs = new List<Vector2>();
		for (int i = 0; i < (x_num * z_num); i++)
		{
			tempTrianglesList.AddRange(ReturnTrianglesMesh(i, tmpUvs));
		}

		mesh.triangles = tempTrianglesList.ToArray();

		mesh.uv = tmpUvs.ToArray();
		mesh.RecalculateNormals();
        var building_material = AssetDatabase.LoadAssetAtPath("Assets/Materials/building/building_middle.mat", typeof(Material)) as Material;
        if(building_material!=null) meshRenderer.material = building_material;
		meshFilter.sharedMesh = mesh;
        float t = 0f;


    }
    void Start(){

    }

    void Update () {
        if (Application.isPlaying) return;
        if (meshFilter == null)
        {
            meshFilter = GetComponent<MeshFilter>();
            return;
        }
        if (meshRenderer == null){
            meshRenderer = GetComponent<MeshRenderer>();
            return;
        }
        if(prevScale!=this.transform.lossyScale){
            UpdateMesh();
        }
        prevScale = this.transform.lossyScale;


	}
    Vector3[] ReturnListVerticle(int x, int z)
    {

        List<Vector3> tmpList = new List<Vector3>(new Vector3[]{
            new Vector3(x,0,z),new Vector3(x+1,0,z),new Vector3(x+1,0,z+1),new Vector3(x,0,z+1),
             new Vector3(x,1,z),new Vector3(x+1,1,z),new Vector3(x+1,1,z+1),new Vector3(x,1,z+1)
        });

        return tmpList.Select((Vector3 v) =>
        {
            return new Vector3(v.x * this.transform.lossyScale.x,
            v.y * this.transform.lossyScale.y,
                         v.z * this.transform.lossyScale.z);
        }).ToArray();
    }

    int[] ReturnTrianglesMesh(int index,List<Vector2> uvs){
        List<int> ret = new List<int>(new int[]{
            4,1,0,
            4,5,1,

            5,2,1,
            5,6,2,

            6,3,2,
            6,7,3,

            7,0,3,
            7,4,0,

            3,1,2,
            3,0,1,

            6,4,7,
            6,5,4,
        });
        var uv = new List<Vector2>();
        for (int i = 0; i < 6;i+=4){
            uv.Add(new Vector2(0, 0));
            uv.Add(new Vector2(0, 1));
            uv.Add(new Vector2(1, 1));
            uv.Add(new Vector2(1, 0));

        }
        uvs.AddRange(uv);
        return ret.Select(v => v + index * 8).ToArray();
    }
}
