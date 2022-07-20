using System;
using UnityEngine;
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
using UnityEngine.SceneManagement;
using UnityEngine.UI ;
using TMPro;
using System.Collections;

public class AdsManager : MonoBehaviour {

    public GameObject Player; //, Heart;
    public int count ;
    public Button AdButton;
    public GameObject WifiProblem;

    // Use this for initialization
    void Start ()
    {
        count = 0; 
       // Debug.Log("Unity Ads initialized: " + Advertisement.isInitialized);
       // Debug.Log("Unity Ads is supported: " + Advertisement.isSupported);
       // Debug.Log("Unity Ads test mode enabled: " + Advertisement.testMode);
    }

    private void Update()
    {
        if (count >= 1)
        {
          //  Heart.SetActive(false);
            AdButton.interactable = false;
        }
        else
        {
            AdButton.interactable = true;
        }        
    }

    public void Reset()
    {
        Lives.lives = Lives.OriginalLives;
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        PlayerController.ReloadTimeIsOver = true;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAdvertisement ()
    {        
        ShowVideoAd();       
    }

    public void ShowVideoAd(Action<UnityEngine.Advertisements.ShowResult> adCallBackAction = null, string zone = "")
    {

        //StartCoroutine(WaitForAdEditor());

        if (string.IsNullOrEmpty(zone))
        {
            zone = null;
        }

        var options = new ShowOptions();

        if (adCallBackAction == null)
        {
            options.resultCallback = DefaultAdCallBackHandler;
        }
        else
        {
            options.resultCallback = adCallBackAction;
        }

        if (Advertisement.IsReady(zone))
        {
          //  Debug.Log("Showing ad for zone: " + zone);
            Advertisement.Show(zone, options);
        }
        else
        {
          //  Debug.LogWarning("Ad was not ready. Zone: " + zone);
        }
    }

    private void DefaultAdCallBackHandler(UnityEngine.Advertisements.ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                RestorePlayer();
                break;

            case ShowResult.Failed:
                StartCoroutine(ShowErrorText());
                break;

            case ShowResult.Skipped:
                RestorePlayer(); 
                break;
        }
    }

    public void RestorePlayer ()
    {
        Player.SetActive(true);
        count++;
        Lives.lives = 1;
        this.gameObject.SetActive(false); // Deactivate the menu
        PlayerController.ReloadTimeIsOver = true;
        Time.timeScale = 1f;
    }

    public IEnumerator ShowErrorText ()
    {
        WifiProblem.GetComponent<TMP_Text>().text = "You must enable Wi-Fi for the ad to show.";
        yield return new WaitForSeconds(2);
        WifiProblem.GetComponent<TMP_Text>().text = "";
    }
}
