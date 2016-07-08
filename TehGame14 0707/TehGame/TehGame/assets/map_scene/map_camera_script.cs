using UnityEngine;
using System.Collections;

public class map_camera_script : MonoBehaviour
{
	private float camera_target_x;
	private float camera_target_z;
	private const float CAMERA_SPEED = 15.0f;
	private float CAMERA_LIMIT_UP = 1.0f;
	private float CAMERA_LIMIT_DOWN = -21.0f;
	private float CAMERA_LIMIT_LEFT = -8.0f;
	private float CAMERA_LIMIT_RIGHT = 14.0f;
	public GameObject tilemap_parent;
	private map_manager map;



	void Start()
	{
		camera_target_x = 1.0f;
		camera_target_z = -6.0f;
		map = tilemap_parent.GetComponent<map_manager>();
		
		float camera_size = gameObject.GetComponent<Camera>().orthographicSize;
		//Debug.Log("size="+camera_size);
		CAMERA_LIMIT_UP = -5.0f;
		CAMERA_LIMIT_LEFT = camera_size + 1.0f;
		CAMERA_LIMIT_RIGHT = map.get_map_width() - camera_size - 2.0f;
		CAMERA_LIMIT_DOWN = -map.get_map_height() - 2.3f;
		
		limit_camera_target();
		set_camera_target(camera_target_x, camera_target_z, true);
	}



	void Update()
	{
		limit_camera_target();
		make_camera_follow_target();
	}



	private void limit_camera_target()
	{
		if (camera_target_x < CAMERA_LIMIT_LEFT) camera_target_x = CAMERA_LIMIT_LEFT;
		if (camera_target_x > CAMERA_LIMIT_RIGHT) camera_target_x = CAMERA_LIMIT_RIGHT;
		if (camera_target_z > CAMERA_LIMIT_UP) camera_target_z = CAMERA_LIMIT_UP;
		if (camera_target_z < CAMERA_LIMIT_DOWN) camera_target_z = CAMERA_LIMIT_DOWN;
		
		Vector3 pos = transform.position;
		pos.x = camera_target_x;
		if (pos.x < CAMERA_LIMIT_LEFT) pos.x = CAMERA_LIMIT_LEFT;
		if (pos.x > CAMERA_LIMIT_RIGHT) pos.x = CAMERA_LIMIT_RIGHT;
		transform.position = pos;
		
	}



	private void make_camera_follow_target()
	{
		Vector3 pos = transform.position;
		pos.x += (camera_target_x - pos.x) * CAMERA_SPEED * Time.deltaTime * 0.2f;
		pos.z += (camera_target_z - pos.z) * CAMERA_SPEED * Time.deltaTime * 0.2f;
		transform.position = pos;
	}



	public void set_camera_target(float x, float z, bool without_delay)
	{
		camera_target_x = x;
		camera_target_z = z - 5.0f;
		
		if (without_delay)
		{
			Vector3 pos = transform.position;
			pos.x = camera_target_x;
			pos.z = camera_target_z;
			transform.position = pos;
		}
	}
}
