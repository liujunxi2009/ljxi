namespace JsonProcess
{
  partial class ShrotCutWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.start_elac = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // start_elac
      // 
      this.start_elac.Location = new System.Drawing.Point(12, 12);
      this.start_elac.Name = "start_elac";
      this.start_elac.Size = new System.Drawing.Size(80, 53);
      this.start_elac.TabIndex = 0;
      this.start_elac.Text = "计算器";
      this.start_elac.UseVisualStyleBackColor = true;
      this.start_elac.Click += new System.EventHandler(this.start_elac_Click);
      // 
      // ShrotCutWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(780, 210);
      this.Controls.Add(this.start_elac);
      this.Name = "ShrotCutWindow";
      this.Text = "ShrotCutWindow";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button start_elac;
  }
}