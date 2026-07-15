# 목적
- 예제를 직접 구현하며 Unity의 기본 기능을 익힌다.
- 책의 예제를 최신 Unity 6 방식으로 개선한다.
- 변경한 이유와 배운 점을 기록한다.

# 변경 사항

## Input
- 책에서는 Legacy Input Manager를 사용한다.
- Unity 6에서는 Input System이 표준이므로 Input System으로 변경하였다.

### Before
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
### After
        Vector2 movedir;

        movedir = InputSystem.actions["Move"].ReadValue<Vector2>();

        rb.AddForce(movedir * speed * Time.deltaTime);

## 변경 이유
- Unity에서 권장하는 최신 입력 시스템이다.
- 런타임 Key Rebinding을 지원한다.
- 멀티플레이 및 다양한 입력 장치 확장에 유리하다.

## 배운 점
- Input Action 기반으로 입력을 처리한다.
- Player가 직접 입력을 읽기보다 InputManager를 통해 전달받는 구조가 유지보수에 유리하다.


## 캡슐화

### Before

public Rigidbody rb;

### After

[SerializeField]
private Rigidbody rb;

이유

- 캡슐화 유지
- 외부에서 직접 접근할 필요가 없는 참조이므로 public으로 노출할 이유가 없음.
- Unity Inspector 사용 가능

