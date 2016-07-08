using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour {

	float normalscaleX,normalscaleY;
	bool largesize = false;
    GameObject partikkelit;
    ParticleSystemScript PSS;
    
    void Start()
    {
        PSS = GameObject.FindObjectOfType<ParticleSystem>().GetComponent<ParticleSystemScript>();
        partikkelit = GameObject.Find("Particle System");

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Items")
        {
            PSS.emiParticles();
            Destroy(col.gameObject);

        }
    }

    public void slowDown()
    {
        if (GameManager.aikamuutettu == false)
        {
            GameManager.aika = 0.5f;
            Time.timeScale = GameManager.aika;
            GameManager.aikamuutettu = true;
            Debug.Log("hidastuu" + GameManager.aikamuutettu);
            Invoke("speedUp", 0.5f);
        }
            

    }

    void speedUp()
    {
        GameManager.aika = 1f;
        Time.timeScale = GameManager.aika;
        GameManager.aikamuutettu = false;
        Debug.Log("palautuu" + Time.timeScale);
    }



    public void LargeBucket()
	{
		if (largesize == false)
        {
            normalscaleX = transform.localScale.x;
			normalscaleY = transform.localScale.y;
			transform.localScale = new Vector2 (normalscaleX + 0.3f, normalscaleY + 0.2f);
			largesize = true;
			Invoke ("Normalsize", 5f);
		}
        
        
    }

	void Normalsize()
	{
		transform.localScale = new Vector2 (normalscaleX, normalscaleY);
		largesize = false;
	}


}
