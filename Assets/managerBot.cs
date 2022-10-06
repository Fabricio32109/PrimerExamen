using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using TMPro;

public class managerBot : MonoBehaviour
{
    public TMP_Text puntosTexto;
    public TMP_Text modo;
    public GameObject zombie;//11,0
    int punt = 0;
    bool bloq1 = false;
    bool bloq2 = false;
    Stopwatch stopwatch = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        modo.text = "Katana";
        stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = stopwatch.Elapsed;
        UnityEngine.Debug.Log(ts.TotalSeconds);
        if (ts.TotalSeconds >= 2 && ts.TotalSeconds < 2.1 && bloq1 == false)
        {
            aleat();
            bloq1 = true;
        }
        if (ts.TotalSeconds >= 3 && ts.TotalSeconds < 3.1 && bloq2 == false)
        {
            aleat();
            bloq2 = true;
        }
        if (ts.TotalSeconds >= 4 )
        {
            var gb = Instantiate(zombie, new Vector2(11, 0), Quaternion.identity) as GameObject;
            stopwatch.Reset();
            stopwatch.Start();
            bloq1 = false;
            bloq2 = false;
        }
    }
    void aleat()
    {
        System.Random random = new System.Random();
        int value = random.Next(0, 101);
        if (value < 33)
        {
            var gb = Instantiate(zombie, new Vector2(11, 0), Quaternion.identity) as GameObject;
            stopwatch.Reset();
            stopwatch.Start();
        }
    }
    public void cambio()
    {
        if (modo.text == "Katana")
            modo.text = "Kunai";
        else
            modo.text = "Katana";
    }
    void escribir()
    {
        puntosTexto.text = "Puntos: " + punt;
    }
    public void ganPuntos(int n)
    {
        punt += n;
        escribir();
    }
}
