using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FDM
{
    public class FdmMain
    {


        //private string aircraftName;
        //private string resetName;
        //private string logOutputName = "JSBout.csv";
        //private string logDirectiveName;
        //private vector<string> CommandLineProperties;
        //private vector<double> CommandLinePropertyValues;

        //private bool hasToRunInRealtime;
        //private bool hasToPlayNice;
        //private bool hasToSuspendAfterInitialization;
        //private bool catalog;
        //private double endTime = -1.0;

        public static void Main(string[] args)
        {
            string rootDir = "";
            bool result = false, success;
            bool was_paused = false;
            FdmExec fdmExec;
            double frame_duration;
            string scriptName = "";    
            double new_five_second_value = 0.0;
            double actual_elapsed_time = 0;
            double initial_seconds = 0;
            double current_seconds = 0.0;
            double paused_seconds = 0.0;
            double sim_time = 0.0;
            double sim_lag_time = 0;
            double cycle_duration = 0.0;
            long sleep_nseconds = 0;

            //realtime = false;
            //play_nice = false;
            //suspend = false;
            //catalog = false;

            //if (!ParseOptions(args))
            //{
            //    PrintHelp();
            //    Environment.Exit(-1);
            //}
        

            // *** SET UP JSBSIM *** //
            fdmExec = new FdmExec();
            fdmExec.AircraftPath = rootDir + "aircraft";
            fdmExec.EnginePath = rootDir + "engine";
            fdmExec.SystemsPath = rootDir + "systems";
            
            ////FDMExec->GetPropertyManager()->Tie("simulation/frame_start_time", &actual_elapsed_time);
            ////FDMExec->GetPropertyManager()->Tie("simulation/cycle_duration", &cycle_duration);

            //// *** OPTION A: LOAD A SCRIPT, WHICH LOADS EVERYTHING ELSE *** //
            //if (!String.IsNullOrEmpty(scriptName))
            //{
            //    scriptName = rootDir + scriptName;
            //    result = fdmExec.LoadScript(scriptName);

            //    if (!result)
            //    {
            //        System.Console.WriteLine("Failed to load script file {0}", scriptName);
            //        Environment.Exit(-1);
            //    }

            //    // *** OPTION B: LOAD AN AIRCRAFT AND A SET OF INITIAL CONDITIONS *** //
            //}
            //else if (!AircraftName.empty() || !ResetName.empty())
            //{

            //    if (catalog) FDMExec->SetDebugLevel(0);

            //    if (! FDMExec->LoadModel(RootDir + "aircraft",
            //                             RootDir + "engine",
            //                             RootDir + "systems",
            //                             AircraftName))
            //    {
            //        cerr << "  JSBSim could not be started" << endl << endl;
            //        delete FDMExec;
            //        exit(-1);
            //    }

            //    if (catalog)
            //    {
            //        FDMExec->PrintPropertyCatalog();
            //        delete FDMExec;
            //        return 0;
            //    }

            //    JSBSim::FGInitialCondition* IC = FDMExec->GetIC();
            //    if (! IC->Load(ResetName))
            //    {
            //        delete FDMExec;
            //        cerr << "Initialization unsuccessful" << endl;
            //        exit(-1);
            //    }

            //}
            //else
            //{
            //    cout << "  No Aircraft, Script, or Reset information given" << endl << endl;
            //    delete FDMExec;
            //    exit(-1);
            //}

            //// Load output directives file, if given
            //if (!LogDirectiveName.empty())
            //{
            //    if (!FDMExec->SetOutputDirectives(LogDirectiveName))
            //    {
            //        cout << "Output directives not properly set" << endl;
            //        delete FDMExec;
            //        exit(-1);
            //    }
            //}

            //// OVERRIDE OUTPUT FILE NAME. THIS IS USEFUL FOR CASES WHERE MULTIPLE
            //// RUNS ARE BEING MADE (SUCH AS IN A MONTE CARLO STUDY) AND THE OUTPUT FILE
            //// NAME MUST BE SET EACH TIME TO AVOID THE PREVIOUS RUN DATA FROM BEING OVER-
            //// WRITTEN. THIS OVERRIDES ONLY THE FILENAME FOR THE FIRST FILE.
            //if (!LogOutputName.empty())
            //{
            //    string old_filename = FDMExec->GetOutputFileName();
            //    if (!FDMExec->SetOutputFileName(LogOutputName))
            //    {
            //        cout << "Output filename could not be set" << endl;
            //    }
            //    else
            //    {
            //        cout << "Output filename change from " << old_filename << " from aircraft"
            //        " configuration file to " << LogOutputName << " specified on"
            //        " command line" << endl;
            //    }
            //}

            //// SET PROPERTY VALUES THAT ARE GIVEN ON THE COMMAND LINE

            //for (unsigned int i = 0;
            //i < CommandLineProperties.size();
            //i++)
            //{

            //    if (!FDMExec->GetPropertyManager()->GetNode(CommandLineProperties[i]))
            //    {
            //        cerr << endl << "  No property by the name " << CommandLineProperties[i] << endl;
            //        goto quit;
            //    }
            //    else
            //    {
            //        FDMExec->SetPropertyValue(CommandLineProperties[i], CommandLinePropertyValues[i]);
            //    }
            //}

            //cout << endl << JSBSim::FGFDMExec::fggreen << JSBSim::FGFDMExec::highint
            //<< "---- JSBSim Execution beginning ... --------------------------------------------"
            //<< JSBSim::FGFDMExec::reset << endl << endl;

            //result = FDMExec->Run(); // MAKE AN INITIAL RUN

            //if (suspend) FDMExec->Hold();

            //JSBSim::FGJSBBase::Message* msg;

            //// Print actual time at start
            //char s [
            //100]
            //;
            //time_t tod;
            //time(&tod);
            //strftime(s, 99, "%A %B %d %Y %X", localtime(&tod));
            //cout << "Start: " << s << " (HH:MM:SS)" << endl;

            //frame_duration = FDMExec->GetDeltaT();
            //if (realtime) sleep_nseconds = (long) (frame_duration*1e9);
            //else sleep_nseconds = (10000000); // 0.01 seconds

            //tzset();
            //current_seconds = initial_seconds = getcurrentseconds();

            //// *** CYCLIC EXECUTION LOOP, AND MESSAGE READING *** //
            //while (result)
            //{
            //    while (FDMExec->SomeMessages())
            //    {
            //        msg = FDMExec->ProcessMessage();
            //        switch (msg->type)
            //        {
            //            case JSBSim::FGJSBBase::Message::eText:
            //                cout << msg->messageId << ": " << msg->text << endl;
            //                break;
            //            case JSBSim::FGJSBBase::Message::eBool:
            //                cout << msg->messageId << ": " << msg->text << " " << msg->bVal << endl;
            //                break;
            //            case JSBSim::FGJSBBase::Message::eInteger:
            //                cout << msg->messageId << ": " << msg->text << " " << msg->iVal << endl;
            //                break;
            //            case JSBSim::FGJSBBase::Message::eDouble:
            //                cout << msg->messageId << ": " << msg->text << " " << msg->dVal << endl;
            //                break;
            //            default:
            //                cerr << "Unrecognized message type." << endl;
            //                break;
            //        }
            //    }

            //    // if running realtime, throttle the execution, else just run flat-out fast
            //    // unless "playing nice", in which case sleep for a while (0.01 seconds) each frame.
            //    // If suspended, then don't increment cumulative realtime "stopwatch".

            //    if (! FDMExec->Holding())
            //    {
            //        if (! realtime)
            //        {
            //            // ------------ RUNNING IN BATCH MODE

            //            result = FDMExec->Run();

            //            if (play_nice) sim_nsleep(sleep_nseconds);

            //        }
            //        else
            //        {
            //            // ------------ RUNNING IN REALTIME MODE

            //            // "was_paused" will be true if entering this "run" loop from a paused state.
            //            if (was_paused)
            //            {
            //                initial_seconds += paused_seconds;
            //                was_paused = false;
            //            }
            //            current_seconds = getcurrentseconds(); // Seconds since 1 Jan 1970
            //            actual_elapsed_time = current_seconds - initial_seconds;
            //                // Real world elapsed seconds since start
            //            sim_lag_time = actual_elapsed_time - FDMExec->GetSimTime();
            //                // How far behind sim-time is from actual
            //            // elapsed time.
            //            for (int i = 0; i < (int) (sim_lag_time/frame_duration); i++)
            //            {
            //                // catch up sim time to actual elapsed time.
            //                result = FDMExec->Run();
            //                cycle_duration = getcurrentseconds() - current_seconds; // Calculate cycle duration
            //                current_seconds = getcurrentseconds(); // Get new current_seconds
            //                if (FDMExec->Holding()) break;
            //            }

            //            if (play_nice) sim_nsleep(sleep_nseconds);

            //            if (FDMExec->GetSimTime() >= new_five_second_value)
            //            {
            //                // Print out elapsed time every five seconds.
            //                cout << "Simulation elapsed time: " << FDMExec->GetSimTime() << endl;
            //                new_five_second_value += 5.0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // Suspended
            //        was_paused = true;
            //        paused_seconds = getcurrentseconds() - current_seconds;
            //        sim_nsleep(sleep_nseconds);
            //        result = FDMExec->Run();
            //    }

            //}

            //quit:

            //// PRINT ENDING CLOCK TIME
            //time(&tod);
            //strftime(s, 99, "%A %B %d %Y %X", localtime(&tod));
            //cout << "End: " << s << " (HH:MM:SS)" << endl;

            //// CLEAN UP
            //delete FDMExec;

            return;
        }

        //private bool ParseOptions(int count, string[] args)
        //{
        //    int i;
        //    bool result = true;
        //    string optionKey;
        //    string optionValue;

        //    if (count == 1)
        //    {
        //        PrintHelp();
        //        Environment.Exit(0);
        //    }

        //    foreach (var arg in args)
        //    {
        //        var match = Regex.Match(arg, @"([A-Za-z0-9\-]+)=([A-Za-z0-9\-]+)", RegexOptions.IgnoreCase);

        //        if (match.Success)
        //        {
        //            optionKey = match.Groups[1].Value;
        //            optionValue = match.Groups[2].Value;

        //            if (optionKey == "--help")
        //            {
        //                PrintHelp();
        //                Environment.Exit(0);
        //            }

        //            if (optionKey == "--version")
        //            {
        //                System.Console.WriteLine("Version: 0.1");
        //                Environment.Exit(0);
        //            }

        //            if (optionKey == "--realtime")
        //            {
        //                hasToRunInRealtime = true;
        //            }

        //            if (optionKey == "--nice")
        //            {
        //                hasToPlayNice = true;
        //            }

        //            if (optionKey == "--suspend")
        //            {
        //                hasToSuspendAfterInitialization = true;
        //            }

        //            if (optionKey == "--outputlogfile")
        //            {
        //                logOutputName = optionValue;
        //            }

        //            if (optionKey == "--logdirectivefile")
        //            {
        //                logDirectiveName = optionValue;
        //            }

        //            if (optionKey == "--root")
        //            {
        //                rootDir = optionValue;
        //            }

        //            if (optionKey == "--aircraft")
        //            {
        //                aircraftName = optionValue;
        //            }

        //            if (optionKey == "--script")
        //            {
        //                scriptName = optionValue;
        //            }

        //            if (optionKey == "--initfile")
        //            {
        //                resetName = optionValue;
        //            }

        //            if (optionKey == "--catalog")
        //            {
        //                catalog = true;
        //            }

        //            if (optionKey == "--property")
        //            {
        //                var propertyMatch = Regex.Match(arg, @"([A-Za-z0-9\-]+)=([A-Za-z0-9\-]+)",
        //                                                RegexOptions.IgnoreCase);
        //                if (propertyMatch.Success)
        //                {
        //                    propertyName = match.Groups[1].Value;
        //                    propertyValue = match.Groups[2].Value;
        //                }
        //            }

        //            if (optionKey == "--end-time")
        //            {
        //                endTime = optionValue;
        //            }
        //        }
        //    }
        //}

        //private void PrintHelp()
        //{
        //    System.Console.WriteLine("FDM version 0.1");
        //    System.Console.WriteLine("  Usage: jsbsim <options>");
        //    System.Console.WriteLine("  options:");
        //    System.Console.WriteLine("    --help  returns this message");
        //    System.Console.WriteLine("    --version  returns the version number");
        //    System.Console.WriteLine("    --outputlogfile=<filename>  sets (overrides) the name of the data output file");
        //    System.Console.WriteLine(
        //        "    --logdirectivefile=<filename>  specifies (overrides) the name of the data logging directives file");
        //    System.Console.WriteLine(
        //        "    --root=<path>  specifies the JSBSim root directory (where aircraft/, engine/, etc. reside)");
        //    System.Console.WriteLine("    --aircraft=<filename>  specifies the name of the aircraft to be modeled");
        //    System.Console.WriteLine("    --script=<filename>  specifies a script to run");
        //    System.Console.WriteLine("    --realtime  specifies to run in actual real world time");
        //    System.Console.WriteLine("    --nice  specifies to run at lower CPU usage");
        //    System.Console.WriteLine("    --suspend  specifies to suspend the simulation after initialization");
        //    System.Console.WriteLine("    --initfile=<filename>  specifies an initilization file");
        //    System.Console.WriteLine(
        //        "    --catalog specifies that all properties for this aircraft model should be printed");
        //    System.Console.WriteLine("    --property=<property_name=property_value> e.g. --property=aero/qbar-psf=3.4");
        //    System.Console.WriteLine("    --end-time=<time (double)> specifies the sim end time");
        //}
    }
}