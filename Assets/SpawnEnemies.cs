using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    public GameObject ghost;
    bool found = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindObjectsOfType<ARLocationMarker>().Length > 0 && !found)
        {
            found = true;
            ARLocationMarker marker = GameObject.FindObjectsOfType<ARLocationMarker>()[0];
            StartCoroutine(wait());
            GameObject newGhost = Instantiate(ghost,marker.transform.position,Quaternion.identity) as GameObject;
            newGhost.SetActive(true);
        }
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }
}
