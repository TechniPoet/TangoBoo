using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    float health = 100;
    public RectTransform healthBar;
    public Text gameoverText;
    private float minX;
    private float maxX;
    private float cachedY;
    bool gameOver = false;
	// Use this for initialization
	void Awake () {
        cachedY = healthBar.anchoredPosition.y;

        maxX = healthBar.anchoredPosition.x;
        Debug.Log(maxX);
        minX = healthBar.anchoredPosition.x - healthBar.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.anchoredPosition = new Vector3(minX + ((health / 100) * healthBar.rect.width), cachedY);
        if (healthBar.anchoredPosition.x <= minX && !gameOver)
        {
            gameOver = true;
            StartCoroutine(StartGameOver());
        }
	}

    void OnTriggerStay(Collider col)
    {
        Debug.Log("hit");
        if (col.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }

    IEnumerator StartGameOver()
    {
        Debug.Log("health "+ health);
        gameoverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("MainMenu");
        yield return null;
    }
}
