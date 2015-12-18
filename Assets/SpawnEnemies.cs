using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    float startTime;
    public GameObject ghost;
    bool found = false;
    float spawnTime = 10f;
	// Use this for initialization
	void Awake () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > spawnTime)
        {
            GameObject newGhost = Instantiate(ghost, transform.position, Quaternion.identity) as GameObject;
            
            newGhost.SetActive(true);
            newGhost.transform.Rotate(new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), Random.Range(-1, 1.1f)), Random.Range(0, 360), Space.Self);
            startTime = Time.time;
            if (spawnTime > 1 && Random.Range(0, 10) > 7f)
            {
                spawnTime--;
            }
        }
	}
}
