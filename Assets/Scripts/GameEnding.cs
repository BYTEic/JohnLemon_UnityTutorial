using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    float m_Timer;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    bool m_IsPlayerAtExit = false;
    bool m_IsPlayerCaught = false;

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart) {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("Game ended");
            if (!doRestart) {
                Application.Quit();
            }
            else SceneManager.LoadScene(0);
        }
    }
    void Update() {
       if (m_IsPlayerAtExit) {
           EndLevel(exitBackgroundImageCanvasGroup, false);
       }
       else if (m_IsPlayerCaught) {
           EndLevel(caughtBackgroundImageCanvasGroup, true);
       }
    }
}
