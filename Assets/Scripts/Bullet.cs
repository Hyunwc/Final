using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kit 2A반 창의설계4조 김태현,신동엽,이상협,이준영
public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;  //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;  //탄알 이동 속력
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 리지드바디 컴포넌트를 찾아 불렛리지드바디에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)//트리거 충돌 시 자동으로 실행되는 메서드  
    {
       //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
       if(other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 플레이어컨트롤러 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            //상대방으로부터 플레이어컨트롤러 컴포넌트를 가져오는 데 성공했다면
            if(playerController != null)
            {
                //상대방 플레이어컨트롤러 컴포넌트의 다이() 메서드 실행
                playerController.Die();
            }
        }
    }
}
