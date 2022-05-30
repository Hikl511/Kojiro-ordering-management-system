namespace Kojiro_ordering_management_system
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butClose = new System.Windows.Forms.Button();
            this.butMinimize = new System.Windows.Forms.Button();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiTextBox2 = new Sunny.UI.UITextBox();
            this.uiTextBox3 = new Sunny.UI.UITextBox();
            this.uiTextBox6 = new Sunny.UI.UITextBox();
            this.uiTextBox7 = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.Location = new System.Drawing.Point(361, 462);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 18;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "返回登录";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(104, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "验证码错误！";
            this.label8.Visible = false;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Location = new System.Drawing.Point(280, 345);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(60, 24);
            this.pictureBox11.TabIndex = 39;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Click += new System.EventHandler(this.pictureBox11_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.butClose);
            this.panel1.Controls.Add(this.butMinimize);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 149);
            this.panel1.TabIndex = 58;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kojiro_ordering_management_system.Properties.Resources.Logo_小次郎_拷贝1;
            this.pictureBox1.Location = new System.Drawing.Point(-20, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.FlatAppearance.BorderSize = 0;
            this.butClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.ForeColor = System.Drawing.SystemColors.Window;
            this.butClose.Location = new System.Drawing.Point(410, 0);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(22, 28);
            this.butClose.TabIndex = 15;
            this.butClose.Text = "O";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butMinimize
            // 
            this.butMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMinimize.FlatAppearance.BorderSize = 0;
            this.butMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMinimize.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12.75F);
            this.butMinimize.ForeColor = System.Drawing.SystemColors.Window;
            this.butMinimize.Location = new System.Drawing.Point(377, 0);
            this.butMinimize.Name = "butMinimize";
            this.butMinimize.Size = new System.Drawing.Size(25, 25);
            this.butMinimize.TabIndex = 16;
            this.butMinimize.Text = "O";
            this.butMinimize.UseVisualStyleBackColor = true;
            this.butMinimize.Click += new System.EventHandler(this.butMinimize_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(184)))), ((int)(((byte)(250)))));
            this.uiButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(184)))), ((int)(((byte)(250)))));
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.uiButton1.Location = new System.Drawing.Point(129, 412);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(170, 32);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 59;
            this.uiButton1.Text = "注  册";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox1.ButtonSymbolSize = 22;
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox1.Icon = global::Kojiro_ordering_management_system.Properties.Resources.用户_拷贝png;
            this.uiTextBox1.IconSize = 20;
            this.uiTextBox1.Location = new System.Drawing.Point(106, 176);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(234, 29);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.Symbol = 1;
            this.uiTextBox1.TabIndex = 60;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "账号";
            this.uiTextBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox2
            // 
            this.uiTextBox2.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox2.ButtonSymbolSize = 22;
            this.uiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox2.Icon = global::Kojiro_ordering_management_system.Properties.Resources.密码;
            this.uiTextBox2.Location = new System.Drawing.Point(106, 215);
            this.uiTextBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox2.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox2.Name = "uiTextBox2";
            this.uiTextBox2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox2.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox2.ShowText = false;
            this.uiTextBox2.Size = new System.Drawing.Size(234, 29);
            this.uiTextBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox2.Symbol = 1;
            this.uiTextBox2.TabIndex = 61;
            this.uiTextBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox2.Watermark = "密码";
            this.uiTextBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox3.ButtonSymbolSize = 22;
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox3.Icon = global::Kojiro_ordering_management_system.Properties.Resources.密码;
            this.uiTextBox3.Location = new System.Drawing.Point(106, 262);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox3.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox3.ShowText = false;
            this.uiTextBox3.Size = new System.Drawing.Size(234, 29);
            this.uiTextBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox3.Symbol = 1;
            this.uiTextBox3.TabIndex = 61;
            this.uiTextBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox3.Watermark = "确认密码";
            this.uiTextBox3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox6
            // 
            this.uiTextBox6.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox6.ButtonSymbolSize = 22;
            this.uiTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox6.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox6.Icon = global::Kojiro_ordering_management_system.Properties.Resources.电话;
            this.uiTextBox6.IconSize = 20;
            this.uiTextBox6.Location = new System.Drawing.Point(106, 301);
            this.uiTextBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox6.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox6.Name = "uiTextBox6";
            this.uiTextBox6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox6.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox6.ShowText = false;
            this.uiTextBox6.Size = new System.Drawing.Size(234, 29);
            this.uiTextBox6.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox6.Symbol = 1;
            this.uiTextBox6.TabIndex = 61;
            this.uiTextBox6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox6.Watermark = "手机";
            this.uiTextBox6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox7
            // 
            this.uiTextBox7.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox7.ButtonSymbolSize = 22;
            this.uiTextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox7.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTextBox7.Icon = global::Kojiro_ordering_management_system.Properties.Resources.验证码;
            this.uiTextBox7.IconSize = 20;
            this.uiTextBox7.Location = new System.Drawing.Point(106, 340);
            this.uiTextBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox7.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox7.Name = "uiTextBox7";
            this.uiTextBox7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox7.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(30)))), ((int)(((byte)(63)))));
            this.uiTextBox7.ShowText = false;
            this.uiTextBox7.Size = new System.Drawing.Size(167, 29);
            this.uiTextBox7.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox7.Symbol = 1;
            this.uiTextBox7.TabIndex = 62;
            this.uiTextBox7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox7.Watermark = "验证码";
            this.uiTextBox7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(436, 483);
            this.Controls.Add(this.uiTextBox7);
            this.Controls.Add(this.uiTextBox6);
            this.Controls.Add(this.uiTextBox3);
            this.Controls.Add(this.uiTextBox2);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.linkLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butMinimize;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UITextBox uiTextBox3;
        private Sunny.UI.UITextBox uiTextBox6;
        private Sunny.UI.UITextBox uiTextBox7;
    }
}