using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story : MonoBehaviour
{
    [Header("UI组件")]
    public List<Text> textLabel = new List<Text>();
    //public Image faceImage;
    
    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public bool textFinished;
    public bool cancelTyping;
   

    List<string> textList = new List<string>();
    void Start()
    {
       
        index = 0;
       
    }
   private void OnEnable() 
   {
       
       GetTxtFromFile(textFile);
        textFinished = true;
        cancelTyping = false;
    }

    // Update is called once per frame
  
        
    
    void Update()
    { 
        
        if(Input.GetMouseButtonDown(0) && index == textList.Count)
        {
            for (int i = 0; i < textLabel.Count ; i++)
            {
                textLabel[i].text = "";
            }
            End();
            textList.Clear();
            textFile = null;
            gameObject.SetActive(false);//结束Diolog画面
        }
        
        if (Input.GetMouseButtonDown(0)){
            if(textFinished && !cancelTyping){
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping){
                cancelTyping = true;
            }
        }
    }
    public void End()
    {
        for (int i = 0; i < textLabel.Count ; i++)
            {
                textLabel[i].text = "";
            }
        textList.Clear();
        textFile = null;
            index = 0;
            gameObject.SetActive(false);//结束Diolog画面
    }
        void GetTxtFromFile(TextAsset file){
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
        
    }

    IEnumerator SetTextUI(){
        textFinished = false;
        switch (textList[index])
        {
            case "A\r":
                 //faceImage.sprite = face01;
                 index++;
                 break;
             }

         int letter = 0;
         while (!cancelTyping && letter < textList[index].Length - 1){
             textLabel[index].text += textList[index][letter];
             letter++;
             yield return new WaitForSeconds(0.1f);
         }
         textLabel[index].text = textList[index];
         cancelTyping = false;
         textFinished = true;
         index++;
    }
} 
