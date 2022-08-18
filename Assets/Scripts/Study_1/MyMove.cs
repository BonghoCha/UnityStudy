using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{ 
    public void MyClickSimple()
    {
        // ���� Ŭ��

        // duration ���� Y��ŭ �̵�
        transform.DOMoveY(500.0f, 2.0f);

        // duration ���� ����(Position ����)
        // ���� ����� DoMoveY�� ���ļ� �갡 ����
        transform.DOShakePosition(5.0f); 

        // duration ���� ����(Scale)
        transform.DOShakeScale(5.0f);
    }

    public void MyClickDoMove(){
        // DoTween ������

        // getter:transform.localPosition, setter:transform.localPosition, targetPosition, duraiton
        DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.zero, 2.0f).SetEase(Ease.InSine);
    }

    public void MyClickSequenceDoMove()
    {
        // DoTween ������(����) ������

        // Append(Tween)       : ������ ������ Tween �߰�
        // Insert(time, Tween) : ���� tiem ���� Tween ����
        // Join(Tween)         : �տ� �߰��� Tween�� ���ÿ� ����
        // Prepend(Tween)      : �� ó���� Tween �߰�

        // �ó����� (0,0) -> (0, 250) -> (-500, 0)

        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.zero, 0.5f).SetEase(Ease.InOutSine));
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.up * 250f, 1f).SetEase(Ease.OutSine));
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.left * 500f, 0.5f).SetEase(Ease.Flash));
        
        // �ݹ� �߰�
        sequence.OnComplete(() => MyCallback(1, 2));

        // ������ ����
        DOTween.Play(sequence);
    }

    public void MyCallback(int a, int b)
    {
        // �ݹ�
        Debug.Log("Finished ! " + (a + b));
    }
}
