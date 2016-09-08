using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CockroachController : MonoBehaviour {

	// data architecture for saved autorun behavior
	private class AutoDat {
		public AutoDat(float x, float z, int wait_time) {
			this.direction = (new Vector3(x, 0, z)).normalized;
			this.wait_time = wait_time;
		}
		public Vector3 direction {get; set; }
		public int wait_time {get; set;}
	}

	[SerializeField]
		private Camera sight;
	[SerializeField]
		private float walk_speed;

	// flag for check auto-running mode
	public static bool auto_running{ get; set; }

	private const float CAM_ROT_LIMIT = 80f;
	private readonly Quaternion INITIAL_ROT = Quaternion.Euler(0, 0, 0);

	private Queue<AutoDat> auto_run_dat;

	private Rigidbody cockroach_rigid;

	// Use this for initialization
	void Start () {

		cockroach_rigid = this.GetComponent<Rigidbody>();

		// initialize and enqueue bahavior data for auto-run mode
		if(auto_running) {
			auto_run_dat = new Queue<AutoDat>();
			auto_run_dat.Enqueue(new AutoDat(1f, 0.5f ,2));
			auto_run_dat.Enqueue(new AutoDat(0, 0, 3));
			auto_run_dat.Enqueue(new AutoDat(0, 2f, 2));
			auto_run_dat.Enqueue(new AutoDat(1.2f, 1f, 2));
			Debug.Log(auto_run_dat.Count);
			StartCoroutine("AutoRun");
		}

	}
	
	// Update is called once per frame
	void Update () {

		rotateSight();

		if(!auto_running) {
			// move to forward while w key is pushed.
			if(Input.GetKey(KeyCode.W)) cockroach_rigid.velocity = transform.forward * walk_speed;
			else cockroach_rigid.velocity = Vector3.zero;
		}
		// back to title scene by escape key
		if(Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene("Title");
			if(auto_running) StopCoroutine("AutoRun");
		}

	}

	void rotateSight() {
		float y_rot = Input.GetAxis("Mouse X");
		float x_rot = Input.GetAxis("Mouse Y");

		Quaternion tmp_x_rot = sight.transform.localRotation * Quaternion.Euler(x_rot * -1, 0, 0);
		if(CAM_ROT_LIMIT > Quaternion.Angle(INITIAL_ROT, Quaternion.Euler(tmp_x_rot.eulerAngles.x, 0, 0))) {
			sight.transform.localRotation = tmp_x_rot;
		}
		transform.localRotation *= Quaternion.Euler(0, y_rot, 0);
	}

	public void changeGravityDir(Vector3 dir) {
		Physics.gravity = -98.0f * dir;
	}

	private IEnumerator AutoRun() {
		while(auto_run_dat.Count > 0) {
			AutoDat current_dat = auto_run_dat.Dequeue(); 
			cockroach_rigid.velocity = walk_speed * current_dat.direction;
			yield return new WaitForSeconds(current_dat.wait_time);
		}
	}

}
