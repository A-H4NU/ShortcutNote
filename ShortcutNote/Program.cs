using ConsoleHotKey;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutNote
{
    public static class Program
    {
        private static readonly List<int> _hotkeys = new List<int>();

        private static ShortcutNote _snf;

        private static Thread _worker;

        private static bool _working = true;

        private static string _noteDirectory;

        [STAThread]
        static void Main()
        {
            Process[] pname = Process.GetProcessesByName("ShortcutNote.exe");
            if (pname.Length > 1) return;

            PrepareNoteDirectory();
            PrepareStartupRun();

            _hotkeys.Add(HotKeyManager.RegisterHotKey(Keys.N, KeyModifiers.Alt));
            _hotkeys.Add(HotKeyManager.RegisterHotKey(Keys.M, KeyModifiers.Alt));
            HotKeyManager.HotKeyPressed += HotKeyPressed;

            _worker = new Thread(WorkerThread);
            _worker.IsBackground = false;
            _worker.Start();

            _snf = new ShortcutNote();
            _snf.Visible = false;
            _snf.ExitNote += OnExitNote;
            _snf.ShowDialog();
        }

        private static void HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (e.Key == Keys.N)
            {
                _snf.ShowInTaskbar = true;
                _snf.Visible = true;
                _snf.Activate();
            }
            if (e.Key == Keys.M)
            {
                Process.Start(_noteDirectory);
            }
        }

        private static void PrepareNoteDirectory()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _noteDirectory = appdata + @"\ShortcutNote";

            if (!Directory.Exists(_noteDirectory))
                Directory.CreateDirectory(_noteDirectory);
        }

        private static void PrepareStartupRun()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (reg.GetValue("ShortcutNote") == null)
                reg.SetValue("ShortcutNote", Application.ExecutablePath);
        }

        private static void OnExitNote(object sender, ExitNoteEvenArgs e)
        {
            string content = e.NoteContent;
            string filepath = Path.Combine(_noteDirectory, $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss_ffff}.txt");

            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Flush();
            }
        }

        private static void WorkerThread()
        {
            while (_working)
            {
                Thread.Sleep(100);
            }
        }
    }
}
