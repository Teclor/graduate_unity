namespace BeatThis.Tools
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
            this.components = new System.ComponentModel.Container();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FileBtnLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.OpenTrackBtn = new System.Windows.Forms.Button();
            this.SaveTimestampsBtn = new System.Windows.Forms.Button();
            this.MarkBtnLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.panSlider1 = new NAudio.Gui.PanSlider();
            this.TrackInfoLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.TrackNameLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BpmLabel = new System.Windows.Forms.Label();
            this.BpmInput = new System.Windows.Forms.NumericUpDown();
            this.AutoSetBpmBtn = new System.Windows.Forms.Button();
            this.UseMetronomeCheckbox = new System.Windows.Forms.CheckBox();
            this.FillTimestampsBtn = new System.Windows.Forms.Button();
            this.TrackLengthLabel = new System.Windows.Forms.Label();
            this.SecondsPassedLabel = new System.Windows.Forms.Label();
            this.SecondsLeftLabel = new System.Windows.Forms.Label();
            this.TimestampsCountLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.DiscardBtn = new System.Windows.Forms.Button();
            this.TimestampList = new System.Windows.Forms.ListView();
            this.OpenTrackDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveTimestampsDialog = new System.Windows.Forms.SaveFileDialog();
            this.ProgressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.MainLayout.SuspendLayout();
            this.FileBtnLayout.SuspendLayout();
            this.MarkBtnLayout.SuspendLayout();
            this.TrackInfoLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BpmInput)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.52532F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.47468F));
            this.MainLayout.Controls.Add(this.FileBtnLayout, 1, 1);
            this.MainLayout.Controls.Add(this.MarkBtnLayout, 0, 1);
            this.MainLayout.Controls.Add(this.TrackInfoLayout, 1, 0);
            this.MainLayout.Controls.Add(this.TimestampList, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.10654F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.893456F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(1264, 681);
            this.MainLayout.TabIndex = 0;
            // 
            // FileBtnLayout
            // 
            this.FileBtnLayout.Controls.Add(this.OpenTrackBtn);
            this.FileBtnLayout.Controls.Add(this.SaveTimestampsBtn);
            this.FileBtnLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBtnLayout.Location = new System.Drawing.Point(629, 616);
            this.FileBtnLayout.Name = "FileBtnLayout";
            this.FileBtnLayout.Size = new System.Drawing.Size(632, 62);
            this.FileBtnLayout.TabIndex = 3;
            // 
            // OpenTrackBtn
            // 
            this.OpenTrackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenTrackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenTrackBtn.Location = new System.Drawing.Point(3, 3);
            this.OpenTrackBtn.Name = "OpenTrackBtn";
            this.OpenTrackBtn.Size = new System.Drawing.Size(297, 57);
            this.OpenTrackBtn.TabIndex = 0;
            this.OpenTrackBtn.Text = "Открыть";
            this.OpenTrackBtn.UseVisualStyleBackColor = true;
            this.OpenTrackBtn.Click += new System.EventHandler(this.OnOpenBtnClick);
            // 
            // SaveTimestampsBtn
            // 
            this.SaveTimestampsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveTimestampsBtn.Enabled = false;
            this.SaveTimestampsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveTimestampsBtn.Location = new System.Drawing.Point(306, 3);
            this.SaveTimestampsBtn.Name = "SaveTimestampsBtn";
            this.SaveTimestampsBtn.Size = new System.Drawing.Size(299, 57);
            this.SaveTimestampsBtn.TabIndex = 1;
            this.SaveTimestampsBtn.Text = "Сохранить";
            this.SaveTimestampsBtn.UseVisualStyleBackColor = true;
            this.SaveTimestampsBtn.Click += new System.EventHandler(this.OnSaveBtnClick);
            // 
            // MarkBtnLayout
            // 
            this.MarkBtnLayout.Controls.Add(this.AddBtn);
            this.MarkBtnLayout.Controls.Add(this.RemoveBtn);
            this.MarkBtnLayout.Controls.Add(this.panSlider1);
            this.MarkBtnLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarkBtnLayout.Location = new System.Drawing.Point(3, 616);
            this.MarkBtnLayout.Name = "MarkBtnLayout";
            this.MarkBtnLayout.Size = new System.Drawing.Size(620, 62);
            this.MarkBtnLayout.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(3, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(297, 57);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Добавить метку";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnAddBtnClick);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveBtn.Location = new System.Drawing.Point(306, 3);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(310, 57);
            this.RemoveBtn.TabIndex = 1;
            this.RemoveBtn.Text = "Удалить метки";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.OnRemoveBtnClick);
            // 
            // panSlider1
            // 
            this.panSlider1.Location = new System.Drawing.Point(3, 66);
            this.panSlider1.Name = "panSlider1";
            this.panSlider1.Pan = 0F;
            this.panSlider1.Size = new System.Drawing.Size(8, 8);
            this.panSlider1.TabIndex = 2;
            // 
            // TrackInfoLayout
            // 
            this.TrackInfoLayout.Controls.Add(this.TrackNameLabel);
            this.TrackInfoLayout.Controls.Add(this.ProgressBar);
            this.TrackInfoLayout.Controls.Add(this.flowLayoutPanel1);
            this.TrackInfoLayout.Controls.Add(this.TrackLengthLabel);
            this.TrackInfoLayout.Controls.Add(this.SecondsPassedLabel);
            this.TrackInfoLayout.Controls.Add(this.SecondsLeftLabel);
            this.TrackInfoLayout.Controls.Add(this.TimestampsCountLabel);
            this.TrackInfoLayout.Controls.Add(this.flowLayoutPanel3);
            this.TrackInfoLayout.Controls.Add(this.flowLayoutPanel2);
            this.TrackInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackInfoLayout.Location = new System.Drawing.Point(629, 3);
            this.TrackInfoLayout.Name = "TrackInfoLayout";
            this.TrackInfoLayout.Size = new System.Drawing.Size(632, 607);
            this.TrackInfoLayout.TabIndex = 2;
            // 
            // TrackNameLabel
            // 
            this.TrackNameLabel.AccessibleDescription = "Название трека: ";
            this.TrackNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrackNameLabel.Location = new System.Drawing.Point(3, 0);
            this.TrackNameLabel.Name = "TrackNameLabel";
            this.TrackNameLabel.Size = new System.Drawing.Size(610, 63);
            this.TrackNameLabel.TabIndex = 2;
            this.TrackNameLabel.Text = "Название трека: ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(3, 66);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(610, 41);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 1;
            this.ProgressBar.Tag = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BpmLabel);
            this.flowLayoutPanel1.Controls.Add(this.BpmInput);
            this.flowLayoutPanel1.Controls.Add(this.AutoSetBpmBtn);
            this.flowLayoutPanel1.Controls.Add(this.UseMetronomeCheckbox);
            this.flowLayoutPanel1.Controls.Add(this.FillTimestampsBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 113);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(602, 75);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // BpmLabel
            // 
            this.BpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BpmLabel.Location = new System.Drawing.Point(3, 0);
            this.BpmLabel.Name = "BpmLabel";
            this.BpmLabel.Size = new System.Drawing.Size(58, 34);
            this.BpmLabel.TabIndex = 4;
            this.BpmLabel.Text = "Bpm:";
            // 
            // BpmInput
            // 
            this.BpmInput.DecimalPlaces = 1;
            this.BpmInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BpmInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.BpmInput.Location = new System.Drawing.Point(67, 3);
            this.BpmInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BpmInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BpmInput.Name = "BpmInput";
            this.BpmInput.Size = new System.Drawing.Size(162, 31);
            this.BpmInput.TabIndex = 10;
            this.BpmInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BpmInput.ValueChanged += new System.EventHandler(this.OnBpmInputValueChanged);
            // 
            // AutoSetBpmBtn
            // 
            this.AutoSetBpmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoSetBpmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoSetBpmBtn.Location = new System.Drawing.Point(235, 3);
            this.AutoSetBpmBtn.Name = "AutoSetBpmBtn";
            this.AutoSetBpmBtn.Size = new System.Drawing.Size(352, 31);
            this.AutoSetBpmBtn.TabIndex = 8;
            this.AutoSetBpmBtn.Text = "Определить автоматически";
            this.AutoSetBpmBtn.UseVisualStyleBackColor = true;
            this.AutoSetBpmBtn.Click += new System.EventHandler(this.OnDetectBpmBtnClick);
            // 
            // UseMetronomeCheckbox
            // 
            this.UseMetronomeCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UseMetronomeCheckbox.Location = new System.Drawing.Point(3, 40);
            this.UseMetronomeCheckbox.Name = "UseMetronomeCheckbox";
            this.UseMetronomeCheckbox.Size = new System.Drawing.Size(226, 31);
            this.UseMetronomeCheckbox.TabIndex = 12;
            this.UseMetronomeCheckbox.Text = "Использовать метроном";
            this.UseMetronomeCheckbox.UseVisualStyleBackColor = true;
            // 
            // FillTimestampsBtn
            // 
            this.FillTimestampsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FillTimestampsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FillTimestampsBtn.Location = new System.Drawing.Point(235, 40);
            this.FillTimestampsBtn.Name = "FillTimestampsBtn";
            this.FillTimestampsBtn.Size = new System.Drawing.Size(352, 31);
            this.FillTimestampsBtn.TabIndex = 11;
            this.FillTimestampsBtn.Text = "Проставить метки автоматически";
            this.FillTimestampsBtn.UseVisualStyleBackColor = true;
            this.FillTimestampsBtn.Click += new System.EventHandler(this.OnFillTimestampsBtnClick);
            // 
            // TrackLengthLabel
            // 
            this.TrackLengthLabel.AccessibleDescription = "Длительность трека (секунд): ";
            this.TrackLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrackLengthLabel.Location = new System.Drawing.Point(3, 191);
            this.TrackLengthLabel.Name = "TrackLengthLabel";
            this.TrackLengthLabel.Size = new System.Drawing.Size(610, 63);
            this.TrackLengthLabel.TabIndex = 6;
            this.TrackLengthLabel.Text = "Длительность трека (секунд): ";
            // 
            // SecondsPassedLabel
            // 
            this.SecondsPassedLabel.AccessibleDescription = "Прошло секунд: ";
            this.SecondsPassedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondsPassedLabel.Location = new System.Drawing.Point(3, 254);
            this.SecondsPassedLabel.Name = "SecondsPassedLabel";
            this.SecondsPassedLabel.Size = new System.Drawing.Size(610, 63);
            this.SecondsPassedLabel.TabIndex = 5;
            this.SecondsPassedLabel.Text = "Прошло секунд: ";
            // 
            // SecondsLeftLabel
            // 
            this.SecondsLeftLabel.AccessibleDescription = "Осталось секунд: ";
            this.SecondsLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondsLeftLabel.Location = new System.Drawing.Point(3, 317);
            this.SecondsLeftLabel.Name = "SecondsLeftLabel";
            this.SecondsLeftLabel.Size = new System.Drawing.Size(610, 63);
            this.SecondsLeftLabel.TabIndex = 9;
            this.SecondsLeftLabel.Text = "Осталось секунд: ";
            // 
            // TimestampsCountLabel
            // 
            this.TimestampsCountLabel.AccessibleDescription = "Меток поставлено: ";
            this.TimestampsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimestampsCountLabel.Location = new System.Drawing.Point(3, 380);
            this.TimestampsCountLabel.Name = "TimestampsCountLabel";
            this.TimestampsCountLabel.Size = new System.Drawing.Size(610, 63);
            this.TimestampsCountLabel.TabIndex = 10;
            this.TimestampsCountLabel.Text = "Меток поставлено: ";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.VolumeTrackBar);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 446);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(620, 55);
            this.flowLayoutPanel3.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Громкость: ";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Громкость: ";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.LargeChange = 10;
            this.VolumeTrackBar.Location = new System.Drawing.Point(139, 3);
            this.VolumeTrackBar.Maximum = 100;
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(446, 45);
            this.VolumeTrackBar.TabIndex = 12;
            this.VolumeTrackBar.Value = 10;
            this.VolumeTrackBar.ValueChanged += new System.EventHandler(this.OnVolumeChange);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.StartBtn);
            this.flowLayoutPanel2.Controls.Add(this.PauseBtn);
            this.flowLayoutPanel2.Controls.Add(this.DiscardBtn);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 507);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(610, 71);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // StartBtn
            // 
            this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartBtn.Location = new System.Drawing.Point(3, 3);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(185, 57);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Начать";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.OnStartBtnClick);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseBtn.Location = new System.Drawing.Point(194, 3);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(194, 57);
            this.PauseBtn.TabIndex = 2;
            this.PauseBtn.Text = "Пауза";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.OnPauseBtnClick);
            // 
            // DiscardBtn
            // 
            this.DiscardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscardBtn.Location = new System.Drawing.Point(394, 3);
            this.DiscardBtn.Name = "DiscardBtn";
            this.DiscardBtn.Size = new System.Drawing.Size(185, 57);
            this.DiscardBtn.TabIndex = 3;
            this.DiscardBtn.Text = "Сбросить";
            this.DiscardBtn.UseVisualStyleBackColor = true;
            this.DiscardBtn.Click += new System.EventHandler(this.OnDiscardBtnClick);
            // 
            // TimestampList
            // 
            this.TimestampList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.TimestampList.BackColor = System.Drawing.Color.Cornsilk;
            this.TimestampList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimestampList.HideSelection = false;
            this.TimestampList.Location = new System.Drawing.Point(1, 1);
            this.TimestampList.Margin = new System.Windows.Forms.Padding(1);
            this.TimestampList.Name = "TimestampList";
            this.TimestampList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimestampList.Size = new System.Drawing.Size(618, 611);
            this.TimestampList.TabIndex = 4;
            this.TimestampList.UseCompatibleStateImageBehavior = false;
            this.TimestampList.View = System.Windows.Forms.View.List;
            // 
            // OpenTrackDialog
            // 
            this.OpenTrackDialog.Filter = "mp3 files(*.mp3)|*.mp3|wav files (*.wav)| *.wav";
            // 
            // SaveTimestampsDialog
            // 
            this.SaveTimestampsDialog.Filter = "JSON files (*.json)|*.json";
            // 
            // ProgressBarTimer
            // 
            this.ProgressBarTimer.Tick += new System.EventHandler(this.OnProgressTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.MainLayout);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "Timestamps Creator";
            this.MainLayout.ResumeLayout(false);
            this.FileBtnLayout.ResumeLayout(false);
            this.MarkBtnLayout.ResumeLayout(false);
            this.TrackInfoLayout.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BpmInput)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.FlowLayoutPanel FileBtnLayout;
        private System.Windows.Forms.Button OpenTrackBtn;
        private System.Windows.Forms.Button SaveTimestampsBtn;
        private System.Windows.Forms.FlowLayoutPanel MarkBtnLayout;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.FlowLayoutPanel TrackInfoLayout;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ListView TimestampList;
        private System.Windows.Forms.OpenFileDialog OpenTrackDialog;
        private System.Windows.Forms.SaveFileDialog SaveTimestampsDialog;
        private System.Windows.Forms.Timer ProgressBarTimer;
        private System.Windows.Forms.Label TrackNameLabel;
        private System.Windows.Forms.Label BpmLabel;
        private System.Windows.Forms.Label SecondsPassedLabel;
        private System.Windows.Forms.Label TrackLengthLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AutoSetBpmBtn;
        private System.Windows.Forms.Label SecondsLeftLabel;
        private System.Windows.Forms.Label TimestampsCountLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button DiscardBtn;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private NAudio.Gui.PanSlider panSlider1;
        private System.Windows.Forms.Button FillTimestampsBtn;
        private System.Windows.Forms.CheckBox UseMetronomeCheckbox;
        private System.Windows.Forms.NumericUpDown BpmInput;
    }
}

