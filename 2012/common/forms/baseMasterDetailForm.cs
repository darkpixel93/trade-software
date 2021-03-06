using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using common.controls;

namespace common.forms
{
    public partial class baseMasterDetailForm : forms.baseForm
    {
        private int selectedColumn = -1;
        public delegate void onPrintEvent(bool fPreview);
        public event onPrintEvent onPrint;
        
        public delegate void onPrintDetailEvent(int idx,bool fPreview);
        public event onPrintDetailEvent onDetailPrint;

        public string[] printDetailItem
        {
            set 
            {
                cbPrintDetailType.Items.Clear();
                for (int idx=0;idx<value.Length;idx++)
                {
                    cbPrintDetailType.Items.Add(new myComboBoxItem(value[idx], idx.ToString()));
                }
                if (value.Length > 0) cbPrintDetailType.SelectedIndex = 0;
            }
        }

        private static bool _fCheckCellValueChange = false;
        private DataTable myMasterNavigatorTbl = new DataTable();
        private BindingSource myMasterNavigatorSource = new BindingSource();
        private bool LoadAllData(string editKeyType)
        {
            int currentPos = myMasterNavigatorSource.Position;
            myMasterNavigatorTbl.Clear();
            if (!FillMasterNavigatorTable(editKeyType, ref myMasterNavigatorTbl)) return false;
            myMasterNavigatorSource.DataSource = myMasterNavigatorTbl;
 
            if (currentPos >= 0 && currentPos < myMasterNavigatorTbl.Rows.Count) myMasterNavigatorSource.Position = currentPos;
            else myMasterNavigatorSource.MoveLast();
            return MoveMasterByNavigator();
        }
        private void PasteDataToGrid()
        {
            string dataType;
            int dataIdx = -1;
            string[] pasteData = Clipboard.GetText(TextDataFormat.UnicodeText).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (pasteData.Length == 0) return;
            for (int idx = detailGrid.SelectedCells.Count - 1; idx >= 0; idx--)
            {
                dataIdx++;
                if (dataIdx >= pasteData.Length) dataIdx = 0;

                dataType = detailGrid[detailGrid.SelectedCells[idx].ColumnIndex, detailGrid.SelectedCells[idx].RowIndex].ValueType.ToString();
                if (dataType.Contains("Decimal") || dataType.Contains("Double"))
                    detailGrid[detailGrid.SelectedCells[idx].ColumnIndex, detailGrid.SelectedCells[idx].RowIndex].Value = common.sysLibs.String2Decimal(pasteData[dataIdx]);
                else
                {
                    if (dataType.Contains("System.Int"))
                        detailGrid[detailGrid.SelectedCells[idx].ColumnIndex, detailGrid.SelectedCells[idx].RowIndex].Value = common.sysLibs.String2Int(pasteData[dataIdx]);
                    else detailGrid[detailGrid.SelectedCells[idx].ColumnIndex, detailGrid.SelectedCells[idx].RowIndex].Value = pasteData[dataIdx];
                }
            }
        }

        private BindingSource _myDetailSource = null;
        public BindingSource myDetailSource
        {
            get
            {
                if (_myDetailSource == null) this.ShowMessage("Chưa thiết lập tham số [myDetailSource]");
                return _myDetailSource;
            }
            set
            {
                _myDetailSource = value;
                detailGrid.DataSource = value;
            }
        }
        public string myMasterEditKeyFldName = null; //Field name of editKey , for exampl "voucherNo"
        public string myMasterKeyFldName = null; //Field name of editKey , for exampl "voucherNo"
        public BindingSource myMasterSource = null;

        public bool AskToSaveWhenClosing = true;

        public static bool IsCheckCellValueChange
        {
            get { return _fCheckCellValueChange; }
            set { _fCheckCellValueChange = value; }
        }
        public bool fLoadDataOnFirstShown=true;
        public string editKeyType = "", copyKeyType = "";
        protected bool fOnLoadDetail = false;
        protected bool fCheckCellValidating = true;
        protected bool fOnLoading = false;

        public string editKey
        {
            set { editKeyEd.Text = value;}
            get { return editKeyEd.Text;}
        }
        
        public bool isLockEdit
        {
            set { lockEditMenuItem.Checked = value; }
            get { return lockEditMenuItem.Checked;}
        }

        private bool ProcessCmdKeyFlag = true;
        
