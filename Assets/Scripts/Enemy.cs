using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[System.Serializable]
    public enum enemyType
    {
        Elf,
        Orc,
        Demon
          
    };

    public enemyType type;

    void OnTriggerEnter(Collider col)
    {
        //Play sound from SoundManager, deactivates the object.
        //The object will be destroyed later on through the "Instantiate" script.

        //Different effects depending on type of enemy

        if (Player.shieldNum > 0)
        {
            Player.shieldNum--;
            Debug.Log("Shielded from damage");
        }

        else if (Player.physicalHlt > 0)
        {
            SoundManager.playHit();
            gameObject.SetActive(false);
            int coinsToGet = Random.Range(1, 5);

            if (Player.goldBooster)
            {
                coinsToGet *= 2;
            }

            Player.coins += coinsToGet;

            switch (type)
            {
                case enemyType.Orc:
                    Player.physicalHit(1);
                    break;
                case enemyType.Demon:
                    Player.holyHit(1);
                    break;
                case enemyType.Elf:
                    Player.magicHit(1);
                    break;
            }
        }

        else
        {
            endGame();
        }

       
    }

    //Function for game end.
    void endGame()
    {
        Time.timeScale = 0;        

        SoundManager.run.Stop();
        SoundManager.playDeath();

        InterfaceManager.disablePause();
        InterfaceManager.showGameOver();
    }

}
