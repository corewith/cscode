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
    /// 数据访问类:Picking_Order
    /// </summary>
    public class Picking_Order
    {
        public Picking_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_picking_order");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Picking_OrderSet ordermodel, List<EMMS.Model.Picking_MaterialSet> goodsmodelList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_picking_order(");
            strSql.Append("no,plan_no,department,found_no,found_time,status,ended,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@plan_no,@department,@found_no,@found_time,@status,@ended,@remarks,@make_no,@make_time )");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("@plan_no",SqlDbType.VarChar,13),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@status",SqlDbType.VarChar,20),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.PlanNo;
            parameters[2].Value = ordermodel.Department;
            parameters[3].Value = ordermodel.FoundNo;
            parameters[4].Value = ordermodel.FoundTime;
            parameters[5].Value = ordermodel.Status;
            parameters[6].Value = ordermodel.Ended;
            parameters[7].Value = ordermodel.Remarks;
            parameters[8].Value = ordermodel.MakeNo;
            parameters[9].Value = ordermodel.MakeTime;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Picking_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_picking_material(");
                strSql1.Append("no,picking,material,counts,stocking ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@picking,@material,@counts,@stocking )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@picking",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@stocking",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Picking;
                parameters1[2].Value = materialmodel.Material;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.Stocking;
        
                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }
            if (rows > 0 && rows1 == goodsmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Picking_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_picking_order set ");
            //strSql.Append("no=@no,");
            strSql.Append("plan_no=@plan_no,");
            strSql.Append("department=@department,");
            strSql.Append("found_no=@found_no,");
            strSql.Append("found_time=@found_time,");
            strSql.Append("status=@status,");
            strSql.Append("ended=@ended,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("make_no=@make_no,");
            strSql.Append("make_time=@make_time ");
            strSql.Append("where no=@no");

            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("@plan_no",SqlDbType.VarChar,13),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@status",SqlDbType.VarChar,20),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.PlanNo;
            parameters[2].Value = ordermodel.Department;
            parameters[3].Value = ordermodel.FoundNo;
            parameters[4].Value = ordermodel.FoundTime;
            parameters[5].Value = ordermodel.Status;
            parameters[6].Value = ordermodel.Ended;
            parameters[7].Value = ordermodel.Remarks;
            parameters[8].Value = ordermodel.MakeNo;
            parameters[9].Value = ordermodel.MakeTime;
 
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
        public bool UpdateGoods(List<EMMS.Model.Picking_MaterialSet> goodsmodelList)
        {
            int rows = 0;
            foreach (EMMS.Model.Picking_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_picking_material set ");
                strSql.Append("picking=@picking,");
                strSql.Append("material=@material,");
                strSql.Append("counts=@counts,");
                strSql.Append("stocking=@stocking ");
                strSql.Append("where no=@no ");

                SqlParameter[] parameters ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@picking",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@stocking",SqlDbType.Int,4)
                                            };
                parameters[0].Value = materialmodel.No;
                parameters[1].Value = materialmodel.Picking;
                parameters[2].Value = materialmodel.Material;
                parameters[3].Value = materialmodel.Counts;
                parameters[4].Value = materialmodel.Stocking;

                rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows == goodsmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从tb_picking_order中得到一个对象实体,Picking_OrderSet
        /// </summary>
        public EMMS.Model.Picking_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,plan_no,department,found_no,found_time,status,ended,remarks,make_no,make_time ");
            strSql.Append(" from tb_picking_order ");
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
        //从tb_picking_material中得到一个对象实体，Picking_MaterialSet
        public EMMS.Model.Picking_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,picking,material,counts,stocking ");
            strSql.Append("from tb_picking_material ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,13)			};
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
        public DataSet GetList(string strWhere)//从view_picking_order中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,departmentname,foundname,foundtime,status,ended,makename,maketime,remarks,planno ");
            strSql.Append(" FROM view_picking_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where ended=" + strWhere);
            }
            return DbHelperSql.Query(strSql.ToString());
        }

        public DataSet GetList1(string no) //从view_picking_material中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,materialname,counts,unit,materialno,stocking ");
            strSql.Append("from getView_picking_material('"+no+"')");
            return DbHelperSql.Query(strSql.ToString());
        }
         /// <summary>
        /// 获取记录总数
        /// </summary>
       
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
       
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Picking_OrderView DataRowToModelView(DataRow row)//从view_picking_order中得到的一行
        {
            EMMS.Model.Picking_OrderView model = new EMMS.Model.Picking_OrderView();
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
                if (row["planno"] != null)
                {
                    model.PlanNo = row["planno"].ToString();
                }
            }
            return model;
        }

        //
        public EMMS.Model.Picking_MaterialView DataRowToModelView1(DataRow row)//从view_picking_material中得到的一行
        {
            EMMS.Model.Picking_MaterialView model = new EMMS.Model.Picking_MaterialView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["materialname"] != null)
                {
                    model.MaterialName= row["materialname"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != null)
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["unit"] != null)
                {
                    model.Unit = row["unit"].ToString();
                }
                if (row["materialno"] != null)
                {
                    model.MaterialNo = row["materialno"].ToString();
                }
                if (row["stocking"] != null && row["stocking"].ToString()!= null)
                {
                    model.Stocking = int.Parse(row["stocking"].ToString());
                }
            }
            return model;
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Picking_OrderSet DataRowToModelSet(DataRow row)//从tb_picking_order得到的一行
        {
            EMMS.Model.Picking_OrderSet model = new EMMS.Model.Picking_OrderSet();
            if (row != null)
            {
                //no,found_no,found_time,audited,ended,remarks,make_no,make_time
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["plan_no"] != null)
                {
                    model.PlanNo = row["plan_no"].ToString();
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
        public EMMS.Model.Picking_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Picking_MaterialSet model = new Model.Picking_MaterialSet();
            if (row != null)
            {
                //no,plan_no,goods,counts,check_no,check_time,audited,check_counts
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["picking"] != null)
                {
                    model.Picking = row["picking"].ToString();
                }
                if (row["material"] != null)
                {
                    model.Material = row["material"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["stocking"] != null)
                {
                    model.Stocking = int.Parse(row["stocking"].ToString());
                }

            }
            return model;
        }

        #endregion  ExtensionMethod
    }
}

