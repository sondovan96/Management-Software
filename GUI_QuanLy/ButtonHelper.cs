using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;

namespace LookUpEdit_Add_Button_To_Popup
{
    public class ButtonHelper
    {
        public ButtonHelper()
        {
            _controls = new List<Control>();
        }
        public void AddButtons(Control form, Control[] controls)
        {
            int index = 0;
            _controls.Clear();
            foreach (Control control in controls)
            {
                control.TabIndex = index++;
                form.Controls.Add(control);
                _controls.Add(control);
            }
            UpdateButtonsSizeAndLocation(form);
            form.SizeChanged += FormOnSizeChanged;
            _size = form.Size;
        }

        public void UpdateButtonsSizeAndLocation(Control form)
        {
            if (_controls.Count == 0)
                return;
            int offset = 0;
            List<int> yAndHeight = FindYAndHeight(form.Controls);
            foreach (Control control in _controls)
            {
                control.Size = new Size(70, yAndHeight[1]);
                offset += control.Size.Width + 20;
                control.Location = new Point(form.Width - offset, yAndHeight[0]);
            }
        }

        List<int> FindYAndHeight(Control.ControlCollection collection)
        {
            List<int> list = new List<int>();
            foreach (Control cntrl in collection)
                if (cntrl is CloseButton)
                {
                    list.Add(cntrl.Location.Y);
                    list.Add(cntrl.Size.Height);
                    break;
                }
            return list;
        }

        private Size _size;
        private List<Control> _controls;
        private void FormOnSizeChanged(object sender, EventArgs eventArgs)
        {
            PopupBaseForm form = sender as PopupBaseForm;
            foreach (Control control in _controls)
                control.Location = new Point(control.Location.X - _size.Width + form.Width, control.Location.Y - _size.Height + form.Height);
            _size = form.Size;
        }
    }
}
