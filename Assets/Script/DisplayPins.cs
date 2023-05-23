using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayPins : MonoBehaviour
{
    //�����s��
    public int CountyNumber; 

    //��ܼҫ�
    public GameObject Pin;
    public GameObject RainyNight;
    public GameObject RainyDay;
    public GameObject CloudyDay;
    public GameObject CloudyNight;
    public GameObject SunnyDay;
    public GameObject SunnyNight;

    public GameObject DataObject;

    public int WeatherNum;


    void Start()
    {
        Pin.SetActive(true);
        RainyNight.SetActive(false);
        RainyDay.SetActive(false);
        CloudyDay.SetActive(false);
        CloudyNight.SetActive(false);
        SunnyDay.SetActive(false);
        SunnyNight.SetActive(false);
    }



    void Update()
    {
        
    }

    public void ShowWeather() //�H�U���ھڤ@��csv�ɮפ��������ܤѮ�ҫ�
    {
        ReadCsv readCsvScript = DataObject.GetComponent<ReadCsv>();

        WeatherNum = int.Parse(readCsvScript.CountyList[CountyNumber]); 
        
        Pin.SetActive(false);

        DateTime now = DateTime.Now;
        DateTime start = DateTime.Today.AddHours(6);
        DateTime end = DateTime.Today.AddHours(18);

        // �P�_��e�ɶ��O�_�b6�I��18�I����
        if (now >= start && now <= end)
        {
            if (WeatherNum == 1 || WeatherNum == 2)
            {
                SunnyDay.SetActive(true);
            }
            else if (WeatherNum >= 3 && WeatherNum <= 7)
            {
                CloudyDay.SetActive(true);
            }
            else
            {
                RainyDay.SetActive(true);
            }

        }
        else
        {
            if (WeatherNum == 1 || WeatherNum == 2)
            {
                SunnyNight.SetActive(true);
            }
            else if (WeatherNum >= 3 && WeatherNum <= 7)
            {
                CloudyNight.SetActive(true);
            }
            else
            {
                RainyNight.SetActive(true);
            }

        }
                
    }


    public void BackDefault()
    {
        Pin.SetActive(true);
        RainyNight.SetActive(false);
        RainyDay.SetActive(false);
        CloudyDay.SetActive(false);
        CloudyNight.SetActive(false);
        SunnyDay.SetActive(false);
        SunnyNight.SetActive(false);
    }


}
