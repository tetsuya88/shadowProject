using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
	public float waittime = 2f;
	void Update(){
		if (waittime < 0) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene (1);
			}
		} else {
			waittime -= Time.deltaTime;
		}
	}
}
