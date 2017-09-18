using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	public float loadTime = 6f;
	public Text text;


	void Update () {
		loadTime -= Time.deltaTime;
		if (loadTime < 0) {
			text.text = "Press Enter";
			if (Input.GetKeyDown(KeyCode.Return)) {
				SceneManager.LoadScene (2);
			}
		}else if (loadTime < 1) {
			text.text = "Now Loading    ";
		}else if (loadTime < 2) {
			text.text = "Now Loading ...";
		}else if (loadTime < 3) {
			text.text = "Now Loading .. ";
		}else if (loadTime < 4) {
			text.text = "Now Loading .  ";
		}else if (loadTime < 5) {
			text.text = "Now Loading    ";
		}
	}
}
