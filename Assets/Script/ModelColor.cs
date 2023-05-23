using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelColor : MonoBehaviour
{
    
    public Color color1 = new Color(0f, 0f, 1f, 1f); // �]�m�Ĥ@���C��
    public Color color2 = new Color(1f, 0f, 0f, 1f); // �]�m�ĤG���C��

    private Renderer _renderer; // ��V��

    public float tempmin = 20f; // �̤p��
    public float tempmax = 32f; // �̤j��



    void Start()
    {
        _renderer = GetComponent<Renderer>();

    }
    private void Update()
    {
        CityTemp TempScript = GetComponent<CityTemp>();
        float myVariableValue = TempScript.CountyTemp;
        float t = Mathf.InverseLerp(tempmin, tempmax, myVariableValue); // �p���ܼƭȦb�̤p�ȩM�̤j�Ȥ��������
        Color color = Color.Lerp(color1, color2, t); // �ھڤ�Ҧb�Ŧ�M���⤧�����ȭp���C��
        _renderer.material.color = color;

    }
}

