using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyRebind : Singleton<KeyRebind>
{
    public KeyCode leftKey, rightKey, upKey, downKey, attackKey;
    private KeyCode tempk;
    //public List<KeyCode> keys = new List<KeyCode>();

    public TextMeshProUGUI leftText, rightText, upText, downText, attackText;
   

    private void Start()
    {
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
        upKey = KeyCode.W;
        downKey = KeyCode.S;
        attackKey = KeyCode.Space;


        leftText.text = leftKey.ToString();
        rightText.text = rightKey.ToString();
        upText.text = upKey.ToString();
        downText.text = downKey.ToString();
        attackText.text = attackKey.ToString();


    }
    public void RebindKeys()
    {
        //Debug.Log("Waiting for input " + attackKey);
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            //Debug.Log (kcode);
            if (Input.GetKey(kcode))
            {
                Debug.Log("KeyCode down: " + kcode);
                //attackKey = kcode;
            }

        }
    }

    public void RebindKey(KeyCode key, TextMeshProUGUI text)
    {
        
        StartCoroutine(WaitForKey(key, text));
        
        

        //Debug.Log("Key pressed!" + key + " Woah");

    }
    public void RebindLeft()
    {
        
        RebindKey(leftKey, leftText);
        leftKey = tempk;


    }
    public void RebindRight()
    {
        RebindKey(rightKey, rightText);
        rightKey = tempk;
    }
    public void RebindUp()
    {
        RebindKey(upKey, upText);
        upKey = tempk;
    }
    public void RebindDown()
    {
        RebindKey(downKey, downText);
        downKey = tempk;
    }
    public void RebindAttack()
    {
        RebindKey(attackKey, attackText);
        attackKey = tempk;
    }


    private IEnumerator WaitForKey(KeyCode mapKey, TextMeshProUGUI text)
    {
        Debug.Log("Waiting for the Space key to be pressed...");

        // Wait until the Space key is pressed down
        yield return new WaitUntil(() => Input.anyKeyDown);
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            //Debug.Log (kcode);
            if (Input.GetKey(kcode))
            {
                Debug.Log("KeyCode down: " + kcode);
                mapKey = kcode;
                tempk = mapKey;
                text.text = mapKey.ToString();
                
            }
            

        }


    }
}
