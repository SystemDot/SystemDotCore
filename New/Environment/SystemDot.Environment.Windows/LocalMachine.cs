﻿namespace SystemDot.Environment
{
    public class LocalMachine : ILocalMachine
    {
        public string GetName()
        {
            return System.Environment.MachineName;
        }

        public string GetModel()
        {
            return "Computer";
        }

        public string GetVersion()
        {
            return "1";
        }
    }
}