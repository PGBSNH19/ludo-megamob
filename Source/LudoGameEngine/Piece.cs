using System.Collections.Generic;

namespace LudoGameEngine
{
    public class Piece
    {
        public int TileId { get; set; }
        public LudoPlayer Player { get; internal set; }
    }
}