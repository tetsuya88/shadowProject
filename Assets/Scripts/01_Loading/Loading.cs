using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
	public float loadTime = 5f;

	void Update () {
		loadTime -= Time.deltaTime;
		if (loadTime < 0) {
			SceneManager.LoadScene (2);
		}
	}
}
