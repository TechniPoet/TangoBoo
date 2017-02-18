using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

    float startTime;
    public GameObject ghost;
    List<GameObject> ghosts;
    bool found = false;
    public float spawnTime = 3f;
    public int maxGhosts = 30;
	// Use this for initialization
	void Awake () {
        startTime = Time.time;
        ghosts = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > spawnTime)
        {
            if (ghosts.Count < maxGhosts)
            {
                GameObject newGhost = Instantiate(ghost, transform.position, Quaternion.identity) as GameObject;
                ghosts.Add(newGhost);
                newGhost.SetActive(true);
                newGhost.transform.Rotate(new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), Random.Range(-1, 1.1f)), Random.Range(0, 360), Space.Self);
                if (spawnTime > 1 && Random.Range(0, 10) > 7f)
                {
                    spawnTime--;
                }
            }
            startTime = Time.time;
        }
        for (int i = 0; i < ghosts.Count; i++ )
            if (ghosts[i] == null)
            {
                ghosts.RemoveAt(i);
            }
        {

        }
	}
}
