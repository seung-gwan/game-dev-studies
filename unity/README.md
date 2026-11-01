# Unity 학습 프로젝트

학교 프로젝트에 기록된 에디터 버전은 **Unity 6000.0.69f1**입니다.
`Assets`, `Packages`, `ProjectSettings`의 학습에 필요한 파일을 프로젝트별로 보관했습니다.

| 프로젝트 | 공부한 내용과 결과 | 주요 코드 |
| --- | --- | --- |
| [손오공 · project_New](project_New/README.md) | 2인 팀의 2D 액션 게임. 공동 기획, 유승관 게임 구현, 이승훈 이미지 디자인 | 이동·점프, 공격·방어, 낙하물, 경고 UI, 점수·체력, 장면 전환 |
| [Car_Game](Car_Game/README.md) | 마우스 조작에 따른 이동과 거리 UI | CarController, GameDirector |
| [Cat](Cat/README.md) | 화살 피하기와 체력 게이지 | PlayerController, AroowGenerator, DropTheArrow, GameDirector |
| [ClimbCloud](ClimbCloud/README.md) | 물리 기반 점프, 카메라 추적, 클리어 화면 | PlayerController, CameraController, ClearDirector |
| [project_260402](project_260402/README.md) | 클릭에 따른 룰렛 회전 상태와 감속 | RouletteController |
| [Test](Test/README.md) | C# 문법·클래스 기초 | NewMonoBehaviourScript, Car, Bank |

## 프로젝트를 살펴보는 방법

1. 각 폴더의 설명에서 시작 장면과 오브젝트 구성을 확인합니다.
2. C# 코드와 `.unity`, `.prefab` 파일을 함께 살펴봅니다.
3. 에디터에서 실행하려면 [리소스 복원 안내](../docs/source-scope.md)에 따라 누락된 이미지와 외부 UI 리소스를 준비합니다.

원래 소스의 로직과 `.meta` GUID를 유지했습니다. 일부 한글 파일의 문자 인코딩을 UTF-8로 바꿨습니다.
현재 공개본의 에디터 실행·새 빌드는 수행하지 않았습니다.
