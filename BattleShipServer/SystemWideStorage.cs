using System.Collections.Generic;
using System.Net.Sockets;

namespace BattleShipServer
{
    internal sealed class SystemWideStorage
    {
        private static readonly SystemWideStorage instance = new SystemWideStorage();

        //list of logged not playing people and their IPs
        public Dictionary<string, Socket> loggedNicks = new Dictionary<string, Socket>();

        //list of logged playing people and thei IPs
        public Dictionary<string, Socket> loggedplayingNicks = new Dictionary<string, Socket>();

        //person and list of enemies who offers game
        public Dictionary<string, List<string>> enemiesoffers = new Dictionary<string, List<string>>();

        //Form1 Players Clicked Start <WHO+WHOM>
        public List<string> whowhomSentStart = new List<string>();

        //Form1 Players Clicked GiveUp
        public List<string> whowhomSentGiveUp = new List<string>();

        private SystemWideStorage()
        { }

        static SystemWideStorage()
        { }

        public static SystemWideStorage Instance => instance;
    }
}
