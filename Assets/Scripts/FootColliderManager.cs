using UnityEngine;
using System.Collections;

public class FootColliderManager : MonoBehaviour {

	[SerializeField]
		private GameObject cockroach;

	private Transform cock_trans;

	private CockroachController instance;

	private bool down_wall;

	// Use this for initialization
	void Start () {
		cock_trans = cockroach.transform;
		instance = cockroach.GetComponent<CockroachController>();
		Debug.Log("set up is completed");
	}
	
	// Update is called once per frame
	void Update () { DownWall(); }

	void OnTriggerEnter(Collider obstacle) { }
	
	void OnTriggerExit(Collider obstacle) { down_wall = true; }

	void OnTriggerStay(Collider obstacle) { down_wall = false; }

	void DownWall() {

		if(down_wall) {
			//cock_trans.position = transform.position;

			Vector3 local_right = cock_trans.worldToLocalMatrix.MultiplyVector(cock_trans.right);

			Debug.Log(cock_trans.rotation.ToString());
			cock_trans.rotation *= Quaternion.AngleAxis(90, local_right);
			Debug.Log(cock_trans.rotation.ToString());

			// 重力方向の変更
			instance.changeGravityDir(cock_trans.up.normalized);
			Debug.Log(Physics.gravity.ToString());
			Debug.Log("hogehoge");
		}
		down_wall = false;
	}

}
