using UnityEngine;
using System.Collections;

public class KeyGate : MonoBehaviour
{
	bool InRange;
	bool hasKey;
	Animator anim;
	Collector playerscript;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnMouseDown()
	{
		if (InRange&&hasKey)
		{
			//   if (playerscript.GetTorches()>0)
			//   {
			//       playerscript.DevourTorches();
			BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
			col.enabled = false;
			anim.SetBool ("Unlock", true);
			Invoke("DestroyDoor", anim.GetNextAnimatorStateInfo(0).length +0.5f);
			Destroy(gameObject, 1);

			//   }
		}
	}

    public void OpenDoor (bool hasKey)
    {
        if(hasKey)
		{
			anim.SetBool ("Unlock", true);
			Invoke("DestroyDoor", anim.GetNextAnimatorStateInfo(0).length +0.5f);
        }
        else
        {
			
            //no key, play sound effect
        }
    }

	void DestroyDoor()
	{
		Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			playerscript = col.gameObject.GetComponent<Collector>();
			InRange = true;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			playerscript = null;
			InRange = false;
		}
	}
}
