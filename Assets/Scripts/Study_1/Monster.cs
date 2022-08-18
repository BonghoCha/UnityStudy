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
        // ������
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
        // ü�°� �ִ� ü�� ����
        hp = maxhp = _hp;
    }

    public void Die()
    {
        // ���ο� ���� ����
        MonsterManager.GetInstance().CreateMonster(maxhp * 2);

        // ���� �ı�
        Destroy(gameObject);
    }
}
