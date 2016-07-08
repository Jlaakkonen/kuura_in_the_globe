using UnityEngine;
using System.Collections;

public class TEMP_MAP_GLOBAL_MANAGER : MonoBehaviour
{
	public enum LEVEL{MAINMENU_SCENE, MAP_SCENE, VELHOPELI, QUIT_GAME, RESTART, MEMORY_GAME, LABYRINTH, BUBBLE};
	private LEVEL level;
	private Vector2 map_character_position = new Vector2(0,0);



	void Start()
	{
		DontDestroyOnLoad(gameObject);
		
		//level = LEVEL.MAINMENU_SCENE;								// initializing global variables.
		level = LEVEL.MAP_SCENE;									// initializing global variables.
		map_character_position = new Vector2(0.5f, -0.5f);			// 
		
		load_level(level);
	}



	void Update()
	{
	}



	public void load_level(LEVEL value)
	{
		if (value == LEVEL.RESTART) value = level;
		level = value;
		
		if (value == LEVEL.MAINMENU_SCENE)
		{
			Debug.Log("changing scene to mainmenu.");
			Application.LoadLevel("mainmenu_scene");
		}
		if (value == LEVEL.MAP_SCENE)
		{
			Debug.Log("changing scene to map_scene.");
			Application.LoadLevel("map_scene");
		}
		if (value == LEVEL.VELHOPELI)
		{
			Debug.Log("changing scene to velhopeli.");
			Application.LoadLevel("game_scene");
		}

        if (value == LEVEL.MEMORY_GAME)
        {
            Debug.Log("changing scene to memory game.");
            Application.LoadLevel("GameScene");
        }

        if (value == LEVEL.LABYRINTH)
        {
            Debug.Log("changing scene to memory game.");
            Application.LoadLevel("LabyLevelSelect");
        }

        if (value == LEVEL.BUBBLE)
        {
            Debug.Log("changing scene to memory game.");
            Application.LoadLevel("ShelfLevelSelect");
        }
    }



	public Vector2 get_map_character_position()
	{
		return map_character_position;
	}



	public void set_map_character_position(Vector2 value)
	{
		map_character_position = value;
	}


}
