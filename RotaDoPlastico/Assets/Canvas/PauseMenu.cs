using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject[] _hudButtons;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    //ao clicar esc vai ao menu de pause
    private void Pausar(GameObject PanelToDisable)
    {
        Time.timeScale = 0;
        PanelToDisable.SetActive(true);
        isPaused = true;

        for (int i = 0; i <= _hudButtons.Length; i++)
        {
            _hudButtons[i].SetActive(false);
        }
    }

    //ao clicar esc de novo ou no botão sai do menu de pause
    public void DesPausar(GameObject PanelToDisable)
    {
        Time.timeScale = 1;
        PanelToDisable.SetActive(false);
        isPaused = false;
        
        for(int i = 0; i<= _hudButtons.Length; i++)
        {
            _hudButtons[i].SetActive(true);
        }
    }

    public void SisPause(GameObject Panel)
    {
        if (isPaused)
        {
            DesPausar(Panel);
        }
        else
        {
            Pausar(Panel);
        }
    }

    //clicar no botão voltar ao menu principal volta ao menu principal
    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    //clicar sair fecha o jogo
    public void SairJogo()
    {
        Application.Quit();
    }



}
