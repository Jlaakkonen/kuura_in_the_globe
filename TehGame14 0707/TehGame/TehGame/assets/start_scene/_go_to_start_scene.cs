using UnityEngine;
using System.Collections;

public class _go_to_start_scene : MonoBehaviour
{
	void Start()
	{
		GameObject globa_scripts = GameObject.Find("_GLOBAL_SCRIPTS");
		if (!globa_scripts) Application.LoadLevel("start_scene");
	}
}
