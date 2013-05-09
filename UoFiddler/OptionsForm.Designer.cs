﻿/***************************************************************************
 *
 * $Author: Turley
 * 
 * "THE BEER-WARE LICENSE"
 * As long as you retain this notice you can do whatever you want with 
 * this stuff. If we meet some day, and you think this stuff is worth it,
 * you can buy me a beer in return.
 *
 ***************************************************************************/

namespace UoFiddler
{
    partial class OptionsForm
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
            this.components = new System.ComponentModel.Container();
            this.checkBoxAltDesign = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseHash = new System.Windows.Forms.CheckBox();
            this.numericUpDownItemSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.checkBoxItemClip = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownItemSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.checkBoxCacheData = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBoxQuintMaps = new System.Windows.Forms.CheckBox();
            this.checkBoxuseDiff = new System.Windows.Forms.CheckBox();
            this.checkBoxNewMapSize = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.map5Nametext = new System.Windows.Forms.TextBox();
            this.argstext = new System.Windows.Forms.TextBox();
            this.cmdtext = new System.Windows.Forms.TextBox();
            this.map4Nametext = new System.Windows.Forms.TextBox();
            this.map3Nametext = new System.Windows.Forms.TextBox();
            this.map2Nametext = new System.Windows.Forms.TextBox();
            this.map1Nametext = new System.Windows.Forms.TextBox();
            this.map0Nametext = new System.Windows.Forms.TextBox();
			this.checkBoxPreAlphaMapSize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemSizeWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAltDesign
            // 
            this.checkBoxAltDesign.AutoSize = true;
            this.checkBoxAltDesign.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAltDesign.Name = "checkBoxAltDesign";
            this.checkBoxAltDesign.Size = new System.Drawing.Size(150, 17);
            this.checkBoxAltDesign.TabIndex = 0;
            this.checkBoxAltDesign.Text = "Альтернативный дизайн";
            this.toolTip1.SetToolTip(this.checkBoxAltDesign, "Alternative layout in item/landtile/texture tab?");
            this.checkBoxAltDesign.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUseHash);
            this.groupBox1.Controls.Add(this.numericUpDownItemSizeHeight);
            this.groupBox1.Controls.Add(this.checkBoxItemClip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownItemSizeWidth);
			this.groupBox1.Location = new System.Drawing.Point(14, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вкладка предметов";
            // 
            // checkBoxUseHash
            // 
            this.checkBoxUseHash.AutoSize = true;
            this.checkBoxUseHash.Location = new System.Drawing.Point(9, 71);
            this.checkBoxUseHash.Name = "checkBoxUseHash";
            this.checkBoxUseHash.Size = new System.Drawing.Size(151, 17);
            this.checkBoxUseHash.TabIndex = 4;
            this.checkBoxUseHash.Text = "Использовать кэш файл";
            this.toolTip1.SetToolTip(this.checkBoxUseHash, "Use Hashfile to speed up load?");
            this.checkBoxUseHash.UseVisualStyleBackColor = true;
            // 
            // numericUpDownItemSizeHeight
            // 
            this.numericUpDownItemSizeHeight.Location = new System.Drawing.Point(118, 19);
            this.numericUpDownItemSizeHeight.Name = "numericUpDownItemSizeHeight";
            this.numericUpDownItemSizeHeight.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownItemSizeHeight.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownItemSizeHeight, "Height");
            // 
            // checkBoxItemClip
            // 
            this.checkBoxItemClip.AutoSize = true;
            this.checkBoxItemClip.Location = new System.Drawing.Point(9, 47);
            this.checkBoxItemClip.Name = "checkBoxItemClip";
            this.checkBoxItemClip.Size = new System.Drawing.Size(129, 17);
            this.checkBoxItemClip.TabIndex = 2;
            this.checkBoxItemClip.Text = "Обрезать предметы";
            this.toolTip1.SetToolTip(this.checkBoxItemClip, "ItemClip images in items tab shrinked or clipped");
            this.checkBoxItemClip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размер";
            this.toolTip1.SetToolTip(this.label1, "ItemSize controls the size of images in items tab");
            // 
            // numericUpDownItemSizeWidth
            // 
            this.numericUpDownItemSizeWidth.Location = new System.Drawing.Point(62, 19);
            this.numericUpDownItemSizeWidth.Name = "numericUpDownItemSizeWidth";
            this.numericUpDownItemSizeWidth.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownItemSizeWidth.TabIndex = 0;
            this.toolTip1.SetToolTip(this.numericUpDownItemSizeWidth, "Width");
            // 
            // checkBoxCacheData
            // 
            this.checkBoxCacheData.AutoSize = true;
            this.checkBoxCacheData.Location = new System.Drawing.Point(6, 42);
            this.checkBoxCacheData.Name = "checkBoxCacheData";
            this.checkBoxCacheData.Size = new System.Drawing.Size(129, 17);
            this.checkBoxCacheData.TabIndex = 2;
            this.checkBoxCacheData.Text = "Кэшировать данные";
            this.toolTip1.SetToolTip(this.checkBoxCacheData, "CacheData should mul entries be cached for faster load");
            this.checkBoxCacheData.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
			this.groupBox2.Controls.Add(this.checkBoxPreAlphaMapSize);
            this.groupBox2.Controls.Add(this.checkBoxQuintMaps);
            this.groupBox2.Controls.Add(this.checkBoxuseDiff);
            this.groupBox2.Controls.Add(this.checkBoxNewMapSize);
            this.groupBox2.Controls.Add(this.checkBoxAltDesign);
            this.groupBox2.Controls.Add(this.checkBoxCacheData);
            this.groupBox2.Location = new System.Drawing.Point(14, 5);
            this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 160);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прочее";
            // 
			// checkBoxQuintMaps
			// 
			this.checkBoxQuintMaps.AutoSize = true;
			this.checkBoxQuintMaps.Location = new System.Drawing.Point(6, 65);
			this.checkBoxQuintMaps.Name = "checkBoxQuintMaps";
			this.checkBoxQuintMaps.Size = new System.Drawing.Size(171, 17);
			this.checkBoxQuintMaps.TabIndex = 5;
			this.checkBoxQuintMaps.Text = "Карты сервера Quintessence";
			this.toolTip1.SetToolTip(this.checkBoxQuintMaps, "Использовать карты сервера Quintessence?");
			this.checkBoxQuintMaps.UseVisualStyleBackColor = true;
			this.checkBoxQuintMaps.CheckedChanged += new System.EventHandler(this.checkBoxQuintMaps_CheckedChanged);
			// 
            // checkBoxuseDiff
            // 
            this.checkBoxuseDiff.AutoSize = true;
			this.checkBoxuseDiff.Location = new System.Drawing.Point(6, 134);
            this.checkBoxuseDiff.Name = "checkBoxuseDiff";
            this.checkBoxuseDiff.Size = new System.Drawing.Size(153, 17);
            this.checkBoxuseDiff.TabIndex = 4;
            this.checkBoxuseDiff.Text = "Использовать diff файлы";
            this.toolTip1.SetToolTip(this.checkBoxuseDiff, "Should map diff files be used");
            this.checkBoxuseDiff.UseVisualStyleBackColor = true;
            // 
            // checkBoxNewMapSize
            // 
            this.checkBoxNewMapSize.AutoSize = true;
            this.checkBoxNewMapSize.Location = new System.Drawing.Point(6, 88);
            this.checkBoxNewMapSize.Name = "checkBoxNewMapSize";
            this.checkBoxNewMapSize.Size = new System.Drawing.Size(145, 17);
            this.checkBoxNewMapSize.TabIndex = 3;
            this.checkBoxNewMapSize.Text = "Новый размер карт ML";
			this.toolTip1.SetToolTip(this.checkBoxNewMapSize, "Новый размер карт Felucca/Trammel, с шириной 7168?");
            this.checkBoxNewMapSize.UseVisualStyleBackColor = true;
			this.checkBoxNewMapSize.CheckedChanged += new System.EventHandler(this.checkBoxNewMapSize_CheckedChanged);
            // 
            // button1
            // 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(339, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickApply);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "map0 Название";
            this.toolTip1.SetToolTip(this.label2, "Definies the map name");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "map1 Название";
            this.toolTip1.SetToolTip(this.label3, "Definies the map name");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "map2 Название";
            this.toolTip1.SetToolTip(this.label4, "Definies the map name");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "map3 Название";
            this.toolTip1.SetToolTip(this.label5, "Definies the map name");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "map4 Название";
            this.toolTip1.SetToolTip(this.label6, "Definies the map name");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Комманда";
            this.toolTip1.SetToolTip(this.label7, "Definies the cmd to send Client to loc");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Аргументы";
            this.toolTip1.SetToolTip(this.label8, "{1} = x, {2} = y, {3} = z, {4} = mapid, {5} = mapname");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "map5 Название";
            this.toolTip1.SetToolTip(this.label9, "Definies the map name");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.map5Nametext);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.argstext);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmdtext);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.map4Nametext);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.map3Nametext);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.map2Nametext);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.map1Nametext);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.map0Nametext);
            this.groupBox3.Location = new System.Drawing.Point(220, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 237);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Карта";
            // 
            // map5Nametext
            // 
            this.map5Nametext.Location = new System.Drawing.Point(94, 146);
            this.map5Nametext.Name = "map5Nametext";
            this.map5Nametext.Size = new System.Drawing.Size(100, 20);
            this.map5Nametext.TabIndex = 14;
            // 
            // argstext
            // 
            this.argstext.Location = new System.Drawing.Point(94, 206);
            this.argstext.Name = "argstext";
            this.argstext.Size = new System.Drawing.Size(100, 20);
            this.argstext.TabIndex = 12;
            // 
            // cmdtext
            // 
            this.cmdtext.Location = new System.Drawing.Point(94, 180);
            this.cmdtext.Name = "cmdtext";
            this.cmdtext.Size = new System.Drawing.Size(100, 20);
            this.cmdtext.TabIndex = 10;
            // 
            // map4Nametext
            // 
            this.map4Nametext.Location = new System.Drawing.Point(94, 120);
            this.map4Nametext.Name = "map4Nametext";
            this.map4Nametext.Size = new System.Drawing.Size(100, 20);
            this.map4Nametext.TabIndex = 8;
            // 
            // map3Nametext
            // 
            this.map3Nametext.Location = new System.Drawing.Point(94, 95);
            this.map3Nametext.Name = "map3Nametext";
            this.map3Nametext.Size = new System.Drawing.Size(100, 20);
            this.map3Nametext.TabIndex = 6;
            // 
            // map2Nametext
            // 
            this.map2Nametext.Location = new System.Drawing.Point(94, 69);
            this.map2Nametext.Name = "map2Nametext";
            this.map2Nametext.Size = new System.Drawing.Size(100, 20);
            this.map2Nametext.TabIndex = 4;
            // 
            // map1Nametext
            // 
            this.map1Nametext.Location = new System.Drawing.Point(94, 43);
            this.map1Nametext.Name = "map1Nametext";
            this.map1Nametext.Size = new System.Drawing.Size(100, 20);
            this.map1Nametext.TabIndex = 2;
            // 
            // map0Nametext
            // 
            this.map0Nametext.Location = new System.Drawing.Point(94, 17);
            this.map0Nametext.Name = "map0Nametext";
            this.map0Nametext.Size = new System.Drawing.Size(100, 20);
            this.map0Nametext.TabIndex = 0;
            // 
			// checkBoxPreAlphaMapSize
            // 
			this.checkBoxPreAlphaMapSize.AutoSize = true;
			this.checkBoxPreAlphaMapSize.Location = new System.Drawing.Point(6, 111);
			this.checkBoxPreAlphaMapSize.Name = "checkBoxPreAlphaMapSize";
			this.checkBoxPreAlphaMapSize.Size = new System.Drawing.Size(139, 17);
			this.checkBoxPreAlphaMapSize.TabIndex = 6;
			this.checkBoxPreAlphaMapSize.Text = "Размер карт pre-Alpha";
			this.toolTip1.SetToolTip(this.checkBoxPreAlphaMapSize, "Старый размер карты Felucca, 1024х1024?");
			this.checkBoxPreAlphaMapSize.UseVisualStyleBackColor = true;
			this.checkBoxPreAlphaMapSize.CheckedChanged += new System.EventHandler(this.checkBoxPreAlphaMapSize_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 283);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Конфигурация";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemSizeWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAltDesign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownItemSizeWidth;
        private System.Windows.Forms.CheckBox checkBoxItemClip;
        private System.Windows.Forms.NumericUpDown numericUpDownItemSizeHeight;
        private System.Windows.Forms.CheckBox checkBoxCacheData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxUseHash;
        private System.Windows.Forms.CheckBox checkBoxNewMapSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox map4Nametext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox map3Nametext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox map2Nametext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox map1Nametext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox map0Nametext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox argstext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cmdtext;
        private System.Windows.Forms.CheckBox checkBoxuseDiff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox map5Nametext;
        private System.Windows.Forms.CheckBox checkBoxQuintMaps;
		private System.Windows.Forms.CheckBox checkBoxPreAlphaMapSize;

    }
}