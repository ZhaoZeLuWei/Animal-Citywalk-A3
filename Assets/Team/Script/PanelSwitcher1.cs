using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject BGMpanel;

    public void TogglePanels()
    {
        panel.SetActive(!panel.activeSelf);
        BGMpanel.SetActive(!BGMpanel.activeSelf);
    }
}