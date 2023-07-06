using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject InputNickName;
    public GameObject WelcomeIntro;
    public GameObject mainMenu;
    public GameObject CreateRoom;
    public GameObject FindRoom;
    public GameObject ListPlayer;
    public GameObject Options;
    public GameObject About;
    public GameObject ExitGame;
    public GameObject Loading;


    [Header("User Interface Buttons")]
    public Button InputNickNameButton;
    public Button WelcomeIntroButton;
    public Button InputNameRoomButton;
    public Button ConfirmNameRoomButton;
    public Button CancelButton;
    public Button GameStartButton;
    public Button SaveOptionButton;
    public Button NoSaveOptionButton;
    public Button ExitGameButton;
    public Button NoButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableInputNickName();

        //Hook events
        InputNickNameButton.onClick.AddListener(EnableWelcomeIntro);
        WelcomeIntroButton.onClick.AddListener(EnableMainMenu);
        InputNameRoomButton.onClick.AddListener(EnableListPlayer);
        ConfirmNameRoomButton.onClick.AddListener(EnableListPlayer);
        CancelButton.onClick.AddListener(CancelRoom);
        GameStartButton.onClick.AddListener(StartGame);
        SaveOptionButton.onClick.AddListener(SaveOptionConf);
        NoSaveOptionButton.onClick.AddListener(NoSaveOptionConf);
        ExitGameButton.onClick.AddListener(ExitGamePrompt);
        NoButton.onClick.AddListener(CancelRoom);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        HideAll();
        Application.Quit();
    }

    public void CancelRoom()
    {
        EnableMainMenu();
    }

    public void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(false);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(true);
    }

    public void EnableInputNickName()
    {
        InputNickName.SetActive(true);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(false);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void EnableWelcomeIntro()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(true);
        mainMenu.SetActive(false);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void EnableListPlayer()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(false);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(true);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void EnableMainMenu()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(true);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void SaveOptionConf()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(true);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(true);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void NoSaveOptionConf()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(true);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(true);
        About.SetActive(false);
        ExitGame.SetActive(false);
        Loading.SetActive(false);
    }

    public void ExitGamePrompt()
    {
        InputNickName.SetActive(false);
        WelcomeIntro.SetActive(false);
        mainMenu.SetActive(false);
        CreateRoom.SetActive(false);
        FindRoom.SetActive(false);
        ListPlayer.SetActive(false);
        Options.SetActive(false);
        About.SetActive(false);
        ExitGame.SetActive(true);
        Loading.SetActive(false);
    }
}