using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwordScript : MonoBehaviour {

    bool swinging = false;
    int score = 0;
    public Text showScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        showScore.text = score.ToString();
	}

    public void Swing()
    {
        if (!swinging)
        {
            StartCoroutine(SwingRoutine());
        }
    }

    IEnumerator SwingRoutine()
    {
        swinging = true;
        float start = Time.time;
        float swingDegrees = 300;
        Quaternion orig = transform.localRotation;
        while (Time.time - start < .2)
        {
            transform.Rotate(Vector3.forward, -(Time.deltaTime * swingDegrees), Space.Self);
            transform.Rotate(Vector3.up, -(Time.deltaTime * swingDegrees), Space.Self);
            yield return null;
        }
        start = Time.time;
        while (Time.time - start < .2)
        {
            transform.Rotate(Vector3.forward, (Time.deltaTime * swingDegrees), Space.Self);
            transform.Rotate(Vector3.up, (Time.deltaTime * swingDegrees), Space.Self);
            yield return null;
        }
        if (transform.localRotation != orig)
        {
            transform.localRotation = orig;
        }
        swinging = false;
        yield return null;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Sword hit!");
        if (col.gameObject.tag == "Enemy")
        {
            score += 5;
            Destroy(col.gameObject);
        }
    }

}
