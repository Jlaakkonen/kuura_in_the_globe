using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour {

	static public int breakingPoints = 0;
	static public int breakingLimit;
	public UI uiScript;
	public Text itemText;
	bool GOPOn = false;

	void Start()
	{
		breakingPoints = 0;

		breakingLimit = 2 + GameManager.brokenItemMultiplier;

		uiScript = FindObjectOfType<UI> ();
	}

	void Update()
	{
		ScoreCalculator ();

		if (breakingPoints == breakingLimit) {
			if (GOPOn == false) {
				uiScript.TextSwitcher (false);
				uiScript.GameOverPanelToggle ();
				GOPOn = true;
			}
		}
	}

	void ScoreCalculator()
	{
        int leveli = GameManager.manager.currentLevel + 1;
		itemText.text = "Level " + leveli + "\nBroken Items: " + breakingPoints + "/" + breakingLimit;
	}
}
