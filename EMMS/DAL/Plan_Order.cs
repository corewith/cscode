using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using EMMS.DbHelper;
using System.Windows.Forms;
using System.Collections.Generic;//Please add references
namespace EMMS.DAL
{
    /// <summary>
    /// 数据访问类:Plan_Order
    /// </summary>
    public class Plan_Order
    {
        public Plan_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //public bool Exists(string no)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from tb_warehouse");
        //    strSql.Append(" where no=@no ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@no", SqlDbType.VarChar,8)			};
        //    parameters[0].Value = no;

        //    return DbHelperSql.Exists(strSql.ToString(), parameters);
        //}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Plan_OrderSet ordermodel, List<EMMS.Model.Plan_ProductionSet> productionList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_plan_order(");
            strSql.Append("no,found_no,found_time,audited,status,ended,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@found_no,@found_time,@audited,@status,@ended,@remarks,@make_no,@make_time )");
            //审核，领料状态，结束否
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@status",SqlDbType.NVarChar,10),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.FoundNo;
            parameters[2].Value = ordermodel.FoundTime;
            parameters[3].Value = ordermodel.Audited;
            parameters[4].Value = ordermodel.Status;
            parameters[5].Value = ordermodel.Ended;
            parameters[6].Value = ordermodel.Remarks;
            parameters[7].Value = ordermodel.MakeNo;
            parameters[8].Value = ordermodel.MakeTime;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Plan_ProductionSet materialmodel in productionList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_plan_production(");
                strSql1.Append("no,plan_no,goods,counts,check_no,check_time,audited,check_counts ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@plan_no,@goods,@counts,@check_no,@check_time,@audited,@check_counts )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@plan_no",SqlDbType.VarChar,13),
                   new SqlParameter("@goods",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.Date,8),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.PlanNo;
                parameters1[2].Value = materialmodel.Goods;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.CheckNo;
                parameters1[5].Value = materialmodel.CheckTime;
                parameters1[6].Value = materialmodel.Audited;
                parameters1[7].Value = materialmodel.CheckCounts;
                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }
            if (rows > 0 && rows1 == productionList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Plan_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_plan_order set ");
            //strSql.Append("no=@no,");
            strSql.Append("found_no=@found_no,");
            strSql.Append("found_time=@found_time,");
            strSql.Append("audited=@audited,");
            strSql.Append("status=@status,");
            strSql.Append("ended=@ended,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("make_no=@make_no,");
            strSql.Append("make_time=@make_time ");
            strSql.Append(" where no=@no ");
            
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@status",SqlDbType.NVarChar,10),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.FoundNo;
            parameters[2].Value = ordermodel.FoundTime;
            parameters[3].Value = ordermodel.Audited;
            parameters[4].Value=ordermodel.Status;
            parameters[5].Value = ordermodel.Ended;
            parameters[6].Value = ordermodel.Remarks;
            parameters[7].Value = ordermodel.MakeNo;
            parameters[8].Value = ordermodel.MakeTime;
            //for (int i = 0; i < 8; i++)
            //{
            //    MessageBox.Show(parameters[i].Value.ToString().Length.ToString());
            //}

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateProduction(List<EMMS.Model.Plan_ProductionSet> productionList)
        {
            int rows = 0;
            foreach (EMMS.Model.Plan_ProductionSet materialmodel in productionList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_plan_production set ");
                strSql.Append("plan_no=@plan_no,");
                strSql.Append("goods=@goods,");
                strSql.Append("counts=@counts,");
                strSql.Append("check_no=@check_no,");
                strSql.Append("check_time=@check_time,");
                strSql.Append("audited=@audited,");
                strSql.Append("check_counts=@check_counts ");
                strSql.Append("where no=@no ");
                SqlParameter[] parameters ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@plan_no",SqlDbType.VarChar,13),
                   new SqlParameter("@goods",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.Date,8),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4)
                                            };
                parameters[0].Value = materialmodel.No;
                parameters[1].Value = materialmodel.PlanNo;
                parameters[2].Value = materialmodel.Goods;
                parameters[3].Value = materialmodel.Counts;
                parameters[4].Value = materialmodel.CheckNo;
                parameters[5].Value = materialmodel.CheckTime;
                parameters[6].Value = materialmodel.Audited;
                parameters[7].Value = materialmodel.CheckCounts;
                rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows == productionList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从tb_delivery_order中得到一个对象实体,Plan_OrderSet
        /// </summary>
        public EMMS.Model.Plan_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,found_no,found_time,audited,status,ended,remarks,make_no,make_time ");
            strSql.Append(" from tb_plan_order ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,13)			};
            parameters[0].Value = no;

            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelSet(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        //从tb_plan_production中得到一个对象实体，Plan_ProductionSet
        public EMMS.Model.Plan_ProductionSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,plan_no,goods,counts,check_no,check_time,audited,check_counts from tb_plan_production ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelSet1(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        
        /// <summary>
        /// 从view中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere,string strWhere1)//从view_plan_order中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,found_name,found_time,audited,status,ended,make_name,make_time,remarks ");
            strSql.Append(" FROM view_plan_order ");
            if (strWhere.Trim() != "")
            {
                //strSql.Append(" where no= '" + strWhere + "'");
                //strSql.Append(" or goodsname= '" + strWhere + "'");
                // strSql.Append(" or foundtime= " + strWhere + "");
                strSql.Append(" where audited= " + strWhere);
                if (strWhere1.Trim() != "")
                    strSql.Append("and ended= " + strWhere1);
            }
            else
            {
                if (strWhere1.Trim() != "")
                    strSql.Append("where ended= " + strWhere1);
            }
            return DbHelperSql.Query(strSql.ToString());
        }

        public DataSet GetList1(string planno) //从view_plan_production中得到
        {
            StringBuilder strSql = new StringBuilder(); //删去了checkname
            strSql.Append("select no,goodsname,counts,audited,checkcounts,checktime,goodsno ");
            strSql.Append("from getView_plan_production( '"+planno+"')");
            return DbHelperSql.Query(strSql.ToString());
        }
        /// <summary>
        ///从view_warehouse中 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ");
        //    if (Top > 0)
        //    {
        //        strSql.Append(" top " + Top.ToString());
        //    }
        //    strSql.Append(" no,name,typename,useable,remarks ");
        //    strSql.Append(" FROM view_warehouse ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSql.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获取记录总数
        /// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) FROM tb_warehouse ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    object obj = DbHelperSql.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby);
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.no desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from view_warehouse T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSql.Query(strSql.ToString());
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Plan_OrderView DataRowToModelView(DataRow row)//从view_plan_order中得到的一行
        {
            EMMS.Model.Plan_OrderView model = new EMMS.Model.Plan_OrderView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["found_name"] != null)
                {
                    model.FoundName = row["found_name"].ToString();
                }
                if (row["found_time"] != null)
                {
                    model.FoundTime = row["found_time"].ToString();
                }
                //if (row["audited"] != null && row["audited"].ToString() != "")
                //{
                //    model.audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true ;
                //}
                if (row["audited"] != null && row["audited"].ToString()!="")
                {
                    model.Audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true;
                }
                if (row["status"] != null)
                {
                    model.Status = row["status"].ToString();
                }
                if (row["ended"] != null && row["ended"].ToString() != "")
                {
                    model.Ended = (int.Parse(row["ended"].ToString()) == 0) ? false : true;
                }
                if (row["make_name"] != null)
                {
                    model.MakeName = row["make_name"].ToString();
                }
                if (row["make_time"] != null)
                {
                    model.MakeTime = row["make_time"].ToString();
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        //
        public EMMS.Model.Plan_ProductionView DataRowToModelView1(DataRow row)//从view_plan_production中得到的一行
        {
            EMMS.Model.Plan_ProductionView model = new EMMS.Model.Plan_ProductionView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["goodsname"] != null)
                {
                    model.GoodsName = row["goodsname"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString()!=null)
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                //if (row["checkname"] != null)
                //{
                //    model.CheckName = row["checkname"].ToString();
                //}
                if (row["audited"] != null && row["audited"].ToString() != "")
                {
                    model.Audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true;
                }
                if (row["checkcounts"] != null && row["checkcounts"].ToString()!=null)
                {
                    model.CheckCounts = int.Parse(row["checkcounts"].ToString());
                }
                if (row["checktime"] != null)
                {
                    model.CheckTime = row["checktime"].ToString();
                }
                if (row["goodsno"] != null)
                {
                    model.GoodsNo = row["goodsno"].ToString();
                }
            }
            return model;
        }
        //得到仓库类别名称
        //public List<String> GetNameList()
        //{
        //    WarehouseAttri dal = new WarehouseAttri();
        //    DataSet ds = new DataSet();
        //    ds = dal.GetList("");
        //    List<String> nameList = new List<String>();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            nameList.Add(row["name"].ToString());
        //        }
        //    }
        //    return nameList;
        //}
        //public List<TreeNode> GetNodeList()
        //{
        //    List<TreeNode> nodeList = new List<TreeNode>();
        //    List<String> nameList = new List<string>();
        //    nameList = GetNameList();
        //    foreach (string name in nameList)
        //    {
        //        nodeList.Add(new TreeNode() { Text = name });
        //    }
        //    return nodeList;
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Plan_OrderSet DataRowToModelSet(DataRow row)//从tb_delivery_order得到的一行
        {
            EMMS.Model.Plan_OrderSet model = new EMMS.Model.Plan_OrderSet();
            if (row != null)
            {
                //no,found_no,found_time,audited,ended,remarks,make_no,make_time
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["found_no"] != null)
                {
                    model.FoundNo = row["found_no"].ToString();
                }
                if (row["found_time"] != null)
                {
                    model.FoundTime = row["found_time"].ToString();
                }
                if (row["audited"] != null && row["audited"].ToString() != null)
                {
                    model.Audited = int.Parse(row["audited"].ToString());
                }
                if (row["status"] != null)
                {
                    model.Status = row["status"].ToString();
                }
                if (row["ended"] != null && row["ended"].ToString() != null)
                {
                    model.Ended = int.Parse(row["ended"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
                if (row["make_no"] != null)
                {
                    model.MakeNo = row["make_no"].ToString();
                }
                if (row["make_time"] != null)
                {
                    model.MakeTime = row["make_time"].ToString();
                }
            }
            return model;
        }
        //
        public EMMS.Model.Plan_ProductionSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Plan_ProductionSet model = new Model.Plan_ProductionSet();
            if (row != null)
            {
                //no,plan_no,goods,counts,check_no,check_time,audited,check_counts
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["plan_no"] != null)
                {
                    model.PlanNo = row["plan_no"].ToString();
                }
                if (row["goods"] != null)
                {
                    model.Goods = row["goods"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["check_no"] != null)
                {
                    model.CheckNo = row["check_no"].ToString();
                }
                if (row["check_time"] != null)
                {
                    model.CheckTime = row["check_time"].ToString();
                }
                if (row["audited"] != null && row["audited"].ToString() != null)
                { 
                    model.Audited=int.Parse(row["audited"].ToString());
                }
                if (row["check_counts"] != null && row["check_counts"].ToString() != null)
                {
                    model.CheckCounts = int.Parse(row["check_counts"].ToString());
                }
            }
            return model;
        }

        #endregion  ExtensionMethod
    }
}