        public baseMasterDetailForm()
        {
            InitializeComponent();

            myPrintDialog.UseEXDialog = false;
            
            myMasterNavigatorSource.DataSource = myMasterNavigatorTbl;
            myMasterNavigator.BindingSource = myMasterNavigatorSource;

            if (myMasterSource == null)
            {
                this.ShowMessage("Chưa thiết lập [myMasterSource]"); return;
            }
            if (myMasterKeyFldName == null)
            {
                this.ShowMessage("Chưa thiết lập [myMasterKeyFldName]"); return;
            }
            if (myMasterEditKeyFldName == null)
            {
                this.ShowMessage("Chưa thiết lập [myMasterEditKeyFldName]"); return;
            }
            if (myDetailSource == null)
            {
                this.ShowMessage("Chưa thiết lập [myDetailSource]"); return;
            }
        }

        //Menu setting
        public bool ViewBeforePrintMode
        {
            get { return  printPreviewMenuItem.Checked;}
            set { printPreviewMenuItem.Checked = value;}
        }
        public bool CopyDataEnable
        {
            get { return copyDataMenuItem.Enabled; }
            set { copyDataMenuItem.Enabled = value; }
        }
        public bool CopyLineEnable
        {
            get { return copyLineMenuItem.Enabled; }
            set { copyLineMenuItem.Enabled = value; }
        }
        public bool AddLineEnable
        {
            get { return addLineMenuItem.Enabled; }
            set { addLineMenuItem.Enabled = value; }
        }
        public bool DeleteLineEnable
        {
            get { return deleteLineMenuItem.Enabled; }
            set { deleteLineMenuItem.Enabled = value; }
        }        
        
        public bool AddNewAfterSaveMode
        {
            get { return newAfterSaveMenuItem.Checked; }
            set { newAfterSaveMenuItem.Checked = value; }
        }
        public bool PrintOnSaveMode
        {
            get { return printOnSaveMenuItem.Checked; }
            set { printOnSaveMenuItem.Checked = value; }
        }

        public bool Goto(int editKeyId)
        {
            return LoadData(editKeyId);
        }
        public void SetColumnVisible(string[] colName, bool visibleMode)
        {
            //Hide all column first
            for (int idx = 0; idx < detailGrid.ColumnCount; idx++) detailGrid.Columns[idx].Visible = false;
            for (int idx = 0; idx < colName.Length; idx++)
                SetColumnVisible(colName[idx], visibleMode);
        }
        public void SetColumnVisible(string colName, bool visibleMode)
        {
            colName = colName.ToUpper();
            for (int idx = 0; idx < detailGrid.ColumnCount; idx++)
            {
                if (detailGrid.Columns[idx].Name.ToUpper() == colName)
                {
                    detailGrid.Columns[idx].Visible = visibleMode;
                    break;
                }
            }
        }
        public string GenerateAutoEditKey(string findKey)
        {
            return GenerateAutoEditKey(findKey, -1);
        }

        public void ReOrderColumn(string[] colName)
        {
            for (int idx = 0; idx < colName.Length; idx++)
                this.detailGrid.Columns[colName[idx]].DisplayIndex = idx;
        }
        protected virtual void AutoAdjustWidth(string colName)
        {
            common.sysLibs.AutoFitGridColumn(detailGrid, colName);
        }
        //========================================
        // Abtrstract functions
        //========================================
        protected virtual void DetailCellClick(object sender, DataGridViewCellEventArgs e) { }

        protected virtual void AddLineBtnClick()
        {
            AddLine();
            this.detailGrid.Focus();
            if (detailGrid[0, detailGrid.CurrentRow.Index].Visible)
                this.detailGrid.CurrentCell = detailGrid[0, detailGrid.CurrentRow.Index];
        }
        protected virtual void DeleteLineBtnClick()
        {
            if (this.detailGrid.CurrentRow == null) return;
            try
            {
                this.detailGrid.Rows.RemoveAt(detailGrid.CurrentRow.Index);
                ShowSubTotal();
                this.ShowMessage("");
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
            }
        }
        protected virtual void SetFirstFocus()
        {
            this.editKeyEd.Focus();
        }
        protected virtual bool BeforeSaveMasterRecord(DataRowView dr) { return true; }
        protected virtual bool RequireTransactionScope() {return false;}
        protected virtual void ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e){}

