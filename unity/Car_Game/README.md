# Car_Game — 마우스 입력과 거리 표시

마우스를 누른 위치와 뗀 위치의 차이를 자동차 이동량으로 바꾸는 실습입니다.

- [CarController.cs](Assets/Scripts/CarController.cs): 입력 위치 차이와 이동량 감쇠
- [GameDirector.cs](Assets/Scripts/GameDirector.cs): 자동차와 깃발의 X 좌표 차이를 TextMeshPro로 표시
- 장면: [Game_Scene.unity](Assets/Game_Scene.unity)

`car`, `flag`, `Distance` 오브젝트와 TextMeshProUGUI 연결이 필요합니다.
거리 계산이 음수가 되면 Game Over 문구를 표시합니다. 이동 정지 상태는 별도 개선 과제입니다.

다음 학습: `Time.deltaTime` 적용, 컴포넌트 참조 저장, Inspector 참조 연결.

[Unity 목록](../README.md) · [리소스 복원 안내](../../docs/source-scope.md)
