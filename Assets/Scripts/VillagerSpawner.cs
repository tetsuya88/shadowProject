using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour {

	private int num = 0; 
	private bool flag = 0;
	private float timecount = 3f;

	public int max = 10;
	public GameObject obasan;
	public GameObject syonen;

	void Start () {
		
	}

	void Update () {
		timecount
		if(timecount <0){
			GameObject[] villagers = GameObject.FindGameObjectsWithTag ("Person");
			if (villagers.Length < max) {
				if()
			}
		}
	}
}
