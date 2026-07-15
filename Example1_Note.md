# 목적
- 예제를 직접 구현하며 Unity의 기본 기능을 익힌다.
- 책의 예제를 최신 Unity 6 방식으로 개선한다.
- 변경한 이유와 배운 점을 기록한다.
---
# 변경 사항

## Input
- 책에서는 Legacy 기능인 `Input Manager`를 사용한다.
- Unity 6에서는 `Input System`이 표준이므로 `Input System`으로 변경하였다.

### Before
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rb.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb.AddForce(-speed, 0f, 0f);
        }
    }
### After
    private Vector2 movedir;
    
    private void FixedUpdate()
    {
        rb.AddForce(movedir * speed);
    }
    void Update()
    {      
        movedir = InputSystem.actions["Move"].ReadValue<Vector2>();
    }

## 변경 이유
- Unity에서 권장하는 최신 입력 시스템이다.
- 런타임 `Key Rebinding`을 지원한다.
- 멀티플레이 및 다양한 입력 장치 확장에 유리하다.
- `addForce` 는 물리연산이므로 일정한 물리 Frame 에서 실행하기 위해 `FixedUpdate` 로 변경 
- `Player`가 직접 입력을 읽기보다 `InputManager`를 통해 전달받는 구조가 유지보수에 유리하다.
- **입력 감지와 물리 연산의 분리:** 
  - `FixedUpdate`는 `Update`보다 느린 주기로 돌기 때문에, `FixedUpdate` 안에서 직접 입력을 읽으면 키 입력이 누락되는 '입력 씹힘' 현상이 발생할 수 있다.
  - 따라서 입력 감지(ReadValue)는 누락이 없는 `Update`에서 처리하여 변수에 저장하고, 실제 힘을 가하는 물리 연산(AddForce)만 `FixedUpdate`에서 해당 변수를 참조하여 실행하는 것이 물리 기반 캐릭터 이동의 정석 패턴임을 배웠다.

---

## 변수 캡슐화
- 책에서는 `public` 생성자를 사용한다.
- 외부에서 접근할 필요가 없는 변수는 `private` 로 캡슐화를 한다

### Before

    public Rigidbody rb;

### After

    [SerializeField]
    private Rigidbody rb;

## 변경이유

- 캡슐화 유지
- 외부에서 직접 접근할 필요가 없는 참조이므로 `public`으로 노출할 이유가 없음.
- Unity Inspector 사용 가능
