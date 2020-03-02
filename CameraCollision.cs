using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

	public float minDist = 1.0f, maxDist = 4.0f, smooth = 10.0f;
	private Vector3 dir;
	public Vector3 dirAdjusted;
	public float distance;

	// Use this for initialization
	void Awake () {
		dir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dir * maxDist);
		RaycastHit hit;

		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
			distance = Mathf.Clamp ((hit.distance * 0.87f), minDist, maxDist);
				
				} else {
					distance = maxDist;
				}
				transform.localPosition = Vector3.Lerp (transform.localPosition, dir * distance, Time.deltaTime * smooth);
	}
}
