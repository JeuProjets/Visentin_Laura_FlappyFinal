using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementObjets : MonoBehaviour
{
    //Variables pour les propri�t�s des objets (colonnes, nuages, decor)
    public float vitesse;

    public float positionDebut;
    public float positionFin;

    public float deplacementAleatoire;
    

    void Update()
    {
        //Lorsque les objets sortent de la sc�ne
        if (transform.position.x < positionFin)
        {
            //Les colonnes se replacent al�atoirement
            float valeurAleatoireY = Random.Range(-deplacementAleatoire, deplacementAleatoire);
            transform.position = new Vector2(positionDebut, valeurAleatoireY);

            //Reviennent de l'autre bord
            transform.position = new Vector3(positionDebut, transform.position.y, 0);
        }
        transform.Translate(vitesse, 0f, 0f);
    }
}


    