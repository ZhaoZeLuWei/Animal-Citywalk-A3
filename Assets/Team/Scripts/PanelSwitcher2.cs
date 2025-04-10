using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher2 : MonoBehaviour
{
    public GameObject panel1; 
    public GameObject panel4; 

    public void TogglePanels()
    {
        panel1.SetActive(!panel1.activeSelf);
        panel4.SetActive(!panel4.activeSelf);
    }
}
