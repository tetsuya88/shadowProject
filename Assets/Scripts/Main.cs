using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			SceneManager.LoadScene (3);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			SceneManager.LoadScene (4);
		}
	}
}
