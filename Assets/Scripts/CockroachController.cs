using UnityEngine;
using System.Collections;

public class CockroachController : MonoBehaviour {

	[SerializeField]
		private Camera sight;
	[SerializeField]
		private float walk_speed;

	private const float CAM_ROT_LIMIT = 80f;
	private readonly Quaternion INITIAL_ROT = Quaternion.Euler(0, 0, 0);

	private float prev_x_rot;
	private float prev_y_rot;

	private Rigidbody cockroach_rigid;

	// Use this for initialization
	void Start () {
		cockroach_rigid = this.GetComponent<Rigidbody>();
		prev_x_rot = 0f;
		prev_y_rot = 0f;
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
		float y_rot = Input.GetAxis("Mouse X");
		float x_rot = Input.GetAxis("Mouse Y");

		Quaternion tmp_x_rot = sight.transform.localRotation * Quaternion.Euler(x_rot * -1, 0, 0);
		if(CAM_ROT_LIMIT > Quaternion.Angle(INITIAL_ROT, Quaternion.Euler(tmp_x_rot.eulerAngles.x, 0, 0))) {
			sight.transform.localRotation = tmp_x_rot;
		}
		transform.localRotation *= Quaternion.Euler(0, y_rot, 0);
	}

	public void changeGravityDir(Vector3 dir) {
		Physics.gravity = -9.8f * dir;
	}

}
