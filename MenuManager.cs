using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    Canvas menuCanvas, gameCanvas, overCanvas, hurtCanvas, lastCanvas, contCanvas;
    GameObject player;
    public Camera camara;

    void Start()
    {
        player = GameObject.Find("player1");      
    }

    public void findCanvas() {
        menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        gameCanvas = GameObject.Find("GameCanvas").GetComponent<Canvas>();
        overCanvas = GameObject.Find("OverCanvas").GetComponent<Canvas>();
        hurtCanvas = GameObject.Find("HurtCanvas").GetComponent<Canvas>();
        lastCanvas = GameObject.Find("LastCanvas").GetComponent<Canvas>();
        contCanvas = GameObject.Find("ContCanvas").GetComponent<Canvas>();
        player = GameObject.Find("player1");
    }
    public void ShowMainMenu()
    {
        menuCanvas.enabled = true;
        gameCanvas.enabled = false;
        overCanvas.enabled = false;
        hurtCanvas.enabled = false;
        lastCanvas.enabled = false;
        contCanvas.enabled = false;
        player.GetComponent<WeaponFire>().enabled = false;
        camara.GetComponent<Mira>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void showControls()
    {
        menuCanvas.enabled = false;
        contCanvas.enabled = true;
    }
    public void HideMainMenu()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = true;
        overCanvas.enabled = false;
        hurtCanvas.enabled = true;
        lastCanvas.enabled = false;
        player.GetComponent<WeaponFire>().enabled = true;
        camara.GetComponent<Mira>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void showGameOver()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = false;
        overCanvas.enabled = true;
        hurtCanvas.enabled = false;
        lastCanvas.enabled = false;
        player.GetComponent<WeaponFire>().enabled = false;
        camara.GetComponent<Mira>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }


    public void showFinal()
    {
        menuCanvas.enabled = false;
        gameCanvas.enabled = false;
        overCanvas.enabled = false;
        hurtCanvas.enabled = false;
        lastCanvas.enabled = true;
        player.GetComponent<WeaponFire>().enabled = false;
        camara.GetComponent<Mira>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
