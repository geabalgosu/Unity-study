using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Null : MonoBehaviour
{
    [SerializeField]        //���⼭ �������־ʾƵ� ������ ���
    Monster monster;
    private void Start()
    {
        //Monster�� ��ũ��Ʈ�� ����ϱ����� getcomponent
        //�̰��ϸ� ����Ƽ���� Monster��ũ��Ʈ�� �� ��ũ��Ʈ�� �ִ� ������Ʈ�� �־���Ѵ� �׷��������� ����
        //���� : ������Ʈ�� ã�� �� ���� �����ε�
        monster = GetComponent<Monster>();     
    }
}
