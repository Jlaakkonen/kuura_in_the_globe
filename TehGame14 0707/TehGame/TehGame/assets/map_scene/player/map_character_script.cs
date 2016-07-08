using UnityEngine;
using System.Collections;

public class map_character_script : MonoBehaviour
{
	private float x;
	private float y;
	private float ukko_speed_x;
	private float ukko_speed_y;
	private const float UKKO_ACCELERATION = 10.0f;
	private const float UKKO_MAX_SPEED = 4.0f;
	private const float UKKO_RADIUS_X = 0.4f;
	private const float UKKO_DODGE_RADIUS_X = 0.1f;
	private const float UKKO_RADIUS_Y = 0.2f;
	private const float UKKO_DODGE_RADIUS_Y = 0.05f;
	private const float ANIMATION_SPEED = 15.0f;
	private map_camera_script camera;
	private map_manager map;
	private int id = -1;
	
	private Material image;
	private int spritesheet_square_x;
	private int spritesheet_square_y;
	private float spritesheet_animation_timer;
	private map_ui_script map_ui;
	
													// TODO: pointteri global manageriin.
													private TEMP_MAP_GLOBAL_MANAGER game_state;



	void Start()
	{
													// TODO: pointteri global manageriin.
													GameObject global_scripts = GameObject.Find("_GLOBAL_SCRIPTS");						// get the pointer to
													if (!global_scripts) Application.LoadLevel("start_scene");							// the global game manager.
													else game_state = GameObject.Find("_GLOBAL_SCRIPTS").GetComponent<TEMP_MAP_GLOBAL_MANAGER>();//
		
		
		camera = GameObject.Find("Main Camera").GetComponent<map_camera_script>();
		map = GameObject.Find("tilemap_parent").GetComponent<map_manager>();
		map_ui = GameObject.Find("HUD Camera").GetComponent<map_ui_script>();
		
													// TODO: lue global managerista ukon sijainti.
													x = game_state.get_map_character_position().x;
													y = game_state.get_map_character_position().y;
		
		camera.set_camera_target(x, y, true);
		
		image = transform.FindChild("character_image").gameObject.GetComponent<Renderer>().material;
		spritesheet_square_x = 0;
		spritesheet_square_y = 0;
		spritesheet_animation_timer = 0.0f;
	}



	void Update()
	{
		if (id == -1) id = map.report_new_object(x, y, UKKO_RADIUS_X, UKKO_RADIUS_Y);
		
		//apply_controls(); // vanha liikkumissysteemi (vapaa)
		apply_controls_supermariomap_style(); // uusi liikkumissysteemi (supermario3-tyylinen)
		
		move_character();
		animate_character();
		camera.set_camera_target(x, y, false);
		
		game_state.set_map_character_position(new Vector2(x, y));
		
		open_message_box();
		enter_level(); // vanhassa liikkumissysteemissä.
		climb_hills();
		
												// TODO: jos painetaan esc, palataan mainmenuun.
												if (Input.GetKeyDown(KeyCode.Escape)) game_state.load_level(TEMP_MAP_GLOBAL_MANAGER.LEVEL.MAINMENU_SCENE);
		
	}



