﻿using System.Collections.Generic;

namespace Application.Common.Models
{
    public class Result<T>
    {
        public Result()
        {
        }

        public Result(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Result(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}