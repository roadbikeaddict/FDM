using System;

namespace FDM
{
    public class FdmExec
    {
        public string AircraftPath { get; set; }
        public string EnginePath { get; set; }
        public string SystemsPath { get; set; }

        public FdmExec()
        {
           
        }

        public bool LoadScript(string scriptName)
        {
            return true;
        }
    }
}