	private void apply_controls()
	{
		float dt = Time.deltaTime;
		
		Vector2 click = new Vector2(0.0f, 0.0f);
		receive_input(ref click);
		const float SENSITIVITY = 0.1f;
		
		if (click.y > SENSITIVITY || click.y < -SENSITIVITY || click.x < -SENSITIVITY || click.x > SENSITIVITY)
			spritesheet_animation_timer += dt * ANIMATION_SPEED;
		else
			spritesheet_animation_timer = 0.0f;
		
		if (click.y > SENSITIVITY)
		{
			ukko_speed_y += UKKO_ACCELERATION * Time.deltaTime * click.y;
			spritesheet_square_y = 2;
			if (ukko_speed_y > 0.0f) // moving up
			{
				if (map.map_value(x - UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
					map.map_value(x + UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) >= 100 &&
					map.map_value(x + UKKO_DODGE_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
					if (ukko_speed_x > -UKKO_MAX_SPEED * 0.3f)
						ukko_speed_x = -UKKO_MAX_SPEED * 0.3f; // dodge left
				if (map.map_value(x + UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
					map.map_value(x - UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) >= 100 &&
					map.map_value(x - UKKO_DODGE_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
					if (ukko_speed_x < UKKO_MAX_SPEED * 0.3f)
						ukko_speed_x = UKKO_MAX_SPEED * 0.3f; // dodge right
			}
		}
		else if (click.y < -SENSITIVITY)
		{
			ukko_speed_y += UKKO_ACCELERATION * Time.deltaTime * click.y;
			spritesheet_square_y = 0;
			if (ukko_speed_y < 0.0f) // moving down
			{
				if (map.map_value(x - UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
					map.map_value(x + UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) >= 100 &&
					map.map_value(x + UKKO_DODGE_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
					if (ukko_speed_x > -UKKO_MAX_SPEED * 0.3f)
						ukko_speed_x = -UKKO_MAX_SPEED * 0.3f; // dodge left
				if (map.map_value(x + UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
					map.map_value(x - UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) >= 100 &&
					map.map_value(x - UKKO_DODGE_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
					if (ukko_speed_x < UKKO_MAX_SPEED * 0.3f)
						ukko_speed_x = UKKO_MAX_SPEED * 0.3f; // dodge right
			}
		}
		else
		{
			if (ukko_speed_y < 0.0f)
			{
				ukko_speed_y += UKKO_ACCELERATION * Time.deltaTime;
				if (ukko_speed_y > 0.0f) ukko_speed_y = 0.0f;
			}
			if (ukko_speed_y > 0.0f)
			{
				ukko_speed_y -= UKKO_ACCELERATION * Time.deltaTime;
				if (ukko_speed_y < 0.0f) ukko_speed_y = 0.0f;
			}
		}
		if (click.x < -SENSITIVITY)
		{
			ukko_speed_x += UKKO_ACCELERATION * Time.deltaTime * click.x;
			if (Mathf.Abs(click.x) > Mathf.Abs(click.y)) spritesheet_square_y = 3;
			if (ukko_speed_x < 0.0f) // moving left
			{
				if (map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) < 100 &&
					map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) >= 100 &&
					map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_DODGE_RADIUS_Y) < 100)
					if (ukko_speed_y < UKKO_MAX_SPEED * 0.3f)
						ukko_speed_y = UKKO_MAX_SPEED * 0.3f; // dodge up
				if (map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) < 100 &&
					map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) >= 100 &&
					map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_DODGE_RADIUS_Y) < 100)
					if (ukko_speed_y > -UKKO_MAX_SPEED * 0.3f)
						ukko_speed_y = -UKKO_MAX_SPEED * 0.3f; // dodge down
			}
		}
		else if (click.x > SENSITIVITY)
		{
			ukko_speed_x += UKKO_ACCELERATION * Time.deltaTime * click.x;
			if (Mathf.Abs(click.x) > Mathf.Abs(click.y)) spritesheet_square_y = 1;
			if (ukko_speed_x > 0.0f) // moving right
			{
				if (map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) < 100 &&
					map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) >= 100 &&
					map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_DODGE_RADIUS_Y) < 100)
					if (ukko_speed_y < UKKO_MAX_SPEED * 0.3f)
						ukko_speed_y = UKKO_MAX_SPEED * 0.3f; // dodge up
				if (map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) < 100 &&
					map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) >= 100 &&
					map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_DODGE_RADIUS_Y) < 100)
					if (ukko_speed_y > -UKKO_MAX_SPEED * 0.3f)
						ukko_speed_y = -UKKO_MAX_SPEED * 0.3f; // dodge down
			}
		}
		else
		{
			if (ukko_speed_x < 0.0f)
			{
				ukko_speed_x += UKKO_ACCELERATION * Time.deltaTime;
				if (ukko_speed_x > 0.0f) ukko_speed_x = 0.0f;
			}
			if (ukko_speed_x > 0.0f)
			{
				ukko_speed_x -= UKKO_ACCELERATION * Time.deltaTime;
				if (ukko_speed_x < 0.0f) ukko_speed_x = 0.0f;
			}
		}
		//Debug.Log("ukko=("+x+", "+y+")   speed=("+ukko_speed_x+", "+ukko_speed_y+")");
	}



