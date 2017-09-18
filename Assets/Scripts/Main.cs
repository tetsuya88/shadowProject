using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
	public Text scoreText;
	public Text timeText;
	public Slider slider;
	public float time =120f;
	public int clearLine = 10;
	public float lifetime = 3;

	private int score = 0;
	bool flag=false;

	void Update () {
		//debug
		//Damage ();
		//Recovery ();
		if (Input.GetKeyDown (KeyCode.G)) {
			SceneManager.LoadScene (3);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			SceneManager.LoadScene (4);
		}
		scoreText.text = ""+score;

		if (flag) {
			time -= Time.deltaTime;
			timeText.text = ""+(int)time;
			if (time < 0) {
				if (score < clearLine) {
					SceneManager.LoadScene (3);
				} else {
					Result ();
				}
			}
		}
	}

	//村人を殺したら呼んでください
	public void scorePlus(){
		score++;
	}

	//タイマーをスタートさせたいとき呼んでください
	public void startTimer(){
		flag = true;
	}

	void Result(){
		//クリア時の処理

		SceneManager.LoadScene (4);
	}

	//ひなたにいる間update関数の中で呼んでください
	public void Damage(){
		slider.value -= Time.deltaTime/lifetime;
		if (slider.value <= 0) {
			SceneManager.LoadScene (3);
		}
	}

	//ひかげ
	public void Recovery(){
		if (slider.value < 1) {
			slider.value += Time.deltaTime / 10;
		}
	}

}
