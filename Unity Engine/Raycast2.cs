using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycst2 : MonoBehaviour
{
    

    
    void Start()
    {
        
    }

    
    void Update()
    {

        //Debug.Log(Input.mousePosition);  //���콺�� ��ǥ(2d)�� ��ũ���� ��ġ���� �ٸ��� ��ǥ�� ���
        
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  //��ũ���� �ִ� ���콺�� ��ġ�� ���� ������ ���

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);  //�Ʒ��� �ּ����� ���� �̰ɷ� ��ü����

            Debug.DrawRay(Camera.main.transform.position,ray.direction,Color.red,1.0f);

            int mask = (1 << 8);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100.0f,mask))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
            
                                        
        }
    }
}
