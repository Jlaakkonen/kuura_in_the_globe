using UnityEngine;
using System.Collections;

public class map_manager : MonoBehaviour
{
											// MAP TILES:
	public GameObject tile_snow1;			// - = maa.
	public GameObject tile_road1;			// r = tie.
	public GameObject tile_housefloor1;		// H = taloa ympäröivä maa, josta ei pääse läpi.
	public GameObject tile_wall1;			// W = kivi.
	public GameObject tile_tree1;			// T = valkoinen puu.
	public GameObject tile_tree2;			// Y = luminen puu (isompi).
	public GameObject tile_tree3;			// U = lumeton puu (isompi).
	public GameObject tile_tree4;			// I = luminen puu (pienempi).
	public GameObject tile_tree5;			// O = lumeton puu (pienempi).
	public GameObject tile_house1;			// 1 = hirsimökki.
	public GameObject tile_house2;			// 2 = puunrunkotalo.
	public GameObject tile_house3;			// 3 = sammakkolampi.
	public GameObject tile_hill1;			// h = pieni kumpu.
	public GameObject tile_puro1;			// 0 = vaaksuora puro.
	public GameObject tile_puro2;
	public GameObject tile_puro3;
	public GameObject tile_puro4;
	public GameObject tile_bridge;			// b )
	public GameObject template_grid; // temp background, will be deleted in instantiate_map().
	
	private const int MAP_WIDTH = 28;
	private const int MAP_HEIGHT = 20;
	private int[,] map = new int[MAP_WIDTH, MAP_HEIGHT];
	
	private int number_of_objects = 0;
	private const int MAX_NUMBER_OF_OBJECTS = 100;
	private Vector2[] object_position = new Vector2[MAX_NUMBER_OF_OBJECTS];
	private Vector2[] object_radius = new Vector2[MAX_NUMBER_OF_OBJECTS];



	public int get_map_width() {return MAP_WIDTH;}
	public int get_map_height() {return MAP_HEIGHT;}



	void Start()
	{
		instantiate_map();
		
		//number_of_objects = 0;
		for (int a = 0; a < MAX_NUMBER_OF_OBJECTS; a++)
		{
			object_position[a] = new Vector2(0.0f, 0.0f);
			object_radius[a] = new Vector2(0.0f, 0.0f);
		}
	}



	void Update()
	{
		//Debug.Log("obejcts="+number_of_objects);
	}



	public int map_value(float x, float z)
	{
		for (int a = 0; a < number_of_objects; a++)
		{
			if (x > object_position[a].x - object_radius[a].x &&
				x < object_position[a].x + object_radius[a].x &&
				z > object_position[a].y - object_radius[a].y &&
				z < object_position[a].y + object_radius[a].y) return 100;
		}
		if (x >= 0.0f && x < MAP_WIDTH && z <= 0.0f && z > -MAP_HEIGHT) return map[(int)x, (int)(-z)];
		else return 100;
	}



	public int map_value_tiles_only(float x, float z)
	{
		if (x >= 0.0f && x < MAP_WIDTH && z <= 0.0f && z > -MAP_HEIGHT) return map[(int)x, (int)(-z)];
		else return 100;
	}



	public int report_new_object(float x, float y, float radius_x, float radius_y)
	{
		
		object_position[number_of_objects] = new Vector2(x, y);
		object_radius[number_of_objects] = new Vector2(radius_x, radius_y);
		number_of_objects++;
		//Debug.Log("REPORT  obejcts="+number_of_objects);
		int value = number_of_objects - 1;
		return value;
	}



	public void update_object_position(int id, float x, float y)
	{
		//Debug.Log("UPDATING POS id="+id+"  "+x+","+y+"    --------   objects="+number_of_objects);
		object_position[id] = new Vector2(x, y);
	}



