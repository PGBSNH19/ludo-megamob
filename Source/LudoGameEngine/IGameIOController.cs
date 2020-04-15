using System;
using System.Collections.Generic;
using System.Text;

namespace LudoGameEngine
{
    public interface IGameIOController
    {
        void ShowMessage(string message);
        int GetIntFromMessage(string v);
        string GetStringFromMessage(string v);
    }
}
