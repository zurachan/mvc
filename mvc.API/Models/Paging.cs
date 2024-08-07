﻿namespace mvc.API.Models
{
    public class Paging
    {
        public Paging()
        {

        }
        public int CurrentRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
    }
}
