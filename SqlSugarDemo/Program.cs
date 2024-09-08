using SqlSugar;
using SqlSugarDemo.Entities;

namespace SqlSugarDemo;

class Program
{
    static void Main(string[] args)
    {
        SqlSugarClient db = new(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            ConnectionString = "server=127.0.0.1;uid=root;pwd=123456fj;database=sqlsugar_demo",
            IsAutoCloseConnection = true,
            ConfigureExternalServices = new ConfigureExternalServices()
            {
                EntityService = (x, p) => //处理列名
                {
                    p.DbColumnName = UtilMethods.ToUnderLine(p.DbColumnName);//驼峰转下划线方法
                },
                EntityNameService = (x, p) => //处理表名
                {
                    p.DbTableName = UtilMethods.ToUnderLine(p.DbTableName);//驼峰转下划线方法
                }
            }
        });
        db.DbMaintenance.CreateDatabase();
        db.CodeFirst.InitTables(typeof(Article), typeof(Comment));

        // 导航插入数据的操作
        // List<Article> articles = [];
        // articles.Add(new Article { Title = "t2", Content = "c2", Comments = [new Comment() { Message = "m21" }, new Comment() { Message = "m22" }] });
        // db.InsertNav(articles).Include(a => a.Comments).ExecuteCommand();
    }
}
