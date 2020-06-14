using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutNote
{
    public partial class ShortcutNote : Form
    {
        public ShortcutNote()
        {
            InitializeComponent();
        }

        public event EventHandler<ExitNoteEvenArgs> ExitNote;

        private void ShortcutNote_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEsc(e);
        }

        private void TxtNote_KeyDown(object sender, KeyEventArgs e)
        {
            CheckEsc(e);
        }

        private void CheckEsc(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                string note = TxtNote.Text;
                if (!String.IsNullOrWhiteSpace(note))
                    ExitNote.Invoke(this, new ExitNoteEvenArgs(note));
                Visible = false;
                ShowInTaskbar = false;
                TxtNote.Text = "";
            }
        }

        private void ShortcutNote_Load(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
        }
    }

    public class ExitNoteEvenArgs : EventArgs
    {
        public string NoteContent { get; private set; } = null;

        public ExitNoteEvenArgs(string noteContent)
        {
            NoteContent = noteContent;
        }
    }
}
