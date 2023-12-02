using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlers : MonoBehaviour
{
    // Start is called before the first frame update
    int RighCount;
    public float maxTime = 30f;
    float timePlay = 0f;

    private void Awake()
    {
        timePlay = maxTime;
    }
    void Start()
    {
        CreateQuestion();
        StartCoroutine(ResetTime());
        UI.instance.SetTimeTx("00 : "+timePlay);


    }
    private void Update()
    {
       
    }



    public void CreateQuestion()//gán đáp án đung và sai và hiện thị lên trên game//tạo câu hỏi khác
    {

        QuestionData qs = QuestionManager.instance.RandomQuestion();

        if (qs != null)
        {

            UI.instance.SetQuestionTx(qs.Question);
            string[] wrongAs = new string[] { qs.Answer1, qs.Answer2, qs.Answer3 };
            UI.instance.MixAnswer();
            var temp = UI.instance.setAnswersBt;// mảng câu hỏi đã đc gắn tag

            if (temp != null && temp.Length>0)
            {


                int dem = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int coutI = i;
                    if (string.Compare(temp[i].tag, "RightAs") ==0)
                    {
                        temp[i].SetAnswerText(qs.AnswerTrue);

                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAs[dem]);
                        dem++;

                    }
                    temp[coutI].AnswerButon.onClick.RemoveAllListeners();
                    temp[coutI].AnswerButon.onClick.AddListener(() => Check(temp[coutI]));


                }
            }


        }
    }
    public void Check(SetAnswerBt setAnswerBt)
    {
        if (setAnswerBt.tag == "RightAs")
        {
            Audios.Instance.Right();
            timePlay = maxTime;
            UI.instance.SetTimeTx("00 : "+timePlay);
            RighCount++;

            if (RighCount == QuestionManager.instance.ArrayQuestionData.Length)
            {
                if (UI.instance.dialogs)
                {
                    Audios.Instance.Win();
                    UI.instance.dialogs.ShowDialog(true);
                    UI.instance.dialogs.SetDialog("Bạn đã thắng");
                    StopAllCoroutines();
                 
                }

            }
            else
            {
                CreateQuestion();
            }
        }
        else
        {
            Audios.Instance.Loss();
            if (UI.instance.dialogs)
            {
                UI.instance.dialogs.ShowDialog(true);
                UI.instance.dialogs.SetDialog("Bạn đã thua");
                StopAllCoroutines();

            }
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }  
    public void Quit()
    {
        Application.Quit();
    }
    // sau o.2f thì tạo bạn sao
    IEnumerator ResetTime()
    {

        yield return new WaitForSeconds(1);
       
        if (timePlay <= 0)
        {
            Audios.Instance.Loss();
            UI.instance.dialogs.ShowDialog(true);
            UI.instance.dialogs.SetDialog("Đã hết thời gian,bạn đã thua");
            StopAllCoroutines();
        }    
        else
        {
            timePlay--;
            UI.instance.SetTimeTx("00 : "+timePlay);
            StartCoroutine(ResetTime());
        }    
        

    }
   
}
