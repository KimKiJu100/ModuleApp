# App.CoreModules

## 역할
비동기 Worker 생명주기 관리 프레임워크. Worker 생성/실행/정리의 전 과정을 추상화한다.
**다른 프로젝트는 이 라이브러리에 의존한다 — 변경 시 영향 범위를 반드시 확인할 것.**

- **Framework:** .NET Framework 4.7.2
- **출력 타입:** Library
- **외부 의존성:** 없음 (System 기본 라이브러리만 사용)

---

## 클래스 계층 구조

```
WorkerBase (추상)
├── ActionWorker<TActionParamType>     일회성 Action 실행
├── ConditionWorker                    Func<bool> 기반 조건 반복 감시
├── StateCheckWorker                   IConditionRule 기반 상태 감시
└── WorkerRequestBase<TPayLoad, TResponse> (추상)
    └── FuncWorker<TPayLoad, TResponse>    요청-응답 패턴
```

### Worker 생명주기
```
SetWorker() → [Pending]
StartAsync() → [IsRunning = true]
작업 완료 → Completed 이벤트 발생
CleanupLoop() → Dispose() → WorkerRemoved 이벤트
```

---

## 주요 파일

| 파일 | 역할 |
|------|------|
| `Thread/Base/WorkerBase.cs` | 모든 Worker의 기반. InstanceKey, IsRunning, Completed/Canceled 이벤트 |
| `Thread/Base/WorkerRequestBase.cs` | ConcurrentQueue 기반 요청-응답 Worker 기반 |
| `Thread/WorkerManager.cs` | ConcurrentDictionary로 Worker 집합 관리. CleanupLoop 포함 |
| `Thread/ActionWorker.cs` | 일회성 Action 실행 Worker |
| `Thread/ConditionWorker.cs` | 조건값 반복 감시. SetCondition/SetCurrentValue |
| `Thread/StateCheckWorker.cs` | IConditionRule/IConditionAction 연동 상태 감시 |
| `Thread/FuncWorker.cs` | "Invoke" 커맨드 처리, Func<TResponse> 실행 |
| `Models/WorkerInfor.cs` | WorkerInfo : IEquatable<WorkerInfo> — UI 변경 감지용 |

---

## 인터페이스

| 인터페이스 | 위치 | 필수 구현 |
|-----------|------|---------|
| `IConditionRule` | `Thread/interfaces/` | `string RuleName`, `bool Check()` |
| `IConditionAction` | `Thread/interfaces/` | `void OnAction()` |
| `IGenericWorkerAction` | `Thread/interfaces/` | `string ActionName` |
| `IWorkerRequest<TResponse>` | `Thread/Base/Interfaces/` | `Task<TResponse> RequestAsync(string, object)` |

---

## 코딩 규칙

### 필수
- **새 Worker 타입 추가 시 반드시 `WorkerBase` 상속**
- **모든 비동기 메서드에 `CancellationToken` 수용 및 전파**
- **스레드 공유 컬렉션은 `ConcurrentCollection` 사용**
- **Worker 내에서 UI 직접 접근 금지** — 이벤트로 상위에 전달
- **Dispose 패턴 준수** — WorkerBase의 Dispose 재정의 시 base.Dispose() 호출

### IConditionRule 구현 규칙
```csharp
public class MyRule : IConditionRule
{
    public string RuleName => nameof(MyRule);  // nameof 사용 필수
    public bool Check() { /* 상태 확인 로직 */ }
}
```

### IConditionAction 구현 규칙
```csharp
public class MyAction : IConditionAction
{
    public void OnAction() { /* 액션 로직 — 블로킹 최소화 */ }
}
```

### WorkerInfo 동등성 비교
- `WorkerInfo`는 `IEquatable<WorkerInfo>` 구현체
- 필드 추가 시 반드시 `Equals()`와 `GetHashCode()` 동시 업데이트 (397 multiplier 패턴 유지)

---

## 금지 사항
- WorkerManager를 우회하여 Worker를 직접 시작/정지하지 말 것
- Worker 내에서 `Thread.Sleep()` 사용 금지 — `Task.Delay()`와 CancellationToken 사용
- WorkerBase를 상속하지 않고 독립 Task를 WorkerManager에 등록하지 말 것
