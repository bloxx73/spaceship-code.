using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour 
{
public SpriteRenderer spaceshipColor;
public Color newColor;

    public float speed;


    public bool Randomcolor;
    public float Timer;
    private float variabel = 1; 

    [Range(-720, 720)]
    public float rotationSpeed;


	// Use this for initialization
	void Start () 
	{	   
        Randomcolor = false;

        // denna rad ger random spawn
        transform.position = new Vector3(Random.Range(-8.66f, 8.66f), Random.Range(-4.99f, 4.99f));

        // denna rad ger random speed
        speed = Random.Range(5, 15);


    }
	
	// Update is called once per frame
	void Update ()
	{
        // denna rad gör så att skeppet konstant åker framåt
        transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.Self);

        // dessa rader gör så att skeppet svänger åt vänster med A och ändrar färg till grönt.
		if (Input.GetKey(KeyCode.A))
		{
             transform.Rotate(0f, 0f, rotationSpeed/2 * Time.deltaTime);


            spaceshipColor.color = new Color(0f, 1f, 0f);
        }

        // dessa rader gör så att skeppet svänger åt höger med D och ändrar färg till blått.
        if (Input.GetKey(KeyCode.D))
        {
	        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            spaceshipColor.color = new Color(0f, 0f, 1f);
        }



        // denna rad gör så att skeppet åker långsamare när S keyn är ner tryckt.
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = speed / 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed = speed * 2;
        }

        // denna rad printar ut timern i consolen.
        Timer += Time.deltaTime;
        if (Timer > variabel &&  Timer < variabel + 0.2)
        {

            Debug.Log(string.Format("Timer:" + Timer));

            variabel = (variabel + 1);


        } 
        
            // denna rad gör så att skeppet får en ny färg varje gång du trycker på space
            if (Input.GetKeyDown(KeyCode.Space))
            {
            Randomcolor = true;

            if (Randomcolor == true)
            {
                newColor = spaceshipColor.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
             
            }



            // dessa två rader gör så att skeppets warp på x axeln funkar.
             if (transform.position.x > 8.66f)
             {
             transform.position = new Vector3(-8.66f, transform.position.y, 0);
             }

             if (transform.position.x < -8.66f)
             {
            transform.position = new Vector3(8.66f, transform.position.y, 0);
             }

             // dessa trå rader gör så att skeppets warp på y axeln funkar.
             if (transform.position.y > 4.99f)
             {
             transform.position = new Vector3(transform.position.x, -4.99f, 0);
             }

             if (transform.position.y < -4.99f)
             {
             transform.position = new Vector3(transform.position.x, 4.99f, 0);
             }


    }


}