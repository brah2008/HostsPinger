using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HostsPinger
{
	public class RegistrationProcess : DevExpress.XtraEditors.XtraForm
    {
		private IContainer components;

		private Label label1;

		public RegistrationProcess()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(50, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(156, 13);
			label1.TabIndex = 0;
			label1.Text = "Registring product. Please wait.";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(256, 55);
			base.ControlBox = false;
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RegistrationProcess";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Registration";
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
