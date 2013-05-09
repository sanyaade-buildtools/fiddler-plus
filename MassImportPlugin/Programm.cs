﻿/***************************************************************************
 *
 * $Author: Turley
 * 
 * "THE BEER-WARE LICENSE"
 * As long as you retain this notice you can do whatever you want with 
 * this stuff. If we meet some day, and you think this stuff is worth it,
 * you can buy me a beer in return.
 *
 ***************************************************************************/

using System;
using System.Windows.Forms;
using MassImport;

namespace UoFiddler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExeReplacer.RemoveFiles();
            return;

            try
            {
                //Options.Startup();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new GumpCombine());
                Application.Run(new MoveShips());
                // Options.Save();
                FiddlerControls.Map.SaveMapOverlays();
            }
            catch (Exception err)
            {
                Clipboard.SetDataObject(err.ToString(), true);
                Application.Run(new GumpCombine());
            }
        }
    }
}