using UnityEngine;
using System.Collections;

public class GravitiManager : MonoBehaviour {

	[SerializeField]
		private GameObject cockroach;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider wall) {
		cockroach.transform.rotation *= Quaternion.Euler(-90, 0, 0);
	}

}
