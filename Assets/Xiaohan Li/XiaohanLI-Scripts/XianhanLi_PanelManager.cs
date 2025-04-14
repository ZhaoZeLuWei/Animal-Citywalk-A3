using UnityEngine;

public class XianhanLi_PanelManager : MonoBehaviour
{
    public GameObject[] panels; // �������
    private Xiaohan_PlayerController playerController;
    private int activePanelCount = 0; // ��ǰ��ʾ���������

    void Start()
    {
        playerController = FindObjectOfType<Xiaohan_PlayerController>();

        // ֻ��ʾһ��Ĭ����壨�����ǵ�һ����壩
        panels[0].SetActive(true);
        activePanelCount = 1; // ��¼��ǰ��ʾ���������
    }

    public void ShowPanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= panels.Length) return;

        // ֻ�����δ��ʾʱ����ʾ
        if (!panels[panelIndex].activeSelf)
        {
            panels[panelIndex].SetActive(true); // ��ʾָ�����
            activePanelCount++;

            // ����Ƿ����ض����
            if (panelIndex == 5) // �����������壨����5����Ӱ���ƶ�
            {
                // ���ı��ƶ�״̬
            }
            else
            {
                playerController.SetMovement(false); // �����ƶ�
            }
        }
    }

    public void HidePanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= panels.Length) return;

        // ֻ���������ʾʱ������
        if (panels[panelIndex].activeSelf)
        {
            panels[panelIndex].SetActive(false); // ����ָ�����
            activePanelCount--;

            // ���û�����������ʾ���������ƶ�
            if (activePanelCount <= 0)
            {
                playerController.SetMovement(true); // �����ƶ�
            }
        }
    }
}


