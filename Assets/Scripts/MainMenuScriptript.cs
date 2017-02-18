using UnityEngine;
using System.Collections;

public class MainMenuScriptript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("TangoBoo");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
