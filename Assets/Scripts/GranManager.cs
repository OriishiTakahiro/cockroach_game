using UnityEngine;
using System.Collections;

public class GranManager : MonoBehaviour {

	[SerializeField]
		private GameObject cockroach;

	private bool on_ground;
	private CockroachController instance;

	// Use this for initialization
	void Start () {
		bool on_ground = true;
		instance = cockroach.GetComponent<CockroachController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!on_ground) {
			instance.changeGravityDir(Vector3.up);
			cockroach.transform.rotation = Quaternion.Euler(0,0,0);
		}
		on_ground = false;
	}
	void OnTriggerStay(Collider obstacle) {
		on_ground = true;
	}
}
