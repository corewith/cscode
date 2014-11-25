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
    /// 数据访问类:Stocking_Order
    /// </summary>
    public class Stocking_Order
    {
        public Stocking_Order()
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
        public bool Add(EMMS.Model.Stocking_OrderSet ordermodel,List<EMMS.Model.Stocking_MaterialSet> materialmodelList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_stocking_order(");
            strSql.Append("no,entry,warehouse,type,found_no,found_time,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@entry,@warehouse,@type,@found_no,@found_time,@remarks,@make_no,@make_time )");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
					new SqlParameter("@entry", SqlDbType.VarChar,13),
					new SqlParameter("@warehouse", SqlDbType.VarChar,8),
                    new SqlParameter("@type",SqlDbType.Int,4),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.Date,8),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Entry;
            parameters[2].Value = ordermodel.Warehouse;
            parameters[3].Value = ordermodel.Type;
            parameters[4].Value = ordermodel.FoundNo;
            parameters[5].Value = ordermodel.FoundTime;
            parameters[6].Value = ordermodel.Remarks;
            parameters[7].Value = ordermodel.MakeNo;
            parameters[8].Value = ordermodel.MakeTime;
            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1=0;
            foreach (EMMS.Model.Stocking_MaterialSet materialmodel in materialmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_stocking_material(");
                strSql1.Append("no,stocking,material,counts ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@stocking,@material,@counts )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@stocking",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4)    };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Stocking;
                parameters1[2].Value = materialmodel.Material;
                parameters1[3].Value = materialmodel.Counts;
                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }       
            if (rows > 0 && rows1==materialmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        /// <summary>
        /// 从tb_stocking_order中得到一个对象实体,Stocking_OrderSet
        /// </summary>
        public EMMS.Model.Stocking_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,entry,warehouse,type,found_no,found_time,remarks from tb_stocking_order ");
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
        //从tb_stocking_material中得到一个对象实体，Stocking_MaterialSet
        public EMMS.Model.Stocking_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,stocking,material,counts from tb_stocking_material ");
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
        /// 从view_warehouse中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,warehousename,type,foundname,foundtime,makename,maketime,remarks,entry ");
            strSql.Append(" FROM view_stocking_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where type=" + strWhere);
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,materialname,counts,unit,materialno ");
            strSql.Append(" FROM getView_stocking_material('"+strWhere+"')");
           
            return DbHelperSql.Query(strSql.ToString());
        }
       

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Stocking_OrderView DataRowToModelView(DataRow row)//从view_stocking_order中得到的一行
        {
            EMMS.Model.Stocking_OrderView model = new EMMS.Model.Stocking_OrderView();
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
                if (row["type"] != null)
                {
                    model.Type = (int.Parse(row["type"].ToString()) == 0) ? false : true;
                }
                if (row["foundname"] != null)
                {
                    model.FoundName = row["foundname"].ToString();
                }
                if (row["foundtime"] != null)
                {
                    model.FoundTime = row["foundtime"].ToString();
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
                if (row["entry"] != null)
                {
                    model.Entry = row["entry"].ToString();
                }
            }
            return model;
        }
       //
        public EMMS.Model.Stocking_MaterialView DataRowToModelView1(DataRow row)//从view_stocking_order中得到的一行
        {
            EMMS.Model.Stocking_MaterialView model = new EMMS.Model.Stocking_MaterialView();
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
                if (row["unit"] != null)
                {
                    model.Unit = row["unit"].ToString();
                }
                //if (row["price"] != null)
                //{
                //    model.Price = float.Parse(row["price"].ToString());
                //}
                //if (row["priceunit"] != null)
                //{
                //    model.PriceUnit = row["priceunit"].ToString();
                //}
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
        public EMMS.Model.Stocking_OrderSet DataRowToModelSet(DataRow row)//从tb_stocking_order得到的一行
        {
            EMMS.Model.Stocking_OrderSet model = new EMMS.Model.Stocking_OrderSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["entry"] != null)
                {
                    model.Entry = row["entry"].ToString();
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
                if (row["type"] != null)
                {
                    model.Type = int.Parse(row["type"].ToString());
                }
            }
            return model;
        }
        //
        public EMMS.Model.Stocking_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Stocking_MaterialSet model = new Model.Stocking_MaterialSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["stocking"] != null)
                {
                    model.Stocking = row["stocking"].ToString();
                }
                if (row["material"] != null)
                {
                    model.Material = row["material"].ToString();
                }
                if (row["counts"] != null && row["count"].ToString() != "")
                {
                    model.Counts = int.Parse(row["found_no"].ToString());
                }
            }
            return model;
        }

        #endregion  ExtensionMethod
    }
}

