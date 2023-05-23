using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class HuvVfxController : MonoBehaviour
{
    CWBWebRequest _CWBWebRequest;
    public float values;//�ݧ令��x����huv data

    [SerializeField]
    private VisualEffect visualEffect;
    [SerializeField]
    private Gradient[] gradients;

    void Update()
    {
        if (visualEffect != null)
        {
            values = _CWBWebRequest.huvValue;
            
            switch (values)
            {
                case > 90: //���~�u���� 90+
                    visualEffect.SetGradient("Color", gradients[0]);
                    break;
                case > 80 and <= 90: //���~�u����80~90
                    visualEffect.SetGradient("Color", gradients[1]);
                    break;
                case > 70 and <= 80:
                    visualEffect.SetGradient("Color", gradients[2]);
                    break;
                case > 60 and <= 70:
                    visualEffect.SetGradient("Color", gradients[3]);
                    break;
                case > 50 and <= 60:
                    visualEffect.SetGradient("Color", gradients[4]);
                    break;
                case > 40 and <= 50:
                    visualEffect.SetGradient("Color", gradients[5]);
                    break;
                case > 30 and <= 40:
                    visualEffect.SetGradient("Color", gradients[6]);
                    break;
                case > 20 and <= 30:
                    visualEffect.SetGradient("Color", gradients[7]);
                    break;
                case > 10 and <= 20:
                    visualEffect.SetGradient("Color", gradients[8]);
                    break;
                case > 0 and <= 10:
                    visualEffect.SetGradient("Color", gradients[9]);
                    break;
                default: //�w�]OR��L���~�u
                    visualEffect.SetGradient("Color", gradients[10]);
                    break;
            }
        }
    }
}