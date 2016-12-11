using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    //Pause Menu Handler

    //Pause Menu Object Group
	public GameObject pauseMenu;

    //Pause Menu Buttons
	public Button shaderButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		shaderButton.onClick.AddListener(OpenShaderMenu);
		quitButton.onClick.AddListener(QuitGame);

        pauseMenu.SetActive(false);
    }

    //Opens Shader Menu when Called and Closes this Menu
	public void OpenShaderMenu()
	{
        this.GetComponent<ShaderMenu>().ToggleVisibility(true);
        this.ToggleVisibility(false);
	}

    //Quits Game (Only when in Build)
	public void QuitGame()
	{
        Application.Quit();
	}
	
    //Toggles Pause Menu Visibility
	public void ToggleVisibility(bool toggle)
	{
        pauseMenu.SetActive(toggle);
	}	
}
