using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblArticleType
    {
        public TblArticleType()
        {
            TblArticles = new HashSet<TblArticle>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblArticle> TblArticles { get; set; }
    }
}
