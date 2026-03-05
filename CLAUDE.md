# MyModule 솔루션 (루트)

## 솔루션 개요
산업용 자동화 시스템을 위한 모듈식 .NET Framework 애플리케이션.
비동기 Worker 관리, 산업용 통신(Serial/TCP), PLC 프로토콜(XGT/MelSec), 모터 제어를 포함한다.

## 프로젝트 구성

| 프로젝트 | 타입 | Framework | 역할 |
|---------|------|-----------|------|
| `App.CoreModules` | Library | 4.7.2 | 비동기 Worker 프레임워크 |
| `Modules` (00.Modules) | Library | 4.8 | 통신/프로토콜/디바이스 라이브러리 |
| `MyModule` | WinExe | 4.8 | 프로젝트 간 통합 테스트용 애플리케이션 |
| `Editor` | WinExe | 4.8 | WPF 에디터 (Prism/DevExpress) |
| `Editor.Core` | Library | 4.8 | 에디터 핵심 라이브러리 |

## 프로젝트 간 의존성
```
MyModule
├── App.CoreModules   (Worker 관리)
└── Modules           (통신/프로토콜/디바이스)

Editor
└── Editor.Core
```

## CLAUDE.md 우선순위
이 파일(루트)과 각 프로젝트 CLAUDE.md가 동시에 로드된다.
- **이 파일의 규칙이 항상 최우선**이다 — 프로젝트 CLAUDE.md와 충돌 시 이 파일을 따를 것
- 프로젝트 CLAUDE.md는 해당 프로젝트에만 적용되는 세부 규칙을 담는다
- 이 파일에 없는 내용은 프로젝트 CLAUDE.md를 참고한다

## 공통 규칙 (전 프로젝트 적용)
- **SOLID 원칙을 기본으로 한다**
- 답변은 **한국어**로
- **자동 커밋 금지** — 명시적으로 요청받을 때만 커밋
- **파일 수정 전 반드시 Read** — 가정으로 수정 금지
- **파일 삭제 전 반드시 확인**

## 빌드
```bash
msbuild MyModule.sln /p:Configuration=Debug
```