	private bool supermariomap_moving = false;
	private bool supermariomap_nextstop_found = false;
	private int supermariomap_nextstop_x = 0;
	private int supermariomap_nextstop_y = 0;
	private int supermariomap_laststop_x = 0;
	private int supermariomap_laststop_y = 0;
	private float supermariomap_movetimer = 0.0f;
	private const float SUPERMARIOMAP_MOVESPEED = 0.3f;
	private void apply_controls_supermariomap_style()
	{
		float dt = Time.deltaTime;
		
		Vector2 click = new Vector2(0.0f, 0.0f);
		receive_input(ref click);
		const float SENSITIVITY = 0.1f;
		
		if (supermariomap_moving) // ukko on liikkumassa pisteestä toiseen.
		{
			if (!supermariomap_nextstop_found) // pitää löytää seuraava pysähtymispiste.
			{
				int stop_x = (int)x;
				int stop_y = (int)y;
				supermariomap_laststop_x = stop_x;
				supermariomap_laststop_y = stop_y;
				Debug.Log("supermariomove: ALOITETAAN LIIKKUMINEN. x,y=("+x+","+y+") tile= ("+stop_x+","+stop_y+")  tiili ukon alla="+map.map_value_tiles_only(stop_x, stop_y));
				int direction_x = 0;
				int direction_y = 0;
				if (spritesheet_square_y == 0) direction_y = -1;// moving down.
				if (spritesheet_square_y == 1) direction_x = 1;// moving right.
				if (spritesheet_square_y == 2) direction_y = 1;// moving up.
				if (spritesheet_square_y == 3) direction_x = -1;// moving left.
				
				while (!supermariomap_nextstop_found) // luuppi, jolla etsitään seuraava pysähtymispiste.
				{
					if (stop_x + direction_x < 0 ||
						stop_x + direction_x >= map.get_map_width() ||
						stop_y + direction_y > 0 ||
						stop_y + direction_y <= -map.get_map_height())
					{
						supermariomap_nextstop_found = true;
						Debug.Log("supermariomove: RAJA TULI VASTAAN pysähdytään tileen ("+stop_x+","+stop_y+")");
					}
					
					if (!supermariomap_nextstop_found)
					{
						stop_x += direction_x;
						stop_y += direction_y;
					}
					if (map.map_value_tiles_only(stop_x, stop_y) >= 20 && map.map_value_tiles_only(stop_x, stop_y) <= 39)
					{
						supermariomap_nextstop_found = true;
						Debug.Log("supermariomove: pysähdytään tileen ("+stop_x+","+stop_y+")");
					}
					
				}// while (!supermariomap_nextstop_found)
				
				supermariomap_nextstop_x = stop_x;
				supermariomap_nextstop_y = stop_y;
				
			}// if (!supermariomap_nextstop_found)
			
			spritesheet_animation_timer += dt * ANIMATION_SPEED;
			supermariomap_movetimer += dt / SUPERMARIOMAP_MOVESPEED;
			if (supermariomap_movetimer > 1.0f) // perillä kohderuudussa.
			{
				supermariomap_moving = false;
				supermariomap_movetimer = 1.0f;
				spritesheet_animation_timer = 0.0f;
			}
			x = supermariomap_movetimer * supermariomap_nextstop_x +
				(1.0f - supermariomap_movetimer) * supermariomap_laststop_x +
				0.5f;
			y = supermariomap_movetimer * supermariomap_nextstop_y +
				(1.0f - supermariomap_movetimer) * supermariomap_laststop_y -
				0.5f;
			
		}// if (supermariomap_moving)
		
		if (!supermariomap_moving) // ei liikuta, otetaan vastaan liikkumiskomento.
		{
			//Debug.Log("OTETAAN LIIKKUMINEN VASTAAN");
			if (click.y > SENSITIVITY &&
				map.map_value_tiles_only(x, y + 1.0f) >= 40 &&
				map.map_value_tiles_only(x, y + 1.0f) <= 59)
			{
				Debug.Log("YLÖS");
				spritesheet_square_y = 2;
				supermariomap_moving = true;
				supermariomap_nextstop_found = false;
				supermariomap_movetimer = 0.0f;
			}
			if (click.y < -SENSITIVITY &&
				map.map_value_tiles_only(x, y - 1.0f) >= 40 &&
				map.map_value_tiles_only(x, y - 1.0f) <= 59)
			{
				Debug.Log("ALAS");
				spritesheet_square_y = 0;
				supermariomap_moving = true;
				supermariomap_nextstop_found = false;
				supermariomap_movetimer = 0.0f;
			}
			if (click.x < -SENSITIVITY &&
				map.map_value_tiles_only(x - 1.0f, y) >= 40 &&
				map.map_value_tiles_only(x - 1.0f, y) <= 59)
			{
				Debug.Log("VASEN");
				spritesheet_square_y = 3;
				supermariomap_moving = true;
				supermariomap_nextstop_found = false;
				supermariomap_movetimer = 0.0f;
			}
			if (click.x > SENSITIVITY &&
				map.map_value_tiles_only(x + 1.0f, y) >= 40 &&
				map.map_value_tiles_only(x + 1.0f, y) <= 59)
			{
				Debug.Log("OIKEA");
				spritesheet_square_y = 1;
				supermariomap_moving = true;
				supermariomap_nextstop_found = false;
				supermariomap_movetimer = 0.0f;
			}
		}
		
		/*
		if (click.y > SENSITIVITY || click.y < -SENSITIVITY || click.x < -SENSITIVITY || click.x > SENSITIVITY)
			spritesheet_animation_timer += dt * ANIMATION_SPEED;
		else
			spritesheet_animation_timer = 0.0f;
		
		*/
	}
	

