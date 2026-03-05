# Editor

## 역할
Prism MVVM 아키텍처 기반의 WPF 에디터 애플리케이션.
DevExpress Ribbon/Docking UI, Region 기반 모듈화, DeviceWizard 연동을 포함한다.

- **Framework:** .NET Framework 4.8
- **출력 타입:** WinExe (WPF)
- **진입점:** `App.xaml` / `App.xaml.cs`
- **의존성:** Editor.Core, DeviceWizard, 00.Modules

---

## 주요 라이브러리

| 라이브러리 | 버전 | 용도 |
|-----------|------|------|
| `Prism` | 7.2.0.1422 | MVVM 프레임워크, Region/Navigation |
| `DryIoc` | 4.0.7 | IoC 컨테이너 (Prism DI) |
| `DevExpress.Xpf.*` | 22.1.3 | Ribbon, Docking, Core UI 컨트롤 |
| `Microsoft.Xaml.Behaviors` | 1.1.135 | XAML 인터랙션 비헤이비어 |

---

## 폴더 구조

```
Editor/
├── App.xaml / App.xaml.cs              진입점, Prism Bootstrapper
├── Core/
│   ├── Adapters/
│   │   ├── DevDockingManagerControlRegionAdapter.cs   DevExpress Docking → Prism Region
│   │   └── DevRibbonControlRegionAdapter.cs           DevExpress Ribbon → Prism Region
│   ├── DependentViewInfo.cs            종속 뷰 정보
│   └── DependentViewRegionBehavior.cs  종속 뷰 Region 동작
├── Helper/
│   └── AttributesHelper.cs            어트리뷰트 헬퍼
├── PageGroup/                          탭 페이지 뷰들
│   ├── DeviceTab.xaml / .cs            디바이스 탭
│   ├── MotionTab.xaml / .cs            모션 탭
│   └── PLCTab.xaml / .cs              PLC 탭
├── ViewModels/
│   ├── RibbonWindowViewModel.cs        메인 창 ViewModel
│   └── DeviceTabViewModel.cs           디바이스 탭 ViewModel
└── Views/
    ├── RibbonWindow.xaml / .cs         메인 Ribbon 창
    └── DevMirror.xaml / .cs            디바이스 미러 뷰
```

---

## 코딩 규칙

### MVVM 패턴 (필수)
- **View에서 비즈니스 로직 작성 금지** — 모든 로직은 ViewModel에
- **ViewModel에서 View 직접 참조 금지** — Command, Binding, Region Navigation 사용
- **ViewModel은 Editor.Core의 `ViewModelBase` 상속**
- DataContext는 XAML 또는 Prism의 ViewModelLocator로 설정

### Prism Region 규칙
- 새 View 추가 시 **Region에 등록** — `IRegionManager.RegisterViewWithRegion()` 사용
- Region 이름은 **Editor.Core의 `RegionNames`** 상수 사용
- DevExpress 컨트롤을 Region으로 쓸 때 **Core/Adapters/** 어댑터 사용

### DevExpress 규칙
- **Ribbon 아이템은 XAML로 선언** — 코드 비하인드에서 동적 추가 최소화
- **Docking 레이아웃 변경 시 직렬화 상태 유지** 고려
- DevExpress 컨트롤의 이벤트 핸들러는 **Command 바인딩으로 대체** 우선 검토

### 종속 뷰(DependentView) 규칙
- 탭/도킹 패널에 종속된 뷰는 `DependentViewAttribute` 사용
- 뷰 순서 지정 시 `OrderByAttribute` 사용
- 종속 뷰 동작은 `DependentViewRegionBehavior`가 자동 처리

### 네이밍 규칙
- View 파일: `[기능]View.xaml` 또는 `[기능]Tab.xaml`
- ViewModel 파일: `[기능]ViewModel.cs` (View와 1:1 대응)
- Command: `[동작]Command` (예: `OpenDeviceCommand`)

---

## 의존성 관계
```
Editor
├── Editor.Core      (ViewModelBase, RegionNames, 인터페이스)
├── DeviceWizard     (디바이스 설정 마법사)
└── 00.Modules       (통신/디바이스 제어)
```

---

## 금지 사항
- View의 코드 비하인드(`.xaml.cs`)에 비즈니스 로직 작성 금지
- ViewModel에서 `System.Windows.Forms` 네임스페이스 사용 금지 (WPF 프로젝트)
- DevExpress 라이선스 파일(`Licenses.licx`) 수정 금지
- Prism의 IoC 컨테이너(DryIoc)를 우회한 직접 인스턴스 생성 금지
