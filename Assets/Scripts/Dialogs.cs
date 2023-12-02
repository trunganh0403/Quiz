using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    public Text dialogTx;
    
    public void ShowDialog(bool isShow)
    {
        gameObject.SetActive(isShow);
        
    }  
    public void SetDialog (string tx)
    {
        if (dialogTx != null)
        {
            dialogTx.text = tx;
        }
        
    }
   
}
