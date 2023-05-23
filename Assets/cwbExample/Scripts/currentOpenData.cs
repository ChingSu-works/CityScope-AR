using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using TMPro;

/*
public class currentOpenData : MonoBehaviour
{
    public CWBOpenDataManager _CWBOpenDataManager;

    string catalog = "";
    string stationId = "";
    public string elementName = "";

    [Header("2D ICON")]
    public Sprite[] temp;
    public Sprite[] weather;
    public Sprite d_tx, d_tn, rain, h_uvi, humd;


    [Header("3D objects")]
    public GameObject[] uvObjs;
    public void init()
    {
        catalog = "O-A0003-001";
        stationId = "466920";
        elementName = "TEMP";
    }

    public string setCatalog()
    {
        return catalog;
    }
    public string setStationId(int index)
    {
        switch (index)
        {
            case 0://�x�_
                stationId = "466920";
                break;
            case 1://�s�_
                stationId = "466881";
                break;
            case 2://���
                stationId = "467050";
                break;
            case 3://�x��
                stationId = "467490";
                break;
            case 4://�x�n
                stationId = "467410";
                break;
            case 5://����
                stationId = "467440";
                break;
            default:
                stationId = null;
                break;
        }
        return stationId;
    }
    public void setElementName(string element)
    {
        elementName = element;
    }
    
    public void jsonConvert(int index, string text)
    {
        jsonObj data = JsonUtility.FromJson<jsonObj>(text);
        enabledWeatherDetails(_CWBOpenDataManager.cityRawImg[index].GetComponent<RawImage>(), elementName, data);
    }
    void enabledWeatherDetails(RawImage rawimg,string element, jsonObj data)
    {
        var location = data.records.location[0].parameter[0].parameterValue;
        var obstime = data.records.location[0].time.obsTime;
        var value = data.records.location[0].weatherElement[0].elementValue;

        switch (element)
        {
            case "TEMP"://�ūסA��� ���
                //TEXTURE//
                if (float.Parse(value) >= 15 && float.Parse(value) <= 20)
                {
                    rawimg.texture = temp[0].texture;
                }
                else if (float.Parse(value) > 20 && float.Parse(value) <= 25)
                {
                    rawimg.texture = temp[1].texture;
                }
                else if (float.Parse(value) > 25)
                {
                    rawimg.texture = temp[2].texture;
                }
                else if (float.Parse(value) < 15)
                {
                    rawimg.texture = temp[3].texture;
                }
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "�ثe���ū�:" + value;
                break;
            case "D_TX"://����̰��šA��� ���
                //TEXTURE//
                rawimg.texture = d_tx.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "����̰���:" + value;
                break;
            case "D_TN"://����̧C�šA��� ���
                //TEXTURE//
                rawimg.texture = d_tn.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "����̧C��:" + value;
                break;
            case "Weather"://�Q�����Ѯ�{�H�y�z
                //TEXTURE//
                switch (value)
                {
                    case "��":
                        rawimg.texture = weather[0].texture;
                        break;
                    case "��":
                        rawimg.texture = weather[1].texture;
                        break;
                    case "�h��":
                        rawimg.texture = weather[2].texture;
                        break;
                    case "�u�ȫB":
                        rawimg.texture = weather[3].texture;
                        break;
                    default:
                        Debug.Log("situation etc. :" + data);
                        break;
                }
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "�ثe�Ѯ𪬪p:" + value;
                break;
            case "24R"://��ֿn�B�q�A��� �@��
                //TEXTURE//
                rawimg.texture = rain.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "����ֿn�B�q:" + value;
                break;
            case "H_UVI"://�p�ɵ��~�u����
                Debug.Log("H_UVI:" + float.Parse(value));
                for(int i = 0;i< uvObjs.Length;i++)
                {
                    uvObjs[i].SetActive(false);
                }
                Instantiate(uvObjs[Mathf.RoundToInt(float.Parse(value))], this.transform.position, this.transform.rotation);
                //TEXTURE//
                rawimg.texture = h_uvi.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "�p�ɵ��~�u����:" + value;
                break;
            case "HUMD"://�۹���סA��� �ʤ���v�A���B�H��� 0-1.0 �O��
                //TEXTURE//
                rawimg.texture = humd.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "�[���a�I:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "�[���ɶ�:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "�۹�ë�:" + value;
                break;
        }
    }
}
*/