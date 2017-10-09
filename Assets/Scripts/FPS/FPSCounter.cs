using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    public int FPS;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RecalculateFPS());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator RecalculateFPS()
    {
        while (true)
        {
            FPS = (int)(1 / Time.unscaledDeltaTime);
            yield return new WaitForSeconds(0.5f);
        }
    }
}