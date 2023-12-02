using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class QuestionManager : MonoBehaviour
{
    public QuestionData[] ArrayQuestionData;
    public static QuestionManager instance;
    public List<QuestionData> listQuestionData;
  
    public QuestionData questionData;
    public QuestionData QuestionData { get => questionData; set => questionData=value; }

    private void Awake()
    {

        Ins();
        listQuestionData = ArrayQuestionData.ToList();
        
    }
    private void Start()
    {
      
    }
    private void Update()
    {
       
    }

    public QuestionData RandomQuestion()// random câu hỏi 
    {

        if (listQuestionData!= null  && listQuestionData.Count >0)
        {
            int randomInt = Random.Range(0, listQuestionData.Count);
            questionData = listQuestionData[randomInt];
            listQuestionData.RemoveAt(randomInt);


        }

        return questionData;
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
}
