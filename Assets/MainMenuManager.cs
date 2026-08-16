using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Oyna butonuna basılınca oyun sahnesine geçer
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Çıkış butonuna basılınca oyunu kapatır
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}