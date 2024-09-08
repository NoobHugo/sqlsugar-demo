using SqlSugar;

namespace SqlSugarDemo.Entities;

class Article
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    [SugarColumn(IsNullable = true)]
    public DateTime CreateTime { get; set; }
    [SugarColumn(IsNullable = true)]
    public DateTime UpdateTime { get; set; }

    [Navigate(NavigateType.OneToMany, nameof(Comment.ArticleId))]
    public List<Comment> Comments { get; set; }
}
