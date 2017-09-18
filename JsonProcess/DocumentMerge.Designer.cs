namespace JsonProcess
{
  partial class DocumentMerge
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.richTextBox2 = new System.Windows.Forms.RichTextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.btn_comparison = new System.Windows.Forms.Button();
      this.txt_merge = new System.Windows.Forms.TextBox();
      this.btn_merge = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.richTextBox3 = new System.Windows.Forms.RichTextBox();
      this.btn_count = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.splitContainer1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1474, 335);
      this.panel1.TabIndex = 0;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
      this.splitContainer1.Size = new System.Drawing.Size(1474, 335);
      this.splitContainer1.SplitterDistance = 715;
      this.splitContainer1.TabIndex = 0;
      // 
      // richTextBox1
      // 
      this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox1.Location = new System.Drawing.Point(0, 0);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(715, 335);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      // 
      // richTextBox2
      // 
      this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox2.Location = new System.Drawing.Point(0, 0);
      this.richTextBox2.Name = "richTextBox2";
      this.richTextBox2.Size = new System.Drawing.Size(755, 335);
      this.richTextBox2.TabIndex = 1;
      this.richTextBox2.Text = "";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btn_count);
      this.panel2.Controls.Add(this.button1);
      this.panel2.Controls.Add(this.btn_comparison);
      this.panel2.Controls.Add(this.txt_merge);
      this.panel2.Controls.Add(this.btn_merge);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 335);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1474, 339);
      this.panel2.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(316, 9);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "取值合并";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btn_comparison
      // 
      this.btn_comparison.Location = new System.Drawing.Point(235, 9);
      this.btn_comparison.Name = "btn_comparison";
      this.btn_comparison.Size = new System.Drawing.Size(75, 23);
      this.btn_comparison.TabIndex = 2;
      this.btn_comparison.Text = "对比";
      this.btn_comparison.UseVisualStyleBackColor = true;
      this.btn_comparison.Click += new System.EventHandler(this.btn_comparison_Click);
      // 
      // txt_merge
      // 
      this.txt_merge.Location = new System.Drawing.Point(12, 9);
      this.txt_merge.Name = "txt_merge";
      this.txt_merge.Size = new System.Drawing.Size(136, 21);
      this.txt_merge.TabIndex = 1;
      this.txt_merge.Text = "|{\"{0}\":\"{1}\"}|";
      // 
      // btn_merge
      // 
      this.btn_merge.Location = new System.Drawing.Point(154, 9);
      this.btn_merge.Name = "btn_merge";
      this.btn_merge.Size = new System.Drawing.Size(75, 23);
      this.btn_merge.TabIndex = 0;
      this.btn_merge.Text = "合并";
      this.btn_merge.UseVisualStyleBackColor = true;
      this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.richTextBox3);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(0, 373);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(1474, 301);
      this.panel3.TabIndex = 2;
      // 
      // richTextBox3
      // 
      this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox3.Location = new System.Drawing.Point(0, 0);
      this.richTextBox3.Name = "richTextBox3";
      this.richTextBox3.Size = new System.Drawing.Size(1474, 301);
      this.richTextBox3.TabIndex = 1;
      this.richTextBox3.Text = "";
      // 
      // btn_count
      // 
      this.btn_count.Location = new System.Drawing.Point(397, 9);
      this.btn_count.Name = "btn_count";
      this.btn_count.Size = new System.Drawing.Size(75, 23);
      this.btn_count.TabIndex = 4;
      this.btn_count.Text = "计数";
      this.btn_count.UseVisualStyleBackColor = true;
      this.btn_count.Click += new System.EventHandler(this.btn_count_Click);
      // 
      // DocumentMerge
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1474, 674);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "DocumentMerge";
      this.Text = "DocumentMerge";
      this.panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.RichTextBox richTextBox2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox txt_merge;
    private System.Windows.Forms.Button btn_merge;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.RichTextBox richTextBox3;
    private System.Windows.Forms.Button btn_comparison;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btn_count;
  }
}