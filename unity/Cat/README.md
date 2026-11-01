# Cat — 화살 피하기

캐릭터를 좌우로 움직이며 위에서 생성되는 화살을 피하는 학습 실습입니다.

| 파일 | 동작 |
| --- | --- |
| [PlayerController.cs](Assets/Script/PlayerController.cs) | 좌우 방향키로 캐릭터 이동 |
| [AroowGenerator.cs](Assets/Script/AroowGenerator.cs) | 시간 간격에 따라 임의 X 위치에 화살 생성 |
| [DropTheArrow.cs](Assets/Script/DropTheArrow.cs) | 화살 하강·화면 밖 제거·캐릭터와 거리 기반 충돌 판정 |
| [GameDirector.cs](Assets/Script/GameDirector.cs) | 피격 시 체력 게이지 감소 |

장면: [GameS.unity](Assets/GameS.unity). 원본 Build Settings의 SampleScene 등록 상태를 유지했으므로 실행 시 GameS를 직접 엽니다.
다음 학습: 프레임 수와 독립적인 이동, 충돌 컴포넌트 활용, 체력 0의 종료 처리.

[Unity 목록](../README.md) · [리소스 복원 안내](../../docs/source-scope.md)
