using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    public MonsterManager mm;
    
    public void TestCreateMonster()
    {
        // 직접 참조한 컴포넌트에 접근해서 함수 실행
        mm.CreateMonster(10);

        // 싱글톤으로 생성한 인스턴스에 접근해서 함수 실행
        MonsterManager.GetInstance().CreateMonster(10);
    }
}
