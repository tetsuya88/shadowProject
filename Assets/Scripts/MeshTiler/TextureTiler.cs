using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[ExecuteInEditMode]
public class TextureTiler : MonoBehaviour {
    public int x_num;
    public int z_num;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
	// Update is called once per frame
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
        var mesh = new Mesh();
		var tempVerticleList = new List<Vector3>();

        for (int z = 0;z<z_num;z++){
            for (int x = 0; x < x_num;x++){
				tempVerticleList.AddRange(ReturnListVerticle(x, z));
            }
        }

        mesh.vertices = tempVerticleList.ToArray();

        var tempTrianglesList = new List<int>();


        for (int i = 0; i < (x_num * z_num);i++){
			tempTrianglesList.AddRange(ReturnTrianglesMesh(i));
        }

        mesh.triangles = tempTrianglesList.ToArray();

		mesh.RecalculateNormals();
        meshFilter.sharedMesh = mesh;


	}
    Vector3[] ReturnListVerticle(int x, int z)
    {
        return new Vector3[]{
            new Vector3(x,0,z),new Vector3(x+1,0,z),new Vector3(x+1,0,z+1),new Vector3(x,0,z+1),
			 new Vector3(x,1,z),new Vector3(x+1,1,z),new Vector3(x+1,1,z+1),new Vector3(x,1,z+1)
        };
    }

    int[] ReturnTrianglesMesh(int index){
        List<int> ret = new List<int>(new int[]{
            3,0,1,
            3,1,2,

            0,5,1,
            0,4,5,

            2,1,5,
            5,6,2,

            7,2,6,
            7,3,2,

            4,3,7,
            4,0,3,

            6,5,4,
            6,4,7
        });

        return ret.Select(v => v + index * 8).ToArray();
    }
}
