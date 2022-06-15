using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// kit 2A반 창의설계4조 김태현,신동엽,이상협,이준영
public class PlayerController : MonoBehaviour { 
    private Rigidbody playerRigidbody;  //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;  //이동 속력
    public GameObject HamburgerText;
    public GameObject ChickenText;
    public GameObject PizzaText;
    public GameObject MakiText;
    public GameObject SushiText;
    public GameObject RamenText;
    public GameObject RiceText;
    private Animator animator;
    public GameObject avata;
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 리지드바디 컴포넌트를 찾아 플레이어리지드바디에 할당
        playerRigidbody = GetComponent<Rigidbody>();
        animator = avata.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0 ,zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
        if (zInput != 0.0f)
        {
            animator.SetBool("Run", true);
        }
        if (zInput == 0.0f)
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Start");
        }
    }
    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
        //씬에 존재하는 게임매니저 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 게임매니저 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
     }
    void OnTriggerEnter(Collider other)
    {
        //햄버거 태그를 가진 오브젝트와 충돌시 햄버거텍스트 활성화
        if (other.tag == "Hamburger")
        {
            HamburgerText.SetActive(true);
        }
        //치킨 태그를 가진 오브젝트와 충돌시 치킨텍스트 활성화
        if (other.tag == "Chicken")
        {
            ChickenText.SetActive(true);
        }
        //피자 태그를 가진 오브젝트와 충돌시 피자텍스트 활성화
        if (other.tag == "Pizza")
        {
            PizzaText.SetActive(true);
        }
        //김밥 태그를 가진 오브젝트와 충돌시 김밥텍스트 활성화
        if (other.tag == "Maki")
        {
            MakiText.SetActive(true);
        }
        if (other.tag == "Sushi")
        {
            SushiText.SetActive(true);
        }
        if (other.tag == "Ramen")
        {
            RamenText.SetActive(true);
        }
        if (other.tag == "Rice")
        {
            RiceText.SetActive(true);
        }
    }



}
