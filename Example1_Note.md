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
- 입력(ReadValue)은 Update에서 처리
- 물리 연산(AddForce)은 FixedUpdate에서 처리

---

## 변수 캡슐화
### Before
    - 생성자 public 사용
### After
    - 생성자 private 으로 변경
## 변경 이유
- 외부 접근이 필요 없는 데이터는 private으로 제한
- Inspector 연결은 유지하면서 캡슐화 적용
- 불필요한 public 노출 방지

---
## Object Pooling
### Before
    - Initiate() -> Destrot() 사용
### After
    - object pooling 기법 사용
## 변경 이유
- destroy 는 연산이 무거우므로 대량으로 생성/파괴 할 때는 object pooling 사용
