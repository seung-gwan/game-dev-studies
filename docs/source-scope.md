# 공개 소스 범위와 실행 안내

## Unity

각 프로젝트의 C# 코드, 장면, 프리팹과 연결된 `.meta` 파일, 입력·렌더링 설정, Packages 파일을 보관했습니다.
일부 CP949 소스를 UTF-8로 변환했으며 게임 로직은 수정하지 않았습니다.
Unity Cloud 연결 정보와 개인 계정에 연결된 설정은 공개본에서 제거했습니다.

에디터 버전은 원본 `ProjectVersion.txt`의 **6000.0.69f1**을 기준으로 합니다.

### 리소스를 복원하여 확인하기

1. 사용할 프로젝트 폴더를 Unity Hub에 추가합니다.
2. Packages에 기록된 패키지를 복원합니다.
3. 원래 프로젝트의 스프라이트·배경·GUI 리소스를 적법하게 확보하여 원래 경로와 `.meta` GUID에 맞춰 복원하거나 대체 리소스로 다시 연결합니다.
4. TextMesh Pro 리소스가 필요한 프로젝트에서는 해당 리소스를 가져오고 폰트·텍스트 참조를 확인합니다.
5. 각 README에 적힌 시작 장면을 열고 Inspector 참조와 Build Settings를 점검합니다.

이미지 디자인·외부 UI 팩의 원본을 포함한 배포용 완성 프로젝트 전체를 복제한 공개본은 아닙니다.
현재 자료를 그대로 내려받아 모든 화면이 동일하게 실행된다고 보장하지 않습니다.
제공된 시연 영상에서 확인할 수 있는 결과는 별도로 연결했습니다.

## Unreal Engine

`.uproject`, 학습 맵, 블루프린트, 자체 폴더의 머티리얼·모델링 결과와 맵 저장 데이터를 보관했습니다.
`__ExternalActors__`와 `__ExternalObjects__`는 맵에 연결된 원본 데이터를 보관하는 폴더이므로 포함했습니다.
`Saved`, `Intermediate`, `DerivedDataCache`, `Binaries`는 포함하지 않았습니다.

`.uproject`의 EngineAssociation은 **5.0**입니다. 에디터 전용 ModelingToolsEditorMode 플러그인이 설정되어 있습니다.
원래 사용한 외부 모델·텍스처 팩, 캐릭터, StarterContent와 일부 기본 리소스는 별도로 복원해야 합니다.
Android File Server의 로컬 연결 토큰 설정은 공개본에서 제거했습니다.

새 5.0 Third Person 프로젝트의 기본 리소스와 원래 사용한 에셋을 같은 경로에 복원하고, Content/Levels의 맵을 에디터에서 확인하는 방식입니다.
에셋이 빠진 상태에서는 Missing Reference가 생길 수 있습니다. 이번 정리에서 맵을 새로 실행하거나 패키징하지 않았습니다.

## 미디어와 문서

- 스크린샷은 사용자가 제공한 결과 화면입니다. 공개 파일명에서 학번을 제거했습니다.
- 과제 1 사진은 위치 메타데이터가 없는 PNG로 공개했습니다.
- Unity 이미지 디자인은 팀원의 작업으로 표시했습니다.
- 영상 원본은 Release에 보관하고 AVI와 초기 HEVC 영상에는 H.264 MP4 공개본을 준비했습니다.
- HWPX·발표 자료는 제작 과정과 기획을 확인하는 근거로 읽었으며, 학번이 포함된 원본 문서는 그대로 공개하지 않았습니다.
- Unity 발표 PPTX에는 공개본에 사용할 수 있는 자료를 선별해 Release에 함께 보관합니다.

큰 영상은 소스 이력과 분리해 Release로 배포합니다. 관련 기준: [GitHub 공식 대용량 파일 안내](https://docs.github.com/en/repositories/working-with-files/managing-large-files/about-large-files-on-github).
