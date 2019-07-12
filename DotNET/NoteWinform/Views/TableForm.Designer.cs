namespace NoteWinCore.Views
{
    partial class TableForm
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
            this.Table = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Content,
            this.CreateTime,
            this.UpdateTime,
            this.Deleted,
            this.DeleteTime});
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowTemplate.Height = 23;
            this.Table.Size = new System.Drawing.Size(844, 387);
            this.Table.TabIndex = 1;
            this.Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellClick);
            this.Table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellContentClick);
            // 
            // Title
            // 
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            // 
            // Content
            // 
            this.Content.HeaderText = "内容";
            this.Content.Name = "Content";
            this.Content.Width = 300;
            // 
            // CreateTime
            // 
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CreateTime.ToolTipText = "2019/07/12";
            // 
            // UpdateTime
            // 
            this.UpdateTime.HeaderText = "更新时间";
            this.UpdateTime.Name = "UpdateTime";
            // 
            // Deleted
            // 
            this.Deleted.HeaderText = "是否删除";
            this.Deleted.Name = "Deleted";
            // 
            // DeleteTime
            // 
            this.DeleteTime.HeaderText = "删除时间";
            this.DeleteTime.Name = "DeleteTime";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 387);
            this.Controls.Add(this.Table);
            this.Name = "TableForm";
            this.Text = "NoteListForm";
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteTime;
    }
}