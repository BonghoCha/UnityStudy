using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public Monster monster;
    public Monster _tempMonster;
    public GameObject goUICanvas;

    static MonsterManager instance = null;

    Vector3 positionDiff = new Vector3(100, 0, 0);
    int createCount = 0;
    int MAX_COUNT = 6;

    [SerializeField] Sprite[] DiceSprites;
    public static MonsterManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("MonsterManager");
            instance = go.AddComponent<MonsterManager>();
            DontDestroyOnLoad(go);
        }

        return instance;
    }

    private void Awake()
    {
        // �̱����� �ϳ� �̻� �����Ѵٸ�
        if (FindObjectsOfType<MonsterManager>().Length > 1) Destroy(gameObject);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CreateMonster(int _hp)
    {
        // Ư�� ���� �̻� �������� �ʵ��� ����
        if (createCount == MAX_COUNT) return;

        // ���� ����
        Monster m = Instantiate<Monster>(_tempMonster);
        m.transform.SetParent(goUICanvas.transform);
        m.gameObject.SetActive(true);

        // ���� �����ϱ� ���� �߰�
        m.transform.localPosition = Vector3.zero + (positionDiff * createCount);
        m.GetComponent<Image>().sprite = DiceSprites[createCount++];

        monster = m;
        m.SetMonster(10);
    }
}
