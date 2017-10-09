using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObjectStaticDestroiable : MonoBehaviour {
    public uint resistencia = 2;
    public SpriteRenderer CaixaSencera;
    public SpriteRenderer CaixaMigTrencada;
    
	void Start () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
            resistencia--;
            if (resistencia == 1)
            {
                CaixaMigTrencada.enabled = true;
                CaixaSencera.enabled = false;
            }
            else if (resistencia <= 0)
            {
                Destroy(gameObject, 1);
            }
        }
    }
}
