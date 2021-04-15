using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public enum PowerUps {
        Shield,
        goldBoost
    }

    public PowerUps type;

    void OnTriggerEnter(Collider col)
    {
        SoundManager.playPowerUp();

        switch (type) {
            case PowerUps.Shield:
                Player.shieldNum++;
                Debug.Log("Shield");
                Destroy(this.gameObject);
                break;
            case PowerUps.goldBoost:
                Player.goldBooster = true;
                Debug.Log("Gold Boost");
                Destroy(this.gameObject);
                break;
        }

        Player.speed += 5;
    }
}
