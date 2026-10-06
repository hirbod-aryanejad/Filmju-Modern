using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Filmju.Activitys;

public class frm_loading : Form
{
	private IContainer components;

	private Label label1;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	public frm_loading()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filmju.Activitys.frm_loading));
		this.label1 = new System.Windows.Forms.Label();
		this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
		this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Yellow;
		this.label1.Location = new System.Drawing.Point(21, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(175, 25);
		this.label1.TabIndex = 0;
		this.label1.Text = "... در حال بارگذاری";
		this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
		this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
		this.shapeContainer1.Name = "shapeContainer1";
		this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[1] { this.rectangleShape1 });
		this.shapeContainer1.Size = new System.Drawing.Size(226, 69);
		this.shapeContainer1.TabIndex = 1;
		this.shapeContainer1.TabStop = false;
		this.rectangleShape1.BackColor = System.Drawing.Color.Yellow;
		this.rectangleShape1.BorderColor = System.Drawing.Color.Yellow;
		this.rectangleShape1.BorderWidth = 3;
		this.rectangleShape1.Location = new System.Drawing.Point(4, 4);
		this.rectangleShape1.Name = "rectangleShape1";
		this.rectangleShape1.Size = new System.Drawing.Size(216, 58);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
		base.ClientSize = new System.Drawing.Size(226, 69);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.shapeContainer1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frm_loading";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frm_loading";
		base.TopMost = true;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
