using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    public MonsterManager mm;
    
    public void TestCreateMonster()
    {
        // ���� ������ ������Ʈ�� �����ؼ� �Լ� ����
        mm.CreateMonster(10);

        // �̱������� ������ �ν��Ͻ��� �����ؼ� �Լ� ����
        MonsterManager.GetInstance().CreateMonster(10);
    }
}
