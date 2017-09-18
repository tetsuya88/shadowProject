using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score: MonoBehaviour {
	public Text rank1;
	public Text rank2;
	public Text rank3;
	public Text rank4;
	public Text rank5;

	public void Start(){
		/*
		PlayerPrefs.SetInt ("score1", 100);
		PlayerPrefs.SetInt ("score2", 10);
		PlayerPrefs.SetInt ("score3", 1);
		PlayerPrefs.SetInt ("score4", 20);
		PlayerPrefs.SetInt ("score5", 200);
		*/
		List<int> ranklist = new List<int> ();
		for (int i=0; i < 5; i++) {
			ranklist.Add(PlayerPrefs.GetInt ("score" + (i + 1), 0));
		}
		ranklist.Sort(delegate(int a,int b) {return b-a;});
		rank1.text = "1st:" + ranklist [0];
		rank2.text = "2nd:" + ranklist [1];
		rank3.text = "3rd:" + ranklist [2];
		rank4.text = "4th:" + ranklist [3];
		rank5.text = "5th:" + ranklist [4];
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene (0);
		}
	}
}
