namespace PasswordStrengthTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            PasswordStrength.PasswordBar passwordBar1 = new PasswordStrength.PasswordBar();
            PasswordStrength.PasswordBar passwordBar2 = new PasswordStrength.PasswordBar();
            PasswordStrength.PasswordBar passwordBar3 = new PasswordStrength.PasswordBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordStrength1 = new PasswordStrength.PasswordStrength();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "通过设置CurrentPasswordLevel属性来\r\n显示当前的密码强度等级，具体的等级规\r\n则自己定义";
            // 
            // passwordStrength1
            // 
            this.passwordStrength1.BarBackColor = System.Drawing.Color.Silver;
            passwordBar1.BarColor = System.Drawing.Color.Red;
            passwordBar1.Content = "弱";
            passwordBar2.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(70)))));
            passwordBar2.Content = "中";
            passwordBar3.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            passwordBar3.Content = "强";
            this.passwordStrength1.BarContentList.Add(passwordBar1);
            this.passwordStrength1.BarContentList.Add(passwordBar2);
            this.passwordStrength1.BarContentList.Add(passwordBar3);
            this.passwordStrength1.BarHeight = 5;
            this.passwordStrength1.CurrentPasswordLevel = 0;
            this.passwordStrength1.Gap = 5;
            this.passwordStrength1.Location = new System.Drawing.Point(32, 58);
            this.passwordStrength1.Name = "passwordStrength1";
            this.passwordStrength1.Padding = new System.Windows.Forms.Padding(1);
            this.passwordStrength1.Radius = 12;
            this.passwordStrength1.Size = new System.Drawing.Size(200, 30);
            this.passwordStrength1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 142);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordStrength1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PasswordStrength.PasswordStrength passwordStrength1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

