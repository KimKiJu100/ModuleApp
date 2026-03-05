# 00.Modules (Modules)

## 역할
산업용 장비 통신, 프로토콜 처리, 프레임 파싱, 디바이스 제어를 담당하는 핵심 라이브러리.
Serial/TCP 통신, XGT(LG PLC)/MelSec(Mitsubishi) 프로토콜, Ajin 모터 제어를 포함한다.

- **Framework:** .NET Framework 4.8
- **출력 타입:** Library
- **프로젝트명(sln 내):** 00.Modules

---

## 폴더 구조 및 역할

```
Modules/
├── 00.Communication/     통신 계층 — Serial/TCP 연결·송수신·상태
├── 01.Protocol/          프로토콜 계층 — XGT, MelSec 패킷 빌드
├── 02.Parsers/           파싱 계층 — 프레임 스키마 기반 응답 파싱
├── 03.Packet/            패킷 정의 — XGTPacket, MelSecPacket
├── ADO/                  DB 접근 — SqlExecutor, DMLParser
├── Base/                 DeviceBase — 3계층 통합 기반
├── Devices/              디바이스 구현 — PLCDevice, Ajin 모터
├── Helper/               BitHelper, CollectionHelper
├── Attributes/           DependentView, OrderBy 어트리뷰트
└── Extensions/           CpuTypeExtension
```

---

## 3계층 아키텍처

```
[Application]
     ↓ uses
DeviceBase (Base/DeviceBase.cs)
     ├── ComunicationContext   (00.Communication/Context/)
     ├── ProtocolContext       (01.Protocol/Context/)
     └── ParserContext         (02.Parsers/Context/)
```

### 계층 1: Communication
| 파일 | 역할 |
|------|------|
| `00.Communication/Context/ComunicationContext.cs` | 통신 통합 진입점. Configure/Connection/Sender/Receiver |
| `00.Communication/Factory/CommunicationFactory.cs` | 통신 타입별 인스턴스 생성 |
| `00.Communication/Connection/` | ConnectionBase + Serial232/TCPClient 구현 |
| `00.Communication/Sender/` | SenderBase + 타입별 구현 |
| `00.Communication/Receiver/` | ReceiverBase + 타입별 구현 |
| `00.Communication/State/` | CommunicationStateBase + 타입별 구현 |
| `00.Communication/Type/` | TypeBase → Serial232Type, TCPClientSocketType |
| `00.Communication/Params/` | CommParamBase 파생 파라미터 클래스들 |

### 계층 2: Protocol
| 파일 | 역할 |
|------|------|
| `01.Protocol/Context/ProtocolContext.cs` | 프로토콜 통합 진입점 |
| `01.Protocol/XGT/Packet/XGTPacketBuild.cs` | XGT 패킷 빌더 |
| `01.Protocol/XGT/` | CommandTypePacketMapper, DataTypePacketMapper, VariableNameConverter 등 |

### 계층 3: Parser
| 파일 | 역할 |
|------|------|
| `02.Parsers/Context/ParserContext.cs` | 파싱 통합 진입점 |
| `02.Parsers/Type/XGTFrameParser.cs` | XGT 응답 파싱 |
| `02.Parsers/Type/MelSecFrameParser.cs` | MelSec 응답 파싱 |
| `02.Parsers/FrameSchemas/XGTFrameSchema.cs` | XGT 프레임 스키마 정의 |
| `02.Parsers/MetaField/FrameSchema.cs` | 프레임 메타 구조 |
| `02.Parsers/MetaField/FrameFieldInfo.cs` | 필드 단위 메타 정보 |

---

## 코딩 규칙

### 통신 계층 규칙
- **새 통신 타입 추가 시:** `TypeBase`, `ConnectionBase`, `SenderBase`, `ReceiverBase`, `CommunicationStateBase`를 모두 상속하여 구현 (Strategy 패턴 유지)
- **ComunicationContext를 통해서만 통신 접근** — 내부 구현체 직접 사용 금지
- 통신 파라미터는 **`CommParamBase` 상속** 클래스로 정의
- 수신 이벤트 등록: `AddReceivedEvent()` 사용

```csharp
// 올바른 사용 패턴
_context.Configure(new SerialParams { Port = "COM1", BaudRate = 9600 });
_context.Connection();
_context.AddReceivedEvent((s, data) => { /* 처리 */ });
_context.Sender(bytes);
```

### 프로토콜 계층 규칙
- **새 프로토콜 추가 시:** 01.Protocol 하위에 별도 폴더 생성 (XGT 폴더 구조 참고)
- 패킷 빌드 로직은 **PacketBuild 클래스에 집중** — Context에서 직접 바이트 조작 금지
- Mapper 클래스는 **단방향 변환만** 담당 (Command→Packet, Data→Packet)

### 파서 계층 규칙
- **새 파서 추가 시:** `ParserBase` 상속 + `FrameParserFactory`에 등록
- 프레임 구조 정의는 **FrameSchema/FrameFieldInfo** 메타 클래스 활용
- 파서는 **순수 변환 로직만** — 통신/프로토콜 레이어에 의존하지 않음

### 디바이스 계층 규칙
- **새 디바이스 추가 시:** `DeviceBase` 상속, 3개 Context(Communication, Protocol, Parser) 주입
- `DeviceBase`의 3개 Context 필드를 직접 사용 — 별도 통신 코드 작성 금지

### 모터 제어 규칙
- Ajin PCI 드라이버는 **`IMotionControl` 인터페이스를 통해서만** 접근
- 축 수에 따라 클래스 선택: `AjinPciN204`(2축), `AjinPciN404`(4축), `AjinPciN804`(8축)
- 알람 상태 확인은 `IMotionAlarm`, 상태 조회는 `IMotionState` 사용

---

## 금지 사항
- 계층 역참조 금지: `02.Parsers`가 `01.Protocol`을 참조하거나, `01.Protocol`이 `00.Communication`을 참조하지 말 것
- `ComunicationContext` 내부 구현 직접 노출 금지
- 패킷 바이트 배열을 Context 외부에서 직접 조립하지 말 것
