using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour
{

	public GameObject letter, layermanager;

	public Transform itemManager;

	public GameObject[] itemPrefabs;

	public string chosenItem1, chosenItem2, chosenItem3, chosenItem4;

	public int randomItem1, randomItem2, randomItem3, randomItem4;

	public void letterScript()
    {// generate the cards

		int item1rnd = Random.Range(0, itemPrefabs.Length);
		int item2rnd = Random.Range(0, itemPrefabs.Length);
		int item3rnd = Random.Range(0, itemPrefabs.Length);
        int item4rnd = Random.Range(0, itemPrefabs.Length);


        itemManager = new GameObject ("items").transform; //luodaan items-kansio

		int currentitemlimit = layermanager.GetComponent<LayerScript>().itemlimit;
		if (currentitemlimit == 1)
        {
			GameObject toInstantiate = itemPrefabs [item1rnd];

			GameObject instance = Instantiate (toInstantiate, new Vector3 (-6f, 8f, 0f), Quaternion.identity) as GameObject;

			instance.transform.SetParent (itemManager);

			randomItem1 = item1rnd;
		}
        else if (currentitemlimit == 2)
        {
			GameObject toInstantiate = itemPrefabs[item1rnd];
			GameObject toInstantiate2 = itemPrefabs[item2rnd];

			GameObject instance = Instantiate (toInstantiate, new Vector3 (-7.5f,8.5f,0f),Quaternion.identity) as GameObject;
			GameObject instance2 = Instantiate (toInstantiate2, new Vector3 (-5.5f,7.5f,0f),Quaternion.identity) as GameObject;

			instance.transform.SetParent(itemManager);
			instance2.transform.SetParent(itemManager);

			randomItem1 = item1rnd;
			randomItem2 = item2rnd;
		}
        else if (currentitemlimit == 3)
        {
			GameObject toInstantiate = itemPrefabs[item1rnd];
			GameObject toInstantiate2 = itemPrefabs[item2rnd];
			GameObject toInstantiate3 = itemPrefabs[item3rnd];

			GameObject instance = Instantiate (toInstantiate, new Vector3 (-8f,9f,0f),Quaternion.identity) as GameObject;
			GameObject instance2 = Instantiate (toInstantiate2, new Vector3 (-6.5f,8f,0f),Quaternion.identity) as GameObject;
			GameObject instance3 = Instantiate (toInstantiate3, new Vector3 (-5f,7f,0f),Quaternion.identity) as GameObject;

			instance.transform.SetParent(itemManager);
			instance2.transform.SetParent(itemManager);
			instance3.transform.SetParent(itemManager);

			randomItem1 = item1rnd;
			randomItem2 = item2rnd;
			randomItem3 = item3rnd;
		}
        else if (currentitemlimit == 4)
        {
            GameObject toInstantiate = itemPrefabs[item1rnd];
            GameObject toInstantiate2 = itemPrefabs[item2rnd];
            GameObject toInstantiate3 = itemPrefabs[item3rnd];
            GameObject toInstantiate4 = itemPrefabs[item4rnd];

            GameObject instance = Instantiate(toInstantiate, new Vector3(-8f, 8.5f, 0f), Quaternion.identity) as GameObject;
            GameObject instance2 = Instantiate(toInstantiate2, new Vector3(-6.5f, 8f, 0f), Quaternion.identity) as GameObject;
            GameObject instance3 = Instantiate(toInstantiate3, new Vector3(-5f, 7.5f, 0f), Quaternion.identity) as GameObject;
            GameObject instance4 = Instantiate(toInstantiate4, new Vector3(-3.5f, 7f, 0f), Quaternion.identity) as GameObject;

            instance.transform.SetParent(itemManager);
            instance2.transform.SetParent(itemManager);
            instance3.transform.SetParent(itemManager);
            instance4.transform.SetParent(itemManager);

            randomItem1 = item1rnd;
            randomItem2 = item2rnd;
            randomItem3 = item3rnd;
            randomItem4 = item4rnd;
        }
    }
}