	private void receive_input(ref Vector2 click) // getting input from mouse or keyboard?
	{
		click = map_ui.get_arrow_click_position();
		
		if (Input.GetKey(KeyCode.UpArrow)) click.y = 1.0f;
		if (Input.GetKey(KeyCode.DownArrow)) click.y = -1.0f;
		if (Input.GetKey(KeyCode.LeftArrow)) click.x = -1.0f;
		if (Input.GetKey(KeyCode.RightArrow)) click.x = 1.0f;
	}



	private void move_character()
	{
		if (ukko_speed_x < -UKKO_MAX_SPEED) ukko_speed_x = -UKKO_MAX_SPEED;
		if (ukko_speed_x > UKKO_MAX_SPEED) ukko_speed_x = UKKO_MAX_SPEED;
		if (ukko_speed_y < -UKKO_MAX_SPEED) ukko_speed_y = -UKKO_MAX_SPEED;
		if (ukko_speed_y > UKKO_MAX_SPEED) ukko_speed_y = UKKO_MAX_SPEED;
		
		float dt = Time.deltaTime;
		
		if (ukko_speed_y > 0.0f) // moving up
		{
			if (map.map_value(x - UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
				map.map_value(x + UKKO_RADIUS_X, y + UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
				y += ukko_speed_y * dt;
			else
				ukko_speed_y = 0.0f;
		}
		if (ukko_speed_y < 0.0f) // moving down
		{
			if (map.map_value(x - UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100 &&
				map.map_value(x + UKKO_RADIUS_X, y - UKKO_RADIUS_Y + ukko_speed_y * dt) < 100)
				y += ukko_speed_y * Time.deltaTime;
			else
				ukko_speed_y = 0.0f;
		}
		if (ukko_speed_x < 0.0f) // moving left
		{
			if (map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) < 100 &&
				map.map_value(x - UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) < 100)
				x += ukko_speed_x * Time.deltaTime;
			else
				ukko_speed_x = 0.0f;
		}
		if (ukko_speed_x > 0.0f) // moving right
		{
			if (map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y + UKKO_RADIUS_Y) < 100 &&
				map.map_value(x + UKKO_RADIUS_X + ukko_speed_x * dt, y - UKKO_RADIUS_Y) < 100)
				x += ukko_speed_x * Time.deltaTime;
			else
				ukko_speed_x = 0.0f;
		}
		transform.position = new Vector3(x, transform.position.y, y);
		map.update_object_position(id, x, y);
	}



	private void animate_character()
	{
		const float SPRITESHEET_W = 6;
		const float SPRITESHEET_H = 4;
		
		if (spritesheet_animation_timer >= 6.0f) spritesheet_animation_timer -= 6.0f;
		
		int square_x = spritesheet_square_x + (int)spritesheet_animation_timer;
		
		int square_y = spritesheet_square_y;
		//if (spritesheet_animation_timer > 0.0f) square_y += 4;
		
		image.mainTextureScale = new Vector2(1.0f / SPRITESHEET_W, 1.0f / SPRITESHEET_H);
		image.mainTextureOffset = new Vector2(square_x / SPRITESHEET_W, -(square_y + 1.0f) / SPRITESHEET_H);
	}



	private void enter_level()
	{
										// TODO: siirrytään eri kenttiin.
										if (map.map_value_tiles_only(x, y) == 21)
										{
											game_state.load_level(TEMP_MAP_GLOBAL_MANAGER.LEVEL.LABYRINTH);
											game_state.set_map_character_position(new Vector2(x, y - 1.7f));
										}
										if (map.map_value_tiles_only(x, y) == 22)
										{
											game_state.load_level(TEMP_MAP_GLOBAL_MANAGER.LEVEL.MEMORY_GAME);
											game_state.set_map_character_position(new Vector2(x, y - 1.7f));
										}
										if (map.map_value_tiles_only(x, y) == 23)
										{
											game_state.load_level(TEMP_MAP_GLOBAL_MANAGER.LEVEL.BUBBLE);
											game_state.set_map_character_position(new Vector2(x, y - 1.7f));
										}
	}



	public void get_map_character_position(ref Vector2 position, ref Vector2 size)
	{
		position = new Vector2(x, y);
		size = new Vector2(UKKO_RADIUS_X, UKKO_RADIUS_Y);
	}



	private int last_message_id = 0;
	private int last_message = 0;
	private void open_message_box()
	{
		int current_message = 0;
		if (map.map_value(x, y + 1.0f) == 1) current_message = 1;
		else if (map.map_value(x, y + 1.0f) == 2) current_message = 2;
		else if (map.map_value(x, y + 1.0f) == 3) current_message = 3;
		
		if (current_message != last_message)
		{
			if (current_message == 0) MAP_MESSAGES.HIDE_MESSAGE(last_message_id);
			if (current_message == 1) last_message_id = MAP_MESSAGES.SHOW_MESSAGE("TALO 1");
			if (current_message == 2) last_message_id = MAP_MESSAGES.SHOW_MESSAGE("TALO 2");
			if (current_message == 3) last_message_id = MAP_MESSAGES.SHOW_MESSAGE("TALO 3");
			
						// debuggausta varten.
						if (current_message > 0)Debug.Log("MAP_CHARACTER_SCRIPT: näytetään message "+current_message+" (id="+last_message_id+")");
						else Debug.Log("MAP_CHARACTER_SCRIPT: piilotetaan message "+last_message_id);
			
			last_message = current_message;
		}
						// debuggausta varten
						if (Input.GetKeyDown(KeyCode.Z))
						{
							MAP_MESSAGES.HIDE_MESSAGE();
							Debug.Log("piilotetaan mikä hyvänsä viesti");
						}
						if (Input.GetKeyDown(KeyCode.X))
						{
							int id = MAP_MESSAGES.SHOW_MESSAGE("TEST TEST");
							Debug.Log("näytetään viesti (id="+id+")");
						}
		
	}



	private void climb_hills()
	{
		float xx = x - (int)x - 0.5f;
		float yy = -y - (int)(-y) - 0.5f;
		
		//Debug.Log("climb_hills value="+xx+"  "+yy);
		
		Vector3 ukko_position = transform.position;
		if (map.map_value_tiles_only(x, y) == 41)
		{
			float height = Mathf.Sqrt(1.0f - yy * yy) - 0.866f;
			ukko_position.y = 3.0f * height;
			Debug.Log("SILTA"+height);
		}
		else if (map.map_value_tiles_only(x, y) == 42)
		{
			float height = Mathf.Sqrt(1.0f - xx * xx) - 0.866f + Mathf.Sqrt(1.0f - yy * yy) - 0.866f;
			ukko_position.y = 3.0f * height;
			Debug.Log("MÄKI"+height);
		}
		else
			ukko_position.y = 0.0f;
		
		transform.position = ukko_position;
	}
}


