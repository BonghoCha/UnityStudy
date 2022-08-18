using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxhp;
    public int hp;
    public Progressbar progressbar;

    public void Damage(int d)
    {
        // 데미지
        hp -= d;

        if (hp <= 0)
        {
            progressbar.SetBarValue(0);
            Die();
        } else
        {
            progressbar.SetBarValue((float)hp / maxhp);
        }
    }

    public void SetMonster(int _hp)
    {
        // 체력과 최대 체력 셋팅
        hp = maxhp = _hp;
    }

    public void Die()
    {
        // 새로운 몬스터 생성
        MonsterManager.GetInstance().CreateMonster(maxhp * 2);

        // 몬스터 파괴
        Destroy(gameObject);
    }
}
