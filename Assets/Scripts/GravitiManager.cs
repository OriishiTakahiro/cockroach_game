using UnityEngine;
using System.Collections;

public class GravitiManager : MonoBehaviour {

	[SerializeField]
		private GameObject cockroach;

	private Transform cock_trans;

	// Use this for initialization
	void Start () {
		cock_trans = cockroach.transform;
	}
	
	// Update is called once per frame
	void Update () { }

	void OnTriggerEnter(Collider wall) {

		Vector3 local_right = cock_trans.worldToLocalMatrix.MultiplyVector(cock_trans.right);

		cock_trans.rotation *= Quaternion.AngleAxis(-90, local_right);

		// 重力方向の変更
		cockroach.GetComponent<CockroachController>().changeGravityDir(cock_trans.up.normalized);

	}
}
