using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePresenter : MonoBehaviour
{
    [SerializeField] private PauseView _view;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (_view.pauseUIInstance == null)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        _view.MakePauseUI();
        //Time.timeScale = 0;
        GameManager.isTimeStop = false;
    }

    public void ResumeGame()
    {
        //Time.timeScale = 1;
        GameManager.isTimeStop = true;
        _view.DestroyPauseUI();
    }
}
