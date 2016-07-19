using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LayerScript : MonoBehaviour
{   
	public GameObject youWon;
//    public GameObject youLose;
    string lose = "Aina ei voi voittaa :)"; //Määritellään Textiin printattava sisältö
    private Text loserText;

    private Text countTries;
    public static int triesLeft; //Luodaan pelaajalle näkymätön yritysten määrän sisältävä objekti
    public static int Tries; //Luodaan pelaajalle näkyvä yritysten määrän sisältävä objekti

    public GameObject Yeti;

	public float columns, rows;

	public int correctcards;

	public Sprite emptySprite;
	public Sprite cardSprite;

	public int clicks;

	public int[] pickedX, pickedY;

	public List<GameObject> clickedObjects;

	public int level;
	public int itemlimit = 0;

	public GameObject card;

	public float x1, y1, x2, y2, x3, y3, x4, y4;

	public GameObject letter;

	public GameObject LayerManager;

	public GameObject Empty;

	public GameObject[] cards;

	public GameObject[] rightCards;
	public GameObject[] wrongCards;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public int maxX, maxY;
    //public float maxX, maxY;

	public float[] xLocations = new float[] {0,2,4,6,8,10};
	public float[] yLocations = new float[] {0,2,4,6,8,10};

    public Button NextLevel; //luodaan viittaus buttoniin

	private Transform layerHolder;
	private List <Vector3> layerPositions = new List <Vector3> ();

    bool lmbDisabled = false; //määritetään klikkausten laskuri
    int counter = 0;

    SpriteRenderer sr;

    void Start()
    {
        GlobalManager.MemoryGameLoad(); //Ladataan aiempi aika
        Layers(); //käynnistää sovelluksen välittömästi ilman buttonin painamista
        CountUpTimer.StartGame(); //Määritellään aloittamaan laskuri alusta.
        CountDownTimer.Start();
        Rotator.Start();
//        GlobalManager.Start();
        sr = GetComponent<SpriteRenderer>();

        Life1 = GameObject.Find("Life1"); //Viitataan sulkeissa määriteltyyn pelinäkymän objektiin
        Life2 = GameObject.Find("Life2");
        Life3 = GameObject.Find("Life3");
        Yeti = GameObject.Find("yeti");        

        if (level == 1)
        {
            triesLeft = 2;
            Tries = 2;
            Life3.SetActive(false);
        }
        else if (level == 2)
        {
            triesLeft = 2;
            Tries = 2;
            Life3.SetActive(false);
        }
        else if (level == 3)
        {
            triesLeft = 2;
            Tries = 2;
            Life3.SetActive(false);
        }
        else if (level == 4)
        {
            triesLeft = 2;
            Tries = 2;
            Life3.SetActive(false);
        }
        else
        {
            triesLeft = 3; //Määritellään pelaajalle näkymättömien yritysten määrä aloitettaessa
            Tries = 3; //Määritellään pelaajalle näkyvien yritysten määrä aloitettaessa
        }
                countTries = GameObject.Find("Tries").GetComponent<Text>(); //Linkitetään yrityslaskuri lainausmerkeissä määriteltyyn objektiin
                countTries.text = Tries.ToString(); //Tulostetaan näkyvien yritysten määrä aloitettaessa linkitettyyn textiin
    }

    void Update()
    {
        
    }

    void ChooseLevel()
	{
		if (level == 1)
        {
			maxX = 2;
			maxY = 3;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 2;
		}
		else if (level == 2)
        {
			maxX = 2;
			maxY = 3;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 3;
		}
		else if (level == 3)
        {
			maxX = 3;
			maxY = 3;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 2;
		}
		else if (level == 4)
        {
			maxX = 3;
			maxY = 3;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 3;
		}
		else if (level == 5)
        {
			maxX = 3;
			maxY = 4;
            columns = maxY * 2;
            rows = maxX * 2;
			itemlimit = 2;            
		}
		else if (level == 6)
        {
			maxX = 3;
			maxY = 4;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 3;
		}
		else if (level == 7)
        {
			maxX = 3;
			maxY = 5;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 2;
		}
		else if (level == 8)
        {
			maxX = 3;
			maxY = 5;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 3;
		}
		else if (level == 9)
        {
			maxX = 4;
			maxY = 5;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 2;
		}
		else if (level == 10)
        {
			maxX = 4;
			maxY = 5;
			columns = maxY * 2;
			rows = maxX * 2; 
			itemlimit = 3;
		}
        else if (level == 11)
        {
            maxX = 3;
            maxY = 5;
            columns = maxY * 2;
            rows = maxX * 2;
            itemlimit = 4;
        }
    }

	void InitialiseList () //Asetetaan oikeat kortit muiden korttien sekaan
	{
		ChooseLevel (); // check level 
		layerPositions.Clear (); // Clear the positions
		letter.GetComponent<Letter> ().letterScript (); //generate  the letter items

		for (int x = 0; x < rows; x+=2 )
        {
			for (float y = 0; y < columns; y+=2)
            {
				layerPositions.Add (new Vector3(x,y,2f)); //add the positions for the cards
			}
		}
	}

	void LayerSetup() //Peitetään kortit
	{
        StartCoroutine(coverBoxes());
/*
        layerHolder = new GameObject ("Layer").transform;
		for (int x = 0; x < rows; x+=2)
        {
			for (float y = 0; y < columns; y+=2)
            { //määritellään korttien välimatka pystysuunnassa, float mahdollistaa desimaalit
				GameObject toInstantiate = card;
				toInstantiate.name = "card " + x.ToString() + " " + y.ToString(); //Instantiate cards

				GameObject instance = Instantiate(toInstantiate,new Vector3(x,y,1f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(layerHolder);
			}
		}
        */
	}

	void ItemSetup()
	{
		if (itemlimit == 1)
        {
			rightCards [0] = cards [letter.GetComponent<Letter> ().randomItem1]; // add right cards into rightcards depending on the item limit
			rightCards [1] = Empty;
			rightCards [2] = Empty;
            rightCards [3] = Empty;
        }
        else if (itemlimit == 2)
        {
			rightCards [0] = cards [letter.GetComponent<Letter> ().randomItem1];
			rightCards [1] = cards [letter.GetComponent<Letter> ().randomItem2];
			rightCards [2] = Empty;
            rightCards [3] = Empty;
        }
        else if (itemlimit == 3)
        {
			rightCards [0] = cards [letter.GetComponent<Letter> ().randomItem1];
			rightCards [1] = cards [letter.GetComponent<Letter> ().randomItem2];
			rightCards [2] = cards [letter.GetComponent<Letter> ().randomItem3];
            rightCards [3] = Empty;
        }
        else if (itemlimit == 4)
        {
            rightCards[0] = cards[letter.GetComponent<Letter>().randomItem1];
            rightCards[1] = cards[letter.GetComponent<Letter>().randomItem2];
            rightCards[2] = cards[letter.GetComponent<Letter>().randomItem3];
            rightCards[3] = cards[letter.GetComponent<Letter>().randomItem4];
        }

        for (int i = 0; i < wrongCards.Length; i++)
        {
			wrongCards[i] = cards[Random.Range(0,cards.Length)]; // add the wrong cards into wrongcards 

			if (wrongCards[i] == rightCards[0] || wrongCards[i] == rightCards[1] || wrongCards[i] == rightCards[2] || wrongCards[i] == rightCards[3])
			{
				i--;
			}
			                     
		}
		ItemXY ();
	}

	void ItemXY()
	{
		x1 = xLocations[Random.Range(0,maxX)]; //locations for the cards that the player needs to find
		y1 = yLocations[Random.Range(0,maxY)];
		x2 = xLocations[Random.Range(0,maxX)];
		y2 = yLocations[Random.Range(0,maxY)];
		x3 = xLocations[Random.Range(0,maxX)];
		y3 = yLocations[Random.Range(0,maxY)];
        x4 = xLocations[Random.Range(0,maxX)];
        y4 = yLocations[Random.Range(0,maxY)];

      if ((x1 == x2 && y1 == y2) || (x1 == x3 && y1 == y3) || (x1 == x4 && y1 == y4) || (x2 == x3 && y2 == y3) || x2 == x4 && y2 == y4 || x3 == x4 && y3 == y4)
//        if ((x1 == x2 && y1 == y2) || (x2 == x3 && y2 == y3) || (x1 == x3 && y1 == y3) || (x1 == x4 && y1 == y4) || x2 == x4 && y2 == y4 || x3 == x4 && y3 == y4)
        {
			ItemXY (); //Estetään korttien asettuminen päällekkäin
		}
        else
        {
			ItemLayer();
		}
	}

	void ItemLayer ()
    {
		if (itemlimit == 1) //Instantiate the cards player needs to find based on the item limit behind the card layer
        {
			GameObject itemInstantiate1 = rightCards [0];
			GameObject itemInstance1 = Instantiate (itemInstantiate1, new Vector3 (x1, y1, 12f), Quaternion.identity) as GameObject;
			itemInstance1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
			itemInstance1.transform.SetParent (layerHolder);
		}
        else if (itemlimit == 2)
        {

			GameObject itemInstantiate1 = rightCards [0];
			GameObject itemInstance1 = Instantiate (itemInstantiate1, new Vector3 (x1, y1, 12f), Quaternion.identity) as GameObject;
			itemInstance1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance1.transform.SetParent (layerHolder);

			GameObject itemInstantiate2 = rightCards [1];
			GameObject itemInstance2 = Instantiate (itemInstantiate2, new Vector3 (x2, y2, 12f), Quaternion.identity) as GameObject;
			itemInstance2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance2.transform.SetParent (layerHolder);
		}
        else if (itemlimit == 3)
        {
			GameObject itemInstantiate1 = rightCards [0];
			GameObject itemInstance1 = Instantiate (itemInstantiate1, new Vector3 (x1, y1, 12f), Quaternion.identity) as GameObject;
			itemInstance1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance1.transform.SetParent (layerHolder);

			GameObject itemInstantiate2 = rightCards [1];
			GameObject itemInstance2 = Instantiate (itemInstantiate2, new Vector3 (x2, y2, 12f), Quaternion.identity) as GameObject;
			itemInstance2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance2.transform.SetParent (layerHolder);

			GameObject itemInstantiate3 = rightCards [2];
			GameObject itemInstance3 = Instantiate (itemInstantiate3, new Vector3 (x3, y3, 12f), Quaternion.identity) as GameObject;
			itemInstance3.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance3.transform.SetParent (layerHolder);
		}
        else if (itemlimit == 4)
        {
            GameObject itemInstantiate1 = rightCards[0];
            GameObject itemInstance1 = Instantiate(itemInstantiate1, new Vector3(x1, y1, 12f), Quaternion.identity) as GameObject;
            itemInstance1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance1.transform.SetParent(layerHolder);

            GameObject itemInstantiate2 = rightCards[1];
            GameObject itemInstance2 = Instantiate(itemInstantiate2, new Vector3(x2, y2, 12f), Quaternion.identity) as GameObject;
            itemInstance2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance2.transform.SetParent(layerHolder);

            GameObject itemInstantiate3 = rightCards[2];
            GameObject itemInstance3 = Instantiate(itemInstantiate3, new Vector3(x3, y3, 12f), Quaternion.identity) as GameObject;
            itemInstance3.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance3.transform.SetParent(layerHolder);

            GameObject itemInstantiate4 = rightCards[3];
            GameObject itemInstance4 = Instantiate(itemInstantiate4, new Vector3(x4, y4, 12f), Quaternion.identity) as GameObject;
            itemInstance4.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            itemInstance4.transform.SetParent(layerHolder);
        }

        for (int x = 0; x < rows; x += 2) //Luodaan väärät objektit oikeiden objektien rinnalle
        {
            if (itemlimit == 1)
            {
                for (float y = 0; y < columns; y += 2)
                {
                    if (x == x1 && y == y1) //Estetään ylimääräisten korttien luominen oikeiden korttien alle
                    {

                    }
                    else
                    {
                        GameObject wrongInstantiate = wrongCards[Random.Range(0, wrongCards.Length)];
                        GameObject wrongInstance = Instantiate(wrongInstantiate, new Vector3(x, y, 12f), Quaternion.identity) as GameObject;
                        wrongInstance.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        wrongInstance.transform.SetParent(layerHolder);
                    }
                }
            }
            else if (itemlimit == 2)
            {
                for (float y = 0; y < columns; y += 2)
                {
                    if ((x == x1 && y == y1) || (x == x2 && y == y2))
                    {

                    }
                    else
                    {
                        GameObject wrongInstantiate = wrongCards[Random.Range(0, wrongCards.Length)];
                        GameObject wrongInstance = Instantiate(wrongInstantiate, new Vector3(x, y, 12f), Quaternion.identity) as GameObject;
                        wrongInstance.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        wrongInstance.transform.SetParent(layerHolder);
                    }
                }
            }
            else if (itemlimit == 3)
            {
                for (float y = 0; y < columns; y += 2)
                {
                    if ((x == x1 && y == y1) || (x == x2 && y == y2) || (x == x3 && y == y3))
                    {

                    }
                    else
                    {
                        GameObject wrongInstantiate = wrongCards[Random.Range(0, wrongCards.Length)];
                        GameObject wrongInstance = Instantiate(wrongInstantiate, new Vector3(x, y, 12f), Quaternion.identity) as GameObject;
                        wrongInstance.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        wrongInstance.transform.SetParent(layerHolder);
                    }
                }
            }
            else if (itemlimit == 4)
            {
                for (float y = 0; y < columns; y += 2)
                {
                    if ((x == x1 && y == y1) || (x == x2 && y == y2) || (x == x3 && y == y3) || (x == x4 && y == y4))
                    {

                    }
                    else
                    {
                        GameObject wrongInstantiate = wrongCards[Random.Range(0, wrongCards.Length)];
                        GameObject wrongInstance = Instantiate(wrongInstantiate, new Vector3(x, y, 12f), Quaternion.identity) as GameObject;
                        wrongInstance.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        wrongInstance.transform.SetParent(layerHolder);
                    }
                }
            }
        }		
	}

	public void Layers() //function to instantiate the cards, letter and items(right/wrong cards).
    {
		InitialiseList ();
		LayerSetup ();
		ItemSetup ();
	} 

	public void ClickAction(GameObject clickedCard, int x, int y) // player clicks cards and this function saves the information of the card and disables the sprite so it shows the card under it
    {        
        if (clicks == 0 && lmbDisabled == false) //1. klikkaus
        {
            if (itemlimit == 4)
            {
                clicks++;
                pickedX[0] = x;
                pickedY[0] = y;
                clickedObjects.Add(clickedCard);
                clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                Debug.Log("LayerScript: 1. klikkaus");
            }
            else if (itemlimit == 3)
            {
                clicks++;
                pickedX[0] = x;
                pickedY[0] = y;
                clickedObjects.Add(clickedCard);
                clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                Debug.Log("LayerScript: 1. klikkaus");
            }
            else if (itemlimit == 2)
            {
                clicks++;
                pickedX[0] = x;
                pickedY[0] = y;
                clickedObjects.Add(clickedCard);
                clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                Debug.Log("LayerScript: 1. klikkaus");
            }
            else if (itemlimit == 1)
            {
                clicks++;
                triesLeft -= 1; //Vähennetään pelaajalle näkymättömien yritysten määrää yhdellä
                pickedX[0] = x;
                pickedY[0] = y;
                clickedObjects.Add(clickedCard);
                clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                checkClicks();

                Debug.Log("LayerScript: 1. klikkaus");
            }
        }

        else if (clicks == 1) // 2. klikkaus
        {
            if (itemlimit == 4)
            {
                if (clickedObjects[0].transform != clickedCard.transform)
                {
                    clicks++;
                    pickedX[1] = x;
                    pickedY[1] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    Debug.Log("LayerScript: 2. klikkaus");
                }
            }
            else if (itemlimit == 3)
            {
                if (clickedObjects[0].transform != clickedCard.transform)
                {
                    clicks++;
                    pickedX[1] = x;
                    pickedY[1] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    Debug.Log("LayerScript: 2. klikkaus");
                }
            }
            else if (itemlimit == 2)
            {
                if (clickedObjects[0].transform != clickedCard.transform)
                {                    
                    clicks++;
                    triesLeft -= 1;
                    pickedX[1] = x;
                    pickedY[1] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    
                    checkClicks();

                    Debug.Log("LayerScripts: 2. klikkaus");
                }                
            }
		}

        else if(clicks == 2) // 3. klikkaus
        {
            if (itemlimit == 4)
            {
                if (clickedObjects[0].transform != clickedCard.transform && clickedObjects[1].transform != clickedCard.transform) //tarkistetaan ettei klikata samoja kortteja kahdesti
                {

                    clicks++;
                    pickedX[2] = x;
                    pickedY[2] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    Debug.Log("LayerScripts: 3. klikkaus");
                }
            }
            else if (itemlimit == 3)
            {
                if (clickedObjects[0].transform != clickedCard.transform && clickedObjects[1].transform != clickedCard.transform) //tarkistetaan ettei klikata samoja kortteja kahdesti
                {

                    clicks++;
                    triesLeft -= 1;
                    pickedX[2] = x;
                    pickedY[2] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    checkClicks();
                    Debug.Log("LayerScripts: 3. klikkaus");
                }
            }
		}
        else if (clicks == 3) // 4. klikkaus
        {            
            if (itemlimit == 4)
            {
                if (clickedObjects[0].transform != clickedCard.transform && clickedObjects[1].transform != clickedCard.transform && clickedObjects[2].transform != clickedCard.transform) //tarkistetaan ettei klikata samoja kortteja kahdesti
                {

                    clicks++;
                    triesLeft -= 1;
                    pickedX[3] = x;
                    pickedY[3] = y;
                    clickedObjects.Add(clickedCard);
                    clickedCard.GetComponent<SpriteRenderer>().sprite = emptySprite;
                    checkClicks();
                    Debug.Log("LayerScripts: 4. klikkaus");
                }
            }
        }
    }

	void checkClicks() //check all the clicked cards if they are right
    {        
		if (itemlimit == 1)
        {
			correctcards = 0;
            //			for (int i = 0; i < pickedX.Length; i++)
            for (int i = 0; i < 1; i++)
            {
				if (pickedX[i] == x1 && pickedY[i] == y1)
                {
					correctcards++;
                    Debug.Log("LayerScript: x1 y1 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }                
			}

            Debug.Log("LayerScript: correctcards laskettu = " + correctcards);

            if (correctcards == 0)
			{
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1; //Vähennetään pelaajalle näkyvien yritysten määrää yhdellä
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 0 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

            else if(correctcards == 1)
            {
//				correctcards = 0;

                /*
                triesLeft += 1;
                Tries += 1;                             //Lisätään yritysten määrää
                countTries.text = Tries.ToString();

                if (Tries >= 2)
                {
                      Life2.SetActive(true);
                }
                if (Tries >= 3)
                {
                      Life3.SetActive(true);
                }
                */

                StartCoroutine(gameWon());
                NextLevel = GameObject.Find("NextLevel").GetComponent<Button>(); //asetetaan button aktiiviseksi
                NextLevel.interactable = true;
//                Destroy(GameObject.Find("Tries"));
                Debug.Log("LayerScript: Kaikki oikein");
            }
		}
                
        else if (itemlimit == 2)
        {
            correctcards = 0;
//            for (int i = 0; i < pickedX.Length; i++)
            for (int i = 0; i < 2; i++) // i:n maksimiarvo on alle 2
            {
                if (pickedX[i] == (int)x1 && pickedY[i] == (int)y1)
                {                    
                    correctcards++;
                    Debug.Log("LayerScript: x1 y1 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }
                else if (pickedX[i] == (int)x2 && pickedY[i] == (int)y2)
                {                    
                    correctcards++;
                    Debug.Log("LayerScript: x2 y2 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }
            }

            Debug.Log("LayerScript: correctcards laskettu = " + correctcards);

            if (correctcards == 0)
			{
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 0 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
//                    Life3.transform.position = new Vector3(-17, 0, 0) * Time.deltaTime;
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

			else if(correctcards == 1)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 1 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

			else if(correctcards == 2)
			{
//				correctcards = 0;

                /*
                triesLeft += 1;
                Tries += 1;                             //Lisätään yritysten määrää
                countTries.text = Tries.ToString();

                if (Tries >= 2)
                {
                      Life2.SetActive(true);
                }
                if (Tries >= 3)
                {
                      Life3.SetActive(true);
                }
                */

                StartCoroutine(gameWon());
                NextLevel = GameObject.Find("NextLevel").GetComponent<Button>(); //Asetetaan button aktiiviseksi
                NextLevel.interactable = true;
//                Destroy(GameObject.Find("Tries"));
                Debug.Log("LayerScript: Kaikki oikein");
            }
		}


		else if (itemlimit == 3)
        {
			correctcards = 0;
//			for (int i = 0; i < pickedX.Length; i++)
            for (int i = 0; i < 3; i++)
            {
				if (pickedX[i] == (int)x1 && pickedY[i] == (int)y1)
                {
					correctcards++;
                    Debug.Log("LayerScript: x1 y1 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }
                else if (pickedX[i] == (int)x2 && pickedY[i] == (int)y2)
                {
					correctcards++;
                    Debug.Log("LayerScript: x2 y2 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }
				else if (pickedX [i] == (int)x3 && pickedY [i] == (int)y3)
                {
					correctcards++;
                    Debug.Log("LayerScript: x3 y3 klikattu");
                    Debug.Log("LayerScript: i = " + i);
                }
			}

            Debug.Log("LayerScript: correctcards laskettu = " + correctcards);

            if (correctcards == 0)
			{
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 0 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

			else if(correctcards == 1)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 1 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

			else if(correctcards == 2)
			{
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 2 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
//                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

			else if(correctcards == 3)
			{
//				correctcards = 0;

                /*
                triesLeft += 1;
                Tries += 1;                             //Lisätään yritysten määrää
                countTries.text = Tries.ToString();

                if (Tries >= 2)
                {
                    Life2.SetActive(true);
                }
                if (Tries >= 3)
                {
                    Life3.SetActive(true);
                }
                */

                StartCoroutine(gameWon());
                NextLevel = GameObject.Find("NextLevel").GetComponent<Button>(); //asetetaan button aktiiviseksi
                NextLevel.interactable = true;
//                Destroy(GameObject.Find("Tries"));
                Debug.Log("LayerScript: Kaikki oikein");
            }
		}

        else if (itemlimit == 4)
        {
            correctcards = 0;
            //			for (int i = 0; i < pickedX.Length; i++)
            for (int i = 0; i < 4; i++)
            {
                if (pickedX[i] == (int)x1 && pickedY[i] == (int)y1)
                {
                    correctcards++;
                    Debug.Log("LayerScript: x1 y1 klikattu");
//                    Debug.Log("LayerScript: i = " + i);
                }
                else if (pickedX[i] == (int)x2 && pickedY[i] == (int)y2)
                {
                    correctcards++;
                    Debug.Log("LayerScript: x2 y2 klikattu");
//                    Debug.Log("LayerScript: i = " + i);
                }
                else if (pickedX[i] == (int)x3 && pickedY[i] == (int)y3)
                {
                    correctcards++;
                    Debug.Log("LayerScript: x3 y3 klikattu");
//                    Debug.Log("LayerScript: i = " + i);
                }
                else if (pickedX[i] == (int)x4 && pickedY[i] == (int)y4)
                {
                    correctcards++;
                    Debug.Log("LayerScript: x4 y4 klikattu");
//                    Debug.Log("LayerScript: i = " + i);
                }
            }

            Debug.Log("LayerScript: correctcards laskettu = " + correctcards);

            if (correctcards == 0)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 0 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
                    //                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

            else if (correctcards == 1)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 1 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
                    //                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

            else if (correctcards == 2)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 2 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
                    //                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

            else if (correctcards == 3)
            {
                if (triesLeft > 0)
                {
                    correctcards = 0;

                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(turnCards());
                    Debug.Log("LayerScript: 3 oikein");
                }
                else if (triesLeft == 0)
                {
                    Tries -= 1;
                    countTries.text = Tries.ToString();

                    StartCoroutine(gameLose());
                }

                if (triesLeft == 2)
                {
                    //                    Destroy(GameObject.Find("Life3"));
                    Life3.SetActive(false);
                }
                if (triesLeft == 1)
                {
                    Life2.SetActive(false);
                }
                if (triesLeft == 0)
                {
                    Life1.SetActive(false);
                }
            }

            else if (correctcards == 4)
            {
                //				correctcards = 0;

                /*
                triesLeft += 1;
                Tries += 1;                             //Lisätään yritysten määrää
                countTries.text = Tries.ToString();

                if (Tries >= 2)
                {
                    Life2.SetActive(true);
                }
                if (Tries >= 3)
                {
                    Life3.SetActive(true);
                }
                */

                StartCoroutine(gameWon());
                NextLevel = GameObject.Find("NextLevel").GetComponent<Button>(); //asetetaan button aktiiviseksi
                NextLevel.interactable = true;
                //                Destroy(GameObject.Find("Tries"));
                Debug.Log("LayerScript: Kaikki oikein");
            }
        }
    }

    /*
	void Restart() //restart the game
    {
                     //level++;
                     //Layers();
        Application.LoadLevel(0);
        
	}
    */

    public IEnumerator coverBoxes()
    {
        yield return new WaitForSeconds(3f); //Peitetään objektit sulkeissa määritellyn ajan kuluttua
        
        layerHolder = new GameObject("Layer").transform;
        for (int x = 0; x < rows; x += 2)
        {
            for (float y = 0; y < columns; y += 2) //Määritellään korttien sijainti ja välimatka pystysuunnassa, float mahdollistaa desimaalit
            {
                GameObject toInstantiate = card; //Luodaan card-objekti
                toInstantiate.name = "card " + x.ToString() + " " + y.ToString(); //Instantiate cards

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 10f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(layerHolder);
            }
        }
    }

    public IEnumerator turnCards()
    {
        yield return new WaitForSeconds(0.5f);

        clicks = 0;

        for (int i = 0; i < clickedObjects.Count; i++)
        {
            clickedObjects[i].GetComponent<SpriteRenderer>().sprite = cardSprite;
        }
        clickedObjects.Clear();
    }

    public IEnumerator gameWon() //show "you won" text for 4 seconds and restart the game
    {
        CountUpTimer.EndGame(); //Viitataan toiseen skriptiin kun peli päättyy. Muutetaan EndGamen sisältämä Cleared trueksi.
        Rotator.Stop();
        GlobalManager.MemoryGameSave();

        lmbDisabled = true;
//        yield return new WaitForSeconds(0.1f);
//        Destroy(GameObject.Find("items"));

        yield return new WaitForSeconds (0.8f);
        Destroy(GameObject.Find("Layer"));
        Destroy(GameObject.Find("Pakastinallaskansi"));
        Debug.Log("LayerScript: You won");
        youWon.SetActive (true);
//        Yeti.SetActive(false);

        yield return new WaitForSeconds (2f);
		youWon.SetActive (false);        
		//Restart ();
	}

    public IEnumerator gameLose()
    {
        CountUpTimer.EndGame();
        lmbDisabled = true;

        yield return new WaitForSeconds(0.8f);
        Destroy(GameObject.Find("Layer"));
        Destroy(GameObject.Find("Pakastinallaskansi"));
        Debug.Log("LayerScript: You lose");
        loserText = GameObject.Find("Loser").GetComponent<Text>(); //Tulostetaan lainausmerkeissä määriteltyyn linkitettyyn textiin
        loserText.text = lose;

        yield return new WaitForSeconds(2f);
        Destroy(GameObject.Find("Loser"));
    }
}
//worst code 2k16