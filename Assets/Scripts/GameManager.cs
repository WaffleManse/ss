using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text nowScore;
    public Text bestScore;

    public Animator anim;

    bool isPlay = true;

    float time = 0.0f;

    string Key = "bestScore";
    static float MaxScore = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Time.timeScale= 1.0f;
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.5f);
        nowScore.text = time.ToString("N2");

        if(MaxScore < time)
        {
            MaxScore = time;
            bestScore.text = time.ToString("N2");
        }
        else
        {
            bestScore.text = MaxScore.ToString("N2");
        }

        //최고점수가 있다면
        //if(PlayerPrefs.HasKey(Key))
        //{
        //    float best = PlayerPrefs.GetFloat(Key);//최고점수 < 현재 점수
        //    if (best < time)
        //    {
        //        PlayerPrefs.SetFloat(Key, time);//현재점수를 최고 점수에 저장
        //        bestScore.text = time.ToString("N2");
        //    }
        //    else
        //    {
        //        bestScore.text = best.ToString("N2");   //최고점수 > 현재점수
        //    }
        //}
        //else//최고점수가 없다면
        //{
        //    PlayerPrefs.SetFloat(Key, time);//현재 점수를 저장
        //    bestScore.text = time.ToString("N2");
        //}
                  
        endPanel.SetActive(true);
    }

    void TimeStop()
    {
        Time.timeScale = 0.0f;
    }
}
