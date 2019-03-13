namespace zd_lab1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеКлючамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportPubKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportPubKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelitPairKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePrivKey = new System.Windows.Forms.ToolStripMenuItem();
            this.tbEditDocument = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnLoadDocument = new System.Windows.Forms.Button();
            this.btnSaveDocument = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.управлениеКлючамиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreate,
            this.tsmiLoad,
            this.tsmiSave,
            this.toolStripSeparator2,
            this.tsmiExit,
            this.toolStripSeparator1,
            this.tsmiAbout});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(57, 24);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiCreate
            // 
            this.tsmiCreate.Enabled = false;
            this.tsmiCreate.Name = "tsmiCreate";
            this.tsmiCreate.Size = new System.Drawing.Size(216, 26);
            this.tsmiCreate.Text = "Создать";
            this.tsmiCreate.Click += new System.EventHandler(this.tsmiCreate_Click);
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.Enabled = false;
            this.tsmiLoad.Name = "tsmiLoad";
            this.tsmiLoad.Size = new System.Drawing.Size(216, 26);
            this.tsmiLoad.Text = "Загрузить";
            this.tsmiLoad.Click += new System.EventHandler(this.tsmiLoad_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Enabled = false;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(216, 26);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(216, 26);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(216, 26);
            this.tsmiAbout.Text = "О программе";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // управлениеКлючамиToolStripMenuItem
            // 
            this.управлениеКлючамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportPubKey,
            this.tsmiImportPubKey,
            this.tsmiDelitPairKey,
            this.tsmiChangePrivKey});
            this.управлениеКлючамиToolStripMenuItem.Name = "управлениеКлючамиToolStripMenuItem";
            this.управлениеКлючамиToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.управлениеКлючамиToolStripMenuItem.Text = "Управление ключами";
            // 
            // tsmiExportPubKey
            // 
            this.tsmiExportPubKey.Enabled = false;
            this.tsmiExportPubKey.Name = "tsmiExportPubKey";
            this.tsmiExportPubKey.Size = new System.Drawing.Size(263, 26);
            this.tsmiExportPubKey.Text = "Экспорт открытого ключа";
            this.tsmiExportPubKey.Click += new System.EventHandler(this.tsmiExportPubKey_Click);
            // 
            // tsmiImportPubKey
            // 
            this.tsmiImportPubKey.Enabled = false;
            this.tsmiImportPubKey.Name = "tsmiImportPubKey";
            this.tsmiImportPubKey.Size = new System.Drawing.Size(263, 26);
            this.tsmiImportPubKey.Text = "Импорт открытого ключа";
            this.tsmiImportPubKey.Click += new System.EventHandler(this.tsmiImportPubKey_Click);
            // 
            // tsmiDelitPairKey
            // 
            this.tsmiDelitPairKey.Enabled = false;
            this.tsmiDelitPairKey.Name = "tsmiDelitPairKey";
            this.tsmiDelitPairKey.Size = new System.Drawing.Size(263, 26);
            this.tsmiDelitPairKey.Text = "Удаление пары ключей";
            this.tsmiDelitPairKey.Click += new System.EventHandler(this.tsmiDelitPairKey_Click);
            // 
            // tsmiChangePrivKey
            // 
            this.tsmiChangePrivKey.Name = "tsmiChangePrivKey";
            this.tsmiChangePrivKey.Size = new System.Drawing.Size(263, 26);
            this.tsmiChangePrivKey.Text = "Выбор закрытого ключа";
            this.tsmiChangePrivKey.Click += new System.EventHandler(this.tsmiChangePrivKey_Click);
            // 
            // tbEditDocument
            // 
            this.tbEditDocument.Location = new System.Drawing.Point(12, 108);
            this.tbEditDocument.Multiline = true;
            this.tbEditDocument.Name = "tbEditDocument";
            this.tbEditDocument.Size = new System.Drawing.Size(573, 228);
            this.tbEditDocument.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(13, 47);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(135, 17);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Имя пользователя:";
            // 
            // tbUserName
            // 
            this.tbUserName.Enabled = false;
            this.tbUserName.Location = new System.Drawing.Point(16, 68);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(176, 22);
            this.tbUserName.TabIndex = 3;
            this.tbUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserName_KeyDown_1);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(198, 47);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(125, 43);
            this.btnChangeUser.TabIndex = 4;
            this.btnChangeUser.Text = "Выбрать пользователя";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnLoadDocument
            // 
            this.btnLoadDocument.Enabled = false;
            this.btnLoadDocument.Location = new System.Drawing.Point(329, 47);
            this.btnLoadDocument.Name = "btnLoadDocument";
            this.btnLoadDocument.Size = new System.Drawing.Size(125, 43);
            this.btnLoadDocument.TabIndex = 5;
            this.btnLoadDocument.Text = "Загрузить документ";
            this.btnLoadDocument.UseVisualStyleBackColor = true;
            this.btnLoadDocument.Click += new System.EventHandler(this.btnLoadDocument_Click);
            // 
            // btnSaveDocument
            // 
            this.btnSaveDocument.Enabled = false;
            this.btnSaveDocument.Location = new System.Drawing.Point(460, 47);
            this.btnSaveDocument.Name = "btnSaveDocument";
            this.btnSaveDocument.Size = new System.Drawing.Size(125, 43);
            this.btnSaveDocument.TabIndex = 6;
            this.btnSaveDocument.Text = "Сохранить документ";
            this.btnSaveDocument.UseVisualStyleBackColor = true;
            this.btnSaveDocument.Click += new System.EventHandler(this.btnSaveDocument_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 348);
            this.Controls.Add(this.btnSaveDocument);
            this.Controls.Add(this.btnLoadDocument);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.tbEditDocument);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Подписанный документ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem управлениеКлючамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportPubKey;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportPubKey;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelitPairKey;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePrivKey;
        private System.Windows.Forms.TextBox tbEditDocument;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnLoadDocument;
        private System.Windows.Forms.Button btnSaveDocument;
    }
}

