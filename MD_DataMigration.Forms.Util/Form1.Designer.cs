namespace MD_DataMigration.Forms.Util
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnReadQuery = new System.Windows.Forms.Button();
            this.txtQueryId = new System.Windows.Forms.TextBox();
            this.btnGenConvertCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(17, 370);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(570, 320);
            this.txtResult.TabIndex = 17;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(12, 324);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(165, 22);
            this.txtTableName.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(184, 315);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 37);
            this.button6.TabIndex = 15;
            this.button6.Text = "MDPark 테이블 생성";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(306, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 162);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(184, 130);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 33);
            this.button5.TabIndex = 13;
            this.button5.Text = "ACCESS BLOB";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 33);
            this.button4.TabIndex = 12;
            this.button4.Text = "MS Access Conn";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 36);
            this.button3.TabIndex = 11;
            this.button3.Text = "syBase conn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "mariadb conn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "mssql conn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(184, 273);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(238, 36);
            this.button7.TabIndex = 18;
            this.button7.Text = "클래스 파일생성(전체테이블)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(664, 370);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(570, 320);
            this.txtQuery.TabIndex = 17;
            // 
            // btnReadQuery
            // 
            this.btnReadQuery.Location = new System.Drawing.Point(842, 315);
            this.btnReadQuery.Name = "btnReadQuery";
            this.btnReadQuery.Size = new System.Drawing.Size(159, 37);
            this.btnReadQuery.TabIndex = 15;
            this.btnReadQuery.Text = "xml쿼리 읽어오기";
            this.btnReadQuery.UseVisualStyleBackColor = true;
            this.btnReadQuery.Click += new System.EventHandler(this.btnReadQuery_Click);
            // 
            // txtQueryId
            // 
            this.txtQueryId.Location = new System.Drawing.Point(670, 324);
            this.txtQueryId.Name = "txtQueryId";
            this.txtQueryId.Size = new System.Drawing.Size(165, 22);
            this.txtQueryId.TabIndex = 16;
            // 
            // btnGenConvertCode
            // 
            this.btnGenConvertCode.Location = new System.Drawing.Point(349, 316);
            this.btnGenConvertCode.Name = "btnGenConvertCode";
            this.btnGenConvertCode.Size = new System.Drawing.Size(144, 36);
            this.btnGenConvertCode.TabIndex = 19;
            this.btnGenConvertCode.Text = "컨버트 코드생성";
            this.btnGenConvertCode.UseVisualStyleBackColor = true;
            this.btnGenConvertCode.Click += new System.EventHandler(this.btnGenConvertCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 791);
            this.Controls.Add(this.btnGenConvertCode);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtQueryId);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnReadQuery);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnReadQuery;
        private System.Windows.Forms.TextBox txtQueryId;
        private System.Windows.Forms.Button btnGenConvertCode;
    }
}

