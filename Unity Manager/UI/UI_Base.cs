using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _lists = new Dictionary<Type, UnityEngine.Object[]>();
    protected void Choice<T>(Type type) where T : UnityEngine.Object          //type�� enum�� �޴´�
    {
        string[] lists = Enum.GetNames(type);       //string�迭�� ��ȯ
        UnityEngine.Object[] objects = new UnityEngine.Object[lists.Length];  //enum List�� ���̸�ŭ ������Ʈ�� value�� �־��ش�
        _lists.Add(typeof(T), objects);
        for (int i = 0; i < lists.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))                              //Object�� typeof(T)�� enum�� type�̴�
                objects[i] = Util.FindChild(gameObject, lists[i], true);      //enum�� ���ʴ�� �迭�� ����,Util�� FIndCild�� �Ѵ�
            else
                objects[i] = Util.FindChild<T>(gameObject, lists[i], true);
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_lists.TryGetValue(typeof(T), out objects) == false)              //Get���� TryGetValue�� �Ҷ� �����ϸ� null�� return
            return null;

        return objects[index] as T;
    }
    protected TextMeshProUGUI GetText(int index)
    {
        return Get<TextMeshProUGUI>(index);
    }
    protected Image GetImage(int index)
    {
        return Get<Image>(index);
    }
    public static void AddUIEvent(GameObject go, Action<PointerEventData> action,Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Event evt = Util.GetOrAddComponent<UI_Event>(go);
        if (evt == null)
        {
            go.AddComponent<UI_Event>();
        }
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
        }
    }
}
