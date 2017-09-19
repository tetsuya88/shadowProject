using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour {
 
	private bool flag = true;
	private float timecount = 1f;

	public int max = 20;
	public float gametime = 90;
	public GameObject obasan;
	public GameObject syonen;
	GameObject[] nodes;

	void Start () {
		nodes = GameObject.FindGameObjectsWithTag ("Node");
	}

	void Update () {
		timecount -= Time.deltaTime;
        gametime -= Time.deltaTime;
		if(timecount <0){
            if(gametime>60){
                timecount = 2f;
            }else if(gametime>30){
                timecount = 1f;
            }else{
                timecount = 0.5f;
            }


			GameObject[] villagers = GameObject.FindGameObjectsWithTag ("Person");
			if (villagers.Length < max) {
				int index = Random.Range (0, nodes.Length);
				if (flag) {
					flag = false;
					Instantiate (obasan, nodes[index].transform.position,Quaternion.identity);
				} else {
					flag = true;
					Instantiate (syonen, nodes[index].transform.position,Quaternion.identity);
				}
			}
		}
	}
}
