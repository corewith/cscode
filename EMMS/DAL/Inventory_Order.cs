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
    /// 数据访问类:Inventory_Order
    /// </summary>
    public class Inventory_Order
    {
        public Inventory_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_inventory_order");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Inventory_OrderSet ordermodel, List<EMMS.Model.Inventory_MaterialSet> goodsmodelList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_inventory_order(");
            strSql.Append("no,warehouse,found_no,found_time,remarks,make_no,make_time,picking ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@warehouse,@found_no,@found_time,@remarks,@make_no,@make_time,@picking )");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    
                    new SqlParameter("@warehouse",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20),
                     new SqlParameter("@picking",SqlDbType.VarChar,13)                             };
            parameters[0].Value = ordermodel.No;
            
            parameters[1].Value = ordermodel.Warehouse;
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;
            
            parameters[4].Value = ordermodel.Remarks;
            parameters[5].Value = ordermodel.MakeNo;
            parameters[6].Value = ordermodel.MakeTime;
            parameters[7].Value = ordermodel.Picking;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Inventory_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_inventory_material(");
                strSql1.Append("no,inventory,goods,counts,critical,need ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@inventory,@goods,@counts,@critical,@need )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@inventory",SqlDbType.VarChar,13),
                   new SqlParameter("@goods",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@critical",SqlDbType.Int,4),
                   new SqlParameter("@need",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Inventory;
                parameters1[2].Value = materialmodel.Goods;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.Critical;
                parameters1[5].Value = materialmodel.Need;

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
        public bool UpdateOrder(EMMS.Model.Inventory_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_inventory_order set ");
            //strSql.Append("no=@no,");
          
            strSql.Append("warehouse=@warehouse,");
            strSql.Append("found_no=@found_no,");
            strSql.Append("found_time=@found_time,");
            
            strSql.Append("remarks=@remarks,");
            strSql.Append("make_no=@make_no,");
            strSql.Append("make_time=@make_time, ");
            strSql.Append("picking=@picking");
            strSql.Append("where no=@no");

            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    
                    new SqlParameter("@warehouse",SqlDbType.VarChar,8),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20),
                     new SqlParameter("@picking",SqlDbType.VarChar,13)                             };
            parameters[0].Value = ordermodel.No;

            parameters[1].Value = ordermodel.Warehouse;
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;

            parameters[4].Value = ordermodel.Remarks;
            parameters[5].Value = ordermodel.MakeNo;
            parameters[6].Value = ordermodel.MakeTime;
            parameters[7].Value = ordermodel.Picking;

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
        public bool UpdateGoods(List<EMMS.Model.Inventory_MaterialSet> goodsmodelList)
        {
            int rows1 = 0;
            foreach (EMMS.Model.Inventory_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("update tb_inventory_material set ");
                strSql1.Append("inventory=@inventory,");
                strSql1.Append("goods=@goods,");
                strSql1.Append("counts=@counts,");
                strSql1.Append("critical=@critical,");
                strSql1.Append("need=@need,");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@inventory",SqlDbType.VarChar,13),
                   new SqlParameter("@goods",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@critical",SqlDbType.Int,4),
                   new SqlParameter("@need",SqlDbType.Int,4)
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Inventory;
                parameters1[2].Value = materialmodel.Goods;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.Critical;
                parameters1[5].Value = materialmodel.Need;

                rows1 += DbHelperSql.ExecuteSql(strSql1.ToString(), parameters1);
            }
            if (rows1 == goodsmodelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从tb_inventory_order中得到一个对象实体,Inventory_OrderSet
        /// </summary>
        public EMMS.Model.Inventory_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,warehouse,found_no,found_time,remarks,make_no,make_time,picking ");
            strSql.Append(" from tb_inventory_order ");
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
        //从tb_inventory_material中得到一个对象实体，Inventory_MaterialSet
        public EMMS.Model.Inventory_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,inventory,goods,counts,critical,need ");
            strSql.Append(" from tb_inventory_material ");
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
        public DataSet GetList(string strWhere)//从view_inventory_order中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,warehousename,foundname,foundtime,makename,maketime,remarks,picking ");
            strSql.Append(" FROM view_inventory_order ");
            if (strWhere.Trim() != "")
            {
                //strSql.Append(" where ended=" + strWhere);
            }
            return DbHelperSql.Query(strSql.ToString());
        }

        public DataSet GetList1(string no) //从view_picking_material中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,goodsname,counts,critical,need,goodsno ");
            strSql.Append("from getView_inventory_material('" + no + "')");
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
        public EMMS.Model.Inventory_OrderView DataRowToModelView(DataRow row)//从view_inventory_order中得到的一行
        {
            EMMS.Model.Inventory_OrderView model = new EMMS.Model.Inventory_OrderView();
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
                if (row["picking"] != null)
                {
                    model.Picking = row["picking"].ToString();
                }
            }
            return model;
        }

        //
        public EMMS.Model.Inventory_MaterialView DataRowToModelView1(DataRow row)//从view_picking_material中得到的一行
        {
            EMMS.Model.Inventory_MaterialView model = new EMMS.Model.Inventory_MaterialView();
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
                if (row["counts"] != null && row["counts"].ToString() != null)
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["critical"] != null)
                {
                    model.Critical = int.Parse(row["critical"].ToString());
                }
                if (row["need"] != null)
                {
                    model.Need = int.Parse(row["need"].ToString());
                }
                if (row["goodsno"] != null)
                {
                    model.GoodsNo = row["goodsno"].ToString();
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.Inventory_OrderSet DataRowToModelSet(DataRow row)//从tb_inventory_order得到的一行
        {
            EMMS.Model.Inventory_OrderSet model = new EMMS.Model.Inventory_OrderSet();
            if (row != null)
            {
                //no,found_no,found_time,audited,ended,remarks,make_no,make_time
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["picking"] != null)
                {
                    model.Picking = row["picking"].ToString();
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
            }
            return model;
        }
        //
        public EMMS.Model.Inventory_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Inventory_MaterialSet model = new Model.Inventory_MaterialSet();
            if (row != null)
            {
                //no,plan_no,goods,counts,check_no,check_time,audited,check_counts
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["inventory"] != null)
                {
                    model.Inventory = row["inventory"].ToString();
                }
                if (row["goods"] != null)
                {
                    model.Goods = row["goods"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["critical"] != null && row["critical"].ToString() != "")
                {
                    model.Critical = int.Parse(row["critical"].ToString());
                }
                if (row["need"] != null && row["need"].ToString() != null)
                {
                    model.Need = int.Parse(row["need"].ToString());
                }
            }
            return model;
        }
        #endregion  ExtensionMethod
    }
}

