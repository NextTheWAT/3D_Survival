# 🧭 3D Survival Game (Unity Project)

Unity를 사용하여 제작한 3D 생존 게임입니다.  
플레이어는 자원을 수집하고, 적과 전투하며, 아이템을 활용해 생존을 이어갑니다.  
**불, 날씨, 사운드 등 환경 요소까지 구현하여 몰입감을 강화했습니다.**  
  
![Animation](https://github.com/user-attachments/assets/f318b468-e3d3-4c13-8dde-af295dcd7c80)  
  
---

## 📌 주요 기능

### 🕹️ 플레이어 조작
- `Input System` 기반 WASD 이동 + Space 점프
- 마우스 카메라 회전 (`LookSensitivity`)
- 체력, 허기, 스태미나 관리 (`PlayerCondition`)

---

### 🛠️ 자원 채집 & 전투 시스템
- `EquipTool` 장비를 통해:
  - 자원 채집 (`Resource.cs`)
  - 적 NPC 공격 (`IDamageable`)
- 공격 시 스태미나 소모 (스태미나 부족 시 공격 불가)

---

### 🤖 적 AI (NPC)
- FSM 상태 기반 (Idle → Wandering → Attacking)
- `NavMeshAgent`로 자동 이동 및 경로 탐색
- 플레이어 감지 후 추적 + 공격
- 사망 시 아이템 드랍 (`ItemData.dropPrefab`)

---

### 🎒 인벤토리 시스템

> **ScriptableObject 기반의 강력한 아이템/장비 관리 기능**

- `ItemData`를 ScriptableObject로 설계 (이름, 설명, 아이콘, 드랍 프리팹, 스탯 등 포함)
- 인벤토리 창(`UIInventory`)에서 다음 기능 제공:
  - ✅ **아이템 획득** (중복 시 스택, 최대 수량 초과 시 드랍)
  - ✅ **아이템 장비/해제** (장비형: `equipPrefab` 연결)
  - ✅ **아이템 사용** (소모형: 체력/허기 회복 등)
  - ✅ **아이템 버리기** (지정 위치에 드랍)
  - ✅ **선택 아이템 정보창** (이름, 설명, 스탯 등 표시)
- `ItemSlot.cs` 기반의 슬롯 UI로 정리됨

---

### 🔥 환경 시스템

#### 🌙 낮/밤 사이클 (`DayNightCycle.cs`)
- 태양과 달의 위치, 색상, 세기 등을 시간에 따라 자동 조정
- `Gradient` + `AnimationCurve` 활용한 자연스러운 변화

#### 🔥 캠프파이어 데미지 (`CampFire.cs`)
- 불에 들어가면 `IDamageable`에게 지속 피해
- `OnTriggerEnter/Exit` + `InvokeRepeating()` 사용

#### 🎵 음악 존 (`MusicZone.cs`)
- 특정 구역에 들어가면 음악이 서서히 켜지고
- 나가면 다시 꺼지는 `Fade In/Out` 사운드 구현

---

### 👣 사운드 연출
- 플레이어가 일정 속도로 움직일 때마다
- 발걸음 소리(`FootSteps.cs`)를 무작위로 재생

---

## 📂 프로젝트 구조

```text
Assets/
├── 01_Scripts/                    → 전체 스크립트 폴더
│   ├── Character/                → 플레이어 컨트롤, 상태 시스템 등 핵심 로직
│   │   ├── CharacterManager.cs   → 싱글톤 플레이어 관리자
│   │   ├── Player.cs             → 입력 & 상태 연결
│   │   ├── PlayerController.cs   → 이동 및 점프 처리
│   │   ├── PlayerCondition.cs    → 체력, 허기, 스태미나 관리
│   │   └── Condition.cs          → 상태 수치 정의용 데이터 클래스
│   │
│   ├── Equipments/               → 장비 및 아이템 사용 관련
│   │   ├── Equip.cs              → 장비 착용
│   │   ├── EquipTool.cs          → 채집 및 공격 도구 처리
│   │   └── Equipment.cs          → 장착 아이템 프리팹 관리
│   │
│   ├── Environment/              → 환경 오브젝트 관련
│   │   ├── CampFire.cs           → 캠프파이어 데미지 처리
│   │   ├── DayNightCycle.cs      → 낮/밤 주기 시스템
│   │   └── MusicZone.cs          → 음악 재생 구역 (페이드 인/아웃)
│   │
│   ├── Interaction/              → 플레이어와 상호작용 가능한 오브젝트
│   │   ├── Interaction.cs        → Raycast 기반 상호작용 처리
│   │   └── Resource.cs           → 자원 채집 가능 오브젝트
│   │
│   ├── Items/                    → 아이템 데이터 및 관련 기능
│   │   ├── ItemData.cs           → ScriptableObject 기반 아이템 정의
│   │   ├── ItemObject.cs         → 인게임 드랍용 오브젝트
│   │   ├── ItemSlot.cs           → 인벤토리 슬롯 UI 처리
│   │   └── Equipment.cs          → 장비 프리팹과 연결되는 아이템 기능
│   │
│   ├── NPCs/                     → 적 AI 관련 스크립트
│   │   └── NPC.cs                → NavMesh 기반 상태 머신 AI (Wander, Attack)
│   │
│   └── UI/                       → 사용자 인터페이스 관련
│       ├── UICondition.cs        → 체력, 허기, 스태미나 UI 연동
│       ├── UIInventory.cs        → 인벤토리 UI 처리
│       └── DamageIndicator.cs    → 피격 시 화면 이펙트
'''












