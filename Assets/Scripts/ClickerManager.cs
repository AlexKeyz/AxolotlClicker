using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] int Score;
    public int[] CostInt;
    private int ClickScore = 1;
    public int[] CostBonus;
    public int[] SaveAchiv; 

    [SerializeField] GameObject _Achive1000_Open;
    [SerializeField] GameObject _Achive1000_Close;
    [SerializeField] GameObject _Achive10000_Open;
    [SerializeField] GameObject _Achive10000_Close;
    [SerializeField] GameObject _Achive50000_Open;
    [SerializeField] GameObject _Achive50000_Close;
    [SerializeField] GameObject _Achive150000_Open;
    [SerializeField] GameObject _Achive150000_Close;
    [SerializeField] GameObject _Achive500000_Open;
    [SerializeField] GameObject _Achive500000_Close;
    [SerializeField] GameObject _Plag;

    public Text[] CostText;
    public Text ScoreText;
    [SerializeField] AudioSource Audio;
    private void Start()
    {
        StartCoroutine(BonusShop());
        Score = PlayerPrefs.GetInt("Money", 0);
        CostInt[0] = PlayerPrefs.GetInt("_CostInt[0]", 100);
        ClickScore = PlayerPrefs.GetInt("_ClickScore", 1);
        CostInt[1] = PlayerPrefs.GetInt("_CostInt[1]", 200);
        CostBonus[0] = PlayerPrefs.GetInt("_CostBonus[0]", 0);
        SaveAchiv[0] = PlayerPrefs.GetInt("_SaveAchiv[0]", 0);
        SaveAchiv[1] = PlayerPrefs.GetInt("_SaveAchiv[1]", 0);
        SaveAchiv[2] = PlayerPrefs.GetInt("_SaveAchiv[2]", 0);
        SaveAchiv[3] = PlayerPrefs.GetInt("_SaveAchiv[3]", 0);
        SaveAchiv[4] = PlayerPrefs.GetInt("_SaveAchiv[4]", 0);

        StartOpenAchiv();
        YandexGame.NewLeaderboardScores("LiderBordClicker", Score);
        /*Achive1000();
        Achive10000();
        Achive50000();
        Achive150000();
        Achive500000();*/
        YandexGame.FullscreenShow();
        StartCoroutine(My_Save());
        //StartCoroutine(AdvertsDisplay());
        Invoke("PlayCoruntikool", 80f);
    }

    public void OnClickButton()
    {
        Score += ClickScore;
    }

    private void Update()
    {
        ScoreText.text = Score + "";
        CostText[0].text = CostInt[0] + "";
        CostText[1].text = CostInt[1] + "";
        CostText[2].text = "+ " + CostBonus[0];
        
        //MySave();
    }
    public void OnCkickBuyLevel()
    {
        if (Score >= CostInt[0])
        {
            Score -= CostInt[0];
            CostInt[0] *= 2;
            ClickScore += 1;
            //StartCoroutine(AdvertsDisplay());
        }
    }
    public void OnCkickBuyBonusShop()
    {
        if (Score >= CostInt[1])
        {
            Score -= CostInt[1];
            CostInt[1] += 200;
            CostBonus[0] += 1;
            //_Plag.SetActive(true);
            //Invoke("Advert", 3f);
        }
    }

    IEnumerator BonusShop()
    {
        while (true)
        {
            Score += CostBonus[0];
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator My_Save()
    {
        while (true)
        {
            //StartOpenAchiv();
            //MySave();
            PlayerPrefs.SetInt("Money", Score);
            PlayerPrefs.SetInt("_CostInt[0]", CostInt[0]);
            PlayerPrefs.SetInt("_ClickScore", ClickScore);
            PlayerPrefs.SetInt("_CostInt[1]", CostInt[1]);
            PlayerPrefs.SetInt("_CostBonus[0]", CostBonus[0]);
            PlayerPrefs.SetInt("_SaveAchiv[0]", SaveAchiv[0]);
            PlayerPrefs.SetInt("_SaveAchiv[1]", SaveAchiv[1]);
            PlayerPrefs.SetInt("_SaveAchiv[2]", SaveAchiv[2]);
            PlayerPrefs.SetInt("_SaveAchiv[3]", SaveAchiv[3]);
            PlayerPrefs.SetInt("_SaveAchiv[4]", SaveAchiv[4]);

            YandexGame.savesData.money = CostBonus[0];
            YandexGame.savesData.money = CostInt[1];
            YandexGame.savesData.money = ClickScore;
            YandexGame.savesData.money = CostInt[0];
            YandexGame.savesData.money = Score;
            YandexGame.savesData.money = SaveAchiv[0];
            YandexGame.savesData.money = SaveAchiv[1];
            YandexGame.savesData.money = SaveAchiv[2];
            YandexGame.savesData.money = SaveAchiv[3];
            YandexGame.savesData.money = SaveAchiv[4];
            YandexGame.SaveProgress(); 
            yield return new WaitForSeconds(1);
        }
    }
    public void MySave()
    {
        PlayerPrefs.SetInt("Money", Score);
        PlayerPrefs.SetInt("_CostInt[0]", CostInt[0]);
        PlayerPrefs.SetInt("_ClickScore", ClickScore);
        PlayerPrefs.SetInt("_CostInt[1]", CostInt[1]);
        PlayerPrefs.SetInt("_CostBonus[0]", CostBonus[0]);
        

        YandexGame.savesData.money = CostBonus[0];
        YandexGame.savesData.money = CostInt[1];
        YandexGame.savesData.money = ClickScore;
        YandexGame.savesData.money = CostInt[0];
        YandexGame.savesData.money = Score;
        YandexGame.SaveProgress();
    }
    public void ExidGame()
    {
        Application.Quit();
    }
    public void Achive1000()
    {
        if (Score >= 1000 || SaveAchiv[0] == 1)
        {
            _Achive1000_Open.SetActive(true);
            _Achive1000_Close.SetActive(false);
            SaveAchiv[0] = 1;
            YandexGame.SaveProgress();
        }
    }
    public void Achive10000()
    {
        if (Score >= 10000 || SaveAchiv[1] == 1)
        {
            _Achive10000_Open.SetActive(true);
            _Achive10000_Close.SetActive(false);
            SaveAchiv[1] = 1;
            YandexGame.SaveProgress();
        }
    }
    public void Achive50000()
    {
        if (Score >= 50000 || SaveAchiv[2] == 1)
        {
            _Achive50000_Open.SetActive(true);
            _Achive50000_Close.SetActive(false);
            SaveAchiv[2] = 1;
            YandexGame.SaveProgress();
        }
    }
    public void Achive150000()
    {
        if (Score >= 150000 || SaveAchiv[3] == 1)
        {
            _Achive150000_Open.SetActive(true);
            _Achive150000_Close.SetActive(false);
            SaveAchiv[3] = 1;
            YandexGame.SaveProgress();
        }
    }
    public void Achive500000()
    {
        if (Score >= 500000 || SaveAchiv[4] == 1)
        {
            _Achive500000_Open.SetActive(true);
            _Achive500000_Close.SetActive(false);
            SaveAchiv[4] = 1;
            YandexGame.SaveProgress();
        }
    }
    public void StartOpenAchiv()
    {
        if (SaveAchiv[0] == 1)
        {
            Achive1000();
        }
        if (SaveAchiv[1] == 1)
        {
            Achive10000();
        }
        if (SaveAchiv[2] == 1)
        {
            Achive50000();
        }
        if (SaveAchiv[3] == 1)
        {
            Achive150000();
        }
        if (SaveAchiv[4] == 1)
        {
            Achive500000();
        }
    }
    public void Advert()
    {
        _Plag.SetActive(false);
        YandexGame.FullscreenShow();
    }
    IEnumerator AdvertsDisplay()
    {
        while (true)
        {
            _Plag.SetActive(true);
            Invoke("Advert", 3f);
            yield return new WaitForSeconds(80);
        }
    }
    public void PlayCoruntikool()
    {
        StartCoroutine(AdvertsDisplay());
    }
}