        // Auto generating EditKeyNo based on the input  
        protected virtual string GenerateAutoEditKey()
        {
            return GenerateAutoEditKey(editKeyType);
        }
        protected virtual string GenerateAutoEditKey(string findKey, int expectedPrefixLen) { return null; }
       
        protected virtual int GetMasterEditKeyId(DataRowView dr) { return -1; } //Unique record ID
        protected virtual bool DataChanged() { return false;}

        protected virtual bool FillMasterTable(int editKeyId) { return true; }
        protected virtual bool FillMasterNavigatorTable(string editKeyType, ref DataTable navigatorTbl) { navigatorTbl = null; return false; }
        protected virtual bool FillDetailTable(int editKeyId) { return true; }

        protected virtual bool AddNew(string editKey) {return false; }

        protected virtual bool UpdateMasterTable() { return false;}
        protected virtual bool CancelAllChanges() { return true; }

        protected virtual DataRowView FindMasterRecord(string editKeyType, string editKey, bool showList) { return null; }
        private DataRowView FindMasterRecord(string editKeyType, string editKey)
        {
            return FindMasterRecord(editKeyType, editKey, false);
        }
        
        //Show total 
        protected virtual void ShowSubTotal() { return; }
        protected virtual void LoadConfiguration() { return; } //Load configuartion from XML file
        protected virtual void SaveConfiguration() { return; } //Save configuartion to XML file
        // Check if the data can be change (in working period, ownwer...)
        protected virtual bool DataChangable() {return true;}

        //===============================================================================================
        // All save data was enclosed in transaction by using TransactionScope 
        // if any error occured or SaveDetailData/DeleteDetailData return FALSE, 
        // all update will be cancelled out
        //===============================================================================================

        protected virtual bool BeforeSaveDetailData(int editKeyId) { return true; } //Function was called before SaveDetailData
        protected virtual bool SaveDetailData(int editKeyId) { return true; } //Save data in detailGrid to database
        protected virtual bool DeleteDetailData(int editKeyId){ return true; } //Remove detail data
        
        protected virtual void DetailValuesNeeded(object sender, DataGridViewRowEventArgs e) { return; } //Detail data needed when adding new line
        protected virtual void DetailRowValidating(object sender,DataGridViewCellCancelEventArgs e) { return; }
        protected virtual void DetailRowEnter(object sender, DataGridViewCellEventArgs e) { return; }
        protected virtual void DetailCellValueChanged(object sender, DataGridViewCellEventArgs e) 
        {
            ShowSubTotal();
            return; 
        }
        protected virtual void DetailCellContentDoubleClick(object sender, DataGridViewCellEventArgs e) { return; }
        protected virtual void DetailCellContentClick(object sender, DataGridViewCellEventArgs e) { return; }
        protected virtual void DetailCellEnter(object sender, DataGridViewCellEventArgs e) { }

        protected virtual void SetDetailGrid() { return; }     //Set detail grid
        //protected virtual void Print(bool preview) 
        //{
        //    common.sysLibs.ShowErrorMessage("Chức năng chưa thực hiện");
        //    return; 
        //} 

        //Copy data
        protected virtual DataRowView FindCopyData()
        {
            string _copyKeyType = (copyKeyType.Trim() == "" ? editKeyType : copyKeyType);
            return FindMasterRecord(_copyKeyType, copyEditKeyNoEd.Text, true);
        }
        protected virtual void CopyFindClick(object sender, EventArgs e)
        {
            DataRowView drFound = FindCopyData();
            if (drFound != null)
                copyEditKeyNoEd.Text = drFound[myMasterEditKeyFldName].ToString();
        }
        protected virtual void CopyClick(object sender, EventArgs e)
        {
            DataRowView drFound = FindCopyData();
            if (drFound == null)
            {
                common.sysLibs.ShowErrorMessage("Không có số phiếu : " + copyEditKeyNoEd.Text);
                return;
            }
            int selectedEditKeyId = GetMasterEditKeyId(drFound);
            if (selectedEditKeyId > 0) CopyData(selectedEditKeyId, copyAppendModeChk.Checked);
        }
        protected virtual void CopyData(int editKeyId, bool appendMode) { return; } //Copy data
        protected virtual void CopyLines() { return; } //Copy one or more selected lines
        protected virtual void ShowCopyForm()
        {
            copyPanel.BringToFront();
            copyPanel.Visible = true; copyEditKeyNoEd.Focus();
            copyPanel.Location = new Point(this.editKeyEd.Location.X, editKeyEd.Location.Y + editKeyEd.Height);
        }

