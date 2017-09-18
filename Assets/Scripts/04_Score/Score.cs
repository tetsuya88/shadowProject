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
	public Text myscore;
	public Text rank;
	public int Sline=20;
	public int Aline=16;
	public int Bline=12;
	public int Cline=8;
	public int Dline=4;

	public void Start(){
		/*
		PlayerPrefs.SetInt ("score1", 0);
		PlayerPrefs.SetInt ("score2", 0);
		PlayerPrefs.SetInt ("score3", 0);
		PlayerPrefs.SetInt ("score4", 0);
		PlayerPrefs.SetInt ("score5", 0);
		*/
		List<int> ranklist = new List<int> ();
		for (int i=0; i < 5; i++) {
			ranklist.Add(PlayerPrefs.GetInt ("score" + (i + 1), 0));
		}
		ranklist.Sort(delegate(int a,int b) {return b-a;});

		rank1.text = "1. " + ranklist [0];
		rank2.text = "2. " + ranklist [1];
		rank3.text = "3. " + ranklist [2];
		rank4.text = "4. " + ranklist [3];
		rank5.text = "5. " + ranklist [4];
		int myscorenum = PlayerPrefs.GetInt ("myscore", 0);
		myscore.text = "" + myscorenum;
		if (myscorenum > Sline) {
			rank.text = "S";
		} else if (myscorenum > Aline) {
			rank.text = "A";
		} else if (myscorenum > Bline) {
			rank.text = "B";
		} else if (myscorenum > Cline) {
			rank.text = "C";
		} else if (myscorenum > Dline) {
			rank.text = "D";
		} else {
			rank.text = "-";
		}
	}

	public void Update(){
		Debug.Log ("a");
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (0);
		}
	}
}
