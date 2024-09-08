using SqlSugar;

namespace SqlSugarDemo.Entities;

class Comment
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public long Id { get; set; }
    public string Message { get; set; }
    public long ArticleId { get; set; }
}
