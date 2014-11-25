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
    /// 数据访问类:Requisition_Order
    /// </summary>
    public class Requisition_Order
    {
        public Requisition_Order()
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
        public bool Add(EMMS.Model.Requisition_OrderSet ordermodel, List<EMMS.Model.Requisition_MaterialSet> goodsList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_requisition_order(");
            strSql.Append("no,department,found_no,found_time,audited,status,ended,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@department,@found_no,@found_time,@audited,@status,@ended,@remarks,@make_no,@make_time )");
            //审核，领料状态，结束否
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@status",SqlDbType.NVarChar,10),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Department;
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;
            parameters[4].Value = ordermodel.Audited;
            parameters[5].Value = ordermodel.Status;
            parameters[6].Value = ordermodel.Ended;
            parameters[7].Value = ordermodel.Remarks;
            parameters[8].Value = ordermodel.MakeNo;
            parameters[9].Value = ordermodel.MakeTime;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Requisition_MaterialSet materialmodel in goodsList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_requisition_material(");
                strSql1.Append("no,requisition,material,counts,check_no,check_time,audited,check_counts ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@requisition,@material,@counts,@check_no,@check_time,@audited,@check_counts )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@requisition",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.Date,8),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Requisition;
                parameters1[2].Value = materialmodel.Material;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.CheckNo;
                parameters1[5].Value = materialmodel.CheckTime;
                parameters1[6].Value = materialmodel.Audited;
                parameters1[7].Value = materialmodel.CheckCounts;
                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }
            if (rows > 0 && rows1 == goodsList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Requisition_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_requisition_order set ");
            strSql.Append("department=@department,");
            strSql.Append("found_no=@found_no,");
            strSql.Append("found_time=@found_time,");
            strSql.Append("audited=@audited,");
            strSql.Append("status=@status,");
            strSql.Append("ended=@ended,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("make_no=@make_no,");
            strSql.Append("make_time=@make_time ");
            strSql.Append(" where no=@no");

            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("department",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@status",SqlDbType.NVarChar,10),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Department;
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;
            parameters[4].Value = ordermodel.Audited;
            parameters[5].Value = ordermodel.Status;
            parameters[6].Value = ordermodel.Ended;
            parameters[7].Value = ordermodel.Remarks;
            parameters[8].Value = ordermodel.MakeNo;
            parameters[9].Value = ordermodel.MakeTime;
            //for (int i = 0; i < 8; i++)
            //{
            //    MessageBox.Show(parameters[i].Value.ToString().Length.ToString());
            //}

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateGoods(List<EMMS.Model.Requisition_MaterialSet> goodsList)
        {
            int rows = 0;
            foreach (EMMS.Model.Requisition_MaterialSet materialmodel in goodsList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_requisition_material set ");
                strSql.Append("requisition=@requisition,");
                strSql.Append("material=@material,");
                strSql.Append("counts=@counts,");
                strSql.Append("check_no=@check_no,");
                strSql.Append("check_time=@check_time,");
                strSql.Append("audited=@audited,");
                strSql.Append("check_counts=@check_counts ");
                strSql.Append("where no=@no ");
                SqlParameter[] parameters ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@requisition",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.Date,8),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4)
                                            };
                parameters[0].Value = materialmodel.No;
                parameters[1].Value = materialmodel.Requisition;
                parameters[2].Value = materialmodel.Material;
                parameters[3].Value = materialmodel.Counts;
                parameters[4].Value = materialmodel.CheckNo;
                parameters[5].Value = materialmodel.CheckTime;
                parameters[6].Value = materialmodel.Audited;
                parameters[7].Value = materialmodel.CheckCounts;
                rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows == goodsList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从tb_delivery_order中得到一个对象实体,Requisition_OrderSet
        /// </summary>
        public EMMS.Model.Requisition_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,department,found_no,found_time,audited,status,ended,remarks,make_no,make_time ");
            strSql.Append(" from tb_requisition_order ");
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
        //从tb_requisition_material中得到一个对象实体，Requisition_MaterialSet
        public EMMS.Model.Requisition_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,requisition,material,counts,check_no,check_time,audited,check_counts from tb_requisition_material ");
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
        public DataSet GetList(string strWhere, string strWhere1)//从view_requisition_order中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,departmentname,foundname,foundtime,audited,status,ended,makename,maketime,remarks ");
            strSql.Append(" FROM view_requisition_order ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,materialname,counts,audited,checkcounts,checktime,materialno ");
            strSql.Append("from getView_requisition_material( '" + planno + "')");
            return DbHelperSql.Query(strSql.ToString());
        }
        

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Requisition_OrderView DataRowToModelView(DataRow row)//从view_requisition_order中得到的一行
        {
            EMMS.Model.Requisition_OrderView model = new EMMS.Model.Requisition_OrderView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["departmentname"] != null)
                {
                    model.DepartmentName = row["departmentname"].ToString();
                }
                if (row["foundname"] != null)
                {
                    model.FoundName = row["foundname"].ToString();
                }
                if (row["foundtime"] != null)
                {
                    model.FoundTime = row["foundtime"].ToString();
                }
                //if (row["audited"] != null && row["audited"].ToString() != "")
                //{
                //    model.audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true ;
                //}
                if (row["audited"] != null && row["audited"].ToString() != "")
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
                if (row["makename"] != null)
                {
                    model.MakeName = row["makename"].ToString();
                }
                if (row["maketime"] != null)
                {
                    model.MakeTime = row["maketime"].ToString();
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        //
        public EMMS.Model.Requisition_MaterialView DataRowToModelView1(DataRow row)//从view_plan_production中得到的一行
        {
            EMMS.Model.Requisition_MaterialView model = new EMMS.Model.Requisition_MaterialView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["materialname"] != null)
                {
                    model.MaterialName = row["materialname"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != null)
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
                if (row["checkcounts"] != null && row["checkcounts"].ToString() != null)
                {
                    model.CheckCounts = int.Parse(row["checkcounts"].ToString());
                }
                if (row["checktime"] != null)
                {
                    model.CheckTime = row["checktime"].ToString();
                }
                if (row["materialno"] != null)
                {
                    model.MaterialNo = row["materialno"].ToString();
                }
            }
            return model;
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Requisition_OrderSet DataRowToModelSet(DataRow row)//从tb_delivery_order得到的一行
        {
            EMMS.Model.Requisition_OrderSet model = new EMMS.Model.Requisition_OrderSet();
            if (row != null)
            {
                //no,found_no,found_time,audited,ended,remarks,make_no,make_time
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["department"] != null)
                {
                    model.Department = row["department"].ToString();
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
        public EMMS.Model.Requisition_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Requisition_MaterialSet model = new Model.Requisition_MaterialSet();
            if (row != null)
            {
                //no,plan_no,goods,counts,check_no,check_time,audited,check_counts
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["requisition"] != null)
                {
                    model.Requisition = row["requisition"].ToString();
                }
                if (row["material"] != null)
                {
                    model.Material = row["material"].ToString();
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
                    model.Audited = int.Parse(row["audited"].ToString());
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

