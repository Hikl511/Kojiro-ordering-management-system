namespace Kojiro_ordering_management_system
{
    partial class Orders_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(137, 50);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(40, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(586, 463);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(150, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "暂时没有订单哦(ˉ▽ˉ；)...";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 20F);
            this.label1.Location = new System.Drawing.Point(301, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "我的订单";
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 10F);
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Image = global::Kojiro_ordering_management_system.Properties.Resources.已取消_拷贝;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(12, 316);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 63);
            this.button6.TabIndex = 18;
            this.button6.Text = "   派送中";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 10F);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = global::Kojiro_ordering_management_system.Properties.Resources.已完成;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(12, 395);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 63);
            this.button4.TabIndex = 16;
            this.button4.Text = "  已完成";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Kojiro_ordering_management_system.Properties.Resources.已取消_拷贝;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 63);
            this.button2.TabIndex = 15;
            this.button2.Text = "   已取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 10F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::Kojiro_ordering_management_system.Properties.Resources.订单黑;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 63);
            this.button1.TabIndex = 14;
            this.button1.Text = "     全部订单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = global::Kojiro_ordering_management_system.Properties.Resources.已付款1;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(12, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 63);
            this.button3.TabIndex = 13;
            this.button3.Text = "   已付款";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Orders_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 520);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_Main";
            this.Text = "Orders_Main";
            this.Load += new System.EventHandler(this.Orders_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
    }
}