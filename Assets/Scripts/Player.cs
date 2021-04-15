using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody player;

    public static bool goldBooster = false;
    public static int shieldNum = 0;

    public static int coins;
    public int _coins;

    public static float sensitivity;
    public float _sensitivity;

    public static float speed;
    public float _speed;

    public int _physicalHlt;
    public int _magicHlt;
    public int _holyHlt;

    public static int physicalHlt;
    public static int magicHlt;
    public static int holyHlt;

    

    public Vector2 startPos;
    public Vector2 direction;

    bool fingerDown;

    //Damage handlers
    public static void physicalHit(int damage)
    {
        physicalHlt -= damage;
    }

    public static void magicHit(int damage)
    {
        magicHlt -= damage;
    }

    public static void holyHit(int damage)
    {
        holyHlt -= damage;
    }


    //Bad solution for changing variables through buttons.
    //Works for it's intents and purposes on a small scale though.
    public void changeSpeed(string action)
    {
        if (action == "+")
        {
            speed++;
            _speed = speed;
        } else
        {
            speed--;
            _speed = speed;
        }
    }

    public void changeSensitivity(string action)
    {
        if (action == "+")
        {
            sensitivity++;
            _sensitivity = sensitivity;
        }
        else
        {
            sensitivity--;
            _sensitivity = sensitivity;
        }
    }

    public void changePhysical(string action)
    {
        if (action == "+")
        {
            physicalHlt++;
            _physicalHlt= physicalHlt;
        }
        else
        {
            physicalHlt--;
            _physicalHlt = physicalHlt;
        }
    }

    public void changeHoly(string action)
    {
        if (action == "+")
        {
            holyHlt++;
            _holyHlt = holyHlt;
        }
        else
        {
            holyHlt--;
            _holyHlt = holyHlt;
        }
    }

    public void changeMagic(string action)
    {
        if (action == "+")
        {
            magicHlt++;
            _magicHlt = magicHlt;
        }
        else
        {
            magicHlt--;
            _magicHlt = magicHlt;
        }
    }


    void Start()
    {
        //Setter
        coins = _coins;

        physicalHlt = _physicalHlt;
        magicHlt = _magicHlt;
        holyHlt = _holyHlt;

        speed = _speed;
        sensitivity = _sensitivity;
    }
    void FixedUpdate()
    {
        //Auto move
        player.transform.position = player.transform.position + new Vector3(0, 0, speed*Time.deltaTime);

        //Player controls PC
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position = player.transform.position + new Vector3(-0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position = player.transform.position + new Vector3(0.2f, 0, 0);
        }

        

        //Player controls touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //Detect initial touch
                case TouchPhase.Began:
                    //Record initial touch position.
                    startPos = touch.position;
                    fingerDown = true;
                    Debug.Log("TOUCH BEGIN");
                    break;

                //Determine movement
                case TouchPhase.Moved:
                    //Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;                    
                    Debug.Log("MOVING...");
                    break;

                case TouchPhase.Ended:
                    //Detect finger lift
                    fingerDown = false;
                    direction = Vector2.zero;
                    Debug.Log("TOUCH END");
                    break;
            }
        }

        //Depending on finger position and set sensitivity, does movement

        if (direction.x < -sensitivity && fingerDown)
        {
            player.transform.position = player.transform.position + new Vector3(-0.1f, 0, 0);
        }
        else if (direction.x > sensitivity && fingerDown)
        {
            player.transform.position = player.transform.position + new Vector3(0.1f, 0, 0);
        }
    }
}
