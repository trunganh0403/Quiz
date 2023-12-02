using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAnswerBt : MonoBehaviour
{
    public Text AnswerTx;
    public Button AnswerButon;

    public void SetAnswerText (string tx)
    {
      
        if (AnswerTx != null)
        {
            
            AnswerTx.text = tx;
        }
    }    
}
