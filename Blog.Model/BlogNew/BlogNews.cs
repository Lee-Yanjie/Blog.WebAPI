using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.BlogNew
{
    public class BlogNews
    {

        //nvarchar带中文比较好
        [SugarColumn(ColumnDataType = "nvarchar(30)")]
        public string Title { get; set; }
        [SugarColumn(ColumnDataType = "text")]
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int BrowseCount { get; set; }
        public int LikeCount { get; set; }  
    }
}
