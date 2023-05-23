using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelOnClick : MonoBehaviour
{
    public GameObject ModelToChange;
    private MeshRenderer meshRenderer;

    private int min;              //�Ω�]�w�˼ƭp�ɪ�����
    private int sec;              //�Ω�]�w�˼ƭp�ɪ����
    public int timer;            //�˼ƭp�ɸg���⪺�`���
    private float TempNumber;             //�ū�

    public Text timertext;         //�]�w�e���˼ƭp�ɪ���r
    public Text nametoshow;



    void Start()
    {
        meshRenderer = ModelToChange.GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        CityTemp TempScript = GetComponent<CityTemp>();
        TempNumber = TempScript.CountyTemp;
    }

    private void OnMouseDown()
    {
        Debug.Log("Click!");
        sec = 2;
        StartCoroutine(StartCountdown());
    }


    IEnumerator StartCountdown()
    {
        meshRenderer.material.color = Color.red;

        timertext.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        nametoshow.text = string.Format("{0}�{�b�ū�:{1}", ModelToChange.name.ToString(), TempNumber.ToString("00.0"));


        timer = (min * 60) + sec;       //�N�ɶ����⬰���

        while (timer > 0)                   //�p�G�ɶ��|������
        {
            yield return new WaitForSecondsRealtime(1); //���Ԥ@��A������

            timer--;                        //�`��ƴ� 1
            sec--;                            //�N��ƴ� 1

            if (sec < 0 && min > 0)         //�p�G��Ƭ� 0 �B�����j�� 0
            {
                min --;                     //���N������h 1
                sec = 59;                     //�A�N��Ƴ]�� 59
            }
            else if (sec < 0 && min == 0)   //�p�G��Ƭ� 0 �B�����j�� 0
            {
                sec = 0;                      //�]�w��Ƶ��� 0
            }
            timertext.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        }

        yield return new WaitForSecondsRealtime(1);   //�ɶ������ɡA��� 00:00 ���d�@��

        nametoshow.text = string.Empty;
        meshRenderer.material.color = Color.yellow;
        sec = 2;
    }
}