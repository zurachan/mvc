﻿namespace mvc.API.Models
{
    public class BaseSearchParam
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public BaseSearchParam()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public BaseSearchParam(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize == 0 ? 10 : pageSize;
        }
    }
}
