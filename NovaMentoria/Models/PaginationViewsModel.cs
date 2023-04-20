using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaMentoria.Models
{
   
    
        [ NotMapped]
        
        public class PaginationViewModel<T>
        { 
            public List<T> Items { get; set; }

            public int PageNumber { get; set; }

            public int PageSize { get; set; }
            public int TotalCount { get; set; }
        }
}
