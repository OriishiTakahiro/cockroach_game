using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHundler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ToAutoRunning() {
		CockroachController.auto_running = true;
		SceneManager.LoadScene("Main");
	}

	public void ToRamble() {
		CockroachController.auto_running = false;
		SceneManager.LoadScene("Main");
	}

	public void QuitGame() { Application.Quit(); }

}
