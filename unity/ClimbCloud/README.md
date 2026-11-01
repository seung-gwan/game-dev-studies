# ClimbCloud — 점프·카메라·장면 전환

- [PlayerController.cs](Assets/Scripts/PlayerController.cs): Space 점프, Shift 키 입력과 수평 힘 적용, 트리거 장면 전환
- [CameraController.cs](Assets/Scripts/CameraController.cs): 플레이어의 Y 좌표를 따라가는 카메라
- [ClearDirector.cs](Assets/Scripts/ClearDirector.cs): 클릭 시 플레이 장면으로 복귀

장면: [GameC.unity](Assets/GameC.unity), [ClearDirector.unity](Assets/ClearDirector.unity).
원본 PlayerController 파일의 클래스명은 `NewMonoBehaviourScript`입니다. 파일명과 클래스명을 맞추고 컴포넌트 연결을 확인하는 작업을 개선 과제로 남깁니다.

다음 학습: 바닥 판정, 연속 입력과 힘 적용 주기, 장면 이름 관리.

[Unity 목록](../README.md) · [리소스 복원 안내](../../docs/source-scope.md)
