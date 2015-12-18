using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    float health = 100;
    public RectTransform red;
	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
        red.localScale = new Vector3(health / 100, red.localScale.y, red.localScale.z);
	}

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
