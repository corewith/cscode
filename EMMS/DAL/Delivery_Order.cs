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
    /// 数据访问类:Delivery_Order
    /// </summary>
    public class Delivery_Order
    {
        public Delivery_Order()
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
        public bool Add(EMMS.Model.Delivery_OrderSet ordermodel, List<EMMS.Model.Delivery_MaterialSet> materialmodelList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_delivery_order(");
            strSql.Append("no,picking,department,warehouse,found_no,found_time,audited,ended,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@picking,@department,@warehouse,@found_no,@found_time,@audited,@ended,@remarks,@make_no,@make_time )");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
					new SqlParameter("@picking", SqlDbType.VarChar,13),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
					new SqlParameter("@warehouse", SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Picking;
            parameters[2].Value = ordermodel.Department;
            parameters[3].Value = ordermodel.Warehouse;
            parameters[4].Value = ordermodel.FoundNo;
            parameters[5].Value = ordermodel.FoundTime;         
            parameters[6].Value = ordermodel.Audited;
            parameters[7].Value = ordermodel.Ended;
            parameters[8].Value = ordermodel.Remarks;
            parameters[9].Value = ordermodel.MakeNo;
            parameters[10].Value = ordermodel.MakeTime;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Delivery_MaterialSet materialmodel in materialmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_delivery_material(");
                strSql1.Append("no,delivery,material,counts,check_no,check_time,audited,check_counts,stocking ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@delivery,@material,@counts,@check_no,@check_time,@audited,@check_counts,@stocking )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@delivery",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4),
                    new SqlParameter("@stocking",SqlDbType.Int,4),
                    //new SqlParameter("@total",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Delivery;
                parameters1[2].Value = materialmodel.Material;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.CheckNo;
                parameters1[5].Value = materialmodel.CheckTime;
                parameters1[6].Value = materialmodel.Audited;
                parameters1[7].Value = materialmodel.CheckCounts;
                parameters1[8].Value = materialmodel.Stocking;
                //parameters1[9].Value = materialmodel.Total;

                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }
            if (rows > 0 && rows1 == materialmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新
        public bool UpdateOrder(EMMS.Model.Delivery_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_delivery_order set ");
            //strSql.Append(" no=@no,");
            strSql.Append(" picking=@picking,");
            strSql.Append(" department=@department,");
            strSql.Append("warehouse=@warehouse,");
            strSql.Append(" found_no=@found_no,");
            strSql.Append(" found_time=@found_time,");
            strSql.Append(" audited=@audited,");
            strSql.Append(" ended=@ended,");
            strSql.Append(" remarks=@remarks,");
            strSql.Append(" make_no=@make_no,");
            strSql.Append(" make_time=@make_time ");
            strSql.Append(" where no=@no");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
					new SqlParameter("@picking", SqlDbType.VarChar,13),
                    new SqlParameter("@department",SqlDbType.VarChar,8),
					new SqlParameter("@warehouse", SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Picking;
            parameters[2].Value = ordermodel.Department;
            parameters[3].Value = ordermodel.Warehouse;
            parameters[4].Value = ordermodel.FoundNo;
            parameters[5].Value = ordermodel.FoundTime;//DateTime.ParseExact(ordermodel.FoundTime, "yyyy-mm-dd", null);
            //DateTime.Parse(ordermodel.FoundTime).ToString("yyyy-MM-dd");//DateTime.Parse(this.tbBirthday.Text).ToString("yyyy-MM-dd hh:mm:ss")
            parameters[6].Value = ordermodel.Audited;
            parameters[7].Value = ordermodel.Ended;
            parameters[8].Value = ordermodel.Remarks;
            parameters[9].Value = ordermodel.MakeNo;
            parameters[10].Value = ordermodel.MakeTime;
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
        public bool UpdateGoods(List<EMMS.Model.Delivery_MaterialSet> materialmodelList)
        {
            int rows = 0;
            foreach (EMMS.Model.Delivery_MaterialSet materialmodel in materialmodelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_delivery_material set ");
                strSql.Append("delivery=@delivery,");
                strSql.Append("material=@material,");
                strSql.Append("counts=@counts,");
                strSql.Append("check_no=@check_no,");
                strSql.Append("check_time=@check_time,");
                strSql.Append("audited=@audited,");
                strSql.Append("check_counts=@check_counts, ");
                strSql.Append("stocking=@stocking ");
                
                strSql.Append("where no=@no ");
                SqlParameter[] parameters ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@delivery",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                    new SqlParameter("@check_no",SqlDbType.VarChar,8),
                    new SqlParameter("@check_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    new SqlParameter("@check_counts",SqlDbType.Int,4),
                    new SqlParameter("@stocking",SqlDbType.Int,4)
                   
                                            };
                parameters[0].Value = materialmodel.No;
                parameters[1].Value = materialmodel.Delivery;
                parameters[2].Value = materialmodel.Material;
                parameters[3].Value = materialmodel.Counts;
                parameters[4].Value = materialmodel.CheckNo;
                parameters[5].Value = materialmodel.CheckTime;
                parameters[6].Value = materialmodel.Audited;
                parameters[7].Value = materialmodel.CheckCounts;
                parameters[8].Value = materialmodel.Stocking;
                

                rows += DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            }
            if ( rows == materialmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从tb_delivery_order中得到一个对象实体,Delivery_OrderSet
        /// </summary>
        public EMMS.Model.Delivery_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,picking,department,warehouse,found_no,found_time,audited,ended,remarks,make_no,make_time from tb_delivery_order ");
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
        //从tb_delivery_material中得到一个对象实体，Delivery_MaterialSet
        public EMMS.Model.Delivery_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,delivery,material,counts,check_no,check_time,audited,check_counts,stocking from tb_delivery_material ");
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
        /// 从view中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere,string strWhere1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,departmentname,warehousename,foundname,foundtime,audited,ended,makename,maketime,remarks,picking ");
            strSql.Append(" FROM view_delivery_order ");
            if (strWhere.Trim() != "")
            {
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

        public DataSet GetList1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,materialname,need,stocking,checktime,audited,checkcounts,materialno,counts,critical ");
            strSql.Append(" FROM getView_delivery_material('"+no+"')");
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where no= '" + strWhere + "'");
            //    //strSql.Append(" or goodsname= '" + strWhere + "'");
            //    // strSql.Append(" or foundtime= " + strWhere + "");
            //}
            return DbHelperSql.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Delivery_OrderView DataRowToModelView(DataRow row)//从view_stocking_order中得到的一行
        {
            EMMS.Model.Delivery_OrderView model = new EMMS.Model.Delivery_OrderView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["warehousename"] != null)
                {
                    model.WarehouseName = row["warehousename"].ToString();
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
                if (row["audited"] != null && row["audited"].ToString() != null)
                {
                    model.Audited = ((int.Parse(row["audited"].ToString())) == 1) ? true : false;
                }
                if (row["ended"] != null && row["ended"].ToString() != null)
                {
                    model.Ended = ((int.Parse(row["ended"].ToString())) == 1) ? true : false;
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
                if (row["picking"] != null)
                {
                    model.Picking = row["picking"].ToString();
                }
            }
            return model;
        }
        //
        public EMMS.Model.Delivery_MaterialView DataRowToModelView1(DataRow row)//从view_stocking_order中得到的一行
        {
            EMMS.Model.Delivery_MaterialView model = new EMMS.Model.Delivery_MaterialView();
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
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["need"] != null)
                { 
                    model.Need=int.Parse(row["need"].ToString());
                }
                //if (row["checkname"] != null)
                //{
                //    model.CheckName = row["checkname"].ToString();
                //}
                if (row["checktime"] != null)
                {
                    model.CheckTime = row["checktime"].ToString();
                }
                if (row["audited"] != null)
                {
                    model.Audited = ((int.Parse(row["audited"].ToString())) == 1) ? true : false;
                }
                if (row["checkcounts"] != null && row["checkcounts"].ToString() != null)
                {
                    model.CheckCounts = int.Parse(row["checkcounts"].ToString());
                }
                if (row["materialno"] != null)
                {
                    model.MaterialNo = row["materialno"].ToString();
                }
                if (row["stocking"] != null)
                {
                    model.Stocking = int.Parse(row["stocking"].ToString());
                }
                if (row["critical"] != null)
                {
                    model.Critical = int.Parse(row["critical"].ToString());
                }
             
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Delivery_OrderSet DataRowToModelSet(DataRow row)//从tb_delivery_order得到的一行
        {
            EMMS.Model.Delivery_OrderSet model = new EMMS.Model.Delivery_OrderSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["picking"] != null)
                {
                    model.Picking = row["picking"].ToString();
                }
                if (row["department"] != null)
                {
                    model.Department = row["department"].ToString();
                }
                if (row["warehouse"] != null)
                {
                    model.Warehouse = row["warehouse"].ToString();
                }
                if (row["found_no"] != null)
                {
                    model.FoundNo = row["found_no"].ToString();
                }
                if (row["found_time"] != null)
                {
                    model.FoundTime = row["found_time"].ToString();
                }
                if (row["audited"] != null)
                {
                    model.Audited = int.Parse(row["audited"].ToString());
                }
                if (row["ended"] != null)
                {
                    model.Ended = int.Parse(row["ended"].ToString());
                }
                if (row["make_no"] != null)
                {
                    model.MakeNo = row["make_no"].ToString();
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
        public EMMS.Model.Delivery_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Delivery_MaterialSet model = new Model.Delivery_MaterialSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["delivery"] != null)
                {
                    model.Delivery = row["delivery"].ToString();
                }
                if (row["material"] != null)
                {
                    model.Material = row["material"].ToString();
                }
                if (row["counts"] != null && row["count"].ToString() != "")
                {
                    model.Counts = int.Parse(row["found_no"].ToString());
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
                if (row["stocking"] != null)
                {
                    model.Stocking = int.Parse(row["stocking"].ToString());
                }
            
            }
            return model;
        }
        public List<EMMS.Model.Delivery_OrderSet> GetModelListByPicking(string picking)
        {
            List<EMMS.Model.Delivery_OrderSet> DeliverySetList = new List<Model.Delivery_OrderSet>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,picking,department,warehouse,found_no,found_time,ended,remarks,make_no,make_time,audited ");
            strSql.Append(" from tb_delivery_order ");
            strSql.Append(" where picking=@picking ");
            SqlParameter[] parameters=new SqlParameter[]
            {
                new SqlParameter("@picking",SqlDbType.VarChar,13)
            };
            parameters[0].Value=picking;
             
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    EMMS.Model.Delivery_OrderSet set=new Model.Delivery_OrderSet();
                    set=DataRowToModelSet(ds.Tables[0].Rows[i]);
                    DeliverySetList.Add(set);
                }
                return DeliverySetList;
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

