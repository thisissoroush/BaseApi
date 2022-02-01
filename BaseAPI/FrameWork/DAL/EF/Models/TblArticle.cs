﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblArticle
    {
        public TblArticle()
        {
            TblArticleComments = new HashSet<TblArticleComment>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TagNames { get; set; }
        public int ArticleTypeId { get; set; }
        public string Article { get; set; }
        public long PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public long VisitCount { get; set; }

        public virtual TblArticleType ArticleType { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblArticleComment> TblArticleComments { get; set; }
    }
}
