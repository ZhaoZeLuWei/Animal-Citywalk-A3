using UnityEngine;

public class XianhanLi_PanelManager : MonoBehaviour
{
    public GameObject[] panels; // 所有面板
    private Xiaohan_PlayerController playerController;
    private int activePanelCount = 0; // 当前显示的面板数量

    void Start()
    {
        playerController = FindObjectOfType<Xiaohan_PlayerController>();

        // 只显示一个默认面板（假设是第一个面板）
        panels[0].SetActive(true);
        activePanelCount = 1; // 记录当前显示的面板数量
    }

    public void ShowPanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= panels.Length) return;

        // 只在面板未显示时才显示
        if (!panels[panelIndex].activeSelf)
        {
            panels[panelIndex].SetActive(true); // 显示指定面板
            activePanelCount++;

            // 检查是否是特定面板
            if (panelIndex == 5) // 假设第六个面板（索引5）不影响移动
            {
                // 不改变移动状态
            }
            else
            {
                playerController.SetMovement(false); // 禁用移动
            }
        }
    }

    public void HidePanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= panels.Length) return;

        // 只在面板已显示时才隐藏
        if (panels[panelIndex].activeSelf)
        {
            panels[panelIndex].SetActive(false); // 隐藏指定面板
            activePanelCount--;

            // 如果没有其他面板显示，则启用移动
            if (activePanelCount <= 0)
            {
                playerController.SetMovement(true); // 启用移动
            }
        }
    }
}


