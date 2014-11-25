using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMMS.View.plan
{
    public partial class Plan_Order : EMMS.Common.View
    {
        private EMMS.BLL.Plan_Order bll = new BLL.Plan_Order();//
        private EMMS.Model.Plan_OrderSet orderModel = new Model.Plan_OrderSet();//保留出库单信息
        private int index;
        public int flag; //标志，0表示增加，1表示修改(审核),2表示查看详情
        private EMMS.Common.View view;
        private int role;

        #region 构造函数
        public Plan_Order()
        {
            InitializeComponent();
            index = -1;
            flag = 0;
            role = EMMS.Common.SavedInfo.Role;

        }
        #endregion

        #region 基本函数
        public void GetParent(EMMS.Common.View view)
        {
            this.view = view;
        }
        public void Init()
        {
            DataGridViewLinkColumn l1 = new DataGridViewLinkColumn();
            l1.UseColumnTextForLinkValue = true;
            l1.HeaderText = "删除";
            l1.Text = "删除";
            l1.Name = "delete";
            dgvPlan.Columns.Add(l1);

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "编码";
            c1.DataPropertyName = "No";
            c1.Name = "no";
            c1.ValueType = typeof(string);
            c1.ReadOnly = true;
            dgvPlan.Columns.Add(c1);

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "产品名称";
            btn1.DataPropertyName = "GoodsName";
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Name = "goodsname";
            btn1.ToolTipText = "请选择物品";
            dgvPlan.Columns.Add(btn1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "数量";
            c2.DataPropertyName = "Counts";
            c2.Name = "counts";
            c2.ValueType = typeof(string);
            dgvPlan.Columns.Add(c2);

            //DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            //c3.HeaderText = "库存量";
            //c3.Name = "storagecounts";
            //c3.ValueType = typeof(int);
            //dgvPlan.Columns.Add(c3);

            //DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            //c4.HeaderText = "警戒线";
            //c4.Name = "critical";
            //c4.ValueType = typeof(int);
            //dgvPlan.Columns.Add(c4);

            //DataGridViewTextBoxColumn c7 = new DataGridViewTextBoxColumn();
            //c7.HeaderText = "审核人员姓名";
            //c7.DataPropertyName = "CheckName";
            //c7.Name = "checkname";
            //c7.ValueType = typeof(string);
            //dgvPlan.Columns.Add(c7);
            //dgvPlan.Columns["checkname"].Visible = false;

            DataGridViewCheckBoxColumn c8 = new DataGridViewCheckBoxColumn();
            c8.HeaderText = "审核";
            c8.DataPropertyName = "Audited";
            c8.Name = "audited";
            c8.ValueType = typeof(bool);
            dgvPlan.Columns.Add(c8);
            dgvPlan.Columns["audited"].Visible = false;

            DataGridViewTextBoxColumn c9 = new DataGridViewTextBoxColumn();
            c9.HeaderText = "审核数量";
            c9.DataPropertyName = "CheckCounts";
            c9.Name = "checkcounts";
            c9.ValueType = typeof(string);
            dgvPlan.Columns.Add(c9);
            dgvPlan.Columns["checkcounts"].Visible = false;

            DataGridViewTextBoxColumn c10 = new DataGridViewTextBoxColumn();
            c10.HeaderText = "审核时间";
            c10.DataPropertyName = "CheckTime";
            c10.Name = "checktime";
            c10.ValueType = typeof(string);
            dgvPlan.Columns.Add(c10);
            dgvPlan.Columns["checktime"].ReadOnly = true;
            dgvPlan.Columns["checktime"].Visible = false;

            DataGridViewTextBoxColumn c11 = new DataGridViewTextBoxColumn();
            c11.HeaderText = "编码";
            c11.DataPropertyName = "GoodsNo";
            c11.Name = "goodsno";
            c11.ValueType = typeof(string);
            dgvPlan.Columns.Add(c11);
            //让其隐藏
            dgvPlan.Columns["goodsno"].Visible = false;
        }
        #endregion

        #region 初始化
        private void Stocking_Order_Load(object sender, EventArgs e)
        {
            Init();
            
            if (flag == 0)
            {
                tbNo.Text = orderModel.No;//生产单编码
                tbMakeName.Text = EMMS.Common.SavedInfo.StaffName;
                tbMakeTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (flag == 1)//标志，0表示增加，1表示修改(审核),2表示查看详情
            {
                //btnStaff.Enabled = false;
                dgvPlan.Columns["delete"].Visible = false;
                dtpTime.Enabled = false;
                if (view.ProductionModelViewFlag == 1)
                { 
                    dgvPlan.DataSource = view.ProductionModelViewList;
                    for (int i = 0; i < dgvPlan.Columns.Count; i++)
                    {
                        if (i == 3 || i == 4)
                        {
                            dgvPlan.Columns[i].ReadOnly = false;
                        }
                        else
                        {
                            dgvPlan.Columns[i].ReadOnly = true;
                        }
                    }
                }
            }
            else if (flag == 2)  //查看详情
            {
                dgvPlan.Columns["delete"].Visible = false;
                tsbSave.Visible = false;
                tbMakeName.ReadOnly = true;
                tbMakeTime.ReadOnly = true;
                tbNo.ReadOnly = true;
                tbRemarks.ReadOnly = true;
                tbStaff.ReadOnly = true;
                dtpTime.Enabled = false;
                //btnStaff.Enabled = false;
                dgvPlan.ReadOnly = true;

                //所有人都可以查看
                //dgvPlan.Columns["checkname"].Visible = true;
                dgvPlan.Columns["audited"].Visible = true;
                dgvPlan.Columns["checkcounts"].Visible = true;
                dgvPlan.Columns["checktime"].Visible = true;
                //dgvPlan.Columns["goodsname"].ReadOnly = true;
                //如何设置按钮不可用呢
                

                tbNo.Text = view.PlanModelView.No;
                tbStaff.Text = view.PlanModelView.FoundName;
                tbRemarks.Text = view.PlanModelView.Remarks;
                dtpTime.Value = DateTime.Parse(view.PlanModelView.FoundTime);
                tbMakeName.Text = view.PlanModelView.MakeName;
                tbMakeTime.Text = view.PlanModelView.MakeTime;

                dgvPlan.DataSource = view.ProductionModelViewList;

                dgvPlan.ReadOnly = true;
            }
            if (flag != 2) //不是查看详情
            {
                if (EMMS.Common.SavedInfo.Role == 0 || EMMS.Common.SavedInfo.Role == 1) //管理员或者产品经理
                {
                    //dgvPlan.Columns["checkname"].Visible = true;
                    dgvPlan.Columns["audited"].Visible = true;
                    dgvPlan.Columns["checkcounts"].Visible = true;
                    dgvPlan.Columns["checktime"].Visible = true;
                }
            }
        }
        #endregion

        #region 其他
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvStocking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.Validate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvStocking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPlan.EndEdit();
        }

        private void dgvStocking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //标志，0表示增加，1表示修改(审核),2表示查看详情
            index = e.RowIndex;
            if (flag == 0)
            {
                if (dgvPlan.Columns[e.ColumnIndex].Name == "goodsname")
                {
                    EMMS.View.goods.List list = new goods.List();
                    list.GetParent(this);
                    list.typename = "成品";
                    list.ShowDialog();
                }
            }
            if (flag != 2)
            {
                if (dgvPlan.Columns[e.ColumnIndex].Name == "audited")
                {
                    if (dgvPlan.Rows[e.RowIndex].Cells["audited"].Value == null)
                    {
                        dgvPlan.Rows[e.RowIndex].Cells["audited"].Value = true;
                    }
                    else if (bool.Parse(dgvPlan.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true)
                    {
                        dgvPlan.Rows[e.RowIndex].Cells["audited"].Value = false;
                        this.Validate();
                    }
                    else if (bool.Parse(dgvPlan.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == false)
                    {
                        dgvPlan.Rows[e.RowIndex].Cells["audited"].Value = true;
                        this.Validate();
                    }
                }
            }
            if (flag != 1 && flag != 2) //不是审核也不是查看详情
            {
                if (dgvPlan.Columns[e.ColumnIndex].Name == "delete")
                {
                    dgvPlan.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void Stocking_Order_Activated(object sender, EventArgs e)
        {
            if (flag == 0)//增加的时候才需要填写
            {
                if (base.GoodsFlag == 1)
                {
                    dgvPlan.Rows[index].Cells["goodsname"].Value = base.GoodsModel.Name;
                    if (base.GoodsModel.No != null)
                    {
                        EMMS.Model.Plan_ProductionSet productionmodel = new Model.Plan_ProductionSet();
                        dgvPlan.Rows[index].Cells["no"].Value = productionmodel.No;//
                        dgvPlan.Rows[index].Cells["goodsno"].Value = base.GoodsModel.No;

                    }
                    base.GoodsFlag = 0;
                }
                if (base.StaffFlag == 1)
                {
                    this.tbStaff.Text = base.StaffModel.Name;//赋值创建人员姓名
                    base.StaffFlag = 0;
                }
            }
            
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            if (flag != 1 && flag!=2)
            {
                EMMS.View.staff.List list = new staff.List();
                list.GetParent(this);
                list.ShowDialog();
            }
        }
        #endregion

        #region 保存
        private void tsbSave_Click(object sender, EventArgs e)
        {
             List<EMMS.Model.Plan_ProductionSet> productionList = new List<Model.Plan_ProductionSet>();//保留出库-物料联系信息

            dgvPlan.EndEdit();
            if (flag == 0)
            {
                if (String.IsNullOrEmpty(tbStaff.Text))
                {
                    MessageBox.Show("请选择经手人员！");
                    return;
                }
            }
            orderModel.No = tbNo.Text;
            if (flag == 0)
            {
                orderModel.FoundNo = base.StaffModel.No;//得到所选择的人员编码
            }
            else if (flag == 1)
            {
                orderModel.FoundNo = view.PlanModelSet.FoundNo;
            }
            orderModel.FoundTime = dtpTime.Value.ToShortDateString();
            orderModel.Remarks = tbRemarks.Text;
            if (flag == 0)
            {
                orderModel.MakeNo = EMMS.Common.SavedInfo.StaffNo;
            }
            else  if (flag == 1)
            {
                orderModel.MakeNo = view.PlanModelSet.MakeNo;
            }
            orderModel.MakeTime = tbMakeTime.Text;

                //if (dgvPlan.Rows.Count < 2)
                //{
                //    MessageBox.Show("请填写好相关信息！");
                //    return;
                //}
            //很特殊的写法，不完善！
            try
            {
                if (dgvPlan.Rows[0].Cells["counts"].Value == null)
                {
                    MessageBox.Show("请填写好相关信息！");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("请填写好相关信息！");
            }
                bool ended = true;//用来判断是否都已审核，若都已经审核，则设为true
            //此处比较特殊
                int count = 0;
                if (flag == 0) //增加
                {
                    count = dgvPlan.Rows.Count - 1;
                }
                else if (flag == 1)
                {
                    count = dgvPlan.Rows.Count;
                }
                for (int i = 0; i < count; i++)//得减一行
                {
                    //bool ended = true;
                    if (dgvPlan.Rows[i].Cells["no"].Value.ToString() != null)
                    {
                        EMMS.Model.Plan_ProductionSet production = new Model.Plan_ProductionSet();
                        production.No = dgvPlan.Rows[i].Cells["no"].Value.ToString();
                        production.PlanNo = tbNo.Text;//记录联系
                        production.Goods = dgvPlan.Rows[i].Cells["goodsno"].Value.ToString();

                        try  //判断是否能是数字
                        {
                            production.Counts = int.Parse(dgvPlan.Rows[i].Cells["counts"].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("请填写正确的生产数目！");
                            return;
                        }
                        if (production.Counts <= 0) //数目小于0,不合法
                        {
                            MessageBox.Show("请填写正确的生产数目！");
                            return;
                        }
                        
                        if (dgvPlan.Rows[i].Cells["audited"].Value != null)  //若不为空，空表示还未审核！
                        {
                            if (bool.Parse(dgvPlan.Rows[i].Cells["audited"].Value.ToString()) == true)
                            {
                                production.CheckNo = EMMS.Common.SavedInfo.StaffNo;
                                production.Audited = 1;//表示已审核
                                production.CheckCounts = int.Parse(dgvPlan.Rows[i].Cells["checkcounts"].Value.ToString());
                                production.CheckTime = dgvPlan.Rows[i].Cells["checktime"].Value.ToString();
                            }
                            else
                            {
                                ended = false;
                            }
                        }
                        else //空表示还未审核
                        {
                            ended = false;
                        }
                        productionList.Add(production);
                    }

                }
                //此处可用触发器代替
                if (ended == true)
                {
                    orderModel.Audited = 1;//所有的都已审核
                }
                if (flag == 0)
                {
                    if (bll.Add(orderModel, productionList))
                    {
                        if (ended == true)
                        {
                            MessageBox.Show("保存成功，且已审核！");
                            //
                            EMMS.Common.SavedInfo.PlanOrderSet = orderModel;
                            List<EMMS.Model.Stocking_MaterialView> stockingViewList = new List<Model.Stocking_MaterialView>();
                            List<EMMS.Model.Plan_ProductionView> planViewList=bll.GetModelListView1(orderModel.No);
                            EMMS.BLL.Goods goodsBll = new BLL.Goods();
                            for (int i = 0; i < planViewList.Count; i++)
                            {
                                EMMS.Model.Stocking_MaterialView stockingView = new Model.Stocking_MaterialView();
                                EMMS.Model.GoodsSet goodsSet = new Model.GoodsSet();
                                goodsSet = goodsBll.GetModel(planViewList[i].GoodsNo);
                                //stockingView.No
                                stockingView.MaterialName = planViewList[i].GoodsName;
                                stockingView.Counts = productionList[i].CheckCounts;
                                stockingView.Unit = goodsSet.Unit;
                                stockingView.MaterialNo = planViewList[i].GoodsNo;
                                stockingViewList.Add(stockingView);
                            }
                            EMMS.Common.SavedInfo.StockingFlag1 = 1;
                            EMMS.Common.SavedInfo.StockingMaterialViewList1 = stockingViewList;
                        }
                        else
                        {
                            MessageBox.Show("保存成功！但还未审核完！");
                        }
                    }
                }
                else if (flag == 1)
                { 
                    if(bll.UpdateOrder(orderModel)&&bll.UpdateProduction(productionList))
                    {
                        if(ended==true)
                        {
                            MessageBox.Show("更新成功，已审核！");
                            //
                            EMMS.Common.SavedInfo.PlanOrderSet = orderModel;
                            List<EMMS.Model.Stocking_MaterialView> stockingViewList = new List<Model.Stocking_MaterialView>();
                            List<EMMS.Model.Plan_ProductionView> planViewList = bll.GetModelListView1(orderModel.No);
                            EMMS.BLL.Goods goodsBll = new BLL.Goods();
                            for (int i = 0; i < planViewList.Count; i++)
                            {
                                EMMS.Model.Stocking_MaterialView stockingView = new Model.Stocking_MaterialView();
                                EMMS.Model.GoodsSet goodsSet = new Model.GoodsSet();
                                goodsSet = goodsBll.GetModel(planViewList[i].GoodsNo);
                                //stockingView.No
                                stockingView.MaterialName = planViewList[i].GoodsName;
                                stockingView.Counts = productionList[i].CheckCounts;
                                stockingView.Unit = goodsSet.Unit;
                                stockingView.MaterialNo = planViewList[i].GoodsNo;
                                stockingViewList.Add(stockingView);
                            }
                            EMMS.Common.SavedInfo.StockingFlag1 = 1;
                            EMMS.Common.SavedInfo.StockingMaterialViewList1 = stockingViewList;
                        }
                        else
                        {
                            MessageBox.Show("更新成功，但仍未审核完！");
                        }
                    }
                }
                this.Dispose();
            }
 
        #endregion

        #region cellvaluechanged
        private void dgvDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //************************管理员或仓库经理***************************************//
            if (dgvPlan.Columns[e.ColumnIndex].Name == "audited")
            {

                if (bool.Parse(dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)//如果选择了审核
                {

                    if (dgvPlan.Rows[e.RowIndex].Cells["goodsno"].Value == null)
                    {
                        MessageBox.Show("请先选择产品！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    if (dgvPlan.Rows[e.RowIndex].Cells["counts"].Value == null)
                    {
                        MessageBox.Show("请先填写生产数量！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        return;
                    }
                    //dgvPlan.Rows[e.RowIndex].Cells["checkname"].Value = EMMS.Common.SavedInfo.StaffName;//

                    dgvPlan.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvPlan.Rows[e.RowIndex].Cells["counts"].Value;//

                    dgvPlan.Rows[e.RowIndex].Cells["checktime"].Value = DateTime.Now.ToShortDateString();
                }
                if (bool.Parse(dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                {
                    //dgvPlan.Rows[e.RowIndex].Cells["checkname"].Value = null;

                    dgvPlan.Rows[e.RowIndex].Cells["checkcounts"].Value = null;

                    dgvPlan.Rows[e.RowIndex].Cells["checktime"].Value = null;
                }
            }
            //************************管理员或仓库经理***************************************//
            if (dgvPlan.Columns[e.ColumnIndex].Name == "counts")
            {
                if (dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (dgvPlan.Rows[e.RowIndex].Cells["goodsno"].Value == null)
                    {   
                        MessageBox.Show("请先选择产品！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                    if (EMMS.Common.PageValidate.IsNumber(dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    { }
                    else
                    {
                        MessageBox.Show("请填写数字！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                    if (dgvPlan.Rows[e.RowIndex].Cells["audited"].Value != null)
                    {
                        if (bool.Parse(dgvPlan.Rows[e.RowIndex].Cells["audited"].Value.ToString()) == true) //如果已经审核
                        {
                            dgvPlan.Rows[e.RowIndex].Cells["checkcounts"].Value = dgvPlan.Rows[e.RowIndex].Cells["counts"].Value;
                        }
                    } 
                }
                if (dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dgvPlan.Rows[e.RowIndex].Cells["checkcounts"].Value = null;
                }
            }

            if (dgvPlan.Columns[e.ColumnIndex].Name == "checkcounts")
            {
                if (dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (dgvPlan.Rows[e.RowIndex].Cells["goodsno"].Value == null)
                    {
                        MessageBox.Show("请先选择产品！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                    if (dgvPlan.Rows[e.RowIndex].Cells["counts"].Value == null)
                    {
                        MessageBox.Show("请先填写生产数量！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                    if (EMMS.Common.PageValidate.IsNumber(dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    { }
                    else
                    {
                        MessageBox.Show("请填写数字！");
                        dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                        return;
                    }
                }
            }
        }
        #endregion

        private void dgvDelivery_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void tsStocking_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    //自定义DataGridViewDisableButtonColumn列按钮类型

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (!this.enabledValue)
            {
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    System.Windows.Forms.VisualStyles.PushButtonState.Disabled);

                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
