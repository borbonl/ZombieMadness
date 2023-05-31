using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    menu,
    inGame,
    gameOver,
    controls, 
    final
}

public class GameManager : MonoBehaviour {

    public GameState currentGameState = GameState.menu;

    public MenuManager menuManager;



    void Start () {
        menuManager.findCanvas();
        SetGameState(GameState.menu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            BackToMenu();
        }
    }


    public void StartGame(){
        SetGameState(GameState.inGame);
    } 

    public void BackToMenu(){
        SetGameState(GameState.menu);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }


    public void Controls()
    {
        SetGameState(GameState.controls);
    }

    public void final()
    {
        SetGameState(GameState.final);
    }


    private void SetGameState(GameState newGameSate){
        if(newGameSate == GameState.menu){
            menuManager.ShowMainMenu();
            GetComponent<AudioSource>().Play();
            Time.timeScale = 0;
        }
        else if(newGameSate == GameState.inGame && currentGameState != GameState.inGame)
        {
            menuManager.HideMainMenu();
            GetComponent<AudioSource>().Stop() ;
             Time.timeScale = 1;
        }
        else if (newGameSate == GameState.gameOver)
        {
            GetComponent<AudioSource>().Play();
            menuManager.showGameOver();
            Time.timeScale = 0;
        }
        else if (newGameSate == GameState.final)
        {
            menuManager.showFinal();
        }
        else if (newGameSate == GameState.controls)
        {
            menuManager.showControls();
        }
        this.currentGameState = newGameSate;
    }

}
