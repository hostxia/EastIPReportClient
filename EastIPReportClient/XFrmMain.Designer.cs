namespace EastIPReportClient
{
    partial class XFrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xspClientNo = new DevExpress.XtraEditors.SpinEdit();
            this.xgcResult = new DevExpress.XtraGrid.GridControl();
            this.xgvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xsbSearch = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xspClientNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xspClientNo);
            this.layoutControl1.Controls.Add(this.xgcResult);
            this.layoutControl1.Controls.Add(this.xsbSearch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(744, 426);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xspClientNo
            // 
            this.xspClientNo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.xspClientNo.Location = new System.Drawing.Point(87, 12);
            this.xspClientNo.Name = "xspClientNo";
            this.xspClientNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.xspClientNo.Size = new System.Drawing.Size(554, 20);
            this.xspClientNo.StyleController = this.layoutControl1;
            this.xspClientNo.TabIndex = 4;
            // 
            // xgcResult
            // 
            this.xgcResult.Location = new System.Drawing.Point(12, 38);
            this.xgcResult.MainView = this.xgvResult;
            this.xgcResult.Name = "xgcResult";
            this.xgcResult.Size = new System.Drawing.Size(720, 376);
            this.xgcResult.TabIndex = 1;
            this.xgcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.xgvResult});
            // 
            // xgvResult
            // 
            this.xgvResult.GridControl = this.xgcResult;
            this.xgvResult.Name = "xgvResult";
            this.xgvResult.OptionsBehavior.Editable = false;
            this.xgvResult.OptionsSelection.MultiSelect = true;
            this.xgvResult.OptionsView.ColumnAutoWidth = false;
            this.xgvResult.OptionsView.ShowAutoFilterRow = true;
            this.xgvResult.OptionsView.ShowFooter = true;
            // 
            // xsbSearch
            // 
            this.xsbSearch.Location = new System.Drawing.Point(645, 12);
            this.xsbSearch.Name = "xsbSearch";
            this.xsbSearch.Size = new System.Drawing.Size(87, 22);
            this.xsbSearch.StyleController = this.layoutControl1;
            this.xsbSearch.TabIndex = 1;
            this.xsbSearch.Text = "查询";
            this.xsbSearch.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(744, 426);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xsbSearch;
            this.layoutControlItem2.Location = new System.Drawing.Point(633, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(91, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.xgcResult;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(724, 380);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.xspClientNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(633, 26);
            this.layoutControlItem4.Text = "委托人编号：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // XFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 426);
            this.Controls.Add(this.layoutControl1);
            this.Name = "XFrmMain";
            this.Text = "客户报表统计";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xspClientNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton xsbSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl xgcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView xgvResult;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SpinEdit xspClientNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}

