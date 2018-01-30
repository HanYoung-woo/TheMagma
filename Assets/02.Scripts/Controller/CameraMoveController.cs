using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CameraMoveController : MonoBehaviour {

    Vector2 InputPos;
    public GameObject MyPlayer;
    float reach = 3.0f;
    float minAngley;
    float maxAngley;
    int cameraMove;
    GameObject Save;
    private void Start()
    {
        cameraMove = -1;
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(i) == false)
                {
                    cameraMove = i;
                    InputPos = Input.GetTouch(i).position;
                }
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved && i == cameraMove)
            {
                Vector2 Movepos = InputPos - Input.GetTouch(i).position;
                InputPos = Input.GetTouch(i).position;
                Movepos = Movepos / 6.0f;
                Vector3 angles = transform.eulerAngles;
                angles.x += Movepos.y;
                angles.y -= Movepos.x;

                if (angles.x > 180.0f) angles.x -= 360.0f;
                angles.x = Mathf.Clamp(angles.x, -10.0f, 60.0f);

                transform.eulerAngles = new Vector3(angles.x, angles.y, transform.eulerAngles.z);
            }
            else if(Input.GetTouch(i).phase == TouchPhase.Ended && i == cameraMove)
            {
                cameraMove = -1;
            }
            else if(Input.GetTouch(i).phase == TouchPhase.Ended &&  i < cameraMove)
            {
                cameraMove -= 1;
            }
        }
        //카메라의 Position값 변경
        Vector3 euler3 = transform.eulerAngles;

        euler3.y += 90.0f;

        float cos = Mathf.Cos(-euler3.y * Mathf.PI / 180) * reach;
        float sin = Mathf.Sin(-euler3.y * Mathf.PI / 180) * reach;

        transform.position = new Vector3(MyPlayer.transform.position.x + cos,
                                        1, MyPlayer.transform.position.z + sin);

        float cos2 = Mathf.Cos(euler3.x * Mathf.PI / 180) * reach;
        float sin2 = Mathf.Sin(euler3.x * Mathf.PI / 180) * reach;

        Vector3 temp = (MyPlayer.transform.position - transform.position).normalized;

        transform.position = new Vector3(MyPlayer.transform.position.x - (temp.x * cos2),
                                        MyPlayer.transform.position.y + sin2 + 1,
                                        MyPlayer.transform.position.z - (temp.z * cos2));
        
    }
}
