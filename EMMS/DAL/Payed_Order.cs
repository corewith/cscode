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
    /// 数据访问类:Payed_Order
    /// </summary>
    public class Payed_Order
    {
        public Payed_Order()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_payed_order");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
                    new SqlParameter("@no", SqlDbType.VarChar,13)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.Payed_OrderSet ordermodel, List<EMMS.Model.Payed_MaterialSet> goodsmodelList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_payed_order(");
            strSql.Append("no,paying,found_no,found_time,audited,ended,remarks,make_no,make_time ) ");
            strSql.Append(" values (");
            strSql.Append("@no,@paying,@found_no,@found_time,@audited,@ended,@remarks,@make_no,@make_time )");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("@paying",SqlDbType.VarChar,13),
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                     new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Paying;
            
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;
            parameters[4].Value = ordermodel.Audited;
            
            parameters[5].Value = ordermodel.Ended;
            parameters[6].Value = ordermodel.Remarks;
            parameters[7].Value = ordermodel.MakeNo;
            parameters[8].Value = ordermodel.MakeTime;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            int rows1 = 0;
            foreach (EMMS.Model.Payed_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("insert into tb_payed_material(");
                strSql1.Append("no,payed,material,counts,cost,check_no,check_time,audited ) ");
                strSql1.Append(" values (");
                strSql1.Append("@no,@payed,@material,@counts,@cost,@check_no,@check_time,@audited )");
                SqlParameter[] parameters1 ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@payed",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@cost",SqlDbType.Float,8),
                   new SqlParameter("@check_no",SqlDbType.VarChar,8),
                   new SqlParameter("@check_time",SqlDbType.VarChar,20),
                   new SqlParameter("@audited",SqlDbType.Int,4),
                   
                                            };
                parameters1[0].Value = materialmodel.No;
                parameters1[1].Value = materialmodel.Payed;
                parameters1[2].Value = materialmodel.Material;
                parameters1[3].Value = materialmodel.Counts;
                parameters1[4].Value = materialmodel.Cost;
                parameters1[5].Value = materialmodel.CheckNo;
                parameters1[6].Value = materialmodel.CheckTime;
                parameters1[7].Value = materialmodel.Audited;
                

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
        public bool UpdateOrder(EMMS.Model.Payed_OrderSet ordermodel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_payed_order set ");
            //strSql.Append("no=@no,");
            strSql.Append("paying=@paying,");
            
            strSql.Append("found_no=@found_no,");
            strSql.Append("found_time=@found_time,");
            strSql.Append("audited=@audited,");
            
            strSql.Append("ended=@ended,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("make_no=@make_no,");
            strSql.Append("make_time=@make_time ");
            strSql.Append("where no=@no");

            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,13),
                    new SqlParameter("@paying",SqlDbType.VarChar,13),
                    
					new SqlParameter("@found_no", SqlDbType.VarChar,8),
                    new SqlParameter("@found_time",SqlDbType.VarChar,20),
                    new SqlParameter("@audited",SqlDbType.Int,4),
                    
                    new SqlParameter("@ended",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100),
                    new SqlParameter("@make_no",SqlDbType.VarChar,8),
                    new SqlParameter("@make_time",SqlDbType.VarChar,20)};
            parameters[0].Value = ordermodel.No;
            parameters[1].Value = ordermodel.Paying;
            
            parameters[2].Value = ordermodel.FoundNo;
            parameters[3].Value = ordermodel.FoundTime;
            parameters[4].Value = ordermodel.Audited;
            
            parameters[5].Value = ordermodel.Ended;
            parameters[6].Value = ordermodel.Remarks;
            parameters[7].Value = ordermodel.MakeNo;
            parameters[8].Value = ordermodel.MakeTime;

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
        public bool UpdateGoods(List<EMMS.Model.Payed_MaterialSet> goodsmodelList)
        {
            int rows = 0;
            foreach (EMMS.Model.Payed_MaterialSet materialmodel in goodsmodelList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_payed_material set ");
                strSql.Append("payed=@payed,");
                strSql.Append("material=@material,");
                strSql.Append("counts=@counts,");
                strSql.Append("cost=@cost,");
                strSql.Append("check_no=@check_no,");
                strSql.Append("check_time=@check_time,");
                strSql.Append("audited=@audited ");
                
                strSql.Append("where no=@no ");

                SqlParameter[] parameters ={
                   new SqlParameter("@no",SqlDbType.VarChar,13),
                   new SqlParameter("@payed",SqlDbType.VarChar,13),
                   new SqlParameter("@material",SqlDbType.VarChar,8),
                   new SqlParameter("@counts",SqlDbType.Int,4),
                   new SqlParameter("@cost",SqlDbType.Float,8),
                   new SqlParameter("@check_no",SqlDbType.VarChar,8),
                   new SqlParameter("@check_time",SqlDbType.VarChar,20),
                   new SqlParameter("@audited",SqlDbType.Int,4),
                                            };
                parameters[0].Value = materialmodel.No;
                parameters[1].Value = materialmodel.Payed;
                parameters[2].Value = materialmodel.Material;
                parameters[3].Value = materialmodel.Counts;
                parameters[4].Value = materialmodel.Cost;
                parameters[5].Value = materialmodel.CheckNo;
                parameters[6].Value = materialmodel.CheckTime;
                parameters[7].Value = materialmodel.Audited;
                

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
        /// 从tb_payed_order中得到一个对象实体,Payed_OrderSet
        /// </summary>
        public EMMS.Model.Payed_OrderSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,paying,found_no,found_time,audited,ended,remarks,make_no,make_time ");
            strSql.Append(" from tb_payed_order ");
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
        //从tb_payed_material中得到一个对象实体，Payed_MaterialSet
        public EMMS.Model.Payed_MaterialSet GetModel1(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,payed,material,counts,cost,check_no,check_time,audited ");
            strSql.Append("from tb_payed_material ");
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
        public DataSet GetList(string strWhere, string strWhere1)//从view_payed_order中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,foundname,foundtime,audited,ended,makename,maketime,remarks,paying ");
            strSql.Append(" FROM view_payed_order ");
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

        public DataSet GetList1(string no) //从view_picking_material中得到
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,materialname,unit,counts,price,priceunit,cost,audited,checktime,materialno ");
            strSql.Append("from getView_payed_material('" + no + "')");
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
        public EMMS.Model.Payed_OrderView DataRowToModelView(DataRow row)//从view_payed_order中得到的一行
        {
            EMMS.Model.Payed_OrderView model = new EMMS.Model.Payed_OrderView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
               
                if (row["foundname"] != null)
                {
                    model.FoundName = row["foundname"].ToString();
                }
                if (row["foundtime"] != null)
                {
                    model.FoundTime = row["foundtime"].ToString();
                }
                if (row["audited"] != null)
                {
                    model.Audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true;
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
                if (row["paying"] != null)
                {
                    model.Paying = row["paying"].ToString();
                }
            }
            return model;
        }

        //
        public EMMS.Model.Payed_MaterialView DataRowToModelView1(DataRow row)//从view_picking_material中得到的一行
        {
            EMMS.Model.Payed_MaterialView model = new EMMS.Model.Payed_MaterialView();
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
                if (row["unit"] != null)
                {
                    model.Unit = row["unit"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != null)
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["price"] != null)
                {
                    model.Price = float.Parse(row["price"].ToString());
                }
                if (row["priceunit"] != null)
                {
                    model.PriceUnit = row["priceunit"].ToString();
                }
                if (row["cost"] != null)
                {
                    model.Cost = float.Parse(row["cost"].ToString());
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
                    model.Audited = (int.Parse(row["audited"].ToString()) == 0) ? false : true;
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
        public EMMS.Model.Payed_OrderSet DataRowToModelSet(DataRow row)//从tb_payed_order得到的一行
        {
            EMMS.Model.Payed_OrderSet model = new EMMS.Model.Payed_OrderSet();
            if (row != null)
            {
                //no,found_no,found_time,audited,ended,remarks,make_no,make_time
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["paying"] != null)
                {
                    model.Paying = row["paying"].ToString();
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
        public EMMS.Model.Payed_MaterialSet DataRowToModelSet1(DataRow row)
        {
            EMMS.Model.Payed_MaterialSet model = new Model.Payed_MaterialSet();
            if (row != null)
            {
                //no,plan_no,goods,counts,check_no,check_time,audited,check_counts
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["payed"] != null)
                {
                    model.Payed = row["payed"].ToString();
                }
                if (row["material"] != null)
                {
                    model.Material = row["material"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "")
                {
                    model.Counts = int.Parse(row["counts"].ToString());
                }
                if (row["cost"] != null)
                {
                    model.Cost = float.Parse(row["cost"].ToString());
                }
                if (row["check_no"] != null)
                {
                    model.CheckNo = row["check_no"].ToString();
                }
                if (row["check_time"] != null)
                {
                    model.CheckTime = row["check_time"].ToString();
                }
                if (row["audited"] != null)
                {
                    model.Audited = int.Parse(row["audited"].ToString());
                }
            }
            return model;
        }

        #endregion  ExtensionMethod
    }
}

