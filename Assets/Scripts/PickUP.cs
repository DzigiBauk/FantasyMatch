using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public enum pickUpType
    {
        Physical,
        Holy,
        Magic
    }

    public pickUpType type;

    void OnTriggerEnter(Collider col)
    {
        //Pick Up discernation and functions
        SoundManager.playPowerUp();

        switch (type)
        {
            case pickUpType.Physical:
                Player.physicalHlt++;
                break;

            case pickUpType.Holy:
                Player.holyHlt++;
                break;

            case pickUpType.Magic:
                Player.magicHlt++;
                break;
        }

        Destroy(this.gameObject);
    }
}
