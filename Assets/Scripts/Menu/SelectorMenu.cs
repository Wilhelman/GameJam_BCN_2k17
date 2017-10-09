using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ACCIO_DE_MENU
{
    PLAY_GAME,
    EXIT
};

public class SelectorMenu : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    Vector3 inputDirection;
    ACCIO_DE_MENU accio;
    float timer;
    public SpriteRenderer playGameSprite;
    public SpriteRenderer exitGameSprite;


    void Start()
    {
        source.clip = clip;

        accio = ACCIO_DE_MENU.PLAY_GAME;
        timer = 1f;
        playGameSprite.enabled = true;
        exitGameSprite.enabled = false;
    }

    void FixedUpdate()
    {
        inputDirection.y = (-1) * Input.GetAxis("P1_LeftJoystickVertical");

        timer += Time.deltaTime;

        if (inputDirection.y > 0.7f && timer > 0.3f)
        {
            timer = 0f;
            if (accio == ACCIO_DE_MENU.EXIT)
                accio = ACCIO_DE_MENU.PLAY_GAME;
            else if (accio == ACCIO_DE_MENU.PLAY_GAME)
                accio = ACCIO_DE_MENU.EXIT;
            changeRenderSpriteMenu();
        }
        else if (inputDirection.y < -0.7f && timer > 0.3f)
        {
            timer = 0f;
            if (accio == ACCIO_DE_MENU.PLAY_GAME)
                accio = ACCIO_DE_MENU.EXIT;
            else if (accio == ACCIO_DE_MENU.EXIT)
                accio = ACCIO_DE_MENU.PLAY_GAME;
            changeRenderSpriteMenu();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0) == true)
            switch (accio)
            {
                case ACCIO_DE_MENU.PLAY_GAME:
                    Application.LoadLevel("MainScene");
                    break;
                case ACCIO_DE_MENU.EXIT:
                    Application.Quit();
                    break;
            }
    }
    void changeRenderSpriteMenu()
    {
        switch (accio)
        {
            case ACCIO_DE_MENU.PLAY_GAME:
                source.Play();
                playGameSprite.enabled = true;
                exitGameSprite.enabled = false;
                break;
            case ACCIO_DE_MENU.EXIT:
                source.Play();
                playGameSprite.enabled = false;
                exitGameSprite.enabled = true;
                break;
        }
    }
}