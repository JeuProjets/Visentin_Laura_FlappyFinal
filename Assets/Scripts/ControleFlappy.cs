using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFlappy : MonoBehaviour
    
{
    //variables pour choisir la vitesse des colonnes, decors... 
    public float vitesseX;
    public float vitesseY;

    //variables pour enregistrer le Sprite de Flappy apr�s les collisions
    public Sprite flappyMort;
    public Sprite flappyVie;

    //variables pour cr�er les GameObject 
    public GameObject lesColonnes;
    public GameObject pieceOr;
    public GameObject packVie;
    public GameObject leChampignon;
 

    void Update()
    {
        //Conditions pour d�placer Flappy
        //Droite
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
        }
        //Gauche
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-vitesseX, vitesseY);
        }

        //Haut
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
        }

    }
    
    //Fonction pour d�tecter les collisions entre Flappy et les gameObjects
    void OnCollisionEnter2D(Collision2D collisionsFlappy)
    {
        if(collisionsFlappy.gameObject.name == "Colonne")
        {
            //On change l'image de Flappy
            GetComponent<SpriteRenderer>().sprite = flappyMort;
        }
        if (collisionsFlappy.gameObject.name == "PieceOr")
        {
            print(collisionsFlappy.gameObject);

            //On d�sactive l'objet
            collisionsFlappy.gameObject.SetActive(false);

            //Appel de la fonction qui le r�active
            Invoke("ReactiverPieceOr", 3f);

        }
        if (collisionsFlappy.gameObject.name == "PackVie")
        {
            print(collisionsFlappy.gameObject);

            //On d�sactive l'objet 
            collisionsFlappy.gameObject.SetActive(false);

            //Appel de la fonction qui le r�active
            Invoke("ReactiverPackVie",3f);

            //On change l'image de Flappy
            GetComponent<SpriteRenderer>().sprite = flappyVie;

        }
        if (collisionsFlappy.gameObject.name == "Champignon")
        {
            print(collisionsFlappy.gameObject);

            //On d�sactive l'objet
            collisionsFlappy.gameObject.SetActive(false);

            //Appel de la fonction qui le r�active et qui r�duit sa taille
            Invoke("ReactiverChampignon", 4f);

            //Grossissement la taille de Flappy pendant quelques secondes
            transform.localScale *= 1.3f;
        }

    }
    //Fonction pour r�activer la pi�ce d'or
    private void ReactiverPieceOr()
    {
        pieceOr.SetActive(true);

        //On met une position al�atoire � son apparition
        float positionPieceOr = Random.Range(-1, 1);
        pieceOr.transform.position = new Vector2(pieceOr.transform.position.x, positionPieceOr);
    }

    //Fonction pour r�activer le pack de vie
    private void ReactiverPackVie()
    {
        packVie.SetActive(true);

    }
    //Fonction pour r�activer le champignon
    private void ReactiverChampignon()
    {
        leChampignon.SetActive(true);

        //on r�duit sa taille quand il apparait
        transform.localScale /= 1.3f;
    }

}