	private void instantiate_map()
	{
		string[] map_data =
		{
		/*
			"---hP89YUIO-----",
			"-rrrrrrr-THHH---",
			"-IOIT-hrI-H1H---",
			"-YHHH--r---r-I--",
			"--HHHh-rrrrr----",
			"-YH3H--r-HHH--I-",
			"---h---r-H2HT---",
			"HHH--I-r--r-----",
			"H2HT---rrrr-W---",
			"-r--rrrr--TW----",
			"-rWWr----W------",
			"-rrrr-------II-I",
			"PP0PBP0P0P0PPPBP",
			"----rrrrrrII-I-I",
			"----------II---I",
			"---------IIIIIII"
		*/
			"r+r+r+r+r+r-----------------",
			"+-+Y+-+I+-------------------",
			"r+hhhhY+r-----1---2---3-----",
			"+T+-+U+-+O----+---+---+-----",
			"r+rhr+r+r+r+r+r+r+r+r+r-----",
			"PPPPPPPPbPP8----------------",
			"----r+r+r--9----------------",
			"----+O-----9-------rrrrrrrrr",
			"----r------9-------r--------",
			"----h------9-------r--------",
			"----r+r----9-------r--------",
			"----+-+----9-------r--------",
			"----r+r----PPPPPPPPbPPPPPPPP",
			"-------------------r--------",
			"-------------------r--------",
			"-------------------r--------",
			"------rrrrrrrrrrrrrr--------",
			"----------------------------",
			"-----------r-r--------------",
			"----------r-r---------------",
		};
		
		Destroy(template_grid);
		for (int x = 0; x < MAP_WIDTH; x++)
		{
			for (int y = 0; y < MAP_HEIGHT; y++)
			{
				GameObject next_tile = null;
				Vector3 tile_position = new Vector3(x, 0.0f, -y);
				Quaternion tile_rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
				
				if (map_data[y][x] == '-')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					map[x, y] = 0;
				}
				if (map_data[y][x] == '+')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					map[x, y] = 40;
				}
				if (map_data[y][x] == 'r')
				{
					next_tile = (GameObject)Instantiate(tile_road1, tile_position, tile_rotation);
					map[x, y] = 20;
				}
				if (map_data[y][x] == 'h')
				{
					next_tile = (GameObject)Instantiate(tile_hill1, tile_position, tile_rotation);
					map[x, y] = 42;
				}
				if (map_data[y][x] == 'W')
				{
					next_tile = (GameObject)Instantiate(tile_wall1, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'P')
				{
					next_tile = (GameObject)Instantiate(tile_puro1, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == '0')
				{
					next_tile = (GameObject)Instantiate(tile_puro2, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == '8')
				{
					next_tile = (GameObject)Instantiate(tile_puro3, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == '9')
				{
					next_tile = (GameObject)Instantiate(tile_puro4, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'b')
				{
					next_tile = (GameObject)Instantiate(tile_bridge, tile_position, tile_rotation);
					map[x, y] = 41;
				}
				if (map_data[y][x] == 'T')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_tree1, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'Y')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_tree2, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'U')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_tree3, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'I')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_tree4, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'O')
				{
					next_tile = (GameObject)Instantiate(tile_snow1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_tree5, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == 'H')
				{
					next_tile = (GameObject)Instantiate(tile_housefloor1, tile_position, tile_rotation);
					map[x, y] = 100;
				}
				if (map_data[y][x] == '1')
				{
					next_tile = (GameObject)Instantiate(tile_house1, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_housefloor1, tile_position, tile_rotation);
					map[x, y] = 21;
				}
				if (map_data[y][x] == '2')
				{
					next_tile = (GameObject)Instantiate(tile_house2, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_housefloor1, tile_position, tile_rotation);
					map[x, y] = 22;
				}
				if (map_data[y][x] == '3')
				{
					next_tile = (GameObject)Instantiate(tile_house3, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
					next_tile = (GameObject)Instantiate(tile_housefloor1, tile_position, tile_rotation);
					map[x, y] = 23;
				}
				
				next_tile.transform.SetParent(transform);
			}
		}
		for (int x = 0; x < MAP_WIDTH - 1; x++) // generate extra trees. jos on 4 puuta neliössä, lisätään keskelle puu.
		{
			for (int y = 0; y < MAP_HEIGHT - 1; y++)
			{
				GameObject next_tile = null;
				Vector3 tile_position = new Vector3(x + 0.5f, 0.0f, -y - 0.5f);
				Quaternion tile_rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
				
				string trees = "TYUIO";
				
				if (trees.Contains(map_data[y][x].ToString()) &&
					trees.Contains(map_data[y][x + 1].ToString()) &&
					trees.Contains(map_data[y + 1][x].ToString()) &&
					trees.Contains(map_data[y + 1][x + 1].ToString()))
				{
					int tree_number = (x + y) % 5;
					if (tree_number == 0)
						next_tile = (GameObject)Instantiate(tile_tree1, tile_position, tile_rotation);
					if (tree_number == 1)
						next_tile = (GameObject)Instantiate(tile_tree2, tile_position, tile_rotation);
					if (tree_number == 2)
						next_tile = (GameObject)Instantiate(tile_tree3, tile_position, tile_rotation);
					if (tree_number == 3)
						next_tile = (GameObject)Instantiate(tile_tree4, tile_position, tile_rotation);
					if (tree_number == 4)
						next_tile = (GameObject)Instantiate(tile_tree5, tile_position, tile_rotation);
					next_tile.transform.SetParent(transform);
				}
			}
		}
	}

}
