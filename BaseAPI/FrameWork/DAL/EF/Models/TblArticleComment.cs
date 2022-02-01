using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblArticleComment
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Comment { get; set; }
        public bool IsApprovd { get; set; }

        public virtual TblArticle Article { get; set; }
    }
}
