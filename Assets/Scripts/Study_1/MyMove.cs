using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{ 
    public void MyClickSimple()
    {
        // 심플 클릭

        // duration 동안 Y만큼 이동
        transform.DOMoveY(500.0f, 2.0f);

        // duration 동안 진동(Position 기준)
        // 먼저 실행된 DoMoveY랑 겹쳐서 얘가 실행
        transform.DOShakePosition(5.0f); 

        // duration 동안 진동(Scale)
        transform.DOShakeScale(5.0f);
    }

    public void MyClickDoMove(){
        // DoTween 움직임

        // getter:transform.localPosition, setter:transform.localPosition, targetPosition, duraiton
        DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.zero, 2.0f).SetEase(Ease.InSine);
    }

    public void MyClickSequenceDoMove()
    {
        // DoTween 시퀀스(연속) 움직임

        // Append(Tween)       : 마지막 순서에 Tween 추가
        // Insert(time, Tween) : 일정 tiem 에서 Tween 시작
        // Join(Tween)         : 앞에 추가된 Tween과 동시에 시작
        // Prepend(Tween)      : 맨 처음에 Tween 추가

        // 시나리오 (0,0) -> (0, 250) -> (-500, 0)

        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.zero, 0.5f).SetEase(Ease.InOutSine));
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.up * 250f, 1f).SetEase(Ease.OutSine));
        sequence.Append(DOTween.To(() => transform.localPosition, p => transform.localPosition = p, Vector3.left * 500f, 0.5f).SetEase(Ease.Flash));
        
        // 콜백 추가
        sequence.OnComplete(() => MyCallback(1, 2));

        // 시퀀스 시작
        DOTween.Play(sequence);
    }

    public void MyCallback(int a, int b)
    {
        // 콜백
        Debug.Log("Finished ! " + (a + b));
    }
}
