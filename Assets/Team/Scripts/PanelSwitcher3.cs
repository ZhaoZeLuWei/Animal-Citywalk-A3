using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher3 : MonoBehaviour
{
    public GameObject panel1; 
    public GameObject panel5; 

    public void TogglePanels()
    {
        panel1.SetActive(!panel1.activeSelf);
        panel5.SetActive(!panel5.activeSelf);
    }
}