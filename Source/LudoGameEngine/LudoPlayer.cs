using System.Collections.Generic;

namespace LudoGameEngine
{
    public class LudoPlayer
    {

        public LudoPlayer()
        {
            PlayerName = string.Empty;
        }

        public LudoPlayer(string playerName)
        {
            PlayerName = playerName;
        }

        public string PlayerName { get; set; }
        public int Index { get; internal set; }
        public string Color { get; internal set; }
    }
}