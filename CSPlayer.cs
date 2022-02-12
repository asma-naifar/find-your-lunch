using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSPlayer : MonoBehaviour
{
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Gui()
    {
        GUI.label(new Rect(20, 20, 200, 40), "score : " + points);
    }
}









