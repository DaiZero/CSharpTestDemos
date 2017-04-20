namespace DZero.Prism.TestDemo.Infrastructure.Page
{
    public class PageContent
    {
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总共取多少条记录
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// 总共多少页
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (PageSize == 0) return 0;
                return (TotalItems + PageSize - 1) / PageSize;
            }
        }
    }
}
