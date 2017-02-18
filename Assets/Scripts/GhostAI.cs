using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {
    float turnSpeed = .4f;
    float moveSpeed = .01f;
    Transform target;
    public float health = 100;
    Vector3 startScale;
	// Use this for initialization
	void Awake () {
        startScale = this.transform.localScale;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1) {
            int ind = Mathf.Clamp(Random.Range(0, 100) % players.Length, 0, 1);
            target = players[ind].transform;
        }
        else
        {
            target = players[0].transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        this.transform.localScale = startScale * (health / 100);

        Vector3 targetDir = target.position - transform.position;
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position = transform.position + (transform.forward * moveSpeed);
	}
}
