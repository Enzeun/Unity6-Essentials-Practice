# 목적
- 예제를 직접 구현하며 Unity의 기본 기능을 익힌다.
- 책의 예제를 최신 Unity 6 방식으로 개선한다.
- 변경한 이유와 배운 점을 기록한다.
---
# 변경 사항

## Input System 적용
### Before
    - Legacy Input Manager 사용
### After
    - Unity Input System 기반으로 변경
### 변경 이유
- Unity 최신 표준 입력 방식 적용
- 키보드 외 Gamepad 등 다양한 입력 장치 확장 가능
- 입력 처리와 물리 처리를 분리하여 안정적인 Rigidbody 제어 구조 확보
### 배운 점
- 입력은 프레임마다 한 번만 읽는다.
- 힘을 가하는 물리 연산(`AddForce`)은 물리 프레임에 맞춰 실행되는 `FixedUpdate`에서 처리하여 프레임 드랍 시 입력이 누락되는 현상을 방지한다.
- Update에서 AddForce를 호출하면 프레임에 따라 물리 결과가 달라질 수 있다.
- 입력과 물리 연산은 서로 다른 생명주기를 가진다는 것을 이해했다.
---

## 변수 캡슐화
### Before
    - public 필드 사용
### After
    - private 로 변경
## 변경 이유
- 외부 접근이 필요 없는 데이터는 private으로 제한
- Inspector 연결은 유지하면서 캡슐화 적용
- 불필요한 public 노출 방지

---
## Object Pooling
### Before
    - Instantiate() -> Destroy() 사용
### After
    - Object Pooling 사용
## 변경 이유
- 총알은 짧은 시간 동안 반복적으로 생성·삭제되는 오브젝트이다.
- Instantiate/Destroy를 반복하면 메모리 할당과 해제가 지속적으로 발생한다.
- 이 과정은 Garbage Collection을 유발하여 프레임 드랍의 원인이 될 수 있다.
- 따라서 ObjectPool을 적용하여 이미 생성된 객체를 재사용하도록 개선하였다.
