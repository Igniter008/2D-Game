using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealthcode : MonoBehaviour
{
    public int numofArwTokill = 4;
    int numofArwTaken = 1;
    gameManagerSc gameGM;

    private void Start()
    {
        gameGM = FindAnyObjectByType<gameManagerSc>();
    }

    public void bulletHit()
    {
        if (numofArwTokill > numofArwTaken)
        {
            numofArwTaken++;

        }
        else
        {
            gameGM.AddKills();
            Destroy(gameObject);
        }
    }
}
