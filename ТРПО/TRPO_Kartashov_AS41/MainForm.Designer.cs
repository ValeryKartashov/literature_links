namespace TRPO_Kartashov_AS41
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbLinksAmountInText = new System.Windows.Forms.TextBox();
            this.lbLinkAmount = new System.Windows.Forms.Label();
            this.lbLinksAmountInList = new System.Windows.Forms.Label();
            this.tbLinksAmountInList = new System.Windows.Forms.TextBox();
            this.lbTextLinks = new System.Windows.Forms.Label();
            this.tbTextLinksList = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pbFileReading = new System.Windows.Forms.ProgressBar();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFile.Location = new System.Drawing.Point(13, 530);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(131, 40);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Выбрать файл";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // tbLinksAmountInText
            // 
            this.tbLinksAmountInText.BackColor = System.Drawing.Color.White;
            this.tbLinksAmountInText.Enabled = false;
            this.tbLinksAmountInText.Location = new System.Drawing.Point(13, 32);
            this.tbLinksAmountInText.Multiline = true;
            this.tbLinksAmountInText.Name = "tbLinksAmountInText";
            this.tbLinksAmountInText.Size = new System.Drawing.Size(404, 27);
            this.tbLinksAmountInText.TabIndex = 99;
            // 
            // lbLinkAmount
            // 
            this.lbLinkAmount.Location = new System.Drawing.Point(13, 9);
            this.lbLinkAmount.Name = "lbLinkAmount";
            this.lbLinkAmount.Size = new System.Drawing.Size(404, 20);
            this.lbLinkAmount.TabIndex = 2;
            this.lbLinkAmount.Text = "Ссылок используется в тексте:";
            this.lbLinkAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLinksAmountInList
            // 
            this.lbLinksAmountInList.Location = new System.Drawing.Point(13, 62);
            this.lbLinksAmountInList.Name = "lbLinksAmountInList";
            this.lbLinksAmountInList.Size = new System.Drawing.Size(404, 20);
            this.lbLinksAmountInList.TabIndex = 4;
            this.lbLinksAmountInList.Text = "Ссылок в списке литературы:";
            this.lbLinksAmountInList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLinksAmountInList
            // 
            this.tbLinksAmountInList.BackColor = System.Drawing.Color.White;
            this.tbLinksAmountInList.Enabled = false;
            this.tbLinksAmountInList.Location = new System.Drawing.Point(13, 85);
            this.tbLinksAmountInList.Multiline = true;
            this.tbLinksAmountInList.Name = "tbLinksAmountInList";
            this.tbLinksAmountInList.Size = new System.Drawing.Size(404, 27);
            this.tbLinksAmountInList.TabIndex = 98;
            // 
            // lbTextLinks
            // 
            this.lbTextLinks.Location = new System.Drawing.Point(13, 115);
            this.lbTextLinks.Name = "lbTextLinks";
            this.lbTextLinks.Size = new System.Drawing.Size(404, 20);
            this.lbTextLinks.TabIndex = 100;
            this.lbTextLinks.Text = "Порядок ссылок в тексте:";
            this.lbTextLinks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTextLinksList
            // 
            this.tbTextLinksList.BackColor = System.Drawing.Color.White;
            this.tbTextLinksList.Enabled = false;
            this.tbTextLinksList.ForeColor = System.Drawing.Color.Black;
            this.tbTextLinksList.Location = new System.Drawing.Point(13, 138);
            this.tbTextLinksList.Multiline = true;
            this.tbTextLinksList.Name = "tbTextLinksList";
            this.tbTextLinksList.Size = new System.Drawing.Size(404, 174);
            this.tbTextLinksList.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(288, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(151, 530);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pbFileReading
            // 
            this.pbFileReading.ForeColor = System.Drawing.Color.White;
            this.pbFileReading.Location = new System.Drawing.Point(12, 511);
            this.pbFileReading.Name = "pbFileReading";
            this.pbFileReading.Size = new System.Drawing.Size(404, 13);
            this.pbFileReading.TabIndex = 6;
            // 
            // lbInfo
            // 
            this.lbInfo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbInfo.Location = new System.Drawing.Point(13, 573);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(406, 23);
            this.lbInfo.TabIndex = 8;
            this.lbInfo.Text = "(с) Карташов, 2022";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbResult
            // 
            this.lbResult.Location = new System.Drawing.Point(13, 315);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(404, 20);
            this.lbResult.TabIndex = 102;
            this.lbResult.Text = "Результаты:";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbResult
            // 
            this.tbResult.BackColor = System.Drawing.Color.White;
            this.tbResult.Enabled = false;
            this.tbResult.ForeColor = System.Drawing.Color.Black;
            this.tbResult.Location = new System.Drawing.Point(12, 338);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(404, 167);
            this.tbResult.TabIndex = 101;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 605);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.lbTextLinks);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.tbTextLinksList);
            this.Controls.Add(this.pbFileReading);
            this.Controls.Add(this.lbLinkAmount);
            this.Controls.Add(this.tbLinksAmountInList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbLinksAmountInList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.tbLinksAmountInText);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Состояние";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbLinksAmountInText;
        private System.Windows.Forms.Label lbLinkAmount;
        private System.Windows.Forms.Label lbLinksAmountInList;
        private System.Windows.Forms.TextBox tbLinksAmountInList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar pbFileReading;
        private System.Windows.Forms.TextBox tbTextLinksList;
        private System.Windows.Forms.Label lbTextLinks;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox tbResult;
    }
}

