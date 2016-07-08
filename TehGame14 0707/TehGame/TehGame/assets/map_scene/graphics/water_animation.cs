using UnityEngine;
using System.Collections;

public class water_animation : MonoBehaviour
{
	private Material image;
	private int square_x;
	private int square_y;
	private float animation_timer;
	private const float FRAME_LENGTH = 0.2f;



	void Start()
	{
		image = gameObject.GetComponent<Renderer>().material;
		animation_timer = 0.0f;
		square_x = 0;
		square_y = 0;
		
		if (transform.name == "tile_puro3(Clone)") square_y = 1;
		if (transform.name == "tile_puro4(Clone)") square_y = 2;
		
		set_uv();
	}



	void Update()
	{
		animation_timer += Time.deltaTime;
		if (animation_timer > FRAME_LENGTH)
		{
			animation_timer = 0.0f;
			set_uv();
		}
	}



	private void set_uv()
	{
		const float SPRITESHEET_W = 6;
		const float SPRITESHEET_H = 3;
		const float SPRITE_W = 256;
		const float SPRITE_H = 194;
		
		square_x++;
		
		image.mainTextureScale = new Vector2(	(SPRITE_W - 2.0f) / (SPRITESHEET_W * SPRITE_W),
												(SPRITE_H - 2.0f) / (SPRITESHEET_H * SPRITE_H));
		image.mainTextureOffset = new Vector2((square_x * SPRITE_W + 1.0f) / (SPRITESHEET_W * SPRITE_W),
											-((square_y + 1.0f) * SPRITE_H - 1.0f) / (SPRITESHEET_H * SPRITE_H));
	}

}
