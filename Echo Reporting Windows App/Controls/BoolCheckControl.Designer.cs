﻿namespace Fetal_Reporting_Windows_App {
	partial class BoolCheckControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.ResultTitleLabel = new System.Windows.Forms.Label();
			this.ResultCheckBox = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ResultTitleLabel
			// 
			this.ResultTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ResultTitleLabel.AutoSize = true;
			this.ResultTitleLabel.Location = new System.Drawing.Point(3, 5);
			this.ResultTitleLabel.Name = "ResultTitleLabel";
			this.ResultTitleLabel.Size = new System.Drawing.Size(83, 13);
			this.ResultTitleLabel.TabIndex = 0;
			this.ResultTitleLabel.Text = "ResultTitleLabel";
			this.ResultTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ResultCheckBox
			// 
			this.ResultCheckBox.AutoSize = true;
			this.ResultCheckBox.Location = new System.Drawing.Point(92, 3);
			this.ResultCheckBox.Name = "ResultCheckBox";
			this.ResultCheckBox.Size = new System.Drawing.Size(105, 17);
			this.ResultCheckBox.TabIndex = 1;
			this.ResultCheckBox.Text = "ResultCheckBox";
			this.ResultCheckBox.UseVisualStyleBackColor = true;
			this.ResultCheckBox.CheckedChanged += new System.EventHandler(this.ResultCheckBox_CheckedChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.ResultTitleLabel);
			this.flowLayoutPanel1.Controls.Add(this.ResultCheckBox);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 26);
			this.flowLayoutPanel1.TabIndex = 2;
			this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
			// 
			// BoolCheckControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "BoolCheckControl";
			this.Size = new System.Drawing.Size(254, 26);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label ResultTitleLabel;
		private System.Windows.Forms.CheckBox ResultCheckBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
