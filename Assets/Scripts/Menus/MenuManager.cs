using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public void OnClick_Play()
    {
        UIManager.OpenMenu(Menu.START_GAME, gameObject);
    }

    public void OnClick_Shop()
    {
        UIManager.OpenMenu(Menu.SHOP, gameObject);
    }

    public void OnClick_Settings()
    {
        UIManager.OpenMenu(Menu.SETTINGS, gameObject);
    }

    public void OnClick_Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