        //Menu
        public bool AutoVoucherMenuMode
        {
            get { return autoVoucherNoMenuItem.Checked;}
            set 
            { 
                autoVoucherNoMenuItem.Checked = value;
            }
        }
        public bool PrintMenuMode
        {
            get { return printOptionsMenuItem.Checked; }
            set { printOptionsMenuItem.Checked = value; }
        }
        public bool NewAfterSaveMenuMode
        {
            get { return newAfterSaveMenuItem.Checked; }
            set { newAfterSaveMenuItem.Checked = value; }
        }
        public bool CopyDataMenuEnable
        {
            get { return copyDataMenuItem.Enabled; }
            set { copyDataMenuItem.Enabled = value; }
        }
        
        //Key trapping
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //If do not require to change the default key process
            if (!ProcessCmdKeyFlag) return base.ProcessCmdKey(ref msg, keyData);

            //Hot keys
            if (!isLockEdit && ( (msg.Msg == Consts.WM_KEYDOWN) || (msg.Msg == Consts.WM_SYSKEYDOWN)) )
            {
                switch (keyData)
                {
                    case Consts.constHotKeySave:
                        if (this.saveBtn.Enabled) saveBtn_Click(null, null);
                        break;
                    case Consts.constHotKeyAddNew:
                        if (this.addNewBtn.Enabled) addNewBtn_Click(null, null);
                        break;
                    case Consts.constHotKeyAddLine:
                        if (this.addLineBtn.Enabled) addLineBtn_Click(null, null);
                        break;
                    case Consts.constHotKeyDeleteLine:
                        if (this.deleteLineBtn.Enabled) deleteLineBtn_Click(null, null);
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool MoveNavigatorSource()
        {
            if (myMasterSource.Current==null) return false;
            DataRowView dr = (DataRowView)myMasterSource.Current;
            int editKeyId = 0;
            if (!int.TryParse( ((DataRowView)myMasterSource.Current)[myMasterKeyFldName].ToString(),out editKeyId)) return false;
            return MoveNavigatorSource(editKeyId);
        }
        private bool MoveNavigatorSource(int editKeyId)
        {
            try
            {
                myMasterNavigatorSource.DataSource = null;
                myMasterNavigatorSource.DataSource = myMasterNavigatorTbl;
                myMasterNavigator.BindingSource = myMasterNavigatorSource;
                int pos=-1;
                if (myMasterNavigatorSource.Count > 0)
                    pos = myMasterNavigatorSource.Find(myMasterKeyFldName, editKeyId);
                if (pos < 0)
                {
                    myMasterNavigatorSource.DataSource = null;
                    myMasterNavigatorTbl.Clear();
                    if (!FillMasterNavigatorTable(editKeyType, ref myMasterNavigatorTbl)) return false;
                    myMasterNavigatorSource.DataSource = myMasterNavigatorTbl;
                    myMasterNavigator.BindingSource = myMasterNavigatorSource;
                    pos = myMasterNavigatorSource.Find(myMasterKeyFldName, editKeyId);
                }
                if (pos < 0) return false;
                myMasterNavigatorSource.Position = pos;
                return true;
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
            }
            return false;
        }

        protected virtual bool LoadData(int editKeyId)
        {
            if (fOnLoading) return false;
            try
            {
                fOnLoading = true;
                bool loadResult = FillMasterTable(editKeyId);
                if (!loadResult) return false;
                if ((DataRowView)myMasterSource.Current != null)
                {
                    this.editKeyEd.Text = ((DataRowView)myMasterSource.Current)[myMasterEditKeyFldName].ToString();
                    this.editKeyEd.Modified = false;
                }
                LoadDetail(editKeyId);
                SetFirstFocus();
                MoveNavigatorSource(editKeyId);
                this.ShowMessage("");
                return true; 
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
            }
            finally
            {
                fOnLoading = false;
            }
            return false;
        }

        protected virtual void LockEdit(bool lockState)
        {
            isLockEdit = lockState;
            editKeyEd.Enabled = !lockState;
            this.saveBtn.Enabled = !lockState;
            this.deleteBtn.Enabled = this.saveBtn.Enabled;
            this.addLineBtn.Enabled = this.saveBtn.Enabled;
            this.deleteLineBtn.Enabled = this.saveBtn.Enabled;
            this.detailGrid.Enabled = this.saveBtn.Enabled;
        }

        protected virtual bool AskToSaveChanged()
        {
            DataRowView dr = (DataRowView)myMasterSource.Current;
            if (dr == null) return false;

            //If the current editKey is empty, ignore it
            if (this.editKeyEd.Text.ToString().Trim() == "" ) return false;
            if (DataChanged())
            {
                return MessageBox.Show("Lưu lại các số liệu thay đổi của " + this.editKeyEd.Tag.ToString().Trim() + " " + this.editKeyEd.Text.ToString().Trim() + " ?", settings.sysApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            return false;
        }

        protected virtual bool AddNew()
        {
            string editKey = (autoVoucherNoMenuItem.Checked ? settings.sysNewDataAutoNumberMarker : "");
            if (AddNew(editKey))
            {
                this.editKeyEd.Text = editKey;
                return true;
            }
            return false;
        }

        protected virtual bool RemoveCurrent()
        {
            try
            {
                if (myMasterSource == null)
                {
                    this.ShowMessage("Chưa thiết lập [myMasterSource]"); return false;
                }
                DataRowView drMaster = (DataRowView)myMasterSource.Current;
                //Existing data need some check before deleting
                if ( !drMaster.IsNew && !DataChangable()) return false;

                TransactionScopeOption tranOption;
                tranOption = (RequireTransactionScope() ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
                using (TransactionScope scope = new TransactionScope(tranOption))
                {
                    int editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
                    if (!DeleteDetailData(editKeyId)) return false;
                    myMasterSource.RemoveCurrent();
                    if (UpdateMasterTable())
                    {
                        scope.Complete();
                        this.ShowMessage("Đã xoá số liệu");
                        return true;
                    }
                }
            }
            catch (Exception er)
            {
                CancelAllChanges();
                this.ErrorHander(er);
            }
            return false;
        }

        private bool DoSaveCurrent()
        {
            if (myMasterSource == null)
            {
                this.ShowMessage("Chưa thiết lập [myMasterSource]"); return false;
            }
            if (!DataChangable()) return false;

            if (!DataValid(true)) return false;
          
            if (!SaveCurrent())
            {
                if (MessageBox.Show("Lưu dữ liệu gặp lỗi, nạp lại dữ liệu từ cơ sở dữ liệu ?", settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CancelAllChanges();
                    //Reloading  current data to solve the problem (keep the current editKeyId number)
                    //but first undo  all change before reload to cancel all changes
                    //int editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
                    LoadData();
                }
                return false;
            }
            return true;
        }
        protected virtual bool SaveCurrent()
        {
            try
            {
                DataRowView drEditData = (DataRowView)myMasterSource.Current;
                if (drEditData == null)
                {
                    common.sysLibs.ShowErrorMessage("Không có mẫu tin hiện thời");
                    return false;
                }
                //Only generate editKey for new data
                //if (this.autoVoucherNoMenuItem && drEditData.IsNew)
                if (this.AutoVoucherMenuMode && editKeyEd.Text.Trim() == settings.sysNewDataAutoNumberMarker)
                {
                    string tmp = GenerateAutoEditKey();
                    if (tmp == null)
                    {
                        this.ShowMessage("[GenerateAutoEditKey()] gặp lỗi"); 
                        return false;
                    }
                    this.editKeyEd.Text = tmp;
                }
                //Call trigger before update
                if (!BeforeSaveMasterRecord(drEditData)) return false;

                //Keep editKey of saved records
                drEditData[myMasterEditKeyFldName] = this.editKeyEd.Text.Trim();
                myMasterSource.EndEdit();
                myMasterSource.ResetCurrentItem();
                
                TransactionScopeOption tranOption; 
                tranOption = (RequireTransactionScope()? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
                using (TransactionScope scope = new TransactionScope(tranOption))
                {
                    if (!UpdateMasterTable()) return false;
                    
                    int editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
                    if (!BeforeSaveDetailData(editKeyId)) return false;
                    if (!SaveDetailData(editKeyId)) return false;
                    
                    MoveNavigatorSource(editKeyId);
                    scope.Complete();
                    this.ShowMessage("Đã lưu số liệu", "");
                    return true;
                }
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
            }
            return false;
        }
        protected virtual bool EditKeyValidating()
        {
            int foundEditKeyId;
            string saveEditKey;

            DataRowView drCurrent = (DataRowView)myMasterSource.Current;
            if (drCurrent == null)
            {
                common.sysLibs.ShowErrorMessage("Không có mẫu tin hiện thời");
                CancelAllChanges(); this.Close();
                return false;
            }
            LockEdit(false);

            DataRowView drFind;
            // New record ?
            if (drCurrent.IsNew)
            {
                drFind = FindMasterRecord(this.editKeyType, this.editKeyEd.Text.Trim());
                if (drFind != null)
                {
                    if (MessageBox.Show("Đã có dữ liệu " + this.editKeyEd.Text.Trim() + ",xem lại chi tiết ?", settings.sysApplicationName, MessageBoxButtons.YesNo) == DialogResult.No) return false;
                    CancelAllChanges();
                    foundEditKeyId = GetMasterEditKeyId(drFind);
                    if (!LoadData(foundEditKeyId))
                    {
                        common.sysLibs.ShowErrorMessage("Không nạp được dữ liệu " + foundEditKeyId.ToString());
                        this.Close(); return false;
                    }
                    this.detailGrid.Focus();
                }
                return true;
            }
            //=====================
            //  Existing record
            //====================
            if (drCurrent[myMasterEditKeyFldName].ToString().Trim() == this.editKeyEd.Text.Trim()) return true;

            drFind = FindMasterRecord(this.editKeyType, this.editKeyEd.Text.Trim());
            if (drFind == null)
            {
                string tmp = "Thay đổi [" + this.editKeyLbl.Text.Trim() + "] " + drCurrent[myMasterEditKeyFldName].ToString().Trim() +
                             " thành " + this.editKeyEd.Text.Trim();
                if (MessageBox.Show(tmp, settings.sysApplicationName, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    AddNew(this.editKeyEd.Text.ToString());
                    LoadDetail();
                    return false;
                }
                return true;
            }
            if (AskToSaveChanged())
            {
                //Set editKey to the old one before saving
                saveEditKey = this.editKeyEd.Text.ToString();
                this.editKeyEd.Text = drFind[myMasterEditKeyFldName].ToString();
                bool fSaveOk = DoSaveCurrent();
                //Set editKey to the new one 
                this.editKeyEd.Text = saveEditKey;
                if (!fSaveOk) return false;
            }
            else CancelAllChanges();
            foundEditKeyId = GetMasterEditKeyId(drFind);
            if (!LoadData(foundEditKeyId))
            {
                common.sysLibs.ShowErrorMessage("Không nạp được dữ liệu " + foundEditKeyId.ToString());
                this.Close(); return false;
            }
            this.detailGrid.Focus();
            return true;
        }
        
        //Add a details record
        protected bool AddLine()
        {
            if (myDetailSource == null)
            {
                this.ShowMessage("Chưa thiết lập [myDetailSource]"); return false;
            }
            DataGridViewCell curCell1 = null, curCell2 = null;
            fOnLoadDetail = true;
            DataRowView dr;
            try
            {
                dr = (DataRowView)myDetailSource.AddNew();
                DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(this.detailGrid.CurrentRow);
                // To simulate the same behavior of _DefaultValuesNeeded event,
                // try to go to the cell where the Add was occured
                if (curCell1 != null) detailGrid.CurrentCell = curCell1;
                DetailValuesNeeded(this, e);
                //Try to go to the newly added cell
                if (curCell2 != null) detailGrid.CurrentCell = curCell2;
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
                common.sysLibs.ShowErrorMessage("Không thêm được dữ liệu");
                return false;
            }
            finally
            {
                fOnLoadDetail = false;
            }
            return true;
        }
       
        protected virtual bool DataValid(bool showMsg)
        {
            if (editKeyEd.Text.Trim() == "")
            {
                if (showMsg) common.sysLibs.ShowErrorMessage("Chưa nhập " + this.editKeyEd.Tag.ToString().Trim());
                editKeyEd.Focus(); 
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            int editKeyId = -1;
            if ((DataRowView)myMasterSource.Current != null) editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
            if (editKeyId > 0) LoadData(editKeyId);
            else LoadDetail(editKeyId);
        }
        private void LoadDetail()
        {
            int editKeyId = -1;
            if ((DataRowView)myMasterSource.Current != null)
                editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
            LoadDetail(editKeyId);
        }
        private void LoadDetail(int editKeyId)
        {
            if (fOnLoadDetail) return;
            fOnLoadDetail = true;
            bool loadResult = FillDetailTable(editKeyId);
            ShowSubTotal();
            fOnLoadDetail = false;
            return;
        }
        private bool MoveMasterByNavigator()
        {
            if (myMasterNavigatorSource.Current == null) return false;
            DataRowView dr = (DataRowView)myMasterNavigatorSource.Current;
            int editKeyId = 0;
            if (!int.TryParse(((DataRowView)myMasterNavigatorSource.Current)[myMasterKeyFldName].ToString(), out editKeyId)) return false;
            return Goto(editKeyId);
        }

        public bool InitForm()
        {
            if (editKeyType == "")
            {
                if (!this.DesignMode) this.ShowMessage("Chưa gán giá trị cho thuộc tính <editType> : " + this.Name.ToString());
                return false;
            }
            LoadConfiguration();
            SetDetailGrid();
            //LoadData();
            return true;
        }

        #region event handler
        protected void whenForm_Load(object sender, EventArgs e)
        {
            try
            {
                LockEdit(lockEditMenuItem.Checked);
                myMasterNavigator.Location = new Point(15, toolBarGroup.Top - myMasterNavigator.Height + 5);
                myMasterNavigator.BringToFront();

                SetFirstFocus();
                if (!fLoadDataOnFirstShown) return;
                InitForm();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void baseMasterDetailForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (!fLoadDataOnFirstShown) return;
                if (this.DesignMode) return;
                if (myMasterSource.Current == null) LoadAllData(editKeyType);
                //If there is no record, add a new one    
                if (myMasterSource.Current == null)
                {
                    AddNew();
                    LoadData();
                }
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        protected void whenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (AskToSaveWhenClosing && AskToSaveChanged())
                    DoSaveCurrent();
                else CancelAllChanges();  //Reject all unexpected changes;
                SaveConfiguration();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //this.ShowMessage(e.Exception.Message.ToString());
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                ShowSubTotal();
                if (DoSaveCurrent())
                {
                    if (this.printOnSaveMenuItem.Checked && onPrint != null)
                    {
                        onPrint(this.printPreviewMenuItem.Checked);
                    }
                    if (this.newAfterSaveMenuItem.Checked)
                    {
                        AddNew(); LoadDetail();
                    }
                    SetFirstFocus();
                }
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        protected void addLineBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddLineBtnClick();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        protected void deleteLineBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLineBtnClick();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DataRowView drEditData = (DataRowView)myMasterSource.Current;
            if (drEditData == null)
            {
                common.sysLibs.ShowErrorMessage("Không có phiếu hiện thời");
                myMasterSource.EndEdit();
                this.Close();
                return;
            }

            if (MessageBox.Show("Hủy tòan bộ dữ liệu này ?", settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            int editKeyId = GetMasterEditKeyId((DataRowView)myMasterSource.Current);
            try
            {
                TransactionScopeOption tranOption;
                tranOption = (RequireTransactionScope() ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
                using (TransactionScope scope = new TransactionScope(tranOption))
                {
                    if (!RemoveCurrent())
                    {
                        //Reload old data
                        LoadData(editKeyId);
                        common.sysLibs.ShowErrorMessage("Không xoá được dữ liệu");
                        return;
                    }
                    scope.Complete();
                }
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
                //Reload old record
                LoadData(editKeyId);
                common.sysLibs.ShowErrorMessage("Không xoá được dữ liệu.");
                return;
            }
            try
            {
                //Reload data for safety
                LoadAllData(this.editKeyType);
                if (myMasterSource.Current == null)
                {
                    if (MessageBox.Show("Đã xóa dữ liệu cuối,thêm một dữ liệu mới để tiếp tục ?", settings.sysApplicationName, MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Close(); return;
                    }
                    AddNew();
                }
                LoadData();
                SetFirstFocus();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CancelAllChanges();
                LoadData();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.ShowMessage("");
            Close();
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AskToSaveChanged())
                {
                    if (!DoSaveCurrent()) return;
                }
                else CancelAllChanges(); //To ensure that unexpected changes are eliminated

                DataRowView drFound = FindMasterRecord(editKeyType, "", true);
                if (drFound != null)
                {
                    int editKeyId = GetMasterEditKeyId(drFound);
                    if (LoadData(editKeyId))
                    {
                        SetFirstFocus(); return;
                    }
                }

                //In the case when there is no Voucher, add one 
                if (myMasterSource.Current == null) AddNew();
                LoadDetail();
                SetFirstFocus();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AskToSaveChanged())
                {
                    if (!DoSaveCurrent()) return;
                }
                else CancelAllChanges();
                AddNew();
                LockEdit(false);
                LoadDetail();
                SetFirstFocus();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void editKeyEd_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.editKeyEd.Text.Trim() == "")
                {
                    this.ShowMessage("Chưa nhập dữ liệu yêu cầu");
                    LockEdit(true);
                    return;
                }
                string code = this.editKeyEd.Text.Trim();
                if (code.Contains(settings.sysNeedFindMarker))
                {
                    code = code.Replace(settings.sysNeedFindMarker.ToString(), "");
                    DataRowView dr = FindMasterRecord(editKeyType, code, true);
                    if (dr != null) code = dr[myMasterEditKeyFldName].ToString();
                    this.editKeyEd.Text = code;
                    this.editKeyEd.Modified = true;
                }
                LockEdit(lockEditMenuItem.Checked);
                if (!this.editKeyEd.Modified) return;
                if (!EditKeyValidating()) e.Cancel = true;
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }


        private void detailGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                fOnLoadDetail = true;
                DetailValuesNeeded(sender, e);
                fOnLoadDetail = false;
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DetailRowValidating(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fOnLoadDetail) return;

                if (IsCheckCellValueChange) return;
                IsCheckCellValueChange = true;
                DetailCellValueChanged(sender, e);
                IsCheckCellValueChange = false;
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fOnLoading || !fCheckCellValidating) return;
                fCheckCellValidating = false;
                DetailCellContentDoubleClick(sender, e);
                fCheckCellValidating = true;
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void detailGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DetailCellContentClick(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void printerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myPrintDialog.ShowDialog();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myPrintDialog.ShowDialog();
                if (onPrint != null) onPrint(printPreviewMenuItem.Checked);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void copyExitBtn_Click(object sender, EventArgs e)
        {
            copyPanel.Visible = false;
        }
        private void copyDataMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCopyForm();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void copyLineMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CopyLines();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void copyFindBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CopyFindClick(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void copyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CopyClick(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void myMasterNavigator_Enter(object sender, EventArgs e)
        {
            try
            {
                MoveNavigatorSource();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            try
            {
                MoveMasterByNavigator();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            try
            {
                MoveMasterByNavigator();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            try
            {
                MoveMasterByNavigator();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            try
            {
                MoveMasterByNavigator();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void bindingNavigatorPositionItem_Leave(object sender, EventArgs e)
        {
            try
            {
                MoveMasterByNavigator();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void lockEditMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LockEdit(lockEditMenuItem.Checked);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        #endregion event handler

        private void detailGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fOnLoadDetail) return;
                DetailRowEnter(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DetailCellClick(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void printDetailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                printDetailBtn.Enabled = false;
                printPnl.Location = new Point(printDetailBtn.Location.X, toolBarGroup.Location.Y - printPnl.Height - 5);
                printPnl.Show(); printPnl.BringToFront();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid(true)) return;
                if (onPrint != null) onPrint(printPreviewMenuItem.Checked);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void doPrintDetailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid(true)) return;
                if (onDetailPrint != null) onDetailPrint(cbPrintDetailType.SelectedIndex, printPreviewMenuItem.Checked);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void printCloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                printPnl.Hide();
                printDetailBtn.Enabled = true;
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    this.selectedColumn = e.ColumnIndex;
                    this.ShowStatus(this.selectedColumn.ToString());
                }
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    this.selectedColumn = -1;
                    this.ShowStatus("");
                }
                if (this.selectedColumn >= 0)
                {
                    int frColIdx = this.selectedColumn;
                    int toColIdx = e.ColumnIndex;
                    for (int idx = 0; idx < detailGrid.Rows.Count; idx++)
                    {
                        detailGrid[toColIdx, idx].Value = detailGrid[frColIdx, idx].Value;
                    }
                }
            }
            catch (Exception er)
            {
                this.ErrorHander(er);
            }
        }

        private void pasteToGridMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PasteDataToGrid();
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }

        private void detailGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fOnLoadDetail) return;
                DetailCellEnter(sender, e);
            }
            catch (Exception er)
            {
                ErrorHander(er);
            }
        }
    }
}