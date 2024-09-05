using UnityEngine;
using  UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isInitialised { get; private set; }
    public static GameObject mainMenu, settingsMenu, shopMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        //startMenu = canvas.transform.Find("StartMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        shopMenu = canvas.transform.Find("ShopMenu").gameObject;

        isInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if(!isInitialised)
            Init();

        switch(menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SHOP:
                shopMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.START_GAME:
                SceneManager.LoadScene("Level 1");
                break;
        }

        callingMenu.SetActive(false);
    }
}
