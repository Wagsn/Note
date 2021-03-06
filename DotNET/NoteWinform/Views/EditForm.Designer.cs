﻿namespace NoteWinform.Views
{
    partial class EditForm
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
            this.TitieEdit = new System.Windows.Forms.TextBox();
            this.ContentEdit = new System.Windows.Forms.RichTextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitieEdit
            // 
            this.TitieEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitieEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitieEdit.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitieEdit.Location = new System.Drawing.Point(0, 0);
            this.TitieEdit.Margin = new System.Windows.Forms.Padding(15);
            this.TitieEdit.Name = "TitieEdit";
            this.TitieEdit.Size = new System.Drawing.Size(800, 29);
            this.TitieEdit.TabIndex = 0;
            this.TitieEdit.Text = "标题";
            // 
            // ContentEdit
            // 
            this.ContentEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContentEdit.Location = new System.Drawing.Point(0, 29);
            this.ContentEdit.Margin = new System.Windows.Forms.Padding(6);
            this.ContentEdit.Name = "ContentEdit";
            this.ContentEdit.Size = new System.Drawing.Size(800, 421);
            this.ContentEdit.TabIndex = 1;
            this.ContentEdit.Text = "内容";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(713, 415);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ContentEdit);
            this.Controls.Add(this.TitieEdit);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitieEdit;
        private System.Windows.Forms.RichTextBox ContentEdit;
        private System.Windows.Forms.Button SaveButton;
    }
}