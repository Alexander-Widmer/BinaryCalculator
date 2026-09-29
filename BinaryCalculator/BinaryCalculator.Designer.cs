namespace MB01.A1_2_5
{
    partial class BinaryCalculator
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
            CmdBit128 = new Button();
            CmdBit64 = new Button();
            CmdBit32 = new Button();
            CmdBit16 = new Button();
            CmdBit8 = new Button();
            CmdBit4 = new Button();
            CmdBit2 = new Button();
            CmdBit1 = new Button();
            CmdCalculateDecimal = new Button();
            CmdReset = new Button();
            LblDecimalValue = new Label();
            SuspendLayout();
            // 
            // CmdBit128
            // 
            CmdBit128.Location = new Point(14, 16);
            CmdBit128.Margin = new Padding(3, 4, 3, 4);
            CmdBit128.Name = "CmdBit128";
            CmdBit128.Size = new Size(29, 33);
            CmdBit128.TabIndex = 0;
            CmdBit128.Text = "0";
            CmdBit128.UseVisualStyleBackColor = true;
            CmdBit128.Click += CmdBit128_Click;
            // 
            // CmdBit64
            // 
            CmdBit64.Location = new Point(49, 16);
            CmdBit64.Margin = new Padding(3, 4, 3, 4);
            CmdBit64.Name = "CmdBit64";
            CmdBit64.Size = new Size(29, 33);
            CmdBit64.TabIndex = 1;
            CmdBit64.Text = "0";
            CmdBit64.UseVisualStyleBackColor = true;
            CmdBit64.Click += CmdBit64_Click;
            // 
            // CmdBit32
            // 
            CmdBit32.Location = new Point(85, 16);
            CmdBit32.Margin = new Padding(3, 4, 3, 4);
            CmdBit32.Name = "CmdBit32";
            CmdBit32.Size = new Size(29, 33);
            CmdBit32.TabIndex = 2;
            CmdBit32.Text = "0";
            CmdBit32.UseVisualStyleBackColor = true;
            CmdBit32.Click += CmdBit32_Click;
            // 
            // CmdBit16
            // 
            CmdBit16.Location = new Point(120, 16);
            CmdBit16.Margin = new Padding(3, 4, 3, 4);
            CmdBit16.Name = "CmdBit16";
            CmdBit16.Size = new Size(29, 33);
            CmdBit16.TabIndex = 3;
            CmdBit16.Text = "0";
            CmdBit16.UseVisualStyleBackColor = true;
            CmdBit16.Click += CmdBit16_Click;
            // 
            // CmdBit8
            // 
            CmdBit8.Location = new Point(155, 16);
            CmdBit8.Margin = new Padding(3, 4, 3, 4);
            CmdBit8.Name = "CmdBit8";
            CmdBit8.Size = new Size(29, 33);
            CmdBit8.TabIndex = 4;
            CmdBit8.Text = "0";
            CmdBit8.UseVisualStyleBackColor = true;
            CmdBit8.Click += CmdBit8_Click;
            // 
            // CmdBit4
            // 
            CmdBit4.Location = new Point(191, 16);
            CmdBit4.Margin = new Padding(3, 4, 3, 4);
            CmdBit4.Name = "CmdBit4";
            CmdBit4.Size = new Size(29, 33);
            CmdBit4.TabIndex = 5;
            CmdBit4.Text = "0";
            CmdBit4.UseVisualStyleBackColor = true;
            CmdBit4.Click += CmdBit4_Click;
            // 
            // CmdBit2
            // 
            CmdBit2.Location = new Point(226, 16);
            CmdBit2.Margin = new Padding(3, 4, 3, 4);
            CmdBit2.Name = "CmdBit2";
            CmdBit2.Size = new Size(29, 33);
            CmdBit2.TabIndex = 6;
            CmdBit2.Text = "0";
            CmdBit2.UseVisualStyleBackColor = true;
            CmdBit2.Click += CmdBit2_Click;
            // 
            // CmdBit1
            // 
            CmdBit1.Location = new Point(262, 16);
            CmdBit1.Margin = new Padding(3, 4, 3, 4);
            CmdBit1.Name = "CmdBit1";
            CmdBit1.Size = new Size(29, 33);
            CmdBit1.TabIndex = 7;
            CmdBit1.Text = "0";
            CmdBit1.UseVisualStyleBackColor = true;
            CmdBit1.Click += CmdBit1_Click;
            // 
            // CmdCalculateDecimal
            // 
            CmdCalculateDecimal.Location = new Point(14, 57);
            CmdCalculateDecimal.Margin = new Padding(3, 4, 3, 4);
            CmdCalculateDecimal.Name = "CmdCalculateDecimal";
            CmdCalculateDecimal.Size = new Size(277, 36);
            CmdCalculateDecimal.TabIndex = 8;
            CmdCalculateDecimal.Text = "Berechne Dezimalwert";
            CmdCalculateDecimal.UseVisualStyleBackColor = true;
            CmdCalculateDecimal.Click += CmdCalculateDecimal_Click;
            // 
            // CmdReset
            // 
            CmdReset.Location = new Point(14, 101);
            CmdReset.Margin = new Padding(3, 4, 3, 4);
            CmdReset.Name = "CmdReset";
            CmdReset.Size = new Size(277, 36);
            CmdReset.TabIndex = 9;
            CmdReset.Text = "Setze zurück";
            CmdReset.UseVisualStyleBackColor = true;
            CmdReset.Click += CmdReset_Click;
            // 
            // LblDecimalValue
            // 
            LblDecimalValue.AutoSize = true;
            LblDecimalValue.Location = new Point(14, 156);
            LblDecimalValue.Name = "LblDecimalValue";
            LblDecimalValue.Size = new Size(130, 20);
            LblDecimalValue.TabIndex = 10;
            LblDecimalValue.Text = "Wert in Dezimal: 0";
            // 
            // BinaryCalculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 414);
            Controls.Add(LblDecimalValue);
            Controls.Add(CmdReset);
            Controls.Add(CmdCalculateDecimal);
            Controls.Add(CmdBit1);
            Controls.Add(CmdBit2);
            Controls.Add(CmdBit4);
            Controls.Add(CmdBit8);
            Controls.Add(CmdBit16);
            Controls.Add(CmdBit32);
            Controls.Add(CmdBit64);
            Controls.Add(CmdBit128);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BinaryCalculator";
            Text = "Binär Rechner";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CmdBit128;
        private Button CmdBit64;
        private Button CmdBit32;
        private Button CmdBit16;
        private Button CmdBit8;
        private Button CmdBit4;
        private Button CmdBit2;
        private Button CmdBit1;
        private Button CmdCalculateDecimal;
        private Button CmdReset;
        private Label LblDecimalValue;
    }
}