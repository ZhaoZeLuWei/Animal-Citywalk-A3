using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher1 : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel3;

    public void TogglePanels()
    {
        panel1.SetActive(!panel1.activeSelf);
        panel3.SetActive(!panel3.activeSelf);
    }
}


