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
    /// 数据访问类:Goods
    /// </summary>
    public class Goods
    {
        public Goods()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EMMS.Model.GoodsSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods(");
            strSql.Append("no,name,type,unit,price,priceunit,disable,remarks)");
            strSql.Append(" values (");
            strSql.Append("@no,@name,@type,@unit,@price,@priceunit,@disable,@remarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@name", SqlDbType.VarChar,10),
					new SqlParameter("@type", SqlDbType.VarChar,2),
                    new SqlParameter("@unit",SqlDbType.VarChar,2),
					new SqlParameter("@price", SqlDbType.Float,8),
                    new SqlParameter("@priceunit",SqlDbType.VarChar,10),
                    new SqlParameter("@disable",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.PriceUnit;
            parameters[6].Value = model.Disable;
            parameters[7].Value = model.Remarks;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EMMS.Model.GoodsSet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods set ");
            strSql.Append("name=@name,");
            strSql.Append("type=@type,");
            strSql.Append("unit=@unit,");
            strSql.Append("price=@price,");
            strSql.Append("priceunit=@priceunit,");
            strSql.Append("disable=@disable,");
            strSql.Append("remarks=@remarks");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8),
					new SqlParameter("@name", SqlDbType.VarChar,10),
					new SqlParameter("@type", SqlDbType.VarChar,2),
                    new SqlParameter("@unit",SqlDbType.VarChar,2),
					new SqlParameter("@price", SqlDbType.Float,8),
                    new SqlParameter("@priceunit",SqlDbType.VarChar,10),
                    new SqlParameter("@disable",SqlDbType.Int,4),
					new SqlParameter("@remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.PriceUnit;
            parameters[6].Value = model.Disable;
            parameters[7].Value = model.Remarks;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)};
            parameters[0].Value = no;

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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string nolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods ");
            strSql.Append(" where no in (" + nolist + ")  ");
            int rows = DbHelperSql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 从tb_goods中得到一个对象实体,WarehousseSet
        /// </summary>
        public EMMS.Model.GoodsSet GetModel(string no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 no,name,type,unit,price,priceunit,disable,remarks from tb_goods ");
            strSql.Append(" where no=@no ");
            SqlParameter[] parameters = {
					new SqlParameter("@no", SqlDbType.VarChar,8)			};
            parameters[0].Value = no;

            EMMS.Model.GoodsGet model = new EMMS.Model.GoodsGet();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.GoodsGet DataRowToModel(DataRow row)
        {
            EMMS.Model.GoodsGet model = new EMMS.Model.GoodsGet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["typename"] != null)
                {
                    model.TypeName = row["typename"].ToString();
                }
                if (row["unit"] != null )//&& row["useable"].ToString() != "")
                {
                    model.Unit = row["unit"].ToString();//int.Parse(row["useable"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.Price = float.Parse(row["price"].ToString());    
                }
                if (row["priceunit"] != null)
                {
                    model.PriceUnit = row["priceunit"].ToString();
                }
                if (row["disable"] != null && row["disable"].ToString() != "")
                {
                    model.Disable = int.Parse(row["disable"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 从view_goods中获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,typename,unit,price,priceunit,disable,remarks ");
            strSql.Append(" FROM view_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where no= '" + strWhere + "'");
                strSql.Append(" or name= '" + strWhere + "'");
                strSql.Append(" or typename= '" + strWhere + "'");
                //strSql.Append(" or disable= "+strWhere );
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetListByNumber(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,typename,unit,price,priceunit,disable,remarks ");
            strSql.Append(" FROM view_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where disable= " + strWhere);
            }
            return DbHelperSql.Query(strSql.ToString());
        }
        //
        public DataSet GetListByNumber1(string strWhere,string strWherer1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select no,name,typename,unit,price,priceunit,disable,remarks ");
            strSql.Append(" FROM view_goods ");
                strSql.Append(" where disable= " + strWhere);
                strSql.Append(" and typename='" + strWherer1+"'");
            return DbHelperSql.Query(strSql.ToString());
        }
        /// <summary>
        ///从view_goods中 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" no,name,typename,unit,price,priceunit,diable,remarks ");
            strSql.Append(" FROM view_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSql.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.no desc");
            }
            strSql.Append(")AS Row, T.*  from view_goods T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSql.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.GoodsView DataRowToModelView(DataRow row)
        {
            EMMS.Model.GoodsView model = new EMMS.Model.GoodsView();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["typename"] != null)
                {
                    model.TypeName = row["typename"].ToString();
                }
                if (row["unit"] != null )//&& row["useable"].ToString() != "")
                {
                    model.Unit = row["unit"].ToString();//int.Parse(row["useable"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.Price = float.Parse(row["price"].ToString());    
                }
                if (row["priceunit"] != null)
                {
                    model.PriceUnit = row["priceunit"].ToString();
                }
                if (row["disable"] != null && row["disable"].ToString() != "")
                {
                    model.Disable = (int.Parse(row["disable"].ToString()) == 1) ? true : false;
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }
        //得到物品类别名称
        public List<String> GetNameList()
        {
            GoodsAttri dal = new GoodsAttri();
            DataSet ds = new DataSet();
            ds = dal.GetList("");
            List<String> nameList = new List<String>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    nameList.Add(row["name"].ToString());
                }
            }
            return nameList;
        }
        public List<TreeNode> GetNodeList()
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            List<String> nameList = new List<string>();
            nameList = GetNameList();
            foreach (string name in nameList)
            {
                nodeList.Add(new TreeNode() { Text = name });
            }
            return nodeList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EMMS.Model.GoodsSet DataRowToModelSet(DataRow row)
        {
            EMMS.Model.GoodsSet model = new EMMS.Model.GoodsSet();
            if (row != null)
            {
                if (row["no"] != null)
                {
                    model.No = row["no"].ToString();
                }
                if (row["name"] != null)
                {
                    model.Name = row["name"].ToString();
                }
                if (row["type"] != null)
                {
                    model.Type = row["type"].ToString();
                }
                if (row["unit"] != null)//&& row["useable"].ToString() != "")
                {
                    model.Unit = row["unit"].ToString();//int.Parse(row["useable"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.Price = float.Parse(row["price"].ToString());
                }
                if (row["priceunit"] != null)
                {
                    model.PriceUnit = row["priceunit"].ToString();
                }
                if (row["disable"] != null && row["disable"].ToString() != "")
                {
                    model.Disable = int.Parse(row["disable"].ToString());
                }
                if (row["remarks"] != null)
                {
                    model.Remarks = row["remarks"].ToString();
                }
            }
            return model;
        }
        #endregion  ExtensionMethod
    }
}

