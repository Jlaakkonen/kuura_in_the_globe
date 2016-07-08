using UnityEngine;
using System.Collections;

public class ParticleSystemScript : MonoBehaviour {

    
    GameObject Player;
    Vector3 position;
    Vector3 playerPosition;
    ParticleSystemScript PSS;
    GameObject partikkelit2;
    float destPointY = 0.0f;
    // Use this for initialization
    void Start () {
        
        
        Player = GameObject.Find("Bucket");

        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Default";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 1;
        //position = Player.transform.position;

    }
    public void emiParticles()
    {

        partikkelit2 = (GameObject)Instantiate(gameObject, Player.transform.position, Player.transform.rotation);

        partikkelit2.GetComponent<ParticleSystem>().Emit(100);

    }
    
    

// Update is called once per frame
void Update () {
        //playerPosition.x = Player.transform.position.x;
        //position = playerPosition;
        //gameObject.transform.position = position;
        /*if (
        {
            Points.breakingPoints++;

            Destroy(gameObject);
        }*/
    }

}
