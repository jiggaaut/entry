namespace Laba1
{
    internal sealed record СКЛ1()
    {
        public const string sqlString = "Select p1.Name, p2.Name from test.Products p1 left join test.Category p2 on p1.CategoryID = p2.ID";
    }
}