using UnityEngine;

public class XiaohanLi_PageMusicController : MonoBehaviour
{
    public GameObject hiddenPage;

    private void Start()
    {
        if (hiddenPage != null)
        {
            hiddenPage.SetActive(false);
        }
    }

    public void ShowPageWithMusic()
    {
        if (hiddenPage != null)
        {
            hiddenPage.SetActive(true);

            if (XiaohanLi_AudioManager3.Instance != null)
            {
                Debug.Log("ShowPageWithMusic called. Attempting to play background music.");
                XiaohanLi_AudioManager3.Instance.PlayBackgroundMusic();
            }
            else
            {
                Debug.LogError("XiaohanLi_AudioManager3 is missing in the scene!");
            }
        }
        else
        {
            Debug.LogError("Hidden page object is not assigned.");
        }
    }
}