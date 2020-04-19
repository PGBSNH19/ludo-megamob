using System;
using System.Collections.Generic;
using System.Text;

namespace LudoGameEngine.Tests.TestDubbles
{
    public class ListIOController : IGameIOController
    {
        public List<string> Messages { get; set; }
        public List<object> Actions { get; set; }

        public int currentAction;

        public ListIOController()
        {
            currentAction = 0;
            Messages = new List<string>();
        }

        public void ShowMessage(string message)
        {
            Messages.Add(message);
        }

        public int GetIntFromMessage(string message)
        {
            Messages.Add(message);
            return (int)Actions[currentAction++];
        }

        public string GetStringFromMessage(string message)
        {
            Messages.Add(message);
            return (string)Actions[currentAction++];
        }
    }
}