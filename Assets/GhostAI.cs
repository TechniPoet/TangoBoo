using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {
    float turnSpeed = .4f;
    float moveSpeed = .01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir = Camera.main.transform.position - transform.position;
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position = transform.position + (transform.forward * moveSpeed);
	}
}
