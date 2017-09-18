using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour {
 
	private bool flag = true;
	private float timecount = 3f;

	public int max = 10;
	public GameObject obasan;
	public GameObject syonen;
	GameObject[] nodes;

	void Start () {
		nodes = GameObject.FindGameObjectsWithTag ("Node");
	}

	void Update () {
		timecount -= Time.deltaTime;
		if(timecount <0){
			timecount = 3f;
			GameObject[] villagers = GameObject.FindGameObjectsWithTag ("Person");
			if (villagers.Length < max) {
				int index = Random.Range (0, nodes.Length);
				if (flag) {
					flag = false;
					//Instantiate (obasan, nodes[index].transform.position);
				} else {
					flag = true;
				//	Instantiate (syonen, nodes[index].transform.position);
				}
			}
		}
	}
}
