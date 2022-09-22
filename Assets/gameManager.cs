using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class gameManager : MonoBehaviour
{
    public TMP_Text puntosTexto;
    public TMP_Text vidasTexto;
    public TMP_Text balasTexto;

    int score;
    int lives = 3;
    int balas = -1;
    // Start is called before the first frame update
    void Start()
    {
        printlives();
        printscore();
        printbalas();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void perderbalas()
    {
        balas--;
        printbalas();
    }
    public int getbalas()
    {
        return balas;
    }
    public void perdervidas()
    {
        lives--;
        printlives();
    }
    public void ganpuntos(int pts)
    {
        score += pts;
        printscore();
    }public void setscore(int pts)
    {
        score = pts;
        printscore();
    }
    public int getvidas()
    {
        return lives;
    }
    public int getpuntos()
    {
        return score;
    }
    void printlives()
    {
        vidasTexto.text = "Vidas: " + lives;
    }
    void printscore()
    {
        puntosTexto.text = "Puntaje: " + score;
    }
    void printbalas()
    {
        balasTexto.text = "Balas: " + balas;
    }
    
}
