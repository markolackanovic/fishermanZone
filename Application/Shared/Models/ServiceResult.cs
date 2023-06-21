﻿namespace Application.Shared.Models
{
    public class ServiceResult<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
