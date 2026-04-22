using Microsoft.AspNetCore.SignalR;

namespace SongRater.Api.Hubs
{
    // 必須繼承自 Hub，這讓這個類別擁有了 WebSocket 通訊的能力
    public class ScoreHub : Hub
    {
        /// <summary>
        /// 接收來自控制台的新分數，並廣播給所有連線的畫面 (OBS)
        /// </summary>
        public async Task BroadcastScore(string title, string artist, int score)
        {
            // Clients.All 代表「所有連線到這個 Hub 的人」(包含 OBS 跟觀眾)
            // "ReceiveUpdate" 是我們在前端網頁 (overlay.html) 裡準備好要監聽的事件名稱
            await Clients.All.SendAsync("ReceiveUpdate", title, artist, score);
        }
    }
}