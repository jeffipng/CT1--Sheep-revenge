using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamepaused = false;
    bool gameover = false;
    [SerializeField] spaceship player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas1;
    [SerializeField] int numen;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        canvas1.SetActive(false);
    }
        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&& gameover == false)
            PauseGame();                  
    }
    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }
    public void Startgame1()
    {
        SceneManager.LoadScene(2);
    }
    public void Startgame2()
    {
        SceneManager.LoadScene(3);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    void PauseGame()
    {
        gamepaused = gamepaused ? false : true;
        player.gamepaused = gamepaused;
        canvas.SetActive(gamepaused);
        Time.timeScale = gamepaused ? 0 : 1;
    }
    public void Reducirnumeme()
    {
        numen = numen - 1;
        if (numen < 1)
        {
           win();
        }
    }
    void win()
    {
        gameover = true;
        Time.timeScale = 0;
        player.gamepaused = true;
        Time.timeScale = gamepaused ? 0 : 1;
        canvas1.SetActive(gameover);
    }
}