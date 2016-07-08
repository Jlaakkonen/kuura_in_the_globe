using UnityEngine;
using System.Collections;

public class SlowDownScript : DropItem
{

    private Catcher bucketScript;
    //static bool aikamuutettu = false;
    //public static float aika;

    protected override void Start()
    {
        base.Start();
        bucketScript = FindObjectOfType<Catcher>();
        
    }

    protected override void Update()
    {
        //if (transform.position.y <= ShelfGameManager.destroyPoint.position.y) {
        if (transform.position.y <= 0.0F)
        {
            Points.breakingPoints++;
            Destroy(gameObject);
        }
    }

    /*void speedUp()
    {
        GameManager.aika = 1f;
        Time.timeScale = GameManager.aika;
        GameManager.aikamuutettu = false;
        Debug.Log("palautuu" + Time.timeScale);
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Bucket")
        {
            bucketScript.slowDown();

            //Invoke("speedUp", 0.5f);
        }
        //Invoke("speedUp", 0.5f);

    }

   




    /*if (col.tag == "Bucket")
    {


        if (GameManager.aikamuutettu == true)
        {
            Time.timeScale = 1f;
            Debug.Log("normalisoituu");
            GameManager.aikamuutettu = false;
        }
        else if (GameManager.aikamuutettu == false)
        {
            float random = Random.Range(0, 3);

            if (random <= 1)
            {
                GameManager.aika = Time.timeScale + 0.5f;
                Time.timeScale = GameManager.aika;
                GameManager.aikamuutettu = true;
                Debug.Log("nopeutuu" + GameManager.aikamuutettu);
            }
            else if(random > 1)
            {
                GameManager.aika = Time.timeScale - 0.25f;
                Time.timeScale = GameManager.aika;
                GameManager.aikamuutettu = true;
                Debug.Log("hidastuu" + GameManager.aikamuutettu);
            }

        }

    }*/

}
    
