using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShaderMenu : MonoBehaviour {

    //Shader Menu Handler

    //Shader Menu Object Group
    public GameObject shaderMenu;

    //Player Body - Target to be effected by Shader Change
    public GameObject targetBody;

    //Material Shaders
    public Material glowShader;
    public Material cellShader;

    //Shader Menu Buttons
	public Button shaderGlowButton;
	public Button shaderCellButton;

	// Use this for initialization
	void Start () {
        shaderGlowButton.onClick.AddListener(ApplyGlowShader);
        shaderCellButton.onClick.AddListener(ApplyCellShader);

        shaderMenu.SetActive(false);
    }

    //Triggered when Applying Glow Shader
    public void ApplyGlowShader()
    {
        targetBody.GetComponent<Renderer>().material = glowShader;
        ToggleVisibility(false);
    }

    //Triggered when Applying Cell Shader
    public void ApplyCellShader()
    {
        targetBody.GetComponent<Renderer>().material = cellShader;
        ToggleVisibility(false);
    }

    //Toggle Shader Menu Visibility
    public void ToggleVisibility(bool toggle)
    {
        shaderMenu.SetActive(toggle);
    }
}
