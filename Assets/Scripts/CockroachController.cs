using UnityEngine;
using System.Collections;

public class CockroachController : MonoBehaviour {

	[SerializeField]
		private float walk_speed;

	private Rigidbody cockroach_rigid;

	// Use this for initialization
	void Start () {
		cockroach_rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		rotateSight();

		if(Input.GetKey(KeyCode.W)) {
			cockroach_rigid.velocity = transform.forward * walk_speed;
		} else {
			cockroach_rigid.velocity = Vector3.zero;
		}

	}

	void rotateSight() {
	}

}
