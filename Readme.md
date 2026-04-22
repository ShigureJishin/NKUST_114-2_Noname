
---

# 🎶 LiveStream Song Rater (直播歌曲評分系統)

這是一個專為實況主（VTuber / 音樂系實況主）設計的即時歌曲評分工具。採用 **.NET** 作為後端核心，並透過 **SignalR** 實現低延遲的即時互動。

---

## 🛠 技術棧 (Tech Stack)
* **Backend:** ASP.NET Core 9.0 (Web API + SignalR)
* **Database:** SQLite (輕量化、免安裝)
* **Frontend (Admin/Viewer/Overlay):** HTML5, CSS3 (Flexbox/Grid), JavaScript (Vanilla)
* **Communication:** SignalR (WebSocket)
* **Deployment:** GitHub Pages (前端靜態頁面) + Local/Cloud Backend

---

## 📋 功能模組 (Feature List)

### 1. 實況主控制台 (Admin Controller)
*目的：提供實況主在直播中即時管理投票流程。*
* **歌曲管理：**
    * 手動輸入當前歌名、歌手。
    * 預載今日歌單清單，一鍵切換。
* **投票流程控制：**
    * `開始投票`：開啟觀眾端投票權限，並通知 OBS Overlay 進場。
    * `結算分數`：停止收票，計算平均值並觸發 OBS 結算動畫。
    * `隱藏/重設`：重置所有狀態，準備下一首歌。
* **即時數據統計：**
    * 顯示目前總投票人數。
    * 實況主視角即時平均分統計。

### 2. OBS 顯示插件 (OBS Overlay)
*目的：在直播畫面上呈現華麗的評分視覺特效。*
* **動態進出場：** 使用 CSS Keyframes 實現流暢的側面滑入與滑出。
* **即時分數更新：** 當觀眾投票時，分數會以「數字跳動 (Pop)」特效即時變動。
* **等級評價系統：** 根據最終分數顯示不同視覺效果（如 SSS: 金色閃爍, A: 銀色, B: 一般）。
* **互動回饋：** 接收投票成功的快訊動畫（如星星閃爍）。

### 3. 觀眾投票頁面 (Viewer Voting Page)
*目的：提供觀眾簡單、快速的評分入口。*
* **直覺操作：**
    * 手機友善設計，使用滑桿 (Slider) 或大型按鈕快速評分 (0-100)。
    * 即時顯示目前正在評分的歌曲資訊。
* **防弊機制：**
    * **一歌一票：** 透過瀏覽器指紋 (Fingerprint) 或 SessionID 限制重複投票。
    * **狀態鎖定：** 當實況主關閉投票時，頁面自動轉為「已結束」狀態。
* **快速存取：** 支援透過 OBS 畫面上的 QR Code 直接掃碼進入。

### 4. 後端與資料中心 (Backend Service)
*目的：處理資料邏輯、存儲與即時推播。*
* **SignalR Hub：** 擔任訊息轉運站，確保管理端、觀眾端與 OBS 端的資料同步。
* **資料持久化：** 使用 SQLite 紀錄每首歌曲的詳細投票紀錄（時間、歌名、平均分、參與人數）。
* **API 提供：**
    * `POST /api/vote`：接收觀眾投票數據。
    * `GET /api/history`：提供給 GitHub Pages 顯示歷史排行榜。

---

## 🗃 資料庫結構 (Database Schema)

| Table | Fields | Description |
| :--- | :--- | :--- |
| **Songs** | `Id`, `Title`, `Artist`, `FinalScore`, `VoteCount`, `CreatedAt` | 紀錄歌曲結算後的最終結果 |
| **Votes** | `Id`, `SongSessionId`, `VoterFingerprint`, `Score`, `Timestamp` | 紀錄每一筆原始選票，用於防重複判斷 |

---

## 🚀 開發進度 (Roadmap)
- [x] 專案構想與技術選型
- [x] 撰寫觀眾端 Web Overlay 靜態原型
- [ ] 建立 ASP.NET Core 專案並整合 SignalR
- [ ] 實作 SQLite 資料表與基礎 CRUD 邏輯
- [ ] 開發實況主控制台 (Custom Browser Dock)
- [ ] 實作觀眾端投票網頁
- [ ] 串連 GitHub Pages 展示歷史評分網頁
---