using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    public Text timeTx;
    public Text questionTx;
    public SetAnswerBt[] setAnswersBt;
    public Dialogs dialogs;
    private void Awake()
    {
        Ins();
       

    }
    //private void Start()
    //{
    //    MixAnswer();
    //}
    public void SetTimeTx(string timex)
    {
        if (timeTx != null)
        {
            timeTx.text = timex;
        }
    }
    public void SetQuestionTx(string timex)
    {
        if (timeTx != null)
        {
            questionTx.text = timex;
        }
    }
    void Ins()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void MixAnswer()//gán tag
    {
        if (setAnswersBt != null && setAnswersBt.Length >0)
        {
            for (int i = 0; i < setAnswersBt.Length; i++)
            {
                if (setAnswersBt[i])
                {
                    setAnswersBt[i].tag="Untagged";
                }    
               

            }
            int randomAs = Random.Range(0, setAnswersBt.Length);

            if (setAnswersBt[randomAs])
            {

                setAnswersBt[randomAs].tag="RightAs";


            }
        }
        
    }
}
